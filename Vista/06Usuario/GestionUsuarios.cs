using GenteFitApp.Controlador;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GenteFitApp.Vista._06Usuario
{
    public partial class GestionUsuarios : Form
    {
        
        private bool enModoEdicion = false;
        
        public GestionUsuarios()
        {
            InitializeComponent();
            DeshabilitarCampos();
        }

        private void DeshabilitarCampos()
        {
            textBoxUserId.Enabled = false;
            textBoxNombre.Enabled = false;
            textBoxApellidos.Enabled = false;
            textBoxEmail.Enabled = false;
            textBoxcontraseña.Enabled = false;
            textBoxRol.Enabled = false;
        }

        private void HabilitarCampos()
        {
            textBoxNombre.Enabled = true;
            textBoxApellidos.Enabled = true;
            textBoxEmail.Enabled = true;
            textBoxcontraseña.Enabled = true;
            
        }

        public void CargarDatosUsuario(string idUsuario, string nombre, string apellidos, string email, string contraseña, string rol)
        {
            textBoxUserId.Text = idUsuario;
            textBoxNombre.Text = nombre;
            textBoxApellidos.Text = apellidos;
            textBoxEmail.Text = email;
            textBoxcontraseña.Text = contraseña;
            textBoxRol.Text = rol;

        }

        private void buttonModificarDatos_Click(object sender, EventArgs e)
        {
            if (enModoEdicion)
            {
                ActualizarDatosUsuario();
                buttonModificarDatos.Text = "Modificar Datos";
                DeshabilitarCampos();
                enModoEdicion = false;
            }
            else
            {
                HabilitarCampos();
                buttonModificarDatos.Text = "Guardar";
                enModoEdicion = true;
            }

        }

        private void ActualizarDatosUsuario()
        {
            string connectionString = DatabaseConfig.ConnectionString;
            string query = "UPDATE Usuario SET nombre = @nombre, apellidos = @apellidos, email = @email, contraseña = @contraseña, rol = @rol WHERE idUsuario = @idUsuario";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@idUsuario", textBoxUserId.Text);
                        command.Parameters.AddWithValue("@nombre", textBoxNombre.Text);
                        command.Parameters.AddWithValue("@apellidos", textBoxApellidos.Text);
                        command.Parameters.AddWithValue("@email", textBoxEmail.Text);
                        command.Parameters.AddWithValue("@contraseña", textBoxcontraseña.Text);
                        command.Parameters.AddWithValue("@rol", textBoxRol.Text);

                        int result = command.ExecuteNonQuery();

                        if (result > 0)
                        {
                            if (textBoxRol.Text == "Cliente")
                            {
                                string deleteReservasQuery = "DELETE FROM Reserva WHERE idCliente = (SELECT idCliente FROM Cliente WHERE idUsuario = @idUsuario)";
                                using (SqlCommand deleteReservasCommand = new SqlCommand(deleteReservasQuery, connection))
                                {
                                    deleteReservasCommand.Parameters.AddWithValue("@idUsuario", textBoxUserId.Text);
                                    deleteReservasCommand.ExecuteNonQuery();
                                }

                                string deleteListaEsperaQuery = "DELETE FROM ListaEspera WHERE idCliente = (SELECT idCliente FROM Cliente WHERE idUsuario = @idUsuario)";
                                using (SqlCommand deleteListaEsperaCommand = new SqlCommand(deleteListaEsperaQuery, connection))
                                {
                                    deleteListaEsperaCommand.Parameters.AddWithValue("@idUsuario", textBoxUserId.Text);
                                    deleteListaEsperaCommand.ExecuteNonQuery();
                                }

                                string deleteClienteQuery = "DELETE FROM Cliente WHERE idUsuario = @idUsuario";
                                using (SqlCommand deleteClienteCommand = new SqlCommand(deleteClienteQuery, connection))
                                {
                                    deleteClienteCommand.Parameters.AddWithValue("@idUsuario", textBoxUserId.Text);
                                    deleteClienteCommand.ExecuteNonQuery();
                                }
                            }

                            MessageBox.Show("Datos actualizados con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("No se encontraron datos para actualizar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar los datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void botonEliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxUserId.Text))
            {
                MessageBox.Show("No se ha seleccionado ningún usuario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string idUsuario = textBoxUserId.Text;
            var result = MessageBox.Show("¿Estás seguro de que deseas eliminar este usuario?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                EliminarUsuario(idUsuario);
            }
        }

        private void EliminarUsuario(string idUsuario)
        {
            string connectionString = DatabaseConfig.ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();
                try
                {
                    string deleteReservasQuery = "DELETE FROM Reserva WHERE idCliente = (SELECT idCliente FROM Cliente WHERE idUsuario = @idUsuario)";
                    using (SqlCommand deleteReservasCommand = new SqlCommand(deleteReservasQuery, connection, transaction))
                    {
                        deleteReservasCommand.Parameters.AddWithValue("@idUsuario", idUsuario);
                        deleteReservasCommand.ExecuteNonQuery();
                    }

                    string deleteClienteQuery = "DELETE FROM Cliente WHERE idUsuario = @idUsuario";
                    using (SqlCommand deleteClienteCommand = new SqlCommand(deleteClienteQuery, connection, transaction))
                    {
                        deleteClienteCommand.Parameters.AddWithValue("@idUsuario", idUsuario);
                        deleteClienteCommand.ExecuteNonQuery();
                    }

                    string deleteListaEsperaQuery = "DELETE FROM ListaEspera WHERE idCliente = (SELECT idCliente FROM Cliente WHERE idUsuario = @idUsuario)";
                    using (SqlCommand deleteListaEsperaCommand = new SqlCommand(deleteListaEsperaQuery, connection, transaction))
                    {
                        deleteListaEsperaCommand.Parameters.AddWithValue("@idUsuario", idUsuario);
                        deleteListaEsperaCommand.ExecuteNonQuery();
                    }

                    string deleteUsuarioQuery = "DELETE FROM Usuario WHERE idUsuario = @idUsuario";
                    using (SqlCommand deleteUsuarioCommand = new SqlCommand(deleteUsuarioQuery, connection, transaction))
                    {
                        deleteUsuarioCommand.Parameters.AddWithValue("@idUsuario", idUsuario);
                        deleteUsuarioCommand.ExecuteNonQuery();
                    }

                    transaction.Commit();

                    MessageBox.Show("Usuario eliminado y todas las relaciones actualizadas con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    EscogerUsuario escogerForm = new EscogerUsuario();
                    escogerForm.ShowDialog();
                    this.Close();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Error al eliminar y actualizar los datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


    }
}
