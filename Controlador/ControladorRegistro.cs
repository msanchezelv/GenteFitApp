using System;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using GenteFitApp.Modelo;

namespace GenteFitApp.controlador
{
    internal class ControladorRegistro
    {
        internal string connectionString = "Data Source=DESKTOP-6VP8HCF;Initial Catalog=GenteFit;Integrated Security=True";

        // Método para registrar un usuario general con rol
        public bool RegistrarUsuario(string nombre, string apellidos, string email, string contraseña, string rol)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                

                string query = "INSERT INTO usuario (nombre, apellido, email, contraseña, rol) VALUES (@nombre, @apellido, @email, @contraseña, @rol)";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@nombre", nombre);
                    command.Parameters.AddWithValue("@apellido", apellidos);
                    command.Parameters.AddWithValue("@email", email);
                    command.Parameters.AddWithValue("@contraseña", contraseña);
                    command.Parameters.AddWithValue("@rol", rol);

                    int filasAfectadas = command.ExecuteNonQuery();
                    return filasAfectadas > 0;
                }
            }
        }

        // Método para hashear la contraseña (opcional, pero recomendado)
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
    }
}
