using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;
using GenteFitApp.Modelo;

namespace GenteFit.Controlador.XMLManager
{
    public class XMLManager
    {
        private DatabaseManager<Usuario> dbManagerUsuario;
        private DatabaseManager<Cliente> dbManagerCliente;
        private DatabaseManager<Actividad> dbManagerActividad;
        private DatabaseManager<Horario> dbManagerHorario;
        private DatabaseManager<ListaEspera> dbManagerListaEspera;
        private DatabaseManager<Monitor> dbManagerMonitor;
        private DatabaseManager<Reserva> dbManagerReserva;

        public XMLManager(string dbConnectionString)
        {
            dbManagerUsuario = new DatabaseManager<Usuario>(dbConnectionString);
            dbManagerCliente = new DatabaseManager<Cliente>(dbConnectionString);
            dbManagerActividad = new DatabaseManager<Actividad>(dbConnectionString);
            dbManagerHorario = new DatabaseManager<Horario>(dbConnectionString);
            dbManagerListaEspera = new DatabaseManager<ListaEspera>(dbConnectionString);
            dbManagerMonitor = new DatabaseManager<Monitor>(dbConnectionString);
            dbManagerReserva = new DatabaseManager<Reserva>(dbConnectionString);
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
                    // Ignorar propiedades que no sean valores simples
                    if (property.PropertyType.IsPrimitive ||
                        property.PropertyType == typeof(string) ||
                        property.PropertyType == typeof(decimal) ||
                        property.PropertyType == typeof(DateTime) ||
                        property.PropertyType.IsValueType)
                    {
                        try
                        {
                            itemElement.Add(new XElement(property.Name, property.GetValue(item) ?? string.Empty));
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error al intentar acceder a la propiedad {property.Name}: {ex.Message}");
                        }
                    }
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


        // Métodos para obtener datos de la base de datos utilizando DatabaseManager
        public void ExportarTabla<T>(string nombreTabla, List<T> datos, string fileName) where T : class
        {
            if (datos != null && datos.Count > 0)
            {
                ExportToXML(datos, nombreTabla, fileName);
                Console.WriteLine($"Tabla '{nombreTabla}' exportada correctamente a {fileName}.");
            }
            else
            {
                Console.WriteLine($"No se encontraron datos para la tabla '{nombreTabla}'.");
            }
        }

        public void ExportarTodasLasTablas()
        {
            Console.WriteLine("Iniciando la exportación de todas las tablas...");

            ExportarTabla("Usuarios", GetUsuariosFromDatabase(), "usuarios.xml");
            ExportarTabla("Clientes", GetClientesFromDatabase(), "clientes.xml");
            ExportarTabla("Actividades", GetActividadesFromDatabase(), "actividades.xml");
            ExportarTabla("Horarios", GetHorariosFromDatabase(), "horarios.xml");
            ExportarTabla("ListaEspera", GetListaEsperaFromDatabase(), "lista_espera.xml");
            ExportarTabla("Monitores", GetMonitoresFromDatabase(), "monitores.xml");
            ExportarTabla("Reservas", GetReservasFromDatabase(), "reservas.xml");

            Console.WriteLine("Exportación de todas las tablas completada.");
        }

        
        public List<Usuario> GetUsuariosFromDatabase() => dbManagerUsuario.GetAll();
        public List<Cliente> GetClientesFromDatabase() => dbManagerCliente.GetAll();
        public List<Actividad> GetActividadesFromDatabase() => dbManagerActividad.GetAll();
        public List<Horario> GetHorariosFromDatabase() => dbManagerHorario.GetAll();
        public List<ListaEspera> GetListaEsperaFromDatabase() => dbManagerListaEspera.GetAll();
        public List<Monitor> GetMonitoresFromDatabase() => dbManagerMonitor.GetAll();
        public List<Reserva> GetReservasFromDatabase() => dbManagerReserva.GetAll();
    }
}

