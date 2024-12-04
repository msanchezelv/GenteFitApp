using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using GenteFitApp.Vista;
using GenteFit.Controlador;
using GenteFit.Controlador.XMLManager;
using GenteFitApp.Modelo;
using System.IO;
using GenteFitApp.Controlador;

namespace GenteFitApp
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Inicio());

            var streamWriter = new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = true };
            Console.SetOut(streamWriter);

            // Des-comentar esto si se quiere hacer el XML desde el programa, si no se hará solo con Encargado y con Admin desde la interfaz!
            //string dbConnectionString = DatabaseConfig.ConnectionString;
            //XMLManager xmlManager = new XMLManager(dbConnectionString);

            //// Exportar todas las tablas
            //ExportarTodasLasTablas(xmlManager);
        }             

    }
}
