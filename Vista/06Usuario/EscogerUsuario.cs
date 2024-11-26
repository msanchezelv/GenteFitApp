using GenteFitApp.Controlador;
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

namespace GenteFitApp.Vista._06Usuario
{
    public partial class EscogerUsuario : Form
    {
        public EscogerUsuario()
        {
            InitializeComponent();
            CargarUsuarios();            
        }

        private void CargarUsuarios()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(DatabaseConfig.ConnectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM Usuario";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        dataGridViewUsuarios.DataSource = dataTable;

                        if (dataGridViewUsuarios.Columns.Contains("idUsuario"))
                            dataGridViewUsuarios.Columns["idUsuario"].HeaderText = "Id Usuario";
                        if (dataGridViewUsuarios.Columns.Contains("nombre"))
                            dataGridViewUsuarios.Columns["nombre"].HeaderText = "Nombre";
                        if (dataGridViewUsuarios.Columns.Contains("apellidos"))
                            dataGridViewUsuarios.Columns["apellidos"].HeaderText = "Apellidos";
                        if (dataGridViewUsuarios.Columns.Contains("email"))
                            dataGridViewUsuarios.Columns["email"].HeaderText = "Correo Electrónico";
                        if (dataGridViewUsuarios.Columns.Contains("contraseña"))                        
                            dataGridViewUsuarios.Columns["contraseña"].HeaderText = "Contraseña";
                        if (dataGridViewUsuarios.Columns.Contains("rol"))
                            dataGridViewUsuarios.Columns["rol"].HeaderText = "Rol";                      
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al cargar los usuarios: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        

        private void dataGridViewUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dataGridViewUsuarios.Rows[e.RowIndex];

                string idUsuario = row.Cells["idUsuario"].Value.ToString();
                string nombre = row.Cells["nombre"].Value.ToString();
                string apellidos = row.Cells["apellidos"].Value.ToString();
                string email = row.Cells["email"].Value.ToString();
                string contraseña = row.Cells["contraseña"].Value.ToString();
                string rol = row.Cells["rol"].Value.ToString();

                GestionUsuarios gestionForm = new GestionUsuarios();
                gestionForm.CargarDatosUsuario(idUsuario, nombre, apellidos, email, contraseña, rol);


                gestionForm.ShowDialog();
            }
        }

    }
}
