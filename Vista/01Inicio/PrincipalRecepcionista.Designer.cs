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
            this.groupBoxClientes = new System.Windows.Forms.GroupBox();
            this.Boton_Abrir_Gestion_Clientes = new System.Windows.Forms.Button();
            this.groupBoxClientes.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxClientes
            // 
            this.groupBoxClientes.Controls.Add(this.Boton_Abrir_Gestion_Clientes);
            this.groupBoxClientes.Font = new System.Drawing.Font("Futura Lt BT", 14F);
            this.groupBoxClientes.Location = new System.Drawing.Point(40, 102);
            this.groupBoxClientes.Margin = new System.Windows.Forms.Padding(4);
            this.groupBoxClientes.Name = "groupBoxClientes";
            this.groupBoxClientes.Padding = new System.Windows.Forms.Padding(4);
            this.groupBoxClientes.Size = new System.Drawing.Size(1032, 106);
            this.groupBoxClientes.TabIndex = 10;
            this.groupBoxClientes.TabStop = false;
            this.groupBoxClientes.Text = "Gestión de clientes";
            // 
            // Boton_Abrir_Gestion_Clientes
            // 
            this.Boton_Abrir_Gestion_Clientes.Location = new System.Drawing.Point(19, 36);
            this.Boton_Abrir_Gestion_Clientes.Margin = new System.Windows.Forms.Padding(4);
            this.Boton_Abrir_Gestion_Clientes.Name = "Boton_Abrir_Gestion_Clientes";
            this.Boton_Abrir_Gestion_Clientes.Size = new System.Drawing.Size(993, 48);
            this.Boton_Abrir_Gestion_Clientes.TabIndex = 0;
            this.Boton_Abrir_Gestion_Clientes.Text = "Abrir gestión de clientes";
            this.Boton_Abrir_Gestion_Clientes.UseVisualStyleBackColor = true;
            // 
            // PrincipalRecepcionista
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Bisque;
            this.ClientSize = new System.Drawing.Size(1111, 483);
            this.Controls.Add(this.groupBoxClientes);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "PrincipalRecepcionista";
            this.Text = "Inicio";
            this.groupBoxClientes.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBoxClientes;
        private System.Windows.Forms.Button Boton_Abrir_Gestion_Clientes;
    }
}