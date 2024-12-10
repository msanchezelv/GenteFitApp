using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GenteFit.Controlador.XMLManager;
using GenteFitApp.Controlador;
using GenteFitApp.Modelo;


namespace GenteFitApp.Vista._01Inicio
{
    public partial class TablasXML : Form
    {
        private XMLManager xmlManager;

        public TablasXML()
        {
            InitializeComponent();
            string dbConnectionString = DatabaseConfig.ConnectionString;
            xmlManager = new XMLManager(dbConnectionString);
        }

        private void Boton_Actividad_Click(object sender, EventArgs e)
        {
            var actividades = xmlManager.GetActividadesFromDatabase();
            xmlManager.ExportarTabla("Actividades", actividades, "actividades.xml");
            MessageBox.Show("Tabla 'Actividades' exportada a XML.");
        }

        private void boton_Cliente_Click(object sender, EventArgs e)
        {
            var clientes = xmlManager.GetClientesFromDatabase();
            xmlManager.ExportarTabla("Clientes", clientes, "clientes.xml");
            MessageBox.Show("Tabla 'Clientes' exportada a XML.");
        }

        private void Boton_Horario_Click(object sender, EventArgs e)
        {
            var horarios = xmlManager.GetHorariosFromDatabase();
            xmlManager.ExportarTabla("Horarios", horarios, "horarios.xml");
            MessageBox.Show("Tabla 'Horarios' exportada a XML.");
        }

        private void Boton_ListaEspera_Click(object sender, EventArgs e)
        {
            var listaEspera = xmlManager.GetListaEsperaFromDatabase();
            xmlManager.ExportarTabla("ListaEspera", listaEspera, "lista_espera.xml");
            MessageBox.Show("Tabla 'Lista de Espera' exportada a XML.");
        }

        private void Boton_Monitor_Click(object sender, EventArgs e)
        {
            var monitores = xmlManager.GetMonitoresFromDatabase();
            xmlManager.ExportarTabla("Monitores", monitores, "monitores.xml");
            MessageBox.Show("Tabla 'Monitores' exportada a XML.");
        }

        private void Boton_Reserva_Click(object sender, EventArgs e)
        {
            var reservas = xmlManager.GetReservasFromDatabase();
            xmlManager.ExportarTabla("Reservas", reservas, "reservas.xml");
            MessageBox.Show("Tabla 'Reservas' exportada a XML.");
        }

        private void Boton_Usuario_Click(object sender, EventArgs e)
        {
            var usuarios = xmlManager.GetUsuariosFromDatabase();
            xmlManager.ExportarTabla("Usuarios", usuarios, "usuarios.xml");
            MessageBox.Show("Tabla 'Usuarios' exportada a XML.");
        }

        private void Boton_Todas_Click(object sender, EventArgs e)
        {
            xmlManager.ExportarTodasLasTablas();
            MessageBox.Show("Todas las tablas han sido exportadas a XML.");
        }

        private void botonSala_Click(object sender, EventArgs e)
        {
            var salas = xmlManager. GetSalasFromDatabase();
            xmlManager.ExportarTabla("Salas", salas, "salas.xml");
            MessageBox.Show("Tabla 'Salas' exportada a XML.");
        }
    }
}
