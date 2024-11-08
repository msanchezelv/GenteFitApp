using System;
using System.Data.SqlClient;
using GenteFitApp.Modelo;

namespace GenteFitApp.Controlador
{
    public class ControladorInicioSesion
    {
        private string connectionString = @"Data Source=DESKTOP-1JIM32R\SQLEXPRESS;Initial Catalog=GenteFit;Integrated Security=True";

        // Método para comprobar las credenciales
        public string ComprobarCredenciales(int idUsuario, string contraseña)
        {
            string mensaje = string.Empty;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT idUsuario, nombre, apellidos, email, contraseña, rol FROM Usuario WHERE idUsuario = @idUsuario";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@idUsuario", idUsuario);

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Aquí solo se obtiene el 'rol' si el usuario es encontrado
                            if (reader["contraseña"].ToString() == contraseña)
                            {
                                mensaje = $"Inicio de sesión correcto. ¡Bienvenid@ {reader["nombre"]}!";
                                // Acceder al rol solo después de validar que la contraseña es correcta
                                string rol = reader["rol"].ToString();
                                if (!string.IsNullOrWhiteSpace(rol))
                                {
                                    // Proseguir con el proceso
                                }
                                else
                                {
                                    mensaje = "El rol del usuario no está definido correctamente.";
                                }
                            }
                            else
                            {
                                mensaje = "Contraseña incorrecta.";
                            }
                        }
                        else
                        {
                            mensaje = "Usuario no encontrado. ¿Registrar nuevo usuario? S/N";
                        }
                    }
                }
            }

            return mensaje;
        }


        // Método para obtener un usuario basado en el ID y la contraseña.
        public Usuario ObtenerUsuario(int idUsuario, string contraseña)
        {
            Usuario usuario = null;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT idUsuario, nombre, apellidos, email, rol FROM Usuario WHERE idUsuario = @idUsuario AND contraseña = @contraseña";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@idUsuario", idUsuario);
                    command.Parameters.AddWithValue("@contraseña", contraseña);

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            usuario = new Usuario
                            {
                                idUsuario = (int)reader["idUsuario"],
                                nombre = reader["nombre"].ToString(),
                                apellidos = reader["apellidos"].ToString(),
                                email = reader["email"].ToString(),
                                rol = reader["rol"].ToString()
                            };
                        }
                    }
                }
            }

            return usuario;
        }

        public Usuario ObtenerUsuarioPorId(int idUsuario)
        {
            Usuario usuario = null;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT idUsuario, nombre, apellidos, email, rol FROM Usuario WHERE idUsuario = @idUsuario";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@idUsuario", idUsuario);

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            usuario = new Usuario
                            {
                                idUsuario = (int)reader["idUsuario"],
                                nombre = reader["nombre"].ToString(),
                                apellidos = reader["apellidos"].ToString(),
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
