namespace GenteFitApp.Vista._01Inicio
{
    partial class EscogerRol
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
            this.label_Escoger = new System.Windows.Forms.Label();
            this.Boton_Recepcionista = new System.Windows.Forms.Button();
            this.Boton_Encargado = new System.Windows.Forms.Button();
            this.Boton_Administrador = new System.Windows.Forms.Button();
            this.boton_Cliente = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label_Escoger
            // 
            this.label_Escoger.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label_Escoger.AutoSize = true;
            this.label_Escoger.Font = new System.Drawing.Font("Futura Lt BT", 9F);
            this.label_Escoger.Location = new System.Drawing.Point(38, 59);
            this.label_Escoger.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Escoger.Name = "label_Escoger";
            this.label_Escoger.Size = new System.Drawing.Size(356, 18);
            this.label_Escoger.TabIndex = 10;
            this.label_Escoger.Text = "Por favor, escoge el rol del usuario que quieres registrar:";
            this.label_Escoger.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Boton_Recepcionista
            // 
            this.Boton_Recepcionista.Font = new System.Drawing.Font("Futura Lt BT", 12F);
            this.Boton_Recepcionista.Location = new System.Drawing.Point(90, 149);
            this.Boton_Recepcionista.Margin = new System.Windows.Forms.Padding(4);
            this.Boton_Recepcionista.Name = "Boton_Recepcionista";
            this.Boton_Recepcionista.Size = new System.Drawing.Size(235, 33);
            this.Boton_Recepcionista.TabIndex = 2;
            this.Boton_Recepcionista.Text = "Recepcionista";
            this.Boton_Recepcionista.UseVisualStyleBackColor = true;
            this.Boton_Recepcionista.Click += new System.EventHandler(this.Boton_Recepcionista_Click);
            // 
            // Boton_Encargado
            // 
            this.Boton_Encargado.Font = new System.Drawing.Font("Futura Lt BT", 12F);
            this.Boton_Encargado.Location = new System.Drawing.Point(90, 199);
            this.Boton_Encargado.Margin = new System.Windows.Forms.Padding(4);
            this.Boton_Encargado.Name = "Boton_Encargado";
            this.Boton_Encargado.Size = new System.Drawing.Size(235, 33);
            this.Boton_Encargado.TabIndex = 3;
            this.Boton_Encargado.Text = "Encargado";
            this.Boton_Encargado.UseVisualStyleBackColor = true;
            this.Boton_Encargado.Click += new System.EventHandler(this.Boton_Encargado_Click);
            // 
            // Boton_Administrador
            // 
            this.Boton_Administrador.Font = new System.Drawing.Font("Futura Lt BT", 12F);
            this.Boton_Administrador.Location = new System.Drawing.Point(90, 250);
            this.Boton_Administrador.Margin = new System.Windows.Forms.Padding(4);
            this.Boton_Administrador.Name = "Boton_Administrador";
            this.Boton_Administrador.Size = new System.Drawing.Size(235, 33);
            this.Boton_Administrador.TabIndex = 4;
            this.Boton_Administrador.Text = "Adminstrador";
            this.Boton_Administrador.UseVisualStyleBackColor = true;
            this.Boton_Administrador.Click += new System.EventHandler(this.Boton_Administrador_Click);
            // 
            // boton_Cliente
            // 
            this.boton_Cliente.Font = new System.Drawing.Font("Futura Lt BT", 12F);
            this.boton_Cliente.Location = new System.Drawing.Point(90, 99);
            this.boton_Cliente.Margin = new System.Windows.Forms.Padding(4);
            this.boton_Cliente.Name = "boton_Cliente";
            this.boton_Cliente.Size = new System.Drawing.Size(235, 33);
            this.boton_Cliente.TabIndex = 1;
            this.boton_Cliente.Text = "Cliente";
            this.boton_Cliente.UseVisualStyleBackColor = true;
            this.boton_Cliente.Click += new System.EventHandler(this.boton_Cliente_Click);
            // 
            // EscogerRol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Bisque;
            this.ClientSize = new System.Drawing.Size(448, 365);
            this.Controls.Add(this.boton_Cliente);
            this.Controls.Add(this.Boton_Administrador);
            this.Controls.Add(this.Boton_Encargado);
            this.Controls.Add(this.Boton_Recepcionista);
            this.Controls.Add(this.label_Escoger);
            this.Name = "EscogerRol";
            this.Text = "Escoger Rol";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_Escoger;
        private System.Windows.Forms.Button Boton_Recepcionista;
        private System.Windows.Forms.Button Boton_Encargado;
        private System.Windows.Forms.Button Boton_Administrador;
        private System.Windows.Forms.Button boton_Cliente;
    }
}