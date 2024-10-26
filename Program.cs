using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using GenteFitApp.Vista;

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
<<<<<<< Updated upstream
=======
            var streamWriter = new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = true };
            Console.SetOut(streamWriter);

            string dbConnectionString = "Data Source=DESKTOP-6VP8HCF;Initial Catalog=GenteFit;Integrated Security=True";
            XMLManager xmlManager = new XMLManager(dbConnectionString);

            List<Usuario> usuarios = xmlManager.GetUsuariosFromDatabase();
            
            if (usuarios == null || usuarios.Count == 0)
            {
                MessageBox.Show("No se encontraron usuarios para exportar.");
                return;
            }

            
            xmlManager.ExportToXML(usuarios, "Usuarios", "usuarios.xml");
>>>>>>> Stashed changes
        }
    }
}
