using GenteFitApp.Modelo;
using GenteFitApp.Modelo.GenteFitApp.Modelo;
using GenteFitApp.Vista._04Reservas;
using GenteFitApp.Controlador;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GenteFit.Controlador;

namespace GenteFitApp.Vista._06Horarios
{
    public partial class FormHorarios : Form
    {
        ControladorInicioSesion controladorInicioSesion = new ControladorInicioSesion();

        public FormHorarios()
        {
            InitializeComponent();
        }


        private void FormHorarios_Resize(object sender, EventArgs e)
        {
            dataGridViewHorarios.AutoResizeColumns();
        }

        private void FormHorarios_Load(object sender, EventArgs e)
        {
            List<HorarioDTO> horarios = HorarioDTO.ObtenerHorariosConActividadYMonitor();
            var horariosAgrupados = horarios.GroupBy(h => h.DiaSemana).ToList();

            foreach (var grupo in horariosAgrupados)
            {
                string diaSemana = grupo.Key;
                TabPage tabPage = null;
                switch (diaSemana.ToLower())
                {
                    case "lunes":
                        tabPage = tabPageLunes;
                        break;
                    case "martes":
                        tabPage = tabPageMartes;
                        break;
                    case "miércoles":
                        tabPage = tabPageMiercoles;
                        break;
                    case "jueves":
                        tabPage = tabPageJueves;
                        break;
                    case "viernes":
                        tabPage = tabPageViernes;
                        break;
                    case "sábado":
                        tabPage = tabPageSabado;
                        break;
                    case "domingo":
                        tabPage = tabPageDomingo;
                        break;
                    default:
                        break;
                }

                if (tabPage != null)
                {
                    DataGridView dataGridViewDia = new DataGridView
                    {
                        AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                        AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells,
                        Dock = DockStyle.Fill,
                        BackgroundColor = Color.Bisque,
                        AllowUserToAddRows = false,
                        ReadOnly = true
                    };

                    BindingList<HorarioDTO> bindingHorariosDia = new BindingList<HorarioDTO>(grupo.ToList());
                    dataGridViewDia.DataSource = bindingHorariosDia;

                    dataGridViewDia.CellClick += dataGridViewDia_CellClick;

                    dataGridViewDia.DataBindingComplete += (s, ev) =>
                    {
                        if (dataGridViewDia.Columns.Contains("Hora"))
                            dataGridViewDia.Columns["Hora"].HeaderText = "Hora";
                        if (dataGridViewDia.Columns.Contains("Actividad"))
                            dataGridViewDia.Columns["Actividad"].HeaderText = "Actividad";
                        if (dataGridViewDia.Columns.Contains("Sala"))
                            dataGridViewDia.Columns["Sala"].HeaderText = "Sala";
                        if (dataGridViewDia.Columns.Contains("Monitor"))
                            dataGridViewDia.Columns["Monitor"].HeaderText = "Monitor";
                        if (dataGridViewDia.Columns.Contains("Plazas"))
                            dataGridViewDia.Columns["Plazas"].HeaderText = "Plazas disponibles";

                        if (dataGridViewDia.Columns.Contains("DiaSemana"))
                        {
                            dataGridViewDia.Columns["DiaSemana"].Visible = false;
                        }

                        dataGridViewDia.Columns["Hora"].DefaultCellStyle.Format = "HH:mm";

                        dataGridViewDia.Columns["Sala"].Visible = true;
                    };

                    tabPage.Controls.Add(dataGridViewDia);
                }
            }
        }

        private void dataGridViewDia_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int idCliente = ControladorInicioSesion.IdClienteActual;

            if (e.RowIndex >= 0)
            {
                DataGridView dataGridView = (DataGridView)sender;
                DataGridViewRow filaSeleccionada = dataGridView.Rows[e.RowIndex];

                string nombreActividad = filaSeleccionada.Cells["Actividad"].Value.ToString();
                string hora = filaSeleccionada.Cells["Hora"].Value.ToString();
                string diaSemana = filaSeleccionada.Cells["DiaSemana"].Value.ToString();
                string monitor = filaSeleccionada.Cells["Monitor"].Value.ToString();
                int plazasDisponibles = Convert.ToInt32(filaSeleccionada.Cells["Plazas"].Value);

                int idHorario = ObtenerIdHorario(nombreActividad, hora, monitor);

                if (idHorario != -1 && plazasDisponibles > 0)
                {
                    string fecha = DateTime.Now.ToString("dd/MM/yyyy");

                    FormReserva formReserva = new FormReserva(idCliente, idHorario, nombreActividad, hora, diaSemana, fecha, monitor, plazasDisponibles);
                    formReserva.ShowDialog();
                }
                else
                {
                    MessageBox.Show("No hay plazas disponibles para esta actividad o el horario no se encontró.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private int ObtenerIdHorario(string actividad, string hora, string monitor)
        {
            int idHorario = -1;

            string connectionString = ConfigurationManager.ConnectionStrings["GenteFitApp.Properties.Settings.GenteFitConnectionString"].ConnectionString;

            // Ajustamos la consulta SQL para hacer una JOIN y buscar por los parámetros correctos
            string query = @"
                            SELECT h.idHorario 
                            FROM Horario h
                            JOIN Actividad a ON h.idActividad = a.idActividad
                            JOIN Monitor m ON a.idMonitor = m.idMonitor
                            WHERE a.nombre = @Actividad 
                            AND CONCAT(FORMAT(CAST(h.horaInicio AS DATETIME), 'HH:mm'), '-', FORMAT(CAST(h.horaFin AS DATETIME), 'HH:mm')) = @Hora 
                            AND m.nombre = @Monitor";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Actividad", actividad);
                command.Parameters.AddWithValue("@Hora", hora);
                command.Parameters.AddWithValue("@Monitor", monitor);

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();
                    if (result != null)
                    {
                        idHorario = Convert.ToInt32(result);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener el idHorario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return idHorario;
        }

        public void ActualizarPlazasDisponibles()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["GenteFitApp.Properties.Settings.GenteFitConnectionString"].ConnectionString;

            string query = @"
                    SELECT h.idHorario, h.PlazasDisponibles
                    FROM Horario h
                    WHERE h.idHorario = @idHorario";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                foreach (TabPage tabPage in tabControlHorarios.TabPages)
                {
                    foreach (Control control in tabPage.Controls)
                    {
                        if (control is DataGridView dataGridView)
                        {
                            foreach (DataGridViewRow row in dataGridView.Rows)
                            {
                                int idHorario = Convert.ToInt32(row.Cells["idHorario"].Value);

                                SqlCommand command = new SqlCommand(query, connection);
                                command.Parameters.AddWithValue("@idHorario", idHorario);

                                object result = command.ExecuteScalar();
                                if (result != null)
                                {
                                    int plazasDisponibles = Convert.ToInt32(result);
                                    row.Cells["Plazas"].Value = plazasDisponibles; // Actualizamos las plazas en la fila correspondiente
                                }
                            }
                        }
                    }
                }
            }
        }


    }

}
