using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GenteFitApp.Controlador.XML { 
        public class XMLManager
        {
                private string connectionString;
                private string xmlDirectoryPath;

                public XMLManager(string connectionString, string xmlDirectoryPath)
                {
                    this.connectionString = connectionString;
                    this.xmlDirectoryPath = xmlDirectoryPath;
                }

                // Método para generar XML de Usuarios
                public void GenerarXMLUsuarios()
                {
                    string query = "SELECT * FROM Usuario";
                    XElement usuariosXml = new XElement("Usuarios");

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        SqlCommand command = new SqlCommand(query, connection);
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            XElement usuario = new XElement("Usuario",
                                new XElement("idUsuario", reader["idUsuario"]),
                                new XElement("nombre", reader["nombre"]),
                                new XElement("apellido", reader["apellido"]),
                                new XElement("email", reader["email"]),
                                new XElement("contraseña", reader["contraseña"]),
                                new XElement("rol", reader["rol"])
                            );
                            usuariosXml.Add(usuario);
                        }
                    }

                    usuariosXml.Save(Path.Combine(xmlDirectoryPath, "Usuarios.xml"));
                }

                // Otros métodos para generar XML de Actividades, Reservas, Horarios, etc.
            
        }
}


