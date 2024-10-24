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
        private Usuario usuarioActual;

        public Inicio()
        {
            InitializeComponent();
            usuarioActual = new Usuario();
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
            usuarioActual.contraseña = BoxPassword.Text;

        }

        private void Boton_Entrar_Click(object sender, EventArgs e)
        {
            try
            {
                int idUsuario;
                if (!int.TryParse(Box_UserId.Text, out idUsuario))
                {
                    MessageBox.Show("El ID de usuario no puede estar vacio.");
                    return;
                }

                string contraseña = BoxPassword.Text;

                if (string.IsNullOrEmpty(contraseña))
                {
                    MessageBox.Show("Por favor, introduce una contraseña.");
                    return;
                }

                if (string.IsNullOrEmpty(contraseña))
                {
                    MessageBox.Show("Por favor, introduce una contraseña.");
                    return;
                }
                if (usuarioActual != null)
                {
                    MessageBox.Show("Inicio de sesión exitoso. Bienvenido " + usuarioActual.nombre);
                    // Aquí puedes redirigir a otra ventana o realizar otras acciones
                }
                else
                {
                    MessageBox.Show("El ID de usuario o la contraseña son incorrectos.");
                }

            }


            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error: " + ex.Message);
            }

        }

        private void Box_UserId_TextChanged(object sender, EventArgs e)
        {

            int id;

            if (int.TryParse(Box_UserId.Text, out id))
            {
                usuarioActual.idUsuario = id;
            }
            else
            {
                MessageBox.Show("Por favor, ingresa un ID de usuario válido.");
            }
        }
    }
}
