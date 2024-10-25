using GenteFitApp.Modelo;
using GenteFitApp.Controlador;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace GenteFitApp.Vista
{
    public partial class Inicio : Form
    {
        ControladorInicioSesion controladorInicioSesion = new ControladorInicioSesion();

        public Inicio()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            // Aquí es donde tienes la lógica para verificar el usuario y la contraseña
            Usuario usuarioActual = ObtenerUsuarioDesdeBD(Box_UserId.Text, BoxPassword.Text);

            // Llamamos al controlador para manejar el flujo de inicio de sesión
            controladorInicioSesion.IniciarSesion(usuarioActual, this);
        }

        private Usuario ObtenerUsuarioDesdeBD(string userId, string password)
        {
            // Aquí iría la lógica para obtener el usuario desde la base de datos, verificando su id y contraseña
            // Este es solo un ejemplo básico
            return new Usuario { nombre = "Marina", rol = "Administrador" }; // Sustituir por la lógica real
        }
    }
}
