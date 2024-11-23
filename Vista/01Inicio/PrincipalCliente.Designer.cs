namespace GenteFitApp.Vista
{
    partial class PrincipalCliente
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PrincipalCliente));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.perfilToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reservasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consultarListaDeEsperaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verMisReservasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBoxReservas = new System.Windows.Forms.GroupBox();
            this.Boton_Abrir_Horarios = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Boton_AbrirReservas = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.Boton_AbrirPerfil = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.groupBoxReservas.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Futura Lt BT", 10.2F);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.perfilToolStripMenuItem,
            this.reservasToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1108, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // perfilToolStripMenuItem
            // 
            this.perfilToolStripMenuItem.Name = "perfilToolStripMenuItem";
            this.perfilToolStripMenuItem.Size = new System.Drawing.Size(57, 24);
            this.perfilToolStripMenuItem.Text = "Perfil";
            this.perfilToolStripMenuItem.Click += new System.EventHandler(this.perfilToolStripMenuItem_Click);
            // 
            // reservasToolStripMenuItem
            // 
            this.reservasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.consultarListaDeEsperaToolStripMenuItem,
            this.verMisReservasToolStripMenuItem});
            this.reservasToolStripMenuItem.Name = "reservasToolStripMenuItem";
            this.reservasToolStripMenuItem.Size = new System.Drawing.Size(81, 24);
            this.reservasToolStripMenuItem.Text = "Reservas";
            // 
            // consultarListaDeEsperaToolStripMenuItem
            // 
            this.consultarListaDeEsperaToolStripMenuItem.Name = "consultarListaDeEsperaToolStripMenuItem";
            this.consultarListaDeEsperaToolStripMenuItem.Size = new System.Drawing.Size(263, 26);
            this.consultarListaDeEsperaToolStripMenuItem.Text = "Consultar lista de espera";
            this.consultarListaDeEsperaToolStripMenuItem.Click += new System.EventHandler(this.consultarListaDeEsperaToolStripMenuItem_Click);
            // 
            // verMisReservasToolStripMenuItem
            // 
            this.verMisReservasToolStripMenuItem.Name = "verMisReservasToolStripMenuItem";
            this.verMisReservasToolStripMenuItem.Size = new System.Drawing.Size(263, 26);
            this.verMisReservasToolStripMenuItem.Text = "Ver mis reservas";
            this.verMisReservasToolStripMenuItem.Click += new System.EventHandler(this.verMisReservasToolStripMenuItem_Click);
            // 
            // groupBoxReservas
            // 
            this.groupBoxReservas.Controls.Add(this.Boton_Abrir_Horarios);
            this.groupBoxReservas.Font = new System.Drawing.Font("Futura Lt BT", 14F);
            this.groupBoxReservas.Location = new System.Drawing.Point(32, 91);
            this.groupBoxReservas.Margin = new System.Windows.Forms.Padding(4);
            this.groupBoxReservas.Name = "groupBoxReservas";
            this.groupBoxReservas.Padding = new System.Windows.Forms.Padding(4);
            this.groupBoxReservas.Size = new System.Drawing.Size(991, 123);
            this.groupBoxReservas.TabIndex = 4;
            this.groupBoxReservas.TabStop = false;
            this.groupBoxReservas.Text = "Horarios";
            // 
            // Boton_Abrir_Horarios
            // 
            this.Boton_Abrir_Horarios.Location = new System.Drawing.Point(25, 36);
            this.Boton_Abrir_Horarios.Margin = new System.Windows.Forms.Padding(4);
            this.Boton_Abrir_Horarios.Name = "Boton_Abrir_Horarios";
            this.Boton_Abrir_Horarios.Size = new System.Drawing.Size(944, 65);
            this.Boton_Abrir_Horarios.TabIndex = 0;
            this.Boton_Abrir_Horarios.Text = "Abrir horarios";
            this.Boton_Abrir_Horarios.UseVisualStyleBackColor = true;
            this.Boton_Abrir_Horarios.Click += new System.EventHandler(this.Boton_Abrir_Horarios_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Boton_AbrirReservas);
            this.groupBox1.Font = new System.Drawing.Font("Futura Lt BT", 14F);
            this.groupBox1.Location = new System.Drawing.Point(32, 234);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(991, 123);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Reservas";
            // 
            // Boton_AbrirReservas
            // 
            this.Boton_AbrirReservas.Location = new System.Drawing.Point(19, 36);
            this.Boton_AbrirReservas.Margin = new System.Windows.Forms.Padding(4);
            this.Boton_AbrirReservas.Name = "Boton_AbrirReservas";
            this.Boton_AbrirReservas.Size = new System.Drawing.Size(951, 65);
            this.Boton_AbrirReservas.TabIndex = 0;
            this.Boton_AbrirReservas.Text = "Ver mis reservas";
            this.Boton_AbrirReservas.UseVisualStyleBackColor = true;
            this.Boton_AbrirReservas.Click += new System.EventHandler(this.Boton_AbrirReservas_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.Boton_AbrirPerfil);
            this.groupBox2.Font = new System.Drawing.Font("Futura Lt BT", 14F);
            this.groupBox2.Location = new System.Drawing.Point(32, 389);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(991, 123);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Perfil";
            // 
            // Boton_AbrirPerfil
            // 
            this.Boton_AbrirPerfil.Location = new System.Drawing.Point(19, 36);
            this.Boton_AbrirPerfil.Margin = new System.Windows.Forms.Padding(4);
            this.Boton_AbrirPerfil.Name = "Boton_AbrirPerfil";
            this.Boton_AbrirPerfil.Size = new System.Drawing.Size(951, 65);
            this.Boton_AbrirPerfil.TabIndex = 0;
            this.Boton_AbrirPerfil.Text = "Abrir perfil de usuario";
            this.Boton_AbrirPerfil.UseVisualStyleBackColor = true;
            this.Boton_AbrirPerfil.Click += new System.EventHandler(this.Boton_AbrirPerfil_Click);
            // 
            // PrincipalCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Bisque;
            this.ClientSize = new System.Drawing.Size(1108, 688);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBoxReservas);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "PrincipalCliente";
            this.Text = "Inicio";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBoxReservas.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem reservasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consultarListaDeEsperaToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBoxReservas;
        private System.Windows.Forms.Button Boton_Abrir_Horarios;
        private System.Windows.Forms.ToolStripMenuItem perfilToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button Boton_AbrirReservas;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button Boton_AbrirPerfil;
        private System.Windows.Forms.ToolStripMenuItem verMisReservasToolStripMenuItem;
    }
}