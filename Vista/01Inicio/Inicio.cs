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
                e.Handled = true;
            }
        }


        private void Inicio_Load(object sender, EventArgs e)
        {
            ControladorInicioSesion.VerificarYProcesarDatos();
            // No eliminar este método, no sé por qué pero da errores si se elimina!
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
            else if (mensaje == "La contraseña es incorrecta. Por favor, inténtalo de nuevo.")
            {
                MessageBox.Show(mensaje, "Error de autenticación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                BoxPassword.Focus();
                BoxPassword.SelectAll();
            }
            else if (mensaje.StartsWith("Inicio de sesión correcto"))
            {
                MessageBox.Show(mensaje);

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
                    case "AgregarActividad":
                        AgregarActividades agregarActividadesForm = new AgregarActividades(usuarioActual.rol);
                        agregarActividadesForm.Show();
                        this.Hide();
                        break;
                    default:
                        MessageBox.Show($"Rol no reconocido: {usuarioActual.rol}");
                        break;
                }

            }
            else
            {
                MessageBox.Show(mensaje, "Error de inicio de sesión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void linkContraseñaOlvidada_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string email = Box_UserId.Text.Trim();

            if (!string.IsNullOrEmpty(email))
            {
                Usuario usuario = controladorInicioSesion.ContraseñaOlvidada(email);

                if (usuario != null)
                {
                    MessageBox.Show($"Se ha enviado un correo electrónico a {usuario.email} con instrucciones para recuperar su contraseña.");
                }
                else
                {
                    MessageBox.Show("El correo electrónico no se encuentra en el sistema.");
                }
            }
            else
            {
                MessageBox.Show("Por favor, introduce un correo electrónico válido.");
            }
        }


    }
}
