using System;
using System.Data.SqlClient;
using GenteFitApp.Modelo;

namespace GenteFitApp.Controlador
{
    public class ControladorInicioSesion
    {
        private string connectionString = @"Data Source=DESKTOP-1JIM32R\SQLEXPRESS;Initial Catalog=GenteFit;Integrated Security=True"; // Cambia esta cadena de conexión según sea necesario

        public string ComprobarCredenciales(int idUsuario, string contraseña)
        {
            string mensaje = string.Empty;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT idUsuario, nombre, apellido, email, contraseña, rol FROM Usuario WHERE idUsuario = @idUsuario";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@idUsuario", idUsuario);

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Usuario encontrado
                            if (reader["contraseña"].ToString() == contraseña)
                            {
                                // Contraseña correcta
                                Usuario usuario = new Usuario
                                {
                                    idUsuario = (int)reader["idUsuario"],
                                    nombre = reader["nombre"].ToString(),
                                    apellido = reader["apellido"].ToString(),
                                    email = reader["email"].ToString(),
                                    rol = reader["rol"].ToString()
                                };

                                // Aquí puedes manejar el inicio de sesión exitoso
                                mensaje = $"Inicio de sesión exitoso. Bienvenido {usuario.nombre}";
                            }
                            else
                            {
                                // Contraseña incorrecta
                                mensaje = "Contraseña incorrecta.";
                            }
                        }
                        else
                        {
                            // Usuario no encontrado
                            mensaje = "Usuario no encontrado. ¿Registrar nuevo usuario? S/N";
                        }
                    }
                }
            }

            return mensaje;
        }
    }
}
