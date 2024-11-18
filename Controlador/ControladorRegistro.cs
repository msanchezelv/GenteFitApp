using System;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using GenteFitApp.Modelo;
using GenteFitApp.Vista;
using GenteFitApp.Vista._01Inicio;

namespace GenteFitApp.controlador
{
    internal class ControladorRegistro
    {
        internal string connectionString = "Data Source=DESKTOP-6VP8HCF;Initial Catalog=GenteFit;Integrated Security=True";

        // Método para registrar un usuario con rol y abrir la pantalla correspondiente
        public int RegistrarUsuario(string nombre, string apellidos, string email, string contraseña, string rol)
        {
            int idUsuario = -1;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Usuario (Nombre, Apellidos, Email, Contraseña, Rol) " +
                               "VALUES (@Nombre, @Apellidos, @Email, @Contraseña, @Rol); " +
                               "SELECT SCOPE_IDENTITY();";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Nombre", nombre);
                    cmd.Parameters.AddWithValue("@Apellidos", apellidos);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Contraseña", contraseña);
                    cmd.Parameters.AddWithValue("@Rol", rol);

                    conn.Open();
                    idUsuario = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }

            return idUsuario;
        }



        private string HashContraseña(string contraseña)
        {
            using (var sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(contraseña));
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }

        internal int ObtenerProximoIdUsuario()
        {
            int proximoId = 1;
            string query = "SELECT ISNULL(MAX(idUsuario), 0) + 1 FROM Usuario";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    proximoId = (int)command.ExecuteScalar();
                }
            }
            return proximoId;
        }

        public bool RegistrarCliente(int idUsuario, string telefono, string direccion)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "INSERT INTO Cliente (idUsuario, telefono, direccion) VALUES (@idUsuario, @telefono, @direccion)";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@idUsuario", idUsuario);
                    command.Parameters.AddWithValue("@telefono", telefono);
                    command.Parameters.AddWithValue("@direccion", direccion);

                    // Ejecutamos la consulta de inserción
                    int filasAfectadas = command.ExecuteNonQuery();

                    // Si se insertaron filas, la operación fue exitosa
                    return filasAfectadas > 0;
                }
            }
        }


    }
}
