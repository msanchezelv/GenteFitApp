using GenteFitApp.controlador;
using System;
using System.Windows.Forms;

namespace GenteFitApp.Vista._01Inicio
{
    public partial class RegistrarCliente : Form
    {
        private int idUsuario;

        public RegistrarCliente()
        {
            InitializeComponent();
        }

        public void SetIdUsuario(int id)
        {
            idUsuario = id;
        }

        private void BotonRegistrarCliente_Click(object sender, EventArgs e)
        {
            string telefono = textBoxTelefono.Text;
            string direccion = textBoxDireccion.Text;

            ControladorRegistro controlador = new ControladorRegistro();
            bool clienteRegistrado = controlador.RegistrarCliente(idUsuario, telefono, direccion);

            if (clienteRegistrado)
            {
                MessageBox.Show("Cliente registrado con éxito.");
                PrincipalCliente principalClienteForm = new PrincipalCliente();
                principalClienteForm.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Error al registrar el cliente.");
            }
        }
    }
}
