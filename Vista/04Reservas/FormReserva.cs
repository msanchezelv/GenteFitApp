using GenteFitApp.Controlador;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace GenteFitApp.Vista._04Reservas
{
    public partial class FormReserva : Form
    {
        private int idCliente;
        private int idHorario;

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
            int plazasDisponiblesEnReserva = 1;

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["GenteFitConnectionString"].ConnectionString))
            {
                connection.Open();

                string insertReservaQuery = @"
                    INSERT INTO Reserva (idCliente, idHorario, fechaReserva, plazasDisponiblesEnReserva)
                    VALUES (@idCliente, @idHorario, @fechaReserva, @plazasDisponiblesEnReserva);
                ";

                using (SqlCommand cmd = new SqlCommand(insertReservaQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@idCliente", this.idCliente);
                    cmd.Parameters.AddWithValue("@idHorario", this.idHorario);
                    cmd.Parameters.AddWithValue("@fechaReserva", DateTime.Now);
                    cmd.Parameters.AddWithValue("@plazasDisponiblesEnReserva", plazasDisponiblesEnReserva);
                    cmd.ExecuteNonQuery();
                }

                string updatePlazasQuery = @"
                    UPDATE Horario
                    SET PlazasDisponibles = PlazasDisponibles - @plazasReservadas
                    WHERE idHorario = @idHorario AND PlazasDisponibles >= @plazasReservadas;
                ";

                using (SqlCommand cmd = new SqlCommand(updatePlazasQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@idHorario", this.idHorario);
                    cmd.Parameters.AddWithValue("@plazasReservadas", plazasDisponiblesEnReserva);
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected == 0)
                    {
                        MessageBox.Show("No hay suficientes plazas disponibles para esta actividad.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }

            MessageBox.Show("Reserva realizada con éxito.");
            this.Close();
        }
    }
}
