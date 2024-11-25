using GenteFitApp.Vista._01Inicio;
using GenteFitApp.Vista._04Reservas;
using GenteFitApp.Vista._05ListaEspera;
using GenteFitApp.Vista._06Usuario;
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

        }

        private void Boton_Abrir_Gestion_Usuarios_Click(object sender, EventArgs e)
        {
            EscogerUsuario escogerUsuario = new EscogerUsuario();
            escogerUsuario.ShowDialog();
        }


        private void añadirClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Registrar registrar = new Registrar();
            registrar.ShowDialog();

        }

        private void editarClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void eliminarClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void consultarClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {

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

        }
    }
}
