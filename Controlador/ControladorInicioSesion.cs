using System;
using System.Data.SqlClient;
using GenteFitApp.Modelo;

namespace GenteFitApp.Controlador
{
    public class ControladorInicioSesion
    {
        private readonly string connectionString = DatabaseConfig.ConnectionString;
        private static string connectionString1 = DatabaseConfig.ConnectionString;

        public static string RolUsuarioActual { get; private set; }
        public static int IdUsuarioActual { get; private set; }
        public static int IdClienteActual { get; private set; }


        // Método para comprobar las credenciales
        public string ComprobarCredencialesPorEmail(string email, string contraseña)
        {
            if (!ExisteUsuarioPorEmail(email))
            {
                return "Usuario no encontrado. ¿Registrar nuevo usuario? S/N";
            }

            Usuario usuario = ObtenerUsuarioPorEmail(email, contraseña);
            if (usuario != null)
            {
                IdUsuarioActual = usuario.idUsuario;
                IdClienteActual = ObtenerIdClientePorIdUsuario(IdUsuarioActual);
                RolUsuarioActual = usuario.rol;
                return $"Inicio de sesión correcto. ¡Bienvenid@ {usuario.nombre}!";
            }
            return "La contraseña es incorrecta. Por favor, inténtalo de nuevo.";
        }


        // Método para obtener un usuario basado en su email y contraseña
        public Usuario ObtenerUsuarioPorEmail(string email, string contraseña)
        {
            string query = "SELECT idUsuario, nombre, apellidos, email, rol FROM Usuario WHERE email = @Email AND contraseña = @Contraseña";
            return EjecutarConsultaUsuario(query, new SqlParameter("@Email", email), new SqlParameter("@Contraseña", contraseña));
        }


        // Método para verificar si el email existe
        public bool ExisteUsuarioPorEmail(string email)
        {
            string query = "SELECT 1 FROM Usuario WHERE email = @Email";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Email", email);
                    connection.Open();
                    return command.ExecuteScalar() != null;
                }
            }
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
            string query = "SELECT idCliente FROM Cliente WHERE idUsuario = @idUsuario";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
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

            return -1;
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


        // Método para verificar y resetear plazas en la tabla Horario
        public static void VerificarYProcesarDatos()
        {

            using (SqlConnection connection = new SqlConnection(connectionString1))
            {
                connection.Open();

                
                string queryFechaUltimoReseteo = "SELECT TOP 1 FechaUltimoReseteo FROM Configuracion";
                DateTime fechaUltimoReseteo;

                using (SqlCommand command = new SqlCommand(queryFechaUltimoReseteo, connection))
                {
                    var resultado = command.ExecuteScalar();
                    fechaUltimoReseteo = resultado != null ? Convert.ToDateTime(resultado) : DateTime.MinValue;
                    Console.WriteLine("Se ha comprobado la fecha del último reseteo");
                }

                // Verificar si han pasado 7 días desde el último proceso
                if (fechaUltimoReseteo == DateTime.MinValue || (DateTime.Now - fechaUltimoReseteo).Days >= 7)
                {
                    Console.WriteLine("Se va a proceder a restablecer la base de datos");
                    // Iniciar el reseteo de plazas disponibles
                    string queryResetearPlazas = "UPDATE Horario SET plazasDisponibles = 8";
                    using (SqlCommand command = new SqlCommand(queryResetearPlazas, connection))
                    {
                        command.ExecuteNonQuery();
                        Console.WriteLine("Se han establecido las plazas disponibles en 8");
                    }

                    // Eliminar registros antiguos de la lista de espera
                    string queryEliminarRegistros = "EXEC [dbo].[EliminarListaEsperaAntigua];";
                    using (SqlCommand command = new SqlCommand(queryEliminarRegistros, connection))
                    {
                        command.Parameters.AddWithValue("@FechaActual", DateTime.Now);
                        command.ExecuteNonQuery();
                    }

                    // Actualizar la fecha del último proceso (reseteo y eliminación)
                    string queryActualizarFecha = "UPDATE Configuracion SET FechaUltimoReseteo = @FechaActual";
                    using (SqlCommand command = new SqlCommand(queryActualizarFecha, connection))
                    {
                        command.Parameters.AddWithValue("@FechaActual", DateTime.Now);
                        command.ExecuteNonQuery();
                    }
                }
            }
        }



    }
}
