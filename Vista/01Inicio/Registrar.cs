using System;
using System.Windows.Forms;
using GenteFitApp.controlador;
using GenteFitApp.Modelo;
using GenteFitApp.Vista._01Inicio;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GenteFitApp.Vista
{
    public partial class Registrar : Form
    {
        private ControladorRegistro controladorRegistro;
        

        public Registrar()
        {
            InitializeComponent();
            controladorRegistro = new ControladorRegistro();
            textBoxcontraseña.PasswordChar = '*';
            this.Load += Registrar_Load;

        }

        private void Registrar_Load(object sender, EventArgs e)
        {
            int proximoId = controladorRegistro.ObtenerProximoIdUsuario();
            textBoxUserId.Text = proximoId.ToString();
        }

        private void Boton_nuevoEmpleado_Click(object sender, EventArgs e)
        {
            string nombre = textBoxNombre.Text;
            string apellidos = textBoxApellidos.Text;
            string email = textBoxemail.Text;
            string contraseña = textBoxcontraseña.Text;

            
            EscogerRol escogerRolForm = new EscogerRol(nombre, apellidos, email, contraseña);
            escogerRolForm.Show();
            this.Close(); // Cerrar el formulario actual para que solo quede el formulario EscogerRol
        }

    }
}
