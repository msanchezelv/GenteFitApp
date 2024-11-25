using GenteFitApp.Controlador;
using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using static GenteFitApp.GenteFitDataSet1;

namespace GenteFitApp.Vista._01Inicio
{
    public partial class RegistrarCliente : Form
    {
        private int idUsuario;

        public RegistrarCliente(int userId)
        {
            InitializeComponent();
            idUsuario = userId;

            this.FormClosing += new FormClosingEventHandler(RegistrarCliente_FormClosing);
        }

        private void RegistrarCliente_FormClosing(object sender, FormClosingEventArgs e)
        {
            PrincipalAdmin principalAdmin = new PrincipalAdmin();
            principalAdmin.Show(); 
        }

        public void SetIdUsuario(int id)
        {
            idUsuario = id;
        }

        private void BotonRegistrarCliente_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                GuardarDatosCliente();
            }
        }

        private bool ValidarCampos()
        {
            bool camposValidos = true;

            if (string.IsNullOrWhiteSpace(textBoxTelefono.Text) || !EsTelefonoValido(textBoxTelefono.Text))
            {
                textBoxTelefono.BackColor = Color.Red;
                camposValidos = false;
            }
            else
            {
                textBoxTelefono.BackColor = Color.White;
            }

            if (string.IsNullOrWhiteSpace(textBoxDireccion.Text))
            {
                textBoxDireccion.BackColor = Color.Red;
                camposValidos = false;
            }
            else
            {
                textBoxDireccion.BackColor = Color.White;
            }

            if (!camposValidos)
            {
                MessageBox.Show("Por favor, rellene correctamente todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return camposValidos;
        }

        private bool EsTelefonoValido(string telefono)
        {            
            return System.Text.RegularExpressions.Regex.IsMatch(telefono, @"^\d{9}$");
        }

        private void GuardarDatosCliente()
        {
            string conString = DatabaseConfig.ConnectionString;

            using (SqlConnection con = new SqlConnection(conString))
            {
                string query = "INSERT INTO Cliente (telefono, direccion, idUsuario) " +
                               "VALUES (@telefono, @direccion, @idUsuario)";

                using (SqlCommand command = new SqlCommand(query, con))
                {
                    command.Parameters.AddWithValue("@telefono", textBoxTelefono.Text);
                    command.Parameters.AddWithValue("@direccion", textBoxDireccion.Text);
                    command.Parameters.AddWithValue("@idUsuario", idUsuario);

                    con.Open();
                    command.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Cliente registrado correctamente.");
        }



    }
}
