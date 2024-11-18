namespace GenteFitApp.Vista
{
    partial class PrincipalRecepcionista
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PrincipalRecepcionista));
            this.Boton_Salir = new System.Windows.Forms.Button();
            this.groupBoxClientes = new System.Windows.Forms.GroupBox();
            this.Boton_Abrir_Gestion_Clientes = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.clientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.añadirClienteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editarClienteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarClienteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consultarClientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBoxClientes.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Boton_Salir
            // 
            this.Boton_Salir.Font = new System.Drawing.Font("Futura Lt BT", 12F);
            this.Boton_Salir.Location = new System.Drawing.Point(628, 632);
            this.Boton_Salir.Name = "Boton_Salir";
            this.Boton_Salir.Size = new System.Drawing.Size(176, 32);
            this.Boton_Salir.TabIndex = 15;
            this.Boton_Salir.Text = "Salir";
            this.Boton_Salir.UseVisualStyleBackColor = true;
            // 
            // groupBoxClientes
            // 
            this.groupBoxClientes.Controls.Add(this.Boton_Abrir_Gestion_Clientes);
            this.groupBoxClientes.Font = new System.Drawing.Font("Futura Lt BT", 14F);
            this.groupBoxClientes.Location = new System.Drawing.Point(30, 83);
            this.groupBoxClientes.Name = "groupBoxClientes";
            this.groupBoxClientes.Size = new System.Drawing.Size(774, 86);
            this.groupBoxClientes.TabIndex = 10;
            this.groupBoxClientes.TabStop = false;
            this.groupBoxClientes.Text = "Gestión de clientes";
            // 
            // Boton_Abrir_Gestion_Clientes
            // 
            this.Boton_Abrir_Gestion_Clientes.Location = new System.Drawing.Point(14, 29);
            this.Boton_Abrir_Gestion_Clientes.Name = "Boton_Abrir_Gestion_Clientes";
            this.Boton_Abrir_Gestion_Clientes.Size = new System.Drawing.Size(745, 39);
            this.Boton_Abrir_Gestion_Clientes.TabIndex = 0;
            this.Boton_Abrir_Gestion_Clientes.Text = "Abrir gestión de clientes";
            this.Boton_Abrir_Gestion_Clientes.UseVisualStyleBackColor = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clientesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(833, 24);
            this.menuStrip1.TabIndex = 9;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // clientesToolStripMenuItem
            // 
            this.clientesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.añadirClienteToolStripMenuItem,
            this.editarClienteToolStripMenuItem,
            this.eliminarClienteToolStripMenuItem,
            this.consultarClientesToolStripMenuItem});
            this.clientesToolStripMenuItem.Name = "clientesToolStripMenuItem";
            this.clientesToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.clientesToolStripMenuItem.Text = "Clientes";
            // 
            // añadirClienteToolStripMenuItem
            // 
            this.añadirClienteToolStripMenuItem.Name = "añadirClienteToolStripMenuItem";
            this.añadirClienteToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.añadirClienteToolStripMenuItem.Text = "Añadir cliente";
            // 
            // editarClienteToolStripMenuItem
            // 
            this.editarClienteToolStripMenuItem.Name = "editarClienteToolStripMenuItem";
            this.editarClienteToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.editarClienteToolStripMenuItem.Text = "Editar cliente";
            // 
            // eliminarClienteToolStripMenuItem
            // 
            this.eliminarClienteToolStripMenuItem.Name = "eliminarClienteToolStripMenuItem";
            this.eliminarClienteToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.eliminarClienteToolStripMenuItem.Text = "Eliminar cliente";
            // 
            // consultarClientesToolStripMenuItem
            // 
            this.consultarClientesToolStripMenuItem.Name = "consultarClientesToolStripMenuItem";
            this.consultarClientesToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.consultarClientesToolStripMenuItem.Text = "Consultar clientes";
            // 
            // PrincipalRecepcionista
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Bisque;
            this.ClientSize = new System.Drawing.Size(833, 697);
            this.Controls.Add(this.Boton_Salir);
            this.Controls.Add(this.groupBoxClientes);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PrincipalRecepcionista";
            this.Text = "PrincipalRecepcionista";
            this.groupBoxClientes.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button Boton_Salir;
        private System.Windows.Forms.GroupBox groupBoxClientes;
        private System.Windows.Forms.Button Boton_Abrir_Gestion_Clientes;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem clientesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem añadirClienteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editarClienteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eliminarClienteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consultarClientesToolStripMenuItem;
    }
}