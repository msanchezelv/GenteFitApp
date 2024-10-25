using System;
using System.Windows.Forms;
using GenteFitApp.controlador;
using GenteFitApp.Modelo;
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

        private void Boton_Entrar_Click(object sender, EventArgs e)
        {
            string nombre = textBoxNombre.Text;
            string apellidos = textBoxApellidos.Text;
            string email = textBoxemail.Text;
            string contraseña = textBoxcontraseña.Text;
            string rol = "Cliente";


            try
            {
                // Registrar el usuario y obtener el ID generado
                bool registrado = controladorRegistro.RegistrarUsuario(nombre, apellidos, email, contraseña, rol);

                if (registrado)
                {
                    MessageBox.Show("Usuario registrado con éxito.");
                    this.Close(); // Cerrar el formulario después de registrar
                }
                else
                {
                    MessageBox.Show("Error al registrar el usuario. Por favor, inténtelo de nuevo.");
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


        private void comboBoxRolEmpleado_SelectedIndexChanged(object sender, EventArgs e)
        {
            string nombre = textBoxNombre.Text;
            string apellidos = textBoxApellidos.Text;
            string email = textBoxemail.Text;
            string contraseña = textBoxcontraseña.Text;

            // Obtener el rol seleccionado del ComboBox
            string rol = comboBoxRolEmpleado.SelectedItem.ToString();

            try
            {
                // Registrar el usuario y obtener el ID generado
                bool registrado = controladorRegistro.RegistrarUsuario(nombre, apellidos, email, contraseña, rol);

                if (registrado)
                {
                    MessageBox.Show("Usuario registrado con éxito.");
                    this.Close(); // Cerrar el formulario después de registrar
                }
                else
                {
                    MessageBox.Show("Error al registrar el usuario. Por favor, inténtelo de nuevo.");
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
