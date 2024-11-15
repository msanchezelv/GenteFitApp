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
    public partial class Inicio : FormularioBase
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
            string email = Box_UserId.Text;
            string password = BoxPassword.Text;

            if (string.IsNullOrWhiteSpace(email) || !email.Contains("@"))
            {
                MessageBox.Show("Por favor, ingrese un correo electrónico válido.");
                return;
            }

            string mensaje = controladorInicioSesion.ComprobarCredencialesPorEmail(email, password);

            if (mensaje == "Usuario no encontrado. ¿Registrar nuevo usuario? S/N")
            {
                DialogResult result = MessageBox.Show("Usuario no encontrado. ¿Registrar nuevo usuario?", "Usuario no encontrado", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    Registrar nuevoUsuarioForm = new Registrar();
                    nuevoUsuarioForm.Show();
                    this.Hide();
                }
            }
            else
            {
                MessageBox.Show(mensaje);
            }

            if (mensaje.StartsWith("Inicio de sesión correcto"))
            {
                Usuario usuarioActual = controladorInicioSesion.ObtenerUsuarioPorEmail(email, password);

                switch (usuarioActual.rol)
                {
                    case "Administrador":
                        PrincipalAdmin adminForm = new PrincipalAdmin();
                        adminForm.Show();
                        this.Hide();
                        break;
                    case "Cliente":
                        int idCliente = controladorInicioSesion.ObtenerIdClientePorIdUsuario(usuarioActual.idUsuario);
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
                        MessageBox.Show($"Rol no reconocido: {usuarioActual.rol}");
                        break;
                }
            }
        }



        private void Box_UserId_TextChanged(object sender, EventArgs e)
        {

        }

        private void linkContraseñaOlvidada_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int userId;

            if (int.TryParse(Box_UserId.Text, out userId))
            {
                // Obtener el usuario solo por el idUsuario
                Usuario usuario = controladorInicioSesion.ObtenerUsuarioPorId(userId);

                if (usuario != null)
                {
                    MessageBox.Show($"Se ha enviado un correo electrónico a {usuario.email} con instrucciones para recuperar su contraseña.");
                }
                else
                {
                    MessageBox.Show("El ID de usuario no se encuentra en el sistema.");
                }
            }
            else
            {
                MessageBox.Show("Por favor, introduce un ID de usuario válido.");
            }
        }

    }
}
