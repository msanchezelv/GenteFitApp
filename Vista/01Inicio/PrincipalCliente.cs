using GenteFitApp.Vista._02Clientes;
using GenteFitApp.Vista._06Horarios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GenteFitApp.Controlador;
using GenteFitApp.Vista._04Reservas;
using GenteFitApp.Vista._05ListaEspera;


namespace GenteFitApp.Vista
{
    public partial class PrincipalCliente : FormularioBase
    {
        public int IdCliente = ControladorInicioSesion.IdClienteActual;

        public PrincipalCliente()
        {
            InitializeComponent();
        }

        private void Boton_Abrir_Horarios_Click(object sender, EventArgs e)
        {
            FormHorarios formHorarios = new FormHorarios();
            formHorarios.ShowDialog();
            // this.Close();
        }

        private void perfilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PerfilCliente perfilCliente = new PerfilCliente();
            perfilCliente.ShowDialog();
            // this.Close();
        }

        private void Boton_AbrirReservas_Click(object sender, EventArgs e)
        {
            VerReservas misReservas = new VerReservas();
            misReservas.ShowDialog();
        }

        private void Boton_AbrirPerfil_Click(object sender, EventArgs e)
        {
            PerfilCliente perfilCliente = new PerfilCliente();
            perfilCliente.ShowDialog();
            // this.Close();
        }

        private void consultarListaDeEsperaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListaEspera listaEspera = new ListaEspera();
            listaEspera.ShowDialog();
        }

        private void verMisReservasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VerReservas misReservas = new VerReservas();
            misReservas.ShowDialog();
        }
    }
}
