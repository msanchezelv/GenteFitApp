using GenteFitApp.Controlador;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace GenteFitApp.Vista._02Clientes
{
    public partial class PerfilCliente : Form
    {
        int idCliente;
        private bool enModoEdicion = false;

        public PerfilCliente()
        {
            InitializeComponent();
            this.idCliente = ControladorInicioSesion.IdClienteActual;
            CargarDatosCliente();
            DeshabilitarCampos();
        }

        private void CargarDatosCliente()
        {
            string connectionString = "Data Source=DESKTOP-1JIM32R\\SQLEXPRESS;Initial Catalog=GenteFit;Integrated Security=True";
            string storedProcedure = "dbo.ObtenerPerfilCliente";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(storedProcedure, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@idCliente", idCliente);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                if (reader.Read())
                                {
                                    textBoxClienteId.Text = idCliente.ToString();
                                    textBoxNombre.Text = reader["nombre"].ToString();
                                    textBoxApellidos.Text = reader["apellidos"].ToString();
                                    textBoxEmail.Text = reader["email"].ToString();
                                    textBoxTelefono.Text = reader["telefono"].ToString();
                                    textBoxDireccion.Text = reader["direccion"].ToString();
                                }
                            }
                            else
                            {
                                MessageBox.Show("No se encontraron datos para el cliente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DeshabilitarCampos()
        {
            textBoxNombre.Enabled = false;
            textBoxApellidos.Enabled = false;
            textBoxEmail.Enabled = false;
            textBoxTelefono.Enabled = false;
            textBoxDireccion.Enabled = false;
            textBoxClienteId.Enabled = false;
        }

        private void HabilitarCampos()
        {
            textBoxNombre.Enabled = true;
            textBoxApellidos.Enabled = true;
            textBoxEmail.Enabled = true;
            textBoxTelefono.Enabled = true;
            textBoxDireccion.Enabled = true;
        }

        private void botonModificarDatos_Click(object sender, EventArgs e)
        {
            if (enModoEdicion)
            {
                ActualizarDatosCliente();
                botonModificarDatos.Text = "Modificar Datos";
                DeshabilitarCampos();
                enModoEdicion = false;
            }
            else
            {
                HabilitarCampos();
                botonModificarDatos.Text = "Guardar";
                enModoEdicion = true;
            }
        }

        private void ActualizarDatosCliente()
        {
            string connectionString = "Data Source=DESKTOP-1JIM32R\\SQLEXPRESS;Initial Catalog=GenteFit;Integrated Security=True";
            string storedProcedure = "dbo.ActualizarDatosCliente";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(storedProcedure, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@idCliente", idCliente);
                        command.Parameters.AddWithValue("@nombre", textBoxNombre.Text);
                        command.Parameters.AddWithValue("@apellidos", textBoxApellidos.Text);
                        command.Parameters.AddWithValue("@email", textBoxEmail.Text);
                        command.Parameters.AddWithValue("@telefono", textBoxTelefono.Text);
                        command.Parameters.AddWithValue("@direccion", textBoxDireccion.Text);

                        command.ExecuteNonQuery();

                        MessageBox.Show("Datos actualizados con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar los datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void botonModContrasena_Click(object sender, EventArgs e)
        {
            CambiarPassword CambiarPassword = new CambiarPassword();
            CambiarPassword.ShowDialog();
        }
    }
}
