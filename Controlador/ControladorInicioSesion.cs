using System;
using System.Data.SqlClient;
using GenteFitApp.Modelo;
using GenteFitApp.Controlador;

namespace GenteFitApp.Controlador
{
    public class ControladorInicioSesion
    {
        private readonly string connectionString = DatabaseConfig.ConnectionString;

        public static int IdUsuarioActual { get; private set; }
        public static int IdClienteActual { get; private set; }

        // Método para comprobar las credenciales
        public string ComprobarCredencialesPorEmail(string email, string contraseña)
        {
            Usuario usuario = ObtenerUsuarioPorEmail(email, contraseña);

            if (usuario != null)
            {
                IdUsuarioActual = usuario.idUsuario;
                IdClienteActual = ObtenerIdClientePorIdUsuario(IdUsuarioActual);
                return $"Inicio de sesión correcto. ¡Bienvenid@ {usuario.nombre}!";
            }

            return "Usuario no encontrado o contraseña incorrecta.";
        }

        // Método para obtener un usuario basado en su email y contraseña
        public Usuario ObtenerUsuarioPorEmail(string email, string contraseña)
        {
            string query = "SELECT idUsuario, nombre, apellidos, email, rol FROM Usuario WHERE email = @Email AND contraseña = @Contraseña";
            return EjecutarConsultaUsuario(query, new SqlParameter("@Email", email), new SqlParameter("@Contraseña", contraseña));
        }

        // Método para obtener un usuario por ID y contraseña
        public Usuario ObtenerUsuario(int idUsuario, string contraseña)
        {
            string query = "SELECT idUsuario, nombre, apellidos, email, rol FROM Usuario WHERE idUsuario = @idUsuario AND contraseña = @Contraseña";
            return EjecutarConsultaUsuario(query, new SqlParameter("@idUsuario", idUsuario), new SqlParameter("@Contraseña", contraseña));
        }

        // Método para recuperar contraseña basado en el email
        public Usuario ContraseñaOlvidada(string email)
        {
            string query = "SELECT idUsuario, nombre, apellidos, email, rol FROM Usuario WHERE email = @Email";
            return EjecutarConsultaUsuario(query, new SqlParameter("@Email", email));
        }

        // Método para obtener el idCliente basado en el idUsuario
        public int ObtenerIdClientePorIdUsuario(int idUsuario)
        {
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
                            return (int)reader["idCliente"];
                        }
                    }
                }
            }

            return -1; // Si no se encuentra, devuelve -1
        }

        // Método auxiliar para ejecutar consultas de usuario
        private Usuario EjecutarConsultaUsuario(string query, params SqlParameter[] parametros)
        {
            Usuario usuario = null;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    foreach (var parametro in parametros)
                    {
                        command.Parameters.Add(parametro);
                    }

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
