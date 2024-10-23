using System;
using System.Data.SqlClient; // Para la conexión a la base de datos
using System.Windows.Forms;

namespace GenteFitApp
{
    public partial class PaginaInicio : Form
    {
        // Constructor del formulario
        public PaginaInicio()
        {
            InitializeComponent();
        }

        // Método para el evento click en el botón "Iniciar Sesión"
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text;
            string contraseña = txtPassword.Text;

            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(contraseña))
            {
                lblMensaje.Text = "Por favor, complete todos los campos.";
                return;
            }

            // Simulación de la conexión con la base de datos
            if (ValidarCredenciales(usuario, contraseña))
            {
                lblMensaje.Text = "Inicio de sesión exitoso.";
                // Aquí puedes abrir el siguiente formulario o la funcionalidad principal
                // Por ejemplo, un menú principal del gimnasio
            }
            else
            {
                lblMensaje.Text = "Usuario o contraseña incorrectos.";
            }
        }

        // Método para validar las credenciales en la base de datos
        private bool ValidarCredenciales(string usuario, string contraseña)
        {
            // Simulación de una consulta de base de datos. Puedes adaptar este código para usar una base real.
            string cadenaConexion = "Server=tuServidor;Database=GenteFitDB;User Id=tuUsuario;Password=tuContraseña;";

            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                try
                {
                    conexion.Open();
                    string consulta = "SELECT COUNT(1) FROM Usuarios WHERE Usuario=@Usuario AND Contraseña=@Contraseña";
                    SqlCommand cmd = new SqlCommand(consulta, conexion);
                    cmd.Parameters.AddWithValue("@Usuario", usuario);
                    cmd.Parameters.AddWithValue("@Contraseña", contraseña);

                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count == 1; // Si la consulta devuelve 1, las credenciales son correctas
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error de conexión: " + ex.Message);
                    return false;
                }
            }
        }
    }
}
