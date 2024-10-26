using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenteFitApp.Controlador
{
    internal class ControladorRegistroCliente
    {
        internal string connectionString = "Data Source=DESKTOP-6VP8HCF;Initial Catalog=GenteFit;Integrated Security=True";

        // Método para registrar un cliente
        public bool RegistrarCliente(string nombre, string apellidos, string email, string contraseña, string direccion, string telefono)
        {
            string query = "INSERT INTO Cliente (nombre, apellido, email, contraseña, dirección, teléfono) VALUES (@IdUsuario, @Nombre, @Apellido, @Email, @Contraseña, @Direccion, @Telefono)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Nombre", nombre);
                    command.Parameters.AddWithValue("@Apellido", apellidos);
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@Contraseña", contraseña);
                    command.Parameters.AddWithValue("@Direccion", direccion);
                    command.Parameters.AddWithValue("@Telefono", telefono);
                    connection.Open();
                    try
                    {
                        command.ExecuteNonQuery();
                        return true;
                    }
                    catch (SqlException ex)
                    {
                        throw new Exception("Error al registrar el usuario: " + ex.Message);
                    }
                }
            }
        }

    }
}
