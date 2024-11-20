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

        private DataGridView CrearDataGridView()
        {
            DataGridView dataGridViewReservas = new DataGridView
            {
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells,
                Dock = DockStyle.Fill,
                BackgroundColor = Color.Bisque,
                AllowUserToAddRows = false,
                ReadOnly = true
            };

            return dataGridViewReservas;
        }


    }
}
