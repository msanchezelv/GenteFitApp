using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Xml.Linq;
using System.Reflection;

namespace GenteFit.Controlador.XML
{
    using GenteFitApp.Modelo;
    public class XMLManager
    {
        private string connectionString;

        public XMLManager(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        // Método genérico para exportar cualquier tipo de entidad a XML
        public void ExportToXML<T>(List<T> items, string rootElementName, string fileName) where T : class
        {
            if (items == null || items.Count == 0)
            {
                Console.WriteLine("No se encontraron elementos para exportar.");
                return;
            }

            // Crear el archivo XML
            XDocument xmlDoc = new XDocument(new XElement(rootElementName));

            foreach (var item in items)
            {
                XElement itemElement = new XElement(typeof(T).Name);

                foreach (var property in typeof(T).GetProperties())
                {
                    itemElement.Add(new XElement(property.Name, property.GetValue(item) ?? string.Empty));
                }

                xmlDoc.Root.Add(itemElement);
            }
                        
            string outputPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);

            try
            {
                xmlDoc.Save(outputPath);
                Console.WriteLine($"Archivo {fileName} generado en {outputPath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al guardar el archivo XML: {ex.Message}");
            }
        }


        // Método para obtener usuarios de la Base de Datos
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
                            idUsuario = reader.GetInt32(0),
                            nombre = reader.GetString(1),
                            apellido = reader.GetString(2),
                            email = reader.GetString(3),
                            rol = reader.GetString(4)
                        };
                        usuarios.Add(usuario);
                    }
                }
            }

            return usuarios;
        }

        // Método para obtener clientes de la BBDD
        public List<Cliente> GetClientesFromDatabase()
        {
            List<Cliente> clientes = new List<Cliente>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = @"SELECT idCliente, telefono, direccion, idUsuario FROM Cliente";

                using (SqlCommand command = new SqlCommand(query, connection))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Cliente cliente = new Cliente
                        {
                            idCliente = reader.GetInt32(0),
                            telefono = reader.IsDBNull(1) ? null : reader.GetString(1),
                            direccion = reader.IsDBNull(2) ? null : reader.GetString(2),
                            idUsuario = reader.IsDBNull(3) ? (int?)null : reader.GetInt32(3)
                        };

                        clientes.Add(cliente);
                    }
                }
            }

            return clientes;
        }

        // Método para obtener actividades de la BBDD
        public List<Actividad> GetActividadesFromDatabase()
        {
            List<Actividad> actividades = new List<Actividad>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = @"SELECT idActividad, nombre, descripcion, nivelIntensidad, sala, plazasDisponibles, idMonitor FROM Actividad";

                using (SqlCommand command = new SqlCommand(query, connection))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Actividad actividad = new Actividad
                        {
                            idActividad = reader.GetInt32(0),
                            nombre = reader.IsDBNull(1) ? null : reader.GetString(1),
                            descripcion = reader.IsDBNull(2) ? null : reader.GetString(2),
                            nivelIntensidad = reader.IsDBNull(3) ? null : reader.GetString(3),
                            sala = reader.IsDBNull(4) ? (int?)null : reader.GetInt32(4),
                            plazasDisponibles = reader.IsDBNull(5) ? (int?)null : reader.GetInt32(5),
                            idMonitor = reader.IsDBNull(6) ? (int?)null : reader.GetInt32(6)
                        };

                        actividades.Add(actividad);
                    }
                }
            }

            return actividades;
        }

        // Método para obtener horarios de la BBDD
        public List<Horario> GetHorariosFromDatabase()
        {
            List<Horario> horarios = new List<Horario>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = @"SELECT idHorario, diaSemana, horaInicio, horaFin, idActividad FROM Horario";

                using (SqlCommand command = new SqlCommand(query, connection))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Horario horario = new Horario
                        {
                            idHorario = reader.GetInt32(0),
                            diaSemana = reader.IsDBNull(1) ? null : reader.GetString(1),
                            horaInicio = reader.GetTimeSpan(2),
                            horaFin = reader.GetTimeSpan(3),
                            idActividad = reader.IsDBNull(4) ? (int?)null : reader.GetInt32(4)
                        };

                        horarios.Add(horario);
                    }
                }
            }

            return horarios;
        }

        // Método para obtener ListaEspera de la BBDD
        public List<ListaEspera> GetListaEsperaFromDatabase()
        {
            List<ListaEspera> listaEspera = new List<ListaEspera>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = @"SELECT idListaEspera, idActividad, idHorario, idCliente, posicion FROM ListaEspera";

                using (SqlCommand command = new SqlCommand(query, connection))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ListaEspera item = new ListaEspera
                        {
                            idListaEspera = reader.GetInt32(0),
                            idActividad = reader.IsDBNull(1) ? (int?)null : reader.GetInt32(1),
                            idHorario = reader.IsDBNull(2) ? (int?)null : reader.GetInt32(2),
                            idCliente = reader.IsDBNull(3) ? (int?)null : reader.GetInt32(3),
                            posicion = reader.IsDBNull(4) ? (int?)null : reader.GetInt32(4)
                        };

                        listaEspera.Add(item);
                    }
                }
            }

            return listaEspera;
        }

        // Método para obtener monitores de la BBDD
        public List<Monitor> GetMonitoresFromDatabase()
        {
            List<Monitor> monitores = new List<Monitor>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT idMonitor, nombre, apellido, idActividad FROM Monitor";

                using (SqlCommand command = new SqlCommand(query, connection))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Monitor monitor = new Monitor
                        {
                            idMonitor = reader.GetInt32(0),
                            nombre = reader.GetString(1),
                            apellido = reader.GetString(2),
                            idActividad = reader.IsDBNull(3) ? (int?)null : reader.GetInt32(3) // Manejo de nullable
                        };
                        monitores.Add(monitor);
                    }
                }
            }

            return monitores;
        }

        // Método para obtener reservas de la BBDD
        public List<Reserva> GetReservasFromDatabase()
        {
            List<Reserva> reservas = new List<Reserva>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT idReserva, idCliente, idHorario FROM Reserva";

                using (SqlCommand command = new SqlCommand(query, connection))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Reserva reserva = new Reserva
                        {
                            idReserva = reader.GetInt32(0),
                            idCliente = reader.IsDBNull(1) ? (int?)null : reader.GetInt32(1), // Manejo de nullable
                            idHorario = reader.IsDBNull(2) ? (int?)null : reader.GetInt32(2)  // Manejo de nullable
                        };
                        reservas.Add(reserva);
                    }
                }
            }

            return reservas;
        }


    }
}
