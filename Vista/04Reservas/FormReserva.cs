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
        private bool fromVerReservas;
        string connectionString = DatabaseConfig.ConnectionString;

        public FormReserva(int idCliente, int idHorario, string nombreActividad, string hora, string diaSemana, string fecha, string monitor, int plazasDisponibles, bool fromVerReservas)
        {
            InitializeComponent();
            this.idCliente = idCliente;
            this.idHorario = idHorario;
            labelNombreActividad.Text = nombreActividad;
            labelHora.Text = "Hora: " + hora;
            DateTime fechaActividad = DateTime.Parse(fecha);
            labelFecha.Text = "Fecha: " + fechaActividad.ToString("dd/MM/yyyy");
            labelMonitor.Text = "Monitor: " + monitor;
            labelPlazasDisponibles.Text = "Plazas Disponibles: " + plazasDisponibles.ToString();

            if (fromVerReservas)
            {
                buttonReservar.Text = "Eliminar reserva";
            }
            else
            {
                buttonReservar.Text = "Reservar";
            }

        }

        private void buttonReservar_Click(object sender, EventArgs e)
        {
            // Si el botón dice "Eliminar reserva", mostramos un mensaje de confirmación
            if (buttonReservar.Text == "Eliminar reserva")
            {
                var confirmResult = MessageBox.Show("¿Estás seguro de que quieres eliminar la reserva?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirmResult == DialogResult.Yes)
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        using (SqlTransaction transaction = connection.BeginTransaction())
                        {
                            try
                            {
                                string deleteReservationQuery = "DELETE FROM Reserva WHERE idCliente = @idCliente AND idHorario = @idHorario";

                                using (SqlCommand deleteCmd = new SqlCommand(deleteReservationQuery, connection, transaction))
                                {
                                    deleteCmd.Parameters.AddWithValue("@idCliente", this.idCliente);
                                    deleteCmd.Parameters.AddWithValue("@idHorario", this.idHorario);

                                    int rowsAffected = deleteCmd.ExecuteNonQuery();

                                    if (rowsAffected > 0)
                                    {
                                        MessageBox.Show("Reserva eliminada con éxito.");
                                        this.Close();
                                                                               
                                    }
                                    else
                                    {
                                        MessageBox.Show("No se encontró una reserva para este horario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }

                                transaction.Commit();
                            }
                            catch (Exception ex)
                            {
                                transaction.Rollback();
                                MessageBox.Show("Ocurrió un error al eliminar la reserva: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
            else
            {
                DateTime fechaActividad = DateTime.Parse(labelFecha.Text.Substring(7));
                string[] horas = labelHora.Text.Substring(7).Split(new string[] { "-" }, StringSplitOptions.None);

                if (horas.Length == 2)
                {
                    DateTime horaInicio = DateTime.Parse(horas[0]);
                    DateTime horaFin = DateTime.Parse(horas[1]);

                    DateTime actividadInicio = fechaActividad.Date.Add(horaInicio.TimeOfDay);
                    DateTime actividadFin = fechaActividad.Date.Add(horaFin.TimeOfDay);

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        using (SqlTransaction transaction = connection.BeginTransaction())
                        {
                            try
                            {
                                string checkReservationQuery = "SELECT COUNT(*) FROM Reserva WHERE idCliente = @idCliente AND idHorario = @idHorario";
                                using (SqlCommand checkReservationCmd = new SqlCommand(checkReservationQuery, connection, transaction))
                                {
                                    checkReservationCmd.Parameters.AddWithValue("@idCliente", this.idCliente);
                                    checkReservationCmd.Parameters.AddWithValue("@idHorario", this.idHorario);

                                    int existingReservations = (int)checkReservationCmd.ExecuteScalar();

                                    if (existingReservations > 0)
                                    {
                                        MessageBox.Show("Ya tienes una reserva para este horario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        transaction.Rollback();
                                        return;
                                    }
                                }

                                // Ejecutar la stored procedure para hacer la reserva
                                string storedProcedure = "dbo.ReservarClase";
                                using (SqlCommand command = new SqlCommand(storedProcedure, connection, transaction))
                                {
                                    command.CommandType = CommandType.StoredProcedure;
                                    command.Parameters.AddWithValue("@idCliente", this.idCliente);
                                    command.Parameters.AddWithValue("@idHorario", this.idHorario);

                                    // Utilizamos un parámetro de salida para obtener el mensaje de la stored procedure
                                    SqlParameter outputMessage = new SqlParameter("@OutputMessage", SqlDbType.NVarChar, 100);
                                    outputMessage.Direction = ParameterDirection.Output;
                                    command.Parameters.Add(outputMessage);

                                    command.ExecuteNonQuery();

                                    // Obtener el mensaje de salida
                                    string message = outputMessage.Value.ToString();

                                    // Mostrar el mensaje correspondiente
                                    if (message == "Reserva realizada con éxito.")
                                    {
                                        MessageBox.Show(message);
                                        this.Close();
                                    }
                                    else
                                    {
                                        MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }

                                    transaction.Commit();
                                }
                            }
                            catch (Exception ex)
                            {
                                transaction.Rollback();
                                MessageBox.Show("Ocurrió un error al realizar la reserva: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("El formato de la hora no es válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

    }

}
