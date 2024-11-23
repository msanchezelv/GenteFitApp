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

        private void Boton_Abrir_Gestion_Clientes_Click(object sender, EventArgs e)
        {

        }

        private void Boton_Abrir_Gestion_Reservas_Click(object sender, EventArgs e)
        {

        }

        private void Boton_Abrir_Gestion_Actividades_Click(object sender, EventArgs e)
        {
            // Código para abrir la ventana GestionActividades
            AgregarActividades gestionActividades = new AgregarActividades();
            gestionActividades.Show(); // Abre la nueva ventana
            this.Hide(); // Oculta la ventana actual (opcional)
        }

        private void Boton_Abrir_Gestion_Monitores_Click(object sender, EventArgs e)
        {

        }

        private void Boton_Abrir_Gestion_Usuarios_Click(object sender, EventArgs e)
        {

        }

        private void añadirClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
