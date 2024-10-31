using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;
using GenteFitApp.Modelo;

namespace GenteFit.Controlador.XML
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

        // Métodos para obtener datos de la base de datos utilizando DatabaseManager

        public List<Usuario> GetUsuariosFromDatabase()
        {
            return dbManagerUsuario.GetAll();
        }

        public List<Cliente> GetClientesFromDatabase()
        {
            return dbManagerCliente.GetAll();
        }

        public List<Actividad> GetActividadesFromDatabase()
        {
            return dbManagerActividad.GetAll();
        }

        public List<Horario> GetHorariosFromDatabase()
        {
            return dbManagerHorario.GetAll();
        }

        public List<ListaEspera> GetListaEsperaFromDatabase()
        {
            return dbManagerListaEspera.GetAll();
        }

        public List<Monitor> GetMonitoresFromDatabase()
        {
            return dbManagerMonitor.GetAll();
        }

        public List<Reserva> GetReservasFromDatabase()
        {
            return dbManagerReserva.GetAll();
        }
    }
}
