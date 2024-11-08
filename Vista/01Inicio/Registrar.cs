using GenteFitApp.controlador;
using GenteFitApp.Vista._01Inicio;
using System;

namespace GenteFitApp.Vista
{
    public partial class Registrar : FormularioBase
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
            textBoxNombre.Focus();
        }

        private void Boton_nuevoEmpleado_Click(object sender, EventArgs e)
        {
            string nombre = textBoxNombre.Text;
            string apellidos = textBoxApellidos.Text;
            string email = textBoxemail.Text;
            string contraseña = textBoxcontraseña.Text;


            EscogerRol escogerRolForm = new EscogerRol(nombre, apellidos, email, contraseña);
            escogerRolForm.Show();
            this.Close();
        }

    }
}
