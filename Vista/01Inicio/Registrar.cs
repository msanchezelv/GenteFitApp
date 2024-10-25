using System;
using System.Windows.Forms;
using GenteFitApp.controlador;


namespace GenteFitApp.Vista
{
    public partial class Registrar : Form
    {
        private ControladorRegistro controladorRegistro;
        private bool esCliente = false;

        public Registrar()
        {
            InitializeComponent();
            controladorRegistro = new ControladorRegistro();
        }

        private void Boton_nuevoCliente_Click(object sender, EventArgs e)
        {
            esCliente = true;
            textBox2.Enabled = true;
            textBox1.Enabled = true;
        }

        private void Boton_Entrar_Click(object sender, EventArgs e)
        {
            // Obtener los valores de los TextBox
            string nombre = textBoxNombre.Text;
            string apellidos = textBoxApellidos.Text;
            string email = textBox3.Text;
            string contraseña = textBoxcontraseña.Text; // Solo se usa si es cliente
            string telefono = textBox2.Text; // Solo se usa si es cliente
            string direccion = textBox1.Text;


            try
            {
                bool registrado;

                if (esCliente)
                {
                    registrado = controladorRegistro.RegistrarCliente(nombre, apellidos, email, contraseña, telefono, direccion);
                }
                else
                {
                    registrado = controladorRegistro.RegistrarUsuario(nombre, apellidos, email);
                }

                if (registrado)
                {
                    MessageBox.Show("Usuario registrado con éxito.");
                }
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message); // Mensaje específico para errores de argumento
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado: " + ex.Message); // Mensaje genérico para otros errores
            }


        }
    }
}
