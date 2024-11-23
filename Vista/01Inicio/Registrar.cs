using GenteFitApp.Controlador;
using GenteFitApp.Vista._01Inicio;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GenteFitApp.Vista
{
    public partial class Registrar : Form
    {
        private ControladorRegistro controladorRegistro;
        
        public Registrar(string rol)
        {
            InitializeComponent();
            controladorRegistro = new ControladorRegistro();
            textBoxcontraseña.PasswordChar = '*';
            this.Load += Registrar_Load;
            

        }

        public Registrar()
        {
        }

        private void Registrar_Load(object sender, EventArgs e)
        {
            int proximoId = controladorRegistro.ObtenerProximoIdUsuario();
            textBoxUserId.Text = proximoId.ToString();

            Task.Delay(50).ContinueWith(_ =>
            {
                Invoke(new Action(() =>
                {
                    textBoxNombre.Focus();
                }));
            });
        }

        private void Boton_nuevoEmpleado_Click(object sender, EventArgs e)
        {
            string nombre = textBoxNombre.Text;
            string apellidos = textBoxApellidos.Text;
            string email = textBoxemail.Text;
            string contraseña = textBoxcontraseña.Text;


            EscogerRol escogerRolForm = new EscogerRol(nombre, apellidos, email, contraseña);
            escogerRolForm.ShowDialog();
            this.Close();
        }

        

    }
}
