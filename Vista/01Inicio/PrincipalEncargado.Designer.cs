namespace GenteFitApp.Vista
{
    partial class PrincipalEncargado
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PrincipalEncargado));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.reservasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consultarReservasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consultarListaDeEsperaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.actividadesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.monitoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBoxMonitores = new System.Windows.Forms.GroupBox();
            this.Boton_Abrir_Gestion_Monitores = new System.Windows.Forms.Button();
            this.groupBoxAct = new System.Windows.Forms.GroupBox();
            this.Boton_Abrir_Gestion_Actividades = new System.Windows.Forms.Button();
            this.groupBoxReservas = new System.Windows.Forms.GroupBox();
            this.Boton_Abrir_Gestion_Reservas = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.groupBoxMonitores.SuspendLayout();
            this.groupBoxAct.SuspendLayout();
            this.groupBoxReservas.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reservasToolStripMenuItem,
            this.actividadesToolStripMenuItem,
            this.monitoresToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1120, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // reservasToolStripMenuItem
            // 
            this.reservasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.consultarReservasToolStripMenuItem,
            this.consultarListaDeEsperaToolStripMenuItem});
            this.reservasToolStripMenuItem.Name = "reservasToolStripMenuItem";
            this.reservasToolStripMenuItem.Size = new System.Drawing.Size(80, 24);
            this.reservasToolStripMenuItem.Text = "Reservas";
            // 
            // consultarReservasToolStripMenuItem
            // 
            this.consultarReservasToolStripMenuItem.Name = "consultarReservasToolStripMenuItem";
            this.consultarReservasToolStripMenuItem.Size = new System.Drawing.Size(254, 26);
            this.consultarReservasToolStripMenuItem.Text = "Consultar reservas";
            this.consultarReservasToolStripMenuItem.Click += new System.EventHandler(this.consultarReservasToolStripMenuItem_Click);
            // 
            // consultarListaDeEsperaToolStripMenuItem
            // 
            this.consultarListaDeEsperaToolStripMenuItem.Name = "consultarListaDeEsperaToolStripMenuItem";
            this.consultarListaDeEsperaToolStripMenuItem.Size = new System.Drawing.Size(254, 26);
            this.consultarListaDeEsperaToolStripMenuItem.Text = "Consultar lista de espera";
            this.consultarListaDeEsperaToolStripMenuItem.Click += new System.EventHandler(this.consultarListaDeEsperaToolStripMenuItem_Click);
            // 
            // actividadesToolStripMenuItem
            // 
            this.actividadesToolStripMenuItem.Name = "actividadesToolStripMenuItem";
            this.actividadesToolStripMenuItem.Size = new System.Drawing.Size(100, 24);
            this.actividadesToolStripMenuItem.Text = "Actividades";
            this.actividadesToolStripMenuItem.Click += new System.EventHandler(this.actividadesToolStripMenuItem_Click);
            // 
            // monitoresToolStripMenuItem
            // 
            this.monitoresToolStripMenuItem.Name = "monitoresToolStripMenuItem";
            this.monitoresToolStripMenuItem.Size = new System.Drawing.Size(90, 24);
            this.monitoresToolStripMenuItem.Text = "Monitores";
            this.monitoresToolStripMenuItem.Click += new System.EventHandler(this.monitoresToolStripMenuItem_Click);
            // 
            // groupBoxMonitores
            // 
            this.groupBoxMonitores.Controls.Add(this.Boton_Abrir_Gestion_Monitores);
            this.groupBoxMonitores.Font = new System.Drawing.Font("Futura Lt BT", 14F);
            this.groupBoxMonitores.Location = new System.Drawing.Point(35, 364);
            this.groupBoxMonitores.Margin = new System.Windows.Forms.Padding(4);
            this.groupBoxMonitores.Name = "groupBoxMonitores";
            this.groupBoxMonitores.Padding = new System.Windows.Forms.Padding(4);
            this.groupBoxMonitores.Size = new System.Drawing.Size(1032, 108);
            this.groupBoxMonitores.TabIndex = 4;
            this.groupBoxMonitores.TabStop = false;
            this.groupBoxMonitores.Text = "Gestión de monitores";
            // 
            // Boton_Abrir_Gestion_Monitores
            // 
            this.Boton_Abrir_Gestion_Monitores.Location = new System.Drawing.Point(19, 36);
            this.Boton_Abrir_Gestion_Monitores.Margin = new System.Windows.Forms.Padding(4);
            this.Boton_Abrir_Gestion_Monitores.Name = "Boton_Abrir_Gestion_Monitores";
            this.Boton_Abrir_Gestion_Monitores.Size = new System.Drawing.Size(993, 52);
            this.Boton_Abrir_Gestion_Monitores.TabIndex = 0;
            this.Boton_Abrir_Gestion_Monitores.Text = "Abrir gestión de monitores";
            this.Boton_Abrir_Gestion_Monitores.UseVisualStyleBackColor = true;
            this.Boton_Abrir_Gestion_Monitores.Click += new System.EventHandler(this.Boton_Abrir_Gestion_Monitores_Click);
            // 
            // groupBoxAct
            // 
            this.groupBoxAct.Controls.Add(this.Boton_Abrir_Gestion_Actividades);
            this.groupBoxAct.Font = new System.Drawing.Font("Futura Lt BT", 14F);
            this.groupBoxAct.Location = new System.Drawing.Point(35, 228);
            this.groupBoxAct.Margin = new System.Windows.Forms.Padding(4);
            this.groupBoxAct.Name = "groupBoxAct";
            this.groupBoxAct.Padding = new System.Windows.Forms.Padding(4);
            this.groupBoxAct.Size = new System.Drawing.Size(1032, 106);
            this.groupBoxAct.TabIndex = 5;
            this.groupBoxAct.TabStop = false;
            this.groupBoxAct.Text = "Gestión de actividades";
            // 
            // Boton_Abrir_Gestion_Actividades
            // 
            this.Boton_Abrir_Gestion_Actividades.Location = new System.Drawing.Point(19, 36);
            this.Boton_Abrir_Gestion_Actividades.Margin = new System.Windows.Forms.Padding(4);
            this.Boton_Abrir_Gestion_Actividades.Name = "Boton_Abrir_Gestion_Actividades";
            this.Boton_Abrir_Gestion_Actividades.Size = new System.Drawing.Size(993, 48);
            this.Boton_Abrir_Gestion_Actividades.TabIndex = 0;
            this.Boton_Abrir_Gestion_Actividades.Text = "Abrir gestión de actividades";
            this.Boton_Abrir_Gestion_Actividades.UseVisualStyleBackColor = true;
            this.Boton_Abrir_Gestion_Actividades.Click += new System.EventHandler(this.Boton_Abrir_Gestion_Actividades_Click);
            // 
            // groupBoxReservas
            // 
            this.groupBoxReservas.Controls.Add(this.Boton_Abrir_Gestion_Reservas);
            this.groupBoxReservas.Font = new System.Drawing.Font("Futura Lt BT", 14F);
            this.groupBoxReservas.Location = new System.Drawing.Point(35, 98);
            this.groupBoxReservas.Margin = new System.Windows.Forms.Padding(4);
            this.groupBoxReservas.Name = "groupBoxReservas";
            this.groupBoxReservas.Padding = new System.Windows.Forms.Padding(4);
            this.groupBoxReservas.Size = new System.Drawing.Size(1032, 103);
            this.groupBoxReservas.TabIndex = 6;
            this.groupBoxReservas.TabStop = false;
            this.groupBoxReservas.Text = "Gestión de reservas";
            // 
            // Boton_Abrir_Gestion_Reservas
            // 
            this.Boton_Abrir_Gestion_Reservas.Location = new System.Drawing.Point(19, 36);
            this.Boton_Abrir_Gestion_Reservas.Margin = new System.Windows.Forms.Padding(4);
            this.Boton_Abrir_Gestion_Reservas.Name = "Boton_Abrir_Gestion_Reservas";
            this.Boton_Abrir_Gestion_Reservas.Size = new System.Drawing.Size(993, 47);
            this.Boton_Abrir_Gestion_Reservas.TabIndex = 0;
            this.Boton_Abrir_Gestion_Reservas.Text = "Abrir gestión de reservas";
            this.Boton_Abrir_Gestion_Reservas.UseVisualStyleBackColor = true;
            this.Boton_Abrir_Gestion_Reservas.Click += new System.EventHandler(this.Boton_Abrir_Gestion_Reservas_Click);
            // 
            // PrincipalEncargado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Bisque;
            this.ClientSize = new System.Drawing.Size(1120, 704);
            this.Controls.Add(this.groupBoxMonitores);
            this.Controls.Add(this.groupBoxAct);
            this.Controls.Add(this.groupBoxReservas);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "PrincipalEncargado";
            this.Text = "Inicio";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBoxMonitores.ResumeLayout(false);
            this.groupBoxAct.ResumeLayout(false);
            this.groupBoxReservas.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem reservasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consultarReservasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consultarListaDeEsperaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem actividadesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem monitoresToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBoxMonitores;
        private System.Windows.Forms.Button Boton_Abrir_Gestion_Monitores;
        private System.Windows.Forms.GroupBox groupBoxAct;
        private System.Windows.Forms.Button Boton_Abrir_Gestion_Actividades;
        private System.Windows.Forms.GroupBox groupBoxReservas;
        private System.Windows.Forms.Button Boton_Abrir_Gestion_Reservas;
    }
}