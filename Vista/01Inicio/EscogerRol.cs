using GenteFitApp.Controlador;
using System;
using System.Windows.Forms;

namespace GenteFitApp.Vista._01Inicio
{
    public partial class EscogerRol : Form
    {
        /*
        private string nombre;
        private string apellidos;
        private string email;
        private string contraseña;
        */ //Marina
        public EscogerRol()
        {
            InitializeComponent();
            this.FormClosing += new FormClosingEventHandler(EscogerRol_FormClosing);
        }

        private void EscogerRol_FormClosing(object sender, FormClosingEventArgs e) 
        { PrincipalAdmin principalAdminForm = new PrincipalAdmin(); 
            principalAdminForm.Show(); 
        }

        public EscogerRol(string nombre, string apellidos, string email, string contraseña)
        {
            InitializeComponent();
            /*
            this.nombre = nombre;
            this.apellidos = apellidos;
            this.email = email;
            this.contraseña = contraseña;
            */ //Marina
        }

        private void Boton_Administrador_Click(object sender, EventArgs e)
        {
            AbrirRegistrar("Administrador");
            //RegistrarYRedirigir("Administrador"); //Marina
        }

        private void boton_Cliente_Click(object sender, EventArgs e)
        {
            AbrirRegistrar("Cliente");
            //RegistrarYRedirigir("Cliente"); //Marina
        }

        private void Boton_Encargado_Click(object sender, EventArgs e)
        {
            AbrirRegistrar("Encargado");
            //RegistrarYRedirigir("Encargado"); //Marina
        }

        private void Boton_Recepcionista_Click(object sender, EventArgs e)
        {
            AbrirRegistrar("Recepcionisa");
            //RegistrarYRedirigir("Recepcionista"); //Marina
        }

        private void AbrirRegistrar(string rol) 
        { Registrar registrarForm = new Registrar(rol); 
            registrarForm.Show(); this.Hide(); 
        }
    }
}
