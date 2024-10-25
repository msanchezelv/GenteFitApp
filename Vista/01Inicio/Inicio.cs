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
                MessageBox.Show(mensaje); // Mostrar el mensaje devuelto por el controlador

                // Implementar el cambio de formulario según el rol del usuario si el inicio de sesión fue exitoso
                if (mensaje.StartsWith("Inicio de sesión exitoso"))
                {
                    // Lógica para cambiar de formulario según el rol del usuario
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
