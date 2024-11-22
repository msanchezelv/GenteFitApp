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
using GenteFitApp.Vista._02Clientes;

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
                        if (dataGridViewDia.Columns.Contains("idHorario"))
                        {
                            dataGridViewDia.Columns["idHorario"].Visible = false;
                        }
                        if (dataGridViewDia.Columns.Contains("Hora"))
                            dataGridViewDia.Columns["Hora"].HeaderText = "Hora";
                        if (dataGridViewDia.Columns.Contains("Actividad"))
                            dataGridViewDia.Columns["Actividad"].HeaderText = "Actividad";
                        if (dataGridViewDia.Columns.Contains("Sala"))
                            dataGridViewDia.Columns["Sala"].HeaderText = "Sala";
                        if (dataGridViewDia.Columns.Contains("Monitor"))
                            dataGridViewDia.Columns["Monitor"].HeaderText = "Monitor";
                        if (dataGridViewDia.Columns.Contains("Plazas"))
                            ActualizarPlazasDisponibles();
                        dataGridViewDia.Columns["Plazas"].HeaderText = "Plazas disponibles";
                        if (dataGridViewDia.Columns.Contains("Fecha"))
                            dataGridViewDia.Columns["Fecha"].HeaderText = "Fecha";

                        // Hacer visible la columna Fecha
                        if (dataGridViewDia.Columns.Contains("Fecha"))
                            dataGridViewDia.Columns["Fecha"].Visible = true;

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

            ActualizarPlazasDisponibles();

            DayOfWeek diaActual = DateTime.Now.DayOfWeek;
            switch (diaActual)
            {
                case DayOfWeek.Monday:
                    this.tabControlHorarios.SelectedTab = tabPageLunes;
                    break;
                case DayOfWeek.Tuesday:
                    this.tabControlHorarios.SelectedTab = tabPageMartes;
                    break;
                case DayOfWeek.Wednesday:
                    this.tabControlHorarios.SelectedTab = tabPageMiercoles;
                    break;
                case DayOfWeek.Thursday:
                    this.tabControlHorarios.SelectedTab = tabPageJueves;
                    break;
                case DayOfWeek.Friday:
                    this.tabControlHorarios.SelectedTab = tabPageViernes;
                    break;
                case DayOfWeek.Saturday:
                    this.tabControlHorarios.SelectedTab = tabPageSabado;
                    break;
                case DayOfWeek.Sunday:
                    this.tabControlHorarios.SelectedTab = tabPageDomingo;
                    break;
                default:
                    break;
            }
        }


        private void dataGridViewDia_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int idCliente = ControladorInicioSesion.IdClienteActual;

            if (e.RowIndex >= 0)
            {
                DataGridView dataGridView = (DataGridView)sender;
                DataGridViewRow filaSeleccionada = dataGridView.Rows[e.RowIndex];

                int idHorario = Convert.ToInt32(filaSeleccionada.Cells["idHorario"].Value);
                string nombreActividad = filaSeleccionada.Cells["Actividad"].Value.ToString();
                string hora = filaSeleccionada.Cells["Hora"].Value.ToString();
                string diaSemana = filaSeleccionada.Cells["DiaSemana"].Value.ToString();
                string monitor = filaSeleccionada.Cells["Monitor"].Value.ToString();
                int plazasDisponibles = Convert.ToInt32(filaSeleccionada.Cells["Plazas"].Value);
                string fechaDeLaActividad = filaSeleccionada.Cells["Fecha"].Value.ToString();

                if (idHorario != -1)
                {
                    // Si hay plazas disponibles, se hace la reserva
                    if (plazasDisponibles > 0)
                    {
                        string fecha = DateTime.Now.ToString("dd/MM/yyyy");
                        FormReserva formReserva = new FormReserva(idCliente, idHorario, nombreActividad, hora, diaSemana, fechaDeLaActividad, monitor, plazasDisponibles, false);
                        formReserva.ShowDialog();

                        // Actualizamos las plazas disponibles después de realizar la reserva
                        ActualizarPlazasDisponibles();
                    }
                    else
                    {
                        // Si no hay plazas disponibles, se agrega al cliente a la lista de espera automáticamente
                        AgregarAListaEspera(idCliente, idHorario);
                    }
                }
                else
                {
                    MessageBox.Show("El horario no se encontró.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void AgregarAListaEspera(int idCliente, int idHorario)
        {
            // Primero, calculamos la nueva posición en la lista de espera
            int nuevaPosicion = ObtenerPosicionListaEspera(idHorario);

            using (SqlConnection connection = new SqlConnection(DatabaseConfig.ConnectionString))
            {
                connection.Open();

                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // Insertamos el cliente en la lista de espera
                        string insertQuery = "INSERT INTO ListaEspera (idHorario, idCliente, posicion) VALUES (@idHorario, @idCliente, @posicion)";
                        using (SqlCommand insertCmd = new SqlCommand(insertQuery, connection, transaction))
                        {
                            insertCmd.Parameters.AddWithValue("@idHorario", idHorario);
                            insertCmd.Parameters.AddWithValue("@idCliente", idCliente);
                            insertCmd.Parameters.AddWithValue("@posicion", nuevaPosicion);

                            insertCmd.ExecuteNonQuery();
                        }

                        transaction.Commit();
                        MessageBox.Show("No hay plazas disponibles. Has sido añadido a la lista de espera.");
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show("Ocurrió un error al agregar a la lista de espera: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private int ObtenerPosicionListaEspera(int idHorario)
        {
            int posicion = 1;

            using (SqlConnection connection = new SqlConnection(DatabaseConfig.ConnectionString))
            {
                connection.Open();

                string query = "SELECT COUNT(*) FROM ListaEspera WHERE idHorario = @idHorario";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@idHorario", idHorario);
                    posicion = (int)cmd.ExecuteScalar() + 1; // La nueva posición es el número total de clientes en la lista + 1
                }
            }

            return posicion;
        }


        public void ActualizarPlazasDisponibles()
        {
            string connectionString = DatabaseConfig.ConnectionString;

            string query = @"
                    SELECT h.PlazasDisponibles
                    FROM Horario h
                    WHERE h.idHorario = @idHorario";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Aseguramos que se actualicen todas las filas de todos los días
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
                                    row.Cells["Plazas"].Value = plazasDisponibles;
                                }
                            }
                        }
                    }
                }
            }
        }

        private void perfilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PerfilCliente perfilCliente = new PerfilCliente();
            perfilCliente.ShowDialog();
            this.Close();
        }

        private void consultarReservasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VerReservas misReservas = new VerReservas();
            misReservas.ShowDialog();
            this.Close();
        }

        private void consultarListaDeEsperaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListaEspera listaEspera = new ListaEspera();
            listaEspera.ShowDialog();
        }
    }

}
