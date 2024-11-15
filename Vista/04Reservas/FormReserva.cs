using GenteFitApp.Controlador;
using GenteFitApp.Vista._06Horarios;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace GenteFitApp.Vista._04Reservas
{
    public partial class FormReserva : Form
    {
        private int idCliente;
        private int idHorario;
        string connectionString = ConfigurationManager.ConnectionStrings["GenteFitApp.Properties.Settings.GenteFitConnectionString"].ConnectionString;

        public FormReserva(int idCliente, int idHorario, string nombreActividad, string hora, string diaSemana, string fecha, string monitor, int plazasDisponibles)
        {
            InitializeComponent();
            this.idCliente = idCliente;
            this.idHorario = idHorario;
            labelNombreActividad.Text = "Nombre de Actividad: " + nombreActividad;
            labelHora.Text = "Hora: " + hora;
            labelFecha.Text = "Fecha: " + fecha;
            labelMonitor.Text = "Monitor: " + monitor;
            labelPlazasDisponibles.Text = "Plazas Disponibles: " + plazasDisponibles.ToString();
        }

        private void buttonReservar_Click(object sender, EventArgs e)
        {
            int plazasSolicitadas = 1;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        string checkReservaQuery = "SELECT COUNT(1) FROM Reserva WHERE idCliente = @idCliente AND idHorario = @idHorario";
                        using (SqlCommand checkReservaCmd = new SqlCommand(checkReservaQuery, connection, transaction))
                        {
                            checkReservaCmd.Parameters.AddWithValue("@idCliente", this.idCliente);
                            checkReservaCmd.Parameters.AddWithValue("@idHorario", this.idHorario);
                            int reservasExistentes = (int)checkReservaCmd.ExecuteScalar();

                            if (reservasExistentes > 0)
                            {
                                MessageBox.Show("Ya has realizado una reserva para este horario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                transaction.Rollback();
                                return;
                            }
                        }

                        string checkPlazasQuery = "SELECT PlazasDisponibles FROM Horario WHERE idHorario = @idHorario";
                        using (SqlCommand checkPlazasCmd = new SqlCommand(checkPlazasQuery, connection, transaction))
                        {
                            checkPlazasCmd.Parameters.AddWithValue("@idHorario", this.idHorario);
                            int plazasDisponibles = (int)checkPlazasCmd.ExecuteScalar();

                            if (plazasDisponibles <= 0)
                            {
                                MessageBox.Show("No hay plazas disponibles para esta actividad.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                transaction.Rollback();
                                return;
                            }

                            if (plazasDisponibles < plazasSolicitadas)
                            {
                                MessageBox.Show("No hay suficientes plazas disponibles para esta actividad.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                transaction.Rollback();
                                return;
                            }
                        }

                        string insertReservaQuery = @"
                    INSERT INTO Reserva (idCliente, idHorario, fechaReserva, plazasDisponiblesEnReserva)
                    VALUES (@idCliente, @idHorario, @fechaReserva, @plazasDisponiblesEnReserva)";
                        using (SqlCommand insertCmd = new SqlCommand(insertReservaQuery, connection, transaction))
                        {
                            insertCmd.Parameters.AddWithValue("@idCliente", this.idCliente);
                            insertCmd.Parameters.AddWithValue("@idHorario", this.idHorario);
                            insertCmd.Parameters.AddWithValue("@fechaReserva", DateTime.Now);
                            insertCmd.Parameters.AddWithValue("@plazasDisponiblesEnReserva", plazasSolicitadas);
                            insertCmd.ExecuteNonQuery();
                        }

                        string updatePlazasQuery = @"
                    UPDATE Horario
                    SET PlazasDisponibles = PlazasDisponibles - @plazasReservadas
                    WHERE idHorario = @idHorario AND PlazasDisponibles >= @plazasReservadas";
                        using (SqlCommand updateCmd = new SqlCommand(updatePlazasQuery, connection, transaction))
                        {
                            updateCmd.Parameters.AddWithValue("@idHorario", this.idHorario);
                            updateCmd.Parameters.AddWithValue("@plazasReservadas", plazasSolicitadas);

                            int rowsAffected = updateCmd.ExecuteNonQuery();
                            if (rowsAffected == 0)
                            {
                                MessageBox.Show("Error al actualizar las plazas disponibles o no hay suficientes.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                transaction.Rollback();
                                return;
                            }
                        }

                        transaction.Commit();

                        FormHorarios formHorarios = Application.OpenForms.OfType<FormHorarios>().FirstOrDefault();
                        if (formHorarios != null)
                        {
                            formHorarios.ActualizarPlazasDisponibles(); // Actualizamos las plazas disponibles en el FormHorarios
                        }

                        MessageBox.Show("Reserva realizada con éxito.");
                        this.Close();

                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show("Ocurrió un error al realizar la reserva: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        

    }

}
