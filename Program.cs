using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using GenteFitApp.Vista;
using GenteFit.Controlador;
using GenteFit.Controlador.XML;
using GenteFitApp.Modelo;
using System.IO;

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

            string dbConnectionString = "Data Source=DESKTOP-1JIM32R\\SQLEXPRESS;Initial Catalog=GenteFit;Integrated Security=True";
            XMLManager xmlManager = new XMLManager(dbConnectionString);

            List<Usuario> usuarios = xmlManager.GetUsuariosFromDatabase();
            
            if (usuarios == null || usuarios.Count == 0)
            {
                MessageBox.Show("No se encontraron usuarios para exportar.");
                return;
            }

            
            xmlManager.ExportToXML(usuarios, "Usuarios", "usuarios.xml");
        }

    }
}
