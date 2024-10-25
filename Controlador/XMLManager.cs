using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Xml.Linq;

namespace GenteFit.CONTROLADOR.XML
{
    public class XMLManager
    {
        private string connectionString;

        public XMLManager(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public void ExportUsuariosToXML(string outputPath)
        {
            List<Usuario> usuarios = GetUsuariosFromDatabase();

            if (usuarios.Count == 0)
            {
                Console.WriteLine("No se encontraron usuarios en la base de datos.");
                return;
            }

            // Crear el archivo XML
            XDocument xmlDoc = new XDocument(new XElement("Usuarios"));

            foreach (var usuario in usuarios)
            {
                XElement usuarioElement = new XElement("Usuario",
                    new XElement("ID", usuario.IdUsuario),
                    new XElement("Nombre", usuario.Nombre),
                    new XElement("Apellido", usuario.Apellido),
                    new XElement("Email", usuario.Email),
                    new XElement("Rol", usuario.Rol)
                );
                xmlDoc.Root.Add(usuarioElement);
            }

            // Guardar el archivo en la ruta especificada (sobrescribiendo si existe)
            try
            {
                xmlDoc.Save(outputPath);
                Console.WriteLine($"Archivo Usuarios.xml generado en {outputPath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al guardar el archivo XML: {ex.Message}");
            }
        }

        private List<Usuario> GetUsuariosFromDatabase()
        {
            List<Usuario> usuarios = new List<Usuario>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT idUsuario, nombre, apellido, email, rol FROM Usuario";

                using (SqlCommand command = new SqlCommand(query, connection))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Usuario usuario = new Usuario
                        {
                            IdUsuario = reader.GetInt32(0),
                            Nombre = reader.GetString(1),
                            Apellido = reader.GetString(2),
                            Email = reader.GetString(3),
                            Rol = reader.GetString(4)
                        };
                        usuarios.Add(usuario);
                    }
                }
            }

            return usuarios;
        }
    }

    // Clase Usuario para modelar los datos
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Rol { get; set; }
    }
}
