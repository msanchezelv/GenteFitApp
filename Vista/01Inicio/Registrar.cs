using GenteFitApp.Controlador;
using GenteFitApp.Vista._01Inicio;
using System;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Data.SqlClient;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GenteFitApp.Vista
{

    public partial class Registrar : Form
    {
        private string usuarioRol;

        public Registrar(string rol)
        {
            InitializeComponent();
            usuarioRol = rol;

            // Deshabilitar y cambiar el color de fondo del textBoxUserId
            textBoxUserId.ReadOnly = true; 
            textBoxUserId.BackColor = Color.LightGray;

            this.FormClosing += new FormClosingEventHandler(Registrar_FormClosing);
        }

        private void Registrar_FormClosing(object sender, FormClosingEventArgs e) 
        { EscogerRol escogerRolForm = new EscogerRol(); 
            escogerRolForm.Show(); 
        }

        public Registrar()
        {
            InitializeComponent();

            // Deshabilitar y cambiar el color de fondo del textBoxUserId
            textBoxUserId.ReadOnly = true;
            textBoxUserId.BackColor = Color.LightGray;

            this.FormClosing += new FormClosingEventHandler(Registrar_FormClosing);
        }

        private void Boton_nuevoEmpleado_Click(object sender, EventArgs e)
        {
            // Validar los campos
            if (ValidarCampos())
            {
                GuardarUsuario();

                if (usuarioRol == "Cliente")
                {
                    // Mostrar mensaje y abrir el formulario RegistrarCliente
                    MessageBox.Show("Datos registrados correctamente. Continúe añadiendo más datos.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RegistrarCliente registrarClienteForm = new RegistrarCliente(int.Parse(textBoxUserId.Text)); // Pasar el idUsuario
                    registrarClienteForm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Usuario registrado correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }




        private bool ValidarCampos()
        {
            bool camposValidos = true;

            if (string.IsNullOrWhiteSpace(textBoxNombre.Text))
            {
                textBoxNombre.BackColor = Color.Red;
                camposValidos = false;
            }
            else
            {
                textBoxNombre.BackColor = Color.White;
            }

            if (string.IsNullOrWhiteSpace(textBoxApellidos.Text))
            {
                textBoxApellidos.BackColor = Color.Red;
                camposValidos = false;
            }
            else
            {
                textBoxApellidos.BackColor = Color.White;
            }

            if (!EsEmailValido(textBoxemail.Text))
            {
                textBoxemail.BackColor = Color.Red;
                camposValidos = false;
            }
            else
            {
                textBoxemail.BackColor = Color.White;
            }

            if (string.IsNullOrWhiteSpace(textBoxcontraseña.Text))
            {
                textBoxcontraseña.BackColor = Color.Red;
                camposValidos = false;
            }
            else
            {
                textBoxcontraseña.BackColor = Color.White;
            }

            if (!camposValidos)
            {
                MessageBox.Show("Por favor, rellene correctamente todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return camposValidos;
        }

        private bool EsEmailValido(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private void GuardarUsuario()
        {
            string conString = DatabaseConfig.ConnectionString;

            using (SqlConnection con = new SqlConnection(conString))
            {
                string query = "INSERT INTO Usuario (nombre, apellidos, email, contraseña, rol) " +
                               "VALUES (@nombre, @apellidos, @email, @contraseña, @rol); " +
                               "SELECT SCOPE_IDENTITY()";

                using (SqlCommand command = new SqlCommand(query, con))
                {
                    command.Parameters.AddWithValue("@nombre", textBoxNombre.Text);
                    command.Parameters.AddWithValue("@apellidos", textBoxApellidos.Text);
                    command.Parameters.AddWithValue("@rol", usuarioRol);
                    command.Parameters.AddWithValue("@email", textBoxemail.Text);
                    command.Parameters.AddWithValue("@contraseña", textBoxcontraseña.Text);

                    con.Open();
                    int idUsuarioGenerado = Convert.ToInt32(command.ExecuteScalar());

                    // Mostrar el idUsuario generado en el TextBox
                    textBoxUserId.Text = idUsuarioGenerado.ToString();
                }
            }

            MessageBox.Show("Usuario registrado correctamente.");
        }


        private void textBoxemail_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
