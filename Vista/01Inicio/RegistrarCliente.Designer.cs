namespace GenteFitApp.Vista._01Inicio
{
    partial class RegistrarCliente
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
            this.labelTelefono = new System.Windows.Forms.Label();
            this.textBoxTelefono = new System.Windows.Forms.TextBox();
            this.textBoxDireccion = new System.Windows.Forms.TextBox();
            this.labelDireccion = new System.Windows.Forms.Label();
            this.BotonRegistrarCliente = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelTelefono
            // 
            this.labelTelefono.AutoSize = true;
            this.labelTelefono.Font = new System.Drawing.Font("Futura Lt BT", 10F);
            this.labelTelefono.Location = new System.Drawing.Point(90, 105);
            this.labelTelefono.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelTelefono.Name = "labelTelefono";
            this.labelTelefono.Size = new System.Drawing.Size(68, 20);
            this.labelTelefono.TabIndex = 33;
            this.labelTelefono.Text = "Teléfono";
            // 
            // textBoxTelefono
            // 
            this.textBoxTelefono.Location = new System.Drawing.Point(95, 127);
            this.textBoxTelefono.Name = "textBoxTelefono";
            this.textBoxTelefono.Size = new System.Drawing.Size(857, 22);
            this.textBoxTelefono.TabIndex = 34;
            // 
            // textBoxDireccion
            // 
            this.textBoxDireccion.Location = new System.Drawing.Point(95, 190);
            this.textBoxDireccion.Name = "textBoxDireccion";
            this.textBoxDireccion.Size = new System.Drawing.Size(857, 22);
            this.textBoxDireccion.TabIndex = 36;
            // 
            // labelDireccion
            // 
            this.labelDireccion.AutoSize = true;
            this.labelDireccion.Font = new System.Drawing.Font("Futura Lt BT", 10F);
            this.labelDireccion.Location = new System.Drawing.Point(91, 167);
            this.labelDireccion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelDireccion.Name = "labelDireccion";
            this.labelDireccion.Size = new System.Drawing.Size(76, 20);
            this.labelDireccion.TabIndex = 35;
            this.labelDireccion.Text = "Dirección";
            // 
            // BotonRegistrarCliente
            // 
            this.BotonRegistrarCliente.Font = new System.Drawing.Font("Futura Lt BT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BotonRegistrarCliente.Location = new System.Drawing.Point(455, 258);
            this.BotonRegistrarCliente.Name = "BotonRegistrarCliente";
            this.BotonRegistrarCliente.Size = new System.Drawing.Size(159, 42);
            this.BotonRegistrarCliente.TabIndex = 37;
            this.BotonRegistrarCliente.Text = "Registrar";
            this.BotonRegistrarCliente.UseVisualStyleBackColor = true;
            this.BotonRegistrarCliente.Click += new System.EventHandler(this.BotonRegistrarCliente_Click);
            // 
            // RegistrarCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Bisque;
            this.ClientSize = new System.Drawing.Size(1043, 359);
            this.Controls.Add(this.BotonRegistrarCliente);
            this.Controls.Add(this.textBoxDireccion);
            this.Controls.Add(this.labelDireccion);
            this.Controls.Add(this.textBoxTelefono);
            this.Controls.Add(this.labelTelefono);
            this.Name = "RegistrarCliente";
            this.Text = "Registrar cliente";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelTelefono;
        private System.Windows.Forms.TextBox textBoxTelefono;
        private System.Windows.Forms.TextBox textBoxDireccion;
        private System.Windows.Forms.Label labelDireccion;
        private System.Windows.Forms.Button BotonRegistrarCliente;
    }
}