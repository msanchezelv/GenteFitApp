using GenteFitApp.Vista._02Clientes;
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
    public partial class PrincipalRecepcionista : Form
    {
        private string usuarioRol;

        public PrincipalRecepcionista()
        {
            InitializeComponent();
            usuarioRol = "Recepcionista"; // Asignar el rol del usuario
        }

        private void Boton_Abrir_Gestion_Actividades_Click_1(object sender, EventArgs e)
        {
            AgregarActividades agregarActividadesForm = new AgregarActividades(usuarioRol);
            agregarActividadesForm.Show();
            this.Hide(); // Oculta la ventana actual (opcional)
        }

        private void Boton_Abrir_Gestion_Clientes_Click_1(object sender, EventArgs e)
        {
            // Abre el formulario PerfilCliente
            PerfilCliente perfilClienteForm = new PerfilCliente();
            perfilClienteForm.Show();
            this.Hide(); // Oculta la ventana actual (opcional)
        }
    }

}
