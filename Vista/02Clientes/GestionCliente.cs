using GenteFitApp.Controlador;
using GenteFitApp.Vista._06Usuario;
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

namespace GenteFitApp.Vista._02Clientes
{
    public partial class GestionCliente : Form
    {
        public GestionCliente()
        {
            InitializeComponent();
            CargarClientes();
        }

        private void CargarClientes()
        {
            string connectionString = DatabaseConfig.ConnectionString;
            string query = @"
                            SELECT 
                                Usuario.idUsuario, 
                                Usuario.nombre AS NombreUsuario, 
                                Usuario.apellidos AS ApellidosUsuario, 
                                Usuario.email AS EmailUsuario, 
                                Cliente.idCliente, 
                                Cliente.direccion AS DireccionCliente, 
                                Cliente.telefono AS TelefonoCliente
                            FROM Usuario
                            INNER JOIN Cliente ON Usuario.idUsuario = Cliente.idUsuario;
";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        dataAdapter.Fill(dataTable);
                        dataGridViewClientes.DataSource = dataTable;

                        if (dataGridViewClientes.Columns.Contains("idUsuario"))
                            dataGridViewClientes.Columns["idUsuario"].HeaderText = "Id Usuario";
                        if (dataGridViewClientes.Columns.Contains("NombreUsuario"))
                            dataGridViewClientes.Columns["NombreUsuario"].HeaderText = "Nombre";
                        if (dataGridViewClientes.Columns.Contains("ApellidosUsuario"))
                            dataGridViewClientes.Columns["ApellidosUsuario"].HeaderText = "Apellidos";
                        if (dataGridViewClientes.Columns.Contains("EmailUsuario"))
                            dataGridViewClientes.Columns["EmailUsuario"].HeaderText = "Correo Electrónico";
                        if (dataGridViewClientes.Columns.Contains("idCliente"))
                            dataGridViewClientes.Columns["idCliente"].HeaderText = "idCliente";
                        if (dataGridViewClientes.Columns.Contains("direccion"))
                            dataGridViewClientes.Columns["direccion"].HeaderText = "Direccion";
                        if (dataGridViewClientes.Columns.Contains("TelefonoCliente"))
                            dataGridViewClientes.Columns["TelefonoCliente"].HeaderText = "Teléfono";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridViewClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dataGridViewClientes.Rows[e.RowIndex];

                string idCliente = row.Cells["idCliente"].Value?.ToString() ?? string.Empty;
                string nombre = row.Cells["NombreUsuario"].Value?.ToString() ?? string.Empty;
                string apellidos = row.Cells["ApellidosUsuario"].Value?.ToString() ?? string.Empty;
                string email = row.Cells["EmailUsuario"].Value?.ToString() ?? string.Empty;
                string telefono = row.Cells["TelefonoCliente"].Value?.ToString() ?? string.Empty;
                string direccion = row.Cells["DireccionCliente"].Value?.ToString() ?? string.Empty;

                PerfilCliente perfilClienteForm = new PerfilCliente();

                perfilClienteForm.textBoxClienteId.Text = idCliente;
                perfilClienteForm.textBoxNombre.Text = nombre;
                perfilClienteForm.textBoxApellidos.Text = apellidos;
                perfilClienteForm.textBoxEmail.Text = email;
                perfilClienteForm.textBoxTelefono.Text = telefono;
                perfilClienteForm.textBoxDireccion.Text = direccion;

                perfilClienteForm.ShowDialog();
            }

        }

    }
}

