using GenteFitApp.Vista._01Inicio;
using GenteFitApp.Vista._04Reservas;
using GenteFitApp.Vista._05ListaEspera;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GenteFitApp.Vista
{
    public partial class PrincipalEncargado : FormularioBase
    {
        public PrincipalEncargado()
        {
            InitializeComponent();
        }

        private void Boton_Abrir_Gestion_Actividades_Click(object sender, EventArgs e)
        {
            string usuarioRol = "Encargado";
            AgregarActividades agregarActividades = new AgregarActividades(usuarioRol);
            agregarActividades.ShowDialog();
        }

        private void Boton_Abrir_Gestion_Reservas_Click(object sender, EventArgs e)
        {
            VerReservas verReservas = new VerReservas();
            verReservas.ShowDialog();
        }

        private void consultarReservasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VerReservas verReservas = new VerReservas();
            verReservas.ShowDialog();
        }

        private void consultarListaDeEsperaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListaEspera lista = new ListaEspera();
            lista.ShowDialog();
        }

        private void actividadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string usuarioRol = "Encargado";
            AgregarActividades agregarActividades = new AgregarActividades(usuarioRol);
            agregarActividades.ShowDialog();
        }

        private void Boton_Abrir_Gestion_Monitores_Click(object sender, EventArgs e)
        {
            RegistrarMonitor registrarMonitor = new RegistrarMonitor();
            registrarMonitor.ShowDialog();
        }

        private void monitoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegistrarMonitor registrarMonitor = new RegistrarMonitor();
            registrarMonitor.ShowDialog();
        }
    }
}
