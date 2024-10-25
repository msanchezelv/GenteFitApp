using System;
using System.Data.SqlClient;
using GenteFitApp.Modelo;

namespace GenteFitApp.Controlador
{
    public class ControladorInicioSesion
    {
        private string connectionString = @"Data Source=DESKTOP-1JIM32R\SQLEXPRESS;Initial Catalog=GenteFit;Integrated Security=True"; // Cambia esta cadena de conexión según sea necesario

        public Usuario ComprobarCredenciales(int userId, string password)
        {
            Usuario usuario = null;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT idUsuario, nombre, apellido, email, rol FROM Usuario WHERE idUsuario = @userId AND contraseña = @password";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@userId", userId);
                    command.Parameters.AddWithValue("@password", password);

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            usuario = new Usuario
                            {
                                idUsuario = (int)reader["idUsuario"],
                                nombre = reader["nombre"].ToString(),
                                apellido = reader["apellido"].ToString(),
                                email = reader["email"].ToString(),
                                rol = reader["rol"].ToString()
                            };
                        }
                    }
                }
            }

            return usuario;
        }
    }
}
