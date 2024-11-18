using GenteFitApp.Controlador;
using GenteFitApp.Modelo;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace GenteFitApp.Vista._02Clientes
{
    public partial class CambiarPassword : Form
    { 

        public CambiarPassword()
        {
            InitializeComponent();
            textBoxContraseñaActual.PasswordChar = '*';
            textBoxContraseñaNueva.PasswordChar = '*';
            textBoxConfirmarContraseña.PasswordChar = '*';
        }

        private void buttonActualizar_Click(object sender, EventArgs e)
        {
            string contraseñaActual = textBoxContraseñaActual.Text;
            string contraseñaNueva = textBoxContraseñaNueva.Text;
            string confirmarContraseña = textBoxConfirmarContraseña.Text;

            if (contraseñaNueva != confirmarContraseña)
            {
                MessageBox.Show("Las contraseñas no coinciden.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (ActualizarContraseña(contraseñaActual, contraseñaNueva))
            {
                MessageBox.Show("Contraseña actualizada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Error al actualizar la contraseña. Verifique que la contraseña actual sea correcta.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private int idUsuario = ControladorInicioSesion.IdUsuarioActual;

        private bool ActualizarContraseña(string contraseñaActual, string contraseñaNueva)
        {
            string connectionString = "Data Source=DESKTOP-1JIM32R\\SQLEXPRESS;Initial Catalog=GenteFit;Integrated Security=True";
            string storedProcedure = "dbo.ActualizarContraseña";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(storedProcedure, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@idUsuario", ControladorInicioSesion.IdUsuarioActual);
                        command.Parameters.AddWithValue("@contraseñaActual", contraseñaActual);
                        command.Parameters.AddWithValue("@contraseñaNueva", contraseñaNueva);

                        var result = command.ExecuteScalar();

                        // Verificar el resultado
                        if (result != null && (int)result == 1)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar la contraseña: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }



    }
}
