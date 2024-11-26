using System;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using GenteFitApp.Controlador;
using GenteFitApp.Modelo;

namespace GenteFitApp.Controlador
{
    public class ControladorRegistro
    {
        private readonly string connectionString = DatabaseConfig.ConnectionString;

        // Método para registrar un usuario con rol
        public int RegistrarUsuario(string nombre, string apellidos, string email, string contraseña, string rol)
        {
            string query = "INSERT INTO Usuario (Nombre, Apellidos, Email, Contraseña, Rol) " +
                           "VALUES (@Nombre, @Apellidos, @Email, @Contraseña, @Rol); " +
                           "SELECT SCOPE_IDENTITY();";

            var parametros = new[]
            {
                new SqlParameter("@Nombre", nombre),
                new SqlParameter("@Apellidos", apellidos),
                new SqlParameter("@Email", email),
                new SqlParameter("@Contraseña", HashContraseña(contraseña)),
                new SqlParameter("@Rol", rol)
            };

            return EjecutarConsultaValorUnico(query, parametros);
        }

        // Método para registrar un cliente asociado a un usuario
        public bool RegistrarCliente(int idUsuario, string telefono, string direccion)
        {
            string query = "INSERT INTO Cliente (idUsuario, telefono, direccion) VALUES (@idUsuario, @telefono, @direccion)";

            var parametros = new[]
            {
                new SqlParameter("@idUsuario", idUsuario),
                new SqlParameter("@telefono", telefono),
                new SqlParameter("@direccion", direccion)
            };

            return EjecutarConsultaNoValorUnico(query, parametros);
        }

        // Método para obtener el próximo ID de usuario (si es necesario manualmente)
        public int ObtenerProximoIdUsuario()
        {
            string query = "SELECT ISNULL(MAX(idUsuario), 0) + 1 FROM Usuario";
            return EjecutarConsultaValorUnico(query);
        }

        // Método privado para hashear contraseñas
        private string HashContraseña(string contraseña)
        {
            using (var sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(contraseña));
                return BitConverter.ToString(bytes).Replace("-", "").ToLower();
            }
        }

        // Método auxiliar para ejecutar consultas que devuelven un escalar
        public int EjecutarConsultaValorUnico(string query, params SqlParameter[] parametros)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand(query, connection))
                {
                    if (parametros != null)
                    {
                        command.Parameters.AddRange(parametros);
                    }

                    connection.Open();
                    return Convert.ToInt32(command.ExecuteScalar());
                }
            }
        }

        // Método auxiliar para ejecutar consultas que no devuelven resultados (INSERT, UPDATE, DELETE)
        private bool EjecutarConsultaNoValorUnico(string query, params SqlParameter[] parametros)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand(query, connection))
                {
                    if (parametros != null)
                    {
                        command.Parameters.AddRange(parametros);
                    }

                    connection.Open();
                    return command.ExecuteNonQuery() > 0;
                }
            }
        }
    }
}
