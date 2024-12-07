using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GenteFitApp.Vista._01Inicio
{
    public partial class ExportaraOdoo : Form
    {
        public ExportaraOdoo()
        {
            InitializeComponent();
        }

        private void Boton_Actividad_Click(object sender, EventArgs e)
        {
            EjecutarScriptPython("actividad_import.py");
        }

        private void boton_Cliente_Click(object sender, EventArgs e)
        {
            EjecutarScriptPython("cliente_import.py");
        }

        private void Boton_Horario_Click(object sender, EventArgs e)
        {
            EjecutarScriptPython("horario_import.py");
        }

        private void Boton_ListaEspera_Click(object sender, EventArgs e)
        {
            EjecutarScriptPython("listaEspera_import.py");
        }

        private void Boton_Monitor_Click(object sender, EventArgs e)
        {
            EjecutarScriptPython("monitor_import.py");
        }

        private void Boton_Reserva_Click(object sender, EventArgs e)
        {
            EjecutarScriptPython("reserva_import.py");

        }

        private void Boton_Usuario_Click(object sender, EventArgs e)
        {
            EjecutarScriptPython("usuario_import.py");
        }

        public void Boton_Todas_Click(object sender, EventArgs e)
        {
            EjecutarScriptPython("conexionOdoo.py");
        }

        // Método para ejecutar el script Python correspondiente
        private void EjecutarScriptPython(string scriptName)
        {
            string projectRoot = Path.GetFullPath(Path.Combine(Application.StartupPath, @"..\..\..\"));
            string scriptPath = Path.Combine(projectRoot, "GenteFitApp", "Controlador", "XML");
            string fullScriptPath = Path.Combine(scriptPath, scriptName);

            Console.WriteLine("Ruta del script: " + fullScriptPath);

            if (!File.Exists(fullScriptPath))
            {
                MessageBox.Show($"El script {scriptName} no se encuentra en la carpeta.");
                return;
            }

            string pythonExePath = GetPythonPath();

            try
            {
                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    FileName = pythonExePath,
                    Arguments = $"\"{scriptPath}\"",
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };

                using (Process process = Process.Start(startInfo))
                {
                    string output = process.StandardOutput.ReadToEnd();
                    process.WaitForExit();
                    MessageBox.Show($"{scriptName} se exportó correctamente a Odoo.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al ejecutar {scriptName}: " + ex.Message);
            }
        }

        // Método para encontrar el path del ejecutable de python
        public static string GetPythonPath()
        {
            string pythonPath = null;

            // Buscar en el registro de Windows la ubicación de Python
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\Python\PythonCore"))
            {
                if (key != null)
                {
                    // Obtenemos la versión de Python
                    string version = key.GetSubKeyNames()[0]; // Primera versión en el registro
                    using (RegistryKey pythonVersionKey = key.OpenSubKey(version + @"\InstallPath"))
                    {
                        if (pythonVersionKey != null)
                        {
                            pythonPath = pythonVersionKey.GetValue("").ToString();
                        }
                    }
                }
            }

            return pythonPath;
        }



    }
}
