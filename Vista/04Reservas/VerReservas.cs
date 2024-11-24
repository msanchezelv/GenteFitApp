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
    public partial class VerReservas : Form
    {
        public VerReservas()
        {
            InitializeComponent();
        }

        private void FormMisReservas_Load(object sender, EventArgs e)
        {
            int idCliente = ControladorInicioSesion.IdClienteActual;
            List<ReservaDTO> reservas = ReservaDTO.ObtenerReservasPorCliente(idCliente != -1 ? (int?)idCliente : null);

            reservas = reservas.Where(r =>
                                DateTime.Parse(r.FechaCompleta) > DateTime.Now ||
                                (DateTime.Parse(r.FechaCompleta) == DateTime.Now.Date && TimeSpan.Parse(r.Hora) >= DateTime.Now.TimeOfDay)
                                ).ToList();

            BindingList<ReservaDTO> bindingReservas = new BindingList<ReservaDTO>(reservas);
            dataGridViewReservas.DataSource = bindingReservas;

            bindingReservas = new BindingList<ReservaDTO>(
                                    reservas.OrderBy(r => DateTime.Parse(r.FechaCompleta))  // Ordenar por fecha completa
                                            .ThenBy(r => TimeSpan.Parse(r.Hora))  // Ordenar por hora
                                            .ToList()
            );



            if (dataGridViewReservas.Columns.Contains("idReserva"))
            {
                dataGridViewReservas.Columns["idReserva"].Visible = false;
            }

            if (dataGridViewReservas.Columns.Contains("Cliente"))
            {
                dataGridViewReservas.Columns["Cliente"].Visible = ControladorInicioSesion.RolUsuarioActual != "Cliente";
            }

            if (dataGridViewReservas.Columns.Contains("FechaReserva"))
                dataGridViewReservas.Columns["FechaReserva"].HeaderText = "Fecha de la reserva";
            if (dataGridViewReservas.Columns.Contains("FechaCompleta"))
                dataGridViewReservas.Columns["FechaCompleta"].HeaderText = "Fecha";

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


                                TimeSpan horaInicio = reader.IsDBNull(reader.GetOrdinal("horaInicio"))
                                    ? TimeSpan.Zero // Si es NULL, asigna "Hora no disponible"
                                    : reader.GetTimeSpan(reader.GetOrdinal("horaInicio"));

                                string horaFormateada = horaInicio == TimeSpan.Zero ? "Hora no disponible" : horaInicio.ToString(@"hh\:mm");

                                string diaSemana = reader.GetString(reader.GetOrdinal("diaSemana"));
                                string monitor = reader.IsDBNull(reader.GetOrdinal("MonitorNombre")) ? "No asignado" : reader.GetString(reader.GetOrdinal("MonitorNombre"));
                                int plazasDisponibles = reader.GetInt32(reader.GetOrdinal("plazasDisponibles"));
                                string fechaDeLaActividad = reader.GetDateTime(reader.GetOrdinal("fecha")).ToString("dd/MM/yyyy");

                                FormReserva formReserva = new FormReserva(idCliente, idHorario, nombreActividad, horaFormateada, diaSemana, fechaDeLaActividad, monitor, plazasDisponibles, true);
                                formReserva.ShowDialog();
                                ActualizarDataGridView();
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

        public void ActualizarDataGridView()
        {
            int idCliente = ControladorInicioSesion.IdClienteActual;
            List<ReservaDTO> reservas = ReservaDTO.ObtenerReservasPorCliente(idCliente);

            reservas = reservas.Where(r =>
                                    DateTime.Parse(r.FechaCompleta) > DateTime.Now ||
                                    (DateTime.Parse(r.FechaCompleta) == DateTime.Now.Date && TimeSpan.Parse(r.Hora) >= DateTime.Now.TimeOfDay)
                                    ).ToList();

            BindingList<ReservaDTO> bindingReservas = new BindingList<ReservaDTO>(reservas);
            dataGridViewReservas.DataSource = bindingReservas;

            bindingReservas = new BindingList<ReservaDTO>(
                                        reservas.OrderBy(r => DateTime.Parse(r.FechaCompleta))
                                                .ThenBy(r => TimeSpan.Parse(r.Hora))
                                                .ToList()
            );

            if (dataGridViewReservas.Columns.Contains("idReserva"))
            {
                dataGridViewReservas.Columns["idReserva"].Visible = false;
            }

            if (dataGridViewReservas.Columns.Contains("Cliente"))
            {
                dataGridViewReservas.Columns["Cliente"].Visible = false;
            }

            if (dataGridViewReservas.Columns.Contains("FechaReserva"))
                dataGridViewReservas.Columns["FechaReserva"].HeaderText = "Fecha de la reserva";
            if (dataGridViewReservas.Columns.Contains("FechaCompleta"))
                dataGridViewReservas.Columns["FechaCompleta"].HeaderText = "Fecha";

            dataGridViewReservas.AllowUserToAddRows = false;
            dataGridViewReservas.AllowUserToDeleteRows = false;
            dataGridViewReservas.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewReservas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewReservas.EditMode = DataGridViewEditMode.EditProgrammatically;
        }


    }
}
