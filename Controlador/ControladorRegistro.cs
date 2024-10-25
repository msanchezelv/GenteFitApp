using System;
using System.Data.SqlClient;
using GenteFitApp.Modelo;

namespace GenteFitApp.controlador
{
    internal class ControladorRegistro
    {
        internal string connectionString = "Data Source=DESKTOP-1JIM32R\\SQLEXPRESS;Initial Catalog=GenteFit;Integrated Security=True";

        // Método para registrar un usuario general
        internal bool RegistrarUsuario(string nombre, string apellidos, string email)
        {
            // Validar los campos
            if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(apellidos) || string.IsNullOrEmpty(email))
            {
                throw new ArgumentException("Los campos obligatorios no pueden estar vacíos.");
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Usuarios (Nombre, Apellidos, Email) VALUES (@Nombre, @Apellidos, @Email)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Nombre", nombre);
                    command.Parameters.AddWithValue("@Apellidos", apellidos);
                    command.Parameters.AddWithValue("@Email", email);

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        return true; // Registro exitoso
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Error al registrar el usuario: " + ex.Message);
                    }
                }
            }
        }

        // Método para registrar un cliente
        internal bool RegistrarCliente(string nombre, string apellidos, string email, string contraseña, string telefono, string direccion)
        {
            // Validar los campos
            if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(apellidos) || 
                string.IsNullOrEmpty(email) || string.IsNullOrEmpty(contraseña))
            {
                throw new ArgumentException("Los campos obligatorios no pueden estar vacíos.");
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Usuarios (Nombre, Apellidos, Email, Contraseña, Telefono, Direccion) VALUES (@Nombre, @Apellidos, @Email, @Contraseña, @Telefono, @Direccion)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Nombre", nombre);
                    command.Parameters.AddWithValue("@Apellidos", apellidos);
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@Contraseña", contraseña);
                    command.Parameters.AddWithValue("@Telefono", telefono);
                    command.Parameters.AddWithValue("@Direccion", direccion);

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        return true; // Registro exitoso
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Error al registrar el cliente: " + ex.Message);
                    }
                }
            }
        }
    }
}
