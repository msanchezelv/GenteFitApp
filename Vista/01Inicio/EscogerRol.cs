using GenteFitApp.Controlador;
using System;
using System.Windows.Forms;

namespace GenteFitApp.Vista._01Inicio
{
    public partial class EscogerRol : Form
    {
        private string nombre;
        private string apellidos;
        private string email;
        private string contraseña;

        public EscogerRol(string nombre, string apellidos, string email, string contraseña)
        {
            InitializeComponent();
            this.nombre = nombre;
            this.apellidos = apellidos;
            this.email = email;
            this.contraseña = contraseña;
        }

        private void Boton_Administrador_Click(object sender, EventArgs e)
        {
            RegistrarYRedirigir("Administrador");
        }

        private void boton_Cliente_Click(object sender, EventArgs e)
        {
            RegistrarYRedirigir("Cliente");
        }

        private void Boton_Encargado_Click(object sender, EventArgs e)
        {
            RegistrarYRedirigir("Encargado");
        }

        private void Boton_Recepcionista_Click(object sender, EventArgs e)
        {
            RegistrarYRedirigir("Recepcionista");
        }


        private void RegistrarYRedirigir(string rol)
        {
            if (string.IsNullOrEmpty(rol))
            {
                MessageBox.Show("Por favor, seleccione un rol.");
                return;
            }

            ControladorRegistro controlador = new ControladorRegistro();
            Form formulario;

            int idUsuario = controlador.RegistrarUsuario(nombre, apellidos, email, contraseña, rol);

            if (idUsuario > 0)
            {
                MessageBox.Show("Usuario registrado con éxito.");

                if (rol == "Cliente")
                {
                    formulario = new RegistrarCliente();
                    (formulario as RegistrarCliente).SetIdUsuario(idUsuario);
                }
                else if (rol == "Administrador")
                {
                    formulario = new PrincipalAdmin();
                }
                else if (rol == "Encargado")
                {
                    formulario = new PrincipalEncargado();
                }
                else
                {
                    formulario = new PrincipalRecepcionista();
                }

                this.Close();
                
                formulario.Show();
                
            }
            else
            {
                MessageBox.Show("Error al registrar el usuario.");
            }
        }


    }


}
