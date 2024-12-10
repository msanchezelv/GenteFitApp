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

        private void botonSala_Click(object sender, EventArgs e)
        {
            EjecutarScriptPython("sala_import.py");
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

            if (string.IsNullOrEmpty(pythonExePath))
            {
                MessageBox.Show("No se encontró Python instalado en el sistema.");
                return;
            }

            try
            {
                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    FileName = pythonExePath,
                    Arguments = $"\"{fullScriptPath}\"",
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };

                using (Process process = Process.Start(startInfo))
                {
                    string output = process.StandardOutput.ReadToEnd();
                    string errors = process.StandardError.ReadToEnd();
                    process.WaitForExit();

                    Console.WriteLine(output);

                    if (!string.IsNullOrEmpty(errors))
                    {
                        Console.WriteLine(errors);
                    }
                    else
                    {
                        Console.WriteLine($"{scriptName} se ejecutó correctamente.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error general al ejecutar {scriptName}: {ex.Message}");
            }
        }


        // Método para encontrar el path del ejecutable de python
        string GetPythonPath()
        {
            string pythonPath = null;
            try
            {
                // Usa "where python" para localizar Python automáticamente
                var process = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = "where",
                        Arguments = "python",
                        RedirectStandardOutput = true,
                        UseShellExecute = false,
                        CreateNoWindow = true
                    }
                };
                process.Start();
                pythonPath = process.StandardOutput.ReadLine(); // Obtiene la primera línea (mejor instalación)
                process.WaitForExit();

                if (string.IsNullOrEmpty(pythonPath))
                {
                    Console.WriteLine("No se encontró una instalación válida de Python.");
                }
                else
                {
                    Console.WriteLine($"Ruta de Python detectada: {pythonPath}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error detectando Python: {ex.Message}");
            }
            return pythonPath;
        }

        
    }
}
