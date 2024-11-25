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
                        {
                            dataGridViewUsuarios.Columns["contraseña"].HeaderText = "Contraseña";
                            foreach (DataGridViewRow row in dataGridViewUsuarios.Rows)
                            {
                                if (row.Cells["contraseña"] != null && row.Cells["contraseña"].Value != null)
                                {
                                    row.Cells["contraseña"].Tag = row.Cells["contraseña"].Value.ToString();
                                    row.Cells["contraseña"].Value = new string('*', row.Cells["contraseña"].Value.ToString().Length);
                                }
                            }
                        }
                        if (dataGridViewUsuarios.Columns.Contains("rol"))
                            dataGridViewUsuarios.Columns["rol"].HeaderText = "Rol";

                        dataGridViewUsuarios.CellMouseClick += DataGridViewUsuarios_CellMouseClick;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al cargar los usuarios: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void DataGridViewUsuarios_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                var cell = dataGridViewUsuarios.Rows[e.RowIndex].Cells[e.ColumnIndex];

                if (cell.OwningColumn.Name == "contraseña" && cell.Tag != null)
                {
                    Console.WriteLine("Se hizo clic en la celda de la contraseña");

                    if (cell.Value.ToString() == new string('*', cell.Value.ToString().Length))
                    {
                        Console.WriteLine("Mostrando la contraseña real");
                        cell.Value = cell.Tag.ToString();
                    }
                    else
                    {
                        Console.WriteLine("Ocultando la contraseña con asteriscos");
                        cell.Value = new string('*', cell.Tag.ToString().Length);
                    }
                }
            }
        }




        private void dataGridViewUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        private void DataGridViewUsuarios_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridViewUsuarios.Columns[e.ColumnIndex].Name == "contraseña" && e.Value != null)
            {
                string contraseña = e.Value.ToString();
                e.Value = new string('*', contraseña.Length);
                e.FormattingApplied = true;
            }
        }

       
    }
}
