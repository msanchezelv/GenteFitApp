using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenteFitApp.Vista;

namespace GenteFitApp.Controlador
{
    public class ControladorInicioSesion
    {
        public void IniciarSesion(Usuario usuarioActual, Form formularioActual)
        {
            if (usuarioActual != null)
            {
                MessageBox.Show("Inicio de sesión exitoso. Bienvenido " + usuarioActual.nombre);

                switch (usuarioActual.rol)
                {
                    case "Administrador":
                        PrincipalAdmin adminForm = new PrincipalAdmin();
                        adminForm.Show();
                        formularioActual.Hide();
                        break;

                    case "Cliente":
                        PrincipalCliente clienteForm = new PrincipalCliente();
                        clienteForm.Show();
                        formularioActual.Hide();
                        break;

                    case "Encargado":
                        PrincipalEncargado encargadoForm = new PrincipalEncargado();
                        encargadoForm.Show();
                        formularioActual.Hide();
                        break;

                    case "Recepcionista":
                        PrincipalRecepcionista recepcionistaForm = new PrincipalRecepcionista();
                        recepcionistaForm.Show();
                        formularioActual.Hide();
                        break;

                    default:
                        MessageBox.Show("Usuario no registrado. Por favor, regístrese.");
                        Registrar nuevoUsuarioForm = new Registrar();
                        nuevoUsuarioForm.Show();
                        formularioActual.Hide();
                        break;
                }
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos.");
            }
        }
    }
}
