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
            // Obtener las reservas del cliente actual
            int idCliente = ControladorInicioSesion.IdClienteActual;
            List<ReservaDTO> reservas = ReservaDTO.ObtenerReservasPorCliente(idCliente);

            // Vincular las reservas al DataGridView
            BindingList<ReservaDTO> bindingReservas = new BindingList<ReservaDTO>(reservas);
            dataGridViewReservas.DataSource = bindingReservas;

            // Configurar las propiedades del DataGridView
            dataGridViewReservas.DataBindingComplete += (s, ev) =>
            {
                // Asegurarse de que las columnas sean ocultadas de inmediato
                if (dataGridViewReservas.Columns.Contains("IdReserva"))
                {
                    dataGridViewReservas.Columns["IdReserva"].Visible = false;
                }
                if (dataGridViewReservas.Columns.Contains("Cliente"))
                {
                    dataGridViewReservas.Columns["Cliente"].Visible = false;
                }

                // Modificar los encabezados de las columnas
                if (dataGridViewReservas.Columns.Contains("FechaReserva"))
                    dataGridViewReservas.Columns["FechaReserva"].HeaderText = "Fecha de Reserva";
                if (dataGridViewReservas.Columns.Contains("Actividad"))
                    dataGridViewReservas.Columns["Actividad"].HeaderText = "Actividad";
                if (dataGridViewReservas.Columns.Contains("Duracion"))
                    dataGridViewReservas.Columns["Duracion"].HeaderText = "Duración";
                if (dataGridViewReservas.Columns.Contains("FechaCompleta"))
                    dataGridViewReservas.Columns["FechaCompleta"].HeaderText = "Día y Fecha";

                // Formato de las fechas
                if (dataGridViewReservas.Columns.Contains("FechaCompleta"))
                    dataGridViewReservas.Columns["FechaCompleta"].DefaultCellStyle.Format = "dddd dd/MM/yyyy";

                if (dataGridViewReservas.Columns.Contains("FechaReserva"))
                    dataGridViewReservas.Columns["FechaReserva"].DefaultCellStyle.Format = "dd/MM/yyyy";

                // Ajustar las columnas al contenido de las celdas
                dataGridViewReservas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

                // Ajustar las filas al contenido de las celdas
                dataGridViewReservas.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

                // Ajustar el tamaño de las columnas y filas automáticamente
                dataGridViewReservas.Dock = DockStyle.Fill;

                // Personalizar el estilo del DataGridView
                dataGridViewReservas.BackgroundColor = Color.Bisque;
                dataGridViewReservas.AllowUserToAddRows = false; // Desactivar la opción de agregar filas
                dataGridViewReservas.ReadOnly = true; // Hacer que todas las celdas sean solo lectura

                // Desactivar el ajuste automático de columnas por el usuario
                foreach (DataGridViewColumn column in dataGridViewReservas.Columns)
                {
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                }
            };
        }

    }
}
