using GenteFitApp.Controlador;
using GenteFitApp.Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace GenteFitApp.Vista._04Reservas
{
    public partial class VerReservas : Form
    {
        private string connectionString = DatabaseConfig.ConnectionString;

        public VerReservas()
        {
            InitializeComponent();
        }

        private void FormVerReservas_Resize(object sender, EventArgs e)
        {
            dataGridViewReservas.AutoResizeColumns();
        }

        private void FormVerReservas_Load(object sender, EventArgs e)
        {
            int idCliente = ControladorInicioSesion.IdClienteActual;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand command = new SqlCommand("ConsultarReservas", connection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    command.Parameters.AddWithValue("@idCliente", idCliente);

                    SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();

                    // Llenamos el DataTable con los resultados de la consulta
                    dataAdapter.Fill(dataTable);

                    // Creamos una lista de ReservaDTO para almacenar los resultados
                    List<ReservaDTO> reservas = new List<ReservaDTO>();

                    // Convertimos cada fila del DataTable en un objeto ReservaDTO
                    foreach (DataRow row in dataTable.Rows)
                    {
                        reservas.Add(new ReservaDTO
                        {
                            IdReserva = Convert.ToInt32(row["idReserva"]),
                            FechaReserva = row["fechaReserva"].ToString(),
                            Cliente = row["Cliente"].ToString(),
                            Actividad = row["Actividad"].ToString(),
                            Dia = row["Día"].ToString(),
                            Hora = row["Hora"].ToString(),
                            Duracion = row["Duracion"].ToString()
                        });
                    }

                    // Asignamos la lista de reservas al DataGridView
                    dataGridViewReservas.DataSource = reservas;

                    // Ajustamos el tamaño de las columnas
                    dataGridViewReservas.AutoResizeColumns();

                    // Configuramos el evento DataBindingComplete para modificar las columnas
                    dataGridViewReservas.DataBindingComplete += (s, ev) =>
                    {
                        if (dataGridViewReservas.Columns.Contains("IdReserva"))
                            dataGridViewReservas.Columns["IdReserva"].Visible = false;  // Ocultamos la columna IdReserva

                        if (dataGridViewReservas.Columns.Contains("Cliente"))
                            dataGridViewReservas.Columns["Cliente"].HeaderText = "Cliente";  // Cambiamos el nombre de la columna Cliente

                        if (dataGridViewReservas.Columns.Contains("Actividad"))
                            dataGridViewReservas.Columns["Actividad"].HeaderText = "Actividad";  // Cambiamos el nombre de la columna Actividad

                        if (dataGridViewReservas.Columns.Contains("Dia"))
                            dataGridViewReservas.Columns["Dia"].HeaderText = "Día";  // Cambiamos el nombre de la columna Día

                        if (dataGridViewReservas.Columns.Contains("Hora"))
                        {
                            dataGridViewReservas.Columns["Hora"].HeaderText = "Hora";  // Cambiamos el nombre de la columna Hora
                            dataGridViewReservas.Columns["Hora"].DefaultCellStyle.Format = "HH:mm";  // Establecemos el formato para la hora
                        }

                        if (dataGridViewReservas.Columns.Contains("Duracion"))
                            dataGridViewReservas.Columns["Duracion"].HeaderText = "Duración";  // Cambiamos el nombre de la columna Duración

                        // Podemos agregar más configuraciones de columnas si lo deseas.
                    };
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar las reservas: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
               
    }
}
