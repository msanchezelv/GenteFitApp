using GenteFitApp.Controlador;
using GenteFitApp.Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GenteFitApp.Vista
{
    public partial class Inicio : Form
    {
        ControladorInicioSesion controladorInicioSesion = new ControladorInicioSesion();

        public Inicio()
        {
            InitializeComponent();
            BoxPassword.PasswordChar = '*';
            BoxPassword.KeyPress += new KeyPressEventHandler(BoxPassword_KeyPress);
        }

        private void BoxPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                // Simula el clic en el botón "Entrar"
                Boton_Entrar.PerformClick();
                e.Handled = true; // Previene el sonido de alerta al presionar Enter
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Inicio_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            

        }

        private void Boton_Entrar_Click(object sender, EventArgs e)
        {
            int userId;
            if (int.TryParse(Box_UserId.Text, out userId))
            {
                string password = BoxPassword.Text;

                string mensaje = controladorInicioSesion.ComprobarCredenciales(userId, password);

                if (mensaje == "Usuario no encontrado. ¿Registrar nuevo usuario? S/N")
                {
                    DialogResult result = MessageBox.Show("Usuario no encontrado. ¿Registrar nuevo usuario?", "Usuario no encontrado", MessageBoxButtons.YesNo);

                    if (result == DialogResult.Yes)
                    {
                        // Abrir la pantalla de registro
                        Registrar nuevoUsuarioForm = new Registrar();
                        nuevoUsuarioForm.Show();
                        this.Hide();
                    }
                }
                else
                {
                    MessageBox.Show(mensaje);
                }

                // Implementar el cambio de formulario según el rol del usuario si el inicio de sesión fue exitoso
                if (mensaje.StartsWith("Inicio de sesión exitoso"))
                {
                    // Extraer el rol del usuario desde el mensaje o hacer una nueva consulta si es necesario
                    Usuario usuarioActual = controladorInicioSesion.ObtenerUsuario(userId, password);

                    switch (usuarioActual.rol)
                    {
                        case "Administrador":
                            PrincipalAdmin adminForm = new PrincipalAdmin();
                            adminForm.Show();
                            this.Hide();
                            break;
                        case "Cliente":
                            PrincipalCliente clienteForm = new PrincipalCliente();
                            clienteForm.Show();
                            this.Hide();
                            break;
                        case "Encargado":
                            PrincipalEncargado encargadoForm = new PrincipalEncargado();
                            encargadoForm.Show();
                            this.Hide();
                            break;
                        case "Recepcionista":
                            PrincipalRecepcionista recepcionistaForm = new PrincipalRecepcionista();
                            recepcionistaForm.Show();
                            this.Hide();
                            break;
                        default:
                            MessageBox.Show("Rol de usuario no reconocido.");
                            break;
                    }
                }
            }
            else
            {
                MessageBox.Show("El ID de usuario debe ser un número.");
            }

        }


        private void Box_UserId_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
