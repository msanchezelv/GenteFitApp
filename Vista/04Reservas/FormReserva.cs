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
            labelNombreActividad.Text = nombreActividad;
            labelHora.Text = "Hora: " + hora;
            labelFecha.Text = "Fecha: " + fecha;
            labelMonitor.Text = "Monitor: " + monitor;
            labelPlazasDisponibles.Text = "Plazas Disponibles: " + plazasDisponibles.ToString();
        }

        private void buttonReservar_Click(object sender, EventArgs e)
        {
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

                        string storedProcedure = "dbo.ReservarClase";
                        using (SqlCommand command = new SqlCommand(storedProcedure, connection, transaction))
                        {
                            command.CommandType = CommandType.StoredProcedure;
                            command.Parameters.AddWithValue("@idCliente", this.idCliente);
                            command.Parameters.AddWithValue("@idHorario", this.idHorario);

                            command.ExecuteNonQuery();

                            transaction.Commit();

                            MessageBox.Show("Reserva realizada con éxito.");
                            this.Close();
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


    }

}
