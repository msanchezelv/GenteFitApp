using GenteFitApp.Controlador;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace GenteFitApp.Vista._01Inicio
{
    public partial class RegistrarMonitor : Form
    {
        public RegistrarMonitor()
        {
            InitializeComponent();            
            CargarDatosMonitores();

            // Configuración inicial de textBoxIdMonitor
            textBoxIdMonitor.ReadOnly = false;
            textBoxIdMonitor.BackColor = Color.White;

            // Configuración inicial de dataGridViewMonitores
            dataGridViewMonitores.ReadOnly = true;
            dataGridViewMonitores.AllowUserToAddRows = false;
            dataGridViewMonitores.AllowUserToDeleteRows = false;

            // Conectar eventos
            buttonCargar.Click += new EventHandler(buttonCargar_Click);
            buttonEliminar.Click += new EventHandler(buttonEliminar_Click);
            buttonGuardar.Click += new EventHandler(buttonGuardar_Click);
        }


        private void CargarDatosMonitores()
        {
            string conString = DatabaseConfig.ConnectionString;
            using (SqlConnection con = new SqlConnection(conString))
            {
                string query = "SELECT * FROM Monitor";
                SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridViewMonitores.DataSource = dt;
            }
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                if (!EsIdMonitorUnico(int.Parse(textBoxIdMonitor.Text)))
                {
                    textBoxIdMonitor.BackColor = Color.Red;
                    MessageBox.Show("El idMonitor ya existe. Por favor, introduce un nuevo idMonitor.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    GuardarMonitor();
                    CargarDatosMonitores();
                    LimpiarCampos();
                }
            }
        }

        private bool ValidarCampos()
        {
            bool camposValidos = true;

            if (string.IsNullOrWhiteSpace(textBoxIdMonitor.Text) || !EsIdMonitorUnico(int.Parse(textBoxIdMonitor.Text)))
            {
                textBoxIdMonitor.BackColor = Color.Red;
                camposValidos = false;
            }
            else
            {
                textBoxIdMonitor.BackColor = Color.White;
            }

            if (string.IsNullOrWhiteSpace(textBoxNombre.Text))
            {
                textBoxNombre.BackColor = Color.Red;
                camposValidos = false;
            }
            else
            {
                textBoxNombre.BackColor = Color.White;
            }

            if (string.IsNullOrWhiteSpace(textBoxApellidos.Text))
            {
                textBoxApellidos.BackColor = Color.Red;
                camposValidos = false;
            }
            else
            {
                textBoxApellidos.BackColor = Color.White;
            }

            if (!camposValidos)
            {
                MessageBox.Show("Por favor, rellene correctamente todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return camposValidos;
        }

        private bool EsIdMonitorUnico(int idMonitor)
        {
            string conString = DatabaseConfig.ConnectionString;
            using (SqlConnection con = new SqlConnection(conString))
            {
                string query = "SELECT COUNT(*) FROM Monitor WHERE idMonitor = @idMonitor";
                SqlCommand command = new SqlCommand(query, con);
                command.Parameters.AddWithValue("@idMonitor", idMonitor);

                con.Open();
                int count = (int)command.ExecuteScalar();
                return count == 0;
            }
        }

        private void GuardarMonitor()
        {
            string conString = DatabaseConfig.ConnectionString;
            using (SqlConnection con = new SqlConnection(conString))
            {
                string query = "SET IDENTITY_INSERT Monitor ON; " +
                               "INSERT INTO Monitor (idMonitor, nombre, apellidos) VALUES (@idMonitor, @nombre, @apellidos); " +
                               "SET IDENTITY_INSERT Monitor OFF;";
                SqlCommand command = new SqlCommand(query, con);
                command.Parameters.AddWithValue("@idMonitor", textBoxIdMonitor.Text);
                command.Parameters.AddWithValue("@nombre", textBoxNombre.Text);
                command.Parameters.AddWithValue("@apellidos", textBoxApellidos.Text);

                con.Open();
                command.ExecuteNonQuery();
            }

            MessageBox.Show("Monitor registrado correctamente.");
        }

        private void buttonCargar_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBoxIdMonitor.Text, out int idMonitor))
            {
                CargarMonitor(idMonitor);
            }
            else
            {
                MessageBox.Show("Por favor, introduzca un idMonitor válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarMonitor(int idMonitor)
        {
            string conString = DatabaseConfig.ConnectionString;
            using (SqlConnection con = new SqlConnection(conString))
            {
                string query = "SELECT nombre, apellidos FROM Monitor WHERE idMonitor = @idMonitor";
                SqlCommand command = new SqlCommand(query, con);
                command.Parameters.AddWithValue("@idMonitor", idMonitor);

                con.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        textBoxNombre.Text = reader["nombre"].ToString();
                        textBoxApellidos.Text = reader["apellidos"].ToString();

                        textBoxNombre.ReadOnly = true;
                        textBoxNombre.BackColor = Color.LightGray;

                        textBoxApellidos.ReadOnly = true;
                        textBoxApellidos.BackColor = Color.LightGray;
                    }
                    else
                    {
                        MessageBox.Show("No se encontró ningún monitor con el id especificado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBoxIdMonitor.Text, out int idMonitor))
            {
                DialogResult result = MessageBox.Show("¿Está seguro de que desea eliminar el monitor?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    EliminarMonitor();
                    MessageBox.Show("El monitor ha sido eliminado.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarDatosMonitores();
                    LimpiarCampos();
                    HabilitarCampos();
                }
            }
            else
            {
                MessageBox.Show("Por favor, introduzca un idMonitor válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EliminarMonitor()
        {
            string conString = DatabaseConfig.ConnectionString;
            using (SqlConnection con = new SqlConnection(conString))
            {
                string query = "DELETE FROM Monitor WHERE idMonitor = @idMonitor";
                SqlCommand command = new SqlCommand(query, con);
                command.Parameters.AddWithValue("@idMonitor", textBoxIdMonitor.Text);

                con.Open();
                command.ExecuteNonQuery();
            }
        }

        private void LimpiarCampos()
        {
            textBoxIdMonitor.Clear();
            textBoxNombre.Clear();
            textBoxApellidos.Clear();
            textBoxIdMonitor.ReadOnly = false;
            textBoxIdMonitor.BackColor = Color.White;
        }

        private void HabilitarCampos()
        {
            textBoxNombre.ReadOnly = false;
            textBoxNombre.BackColor = Color.White;

            textBoxApellidos.ReadOnly = false;
            textBoxApellidos.BackColor = Color.White;
        }

     
    }



}
