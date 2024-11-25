using GenteFitApp.Controlador;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
            textBoxRol.Enabled = true;
        }
        
    }
}
