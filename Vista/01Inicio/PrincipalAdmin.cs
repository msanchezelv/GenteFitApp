using GenteFitApp.Vista._01Inicio;
using GenteFitApp.Vista._02Clientes;
using GenteFitApp.Vista._04Reservas;
using GenteFitApp.Vista._05ListaEspera;
using GenteFitApp.Vista._06Usuario;
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

namespace GenteFitApp.Vista
{
    public partial class PrincipalAdmin : FormularioBase
    {
        public PrincipalAdmin()
        {
            InitializeComponent();
        }

        private void Boton_Abrir_Gestion_Reservas_Click(object sender, EventArgs e)
        {
            VerReservas verReservas = new VerReservas();
            verReservas.ShowDialog();
        }

        private void Boton_Abrir_Gestion_Actividades_Click(object sender, EventArgs e)
        {
            string usuarioRol = "Administrador";            
            AgregarActividades gestionActividades = new AgregarActividades(usuarioRol);
            gestionActividades.Show(); // Abre la nueva ventana
            this.Hide(); // Oculta la ventana actual (opcional)
        }

        private void Boton_Abrir_Gestion_Monitores_Click(object sender, EventArgs e)
        {
            RegistrarMonitor registrarMonitor = new RegistrarMonitor();
            registrarMonitor.ShowDialog();
        }

        private void Boton_Abrir_Gestion_Usuarios_Click(object sender, EventArgs e)
        {
            EscogerUsuario escogerUsuario = new EscogerUsuario();
            escogerUsuario.ShowDialog();
        }
                

        private void consultarReservasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VerReservas verReservas = new VerReservas();
            verReservas.ShowDialog();

        }

        private void actividadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string usuarioRol = "Administrador";
            AgregarActividades gestionActividades = new AgregarActividades(usuarioRol);
            gestionActividades.Show(); // Abre la nueva ventana
            this.Hide(); // Oculta la ventana actual (opcional)
        }

        private void añadirUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Registrar registrar = new Registrar();
            registrar.ShowDialog();
        }

        private void consultarListaDeEsperaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListaEspera lista = new ListaEspera();
            lista.ShowDialog();
        }

       
        private void Boton_Abrir_Gestion_Clientes_Click(object sender, EventArgs e)
        {
            GestionCliente cliente = new GestionCliente();
            cliente.ShowDialog();
        }

        private void monitoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegistrarMonitor registrarMonitor = new RegistrarMonitor();
            registrarMonitor.ShowDialog();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GestionCliente cliente = new GestionCliente();
            cliente.ShowDialog();
        }

        private void Boton_Odoo_Click(object sender, EventArgs e)
        {
            ExportaraOdoo exportaraOdoo = new ExportaraOdoo();
            exportaraOdoo.ShowDialog();
        }

        private void buttonXML_Click(object sender, EventArgs e)
        {
            TablasXML tablasXML = new TablasXML();
            tablasXML.ShowDialog();
        }

        private void Boton_obtenerOdoo_Click(object sender, EventArgs e)
        {
            Task.Run(() => EjecutarScriptPython("odoo_sync.py"));
        }

        private async Task EjecutarScriptPython(string scriptName)
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
                    // Leer las salidas de manera asíncrona en tiempo real
                    Task outputTask = Task.Run(() =>
                    {
                        string outputLine;
                        while ((outputLine = process.StandardOutput.ReadLine()) != null)
                        {
                            Console.WriteLine("Salida estándar: " + outputLine);
                        }
                    });

                    Task errorTask = Task.Run(() =>
                    {
                        string errorLine;
                        while ((errorLine = process.StandardError.ReadLine()) != null)
                        {
                            Console.WriteLine("Errores: " + errorLine);
                        }
                    });

                    // Esperar a que el proceso termine
                    await Task.Run(() => process.WaitForExit());

                    // Esperar a que todas las tareas de lectura de salida se completen
                    await outputTask;
                    await errorTask;

                    Console.WriteLine($"{scriptName} se ejecutó correctamente.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error general al ejecutar {scriptName}: {ex.Message}");
                MessageBox.Show($"Error al ejecutar {scriptName}: {ex.Message}");
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
                pythonPath = process.StandardOutput.ReadLine();
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
