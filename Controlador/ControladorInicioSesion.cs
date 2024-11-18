using System;
using System.Data.SqlClient;
using GenteFitApp.Modelo;

namespace GenteFitApp.Controlador
{
    public class ControladorInicioSesion
    {
        private string connectionString = @"Data Source=DESKTOP-1JIM32R\SQLEXPRESS;Initial Catalog=GenteFit;Integrated Security=True";

        public static int IdUsuarioActual { get; private set; }
        public static int IdClienteActual { get; private set; }



        // Método para comprobar las credenciales
        public string ComprobarCredencialesPorEmail(string email, string contraseña)
        {
            string mensaje = string.Empty;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT u.idUsuario, u.nombre, u.rol, c.idCliente " +
                               "FROM Usuario u " +
                               "LEFT JOIN Cliente c ON u.idUsuario = c.idUsuario " +
                               "WHERE u.email = @Email AND u.contraseña = @Contraseña";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@Contraseña", contraseña);

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            IdUsuarioActual = (int)reader["idUsuario"];
                            IdClienteActual = reader["idCliente"] != DBNull.Value ? (int)reader["idCliente"] : -1;
                            mensaje = $"Inicio de sesión correcto. ¡Bienvenid@ {reader["nombre"]}!";
                        }
                        else
                        {
                            mensaje = "Usuario no encontrado o contraseña incorrecta.";
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

        public Usuario ObtenerUsuarioPorEmail(string email, string contraseña)
        {
            Usuario usuario = null;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT idUsuario, nombre, apellidos, email, rol FROM Usuario WHERE email = @Email AND contraseña = @contraseña";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Email", email);
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


        // Método para obtener el idCliente basado en el idUsuario
        public int ObtenerIdClientePorIdUsuario(int idUsuario)
        {
            int idCliente = -1; // Retornamos -1 si no se encuentra el cliente

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT idCliente FROM Cliente WHERE idUsuario = @idUsuario";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@idUsuario", idUsuario);

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            idCliente = (int)reader["idCliente"];
                        }
                    }
                }
            }

            return idCliente;
        }
    }
}
