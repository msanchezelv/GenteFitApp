﻿using System;
using System.Windows.Forms;
using System.Drawing;

namespace GenteFitApp.Vista
{
    public partial class FormularioBase : Form
    {
        public FormularioBase()
        {
            InitializeComponent();
            this.BackColor = Color.Bisque;
            this.Icon = new Icon("C:\\Users\\Marina\\source\\repos\\GenteFitApp\\GenteFitApp\\logoGenteFit.ico");

            this.FormClosing += FormularioBase_FormClosing;
        }

        private void FormularioBase_FormClosing(object sender, FormClosingEventArgs e)
        {
            var result = MessageBox.Show("¿Estás seguro de que deseas salir?", "Confirmar salida", MessageBoxButtons.YesNo);
            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
            
        }

    }
}
