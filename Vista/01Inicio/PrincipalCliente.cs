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

namespace GenteFitApp.Vista
{
    public partial class PrincipalCliente : Form
    {
        public int IdCliente { get; set; }

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
    }
}
