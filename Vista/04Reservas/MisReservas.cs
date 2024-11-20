using GenteFitApp.Controlador;
using GenteFitApp.Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GenteFitApp.Vista._04Reservas
{
    public partial class MisReservas : Form
    {
        public MisReservas()
        {
            InitializeComponent();
        }

        private void FormMisReservas_Load(object sender, EventArgs e)
        {
            int idCliente = ControladorInicioSesion.IdClienteActual;
            List<ReservaDTO> reservas = ReservaDTO.ObtenerReservasPorCliente(idCliente);

            BindingList<ReservaDTO> bindingReservas = new BindingList<ReservaDTO>(reservas);
            dataGridViewReservas.DataSource = bindingReservas;

            if (dataGridViewReservas.Columns.Contains("idReserva"))
            {
                dataGridViewReservas.Columns["idReserva"].Visible = false;
            }

            if (dataGridViewReservas.Columns.Contains("Cliente"))
            {
                dataGridViewReservas.Columns["Cliente"].Visible = false;
            }

            dataGridViewReservas.AllowUserToAddRows = false;
            dataGridViewReservas.AllowUserToDeleteRows = false;
            dataGridViewReservas.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewReservas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewReservas.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void dataGridViewReservas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridView dataGridView = (DataGridView)sender;
                DataGridViewRow filaSeleccionada = dataGridView.Rows[e.RowIndex];

                int idReserva = Convert.ToInt32(filaSeleccionada.Cells["idReserva"].Value);

                // Llamar al Stored Procedure para obtener los detalles de la reserva
                using (var connection = new SqlConnection(DatabaseConfig.ConnectionString))
                {
                    connection.Open();
                    using (var command = new SqlCommand("GetReservaDetails", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@idReserva", idReserva);

                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int idCliente = reader.GetInt32(reader.GetOrdinal("idCliente"));
                                int idHorario = reader.GetInt32(reader.GetOrdinal("idHorario"));
                                string nombreActividad = reader.GetString(reader.GetOrdinal("ActividadNombre"));

                                // Obtener horaInicio como TimeSpan (solo si no es NULL o 00:00)
                                TimeSpan horaInicio = reader.IsDBNull(reader.GetOrdinal("horaInicio"))
                                    ? TimeSpan.Zero // Si es NULL, asigna "Hora no disponible"
                                    : reader.GetTimeSpan(reader.GetOrdinal("horaInicio"));

                                // Si horaInicio es 00:00, lo consideramos como "hora no disponible"
                                string horaFormateada = horaInicio == TimeSpan.Zero ? "Hora no disponible" : horaInicio.ToString(@"hh\:mm");

                                string diaSemana = reader.GetString(reader.GetOrdinal("diaSemana"));
                                string monitor = reader.IsDBNull(reader.GetOrdinal("MonitorNombre")) ? "No asignado" : reader.GetString(reader.GetOrdinal("MonitorNombre"));
                                int plazasDisponibles = reader.GetInt32(reader.GetOrdinal("plazasDisponibles"));
                                string fechaDeLaActividad = reader.GetDateTime(reader.GetOrdinal("fecha")).ToString("dd/MM/yyyy");

                                // Comprobar si hay plazas disponibles y mostrar el FormReserva
                                if (plazasDisponibles > 0)
                                {
                                    // Si horaInicio es TimeSpan.Zero, significa que no hay hora válida
                                    FormReserva formReserva = new FormReserva(idCliente, idHorario, nombreActividad, horaFormateada, diaSemana, fechaDeLaActividad, monitor, plazasDisponibles);
                                    formReserva.ShowDialog();
                                }
                                else
                                {
                                    MessageBox.Show("No hay plazas disponibles para esta actividad.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Reserva no encontrada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
        }

    }
}
