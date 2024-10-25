namespace GenteFitApp.Vista._02Clientes
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
            this.Boton_nuevoEmpleado = new System.Windows.Forms.Button();
            this.Boton_nuevoCliente = new System.Windows.Forms.Button();
            this.textBoxNombre = new System.Windows.Forms.TextBox();
            this.Label_nombre = new System.Windows.Forms.Label();
            this.textBoxUserId = new System.Windows.Forms.TextBox();
            this.label_IdUsuario = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Boton_nuevoEmpleado
            // 
            this.Boton_nuevoEmpleado.Font = new System.Drawing.Font("Futura Lt BT", 12F);
            this.Boton_nuevoEmpleado.Location = new System.Drawing.Point(561, 469);
            this.Boton_nuevoEmpleado.Name = "Boton_nuevoEmpleado";
            this.Boton_nuevoEmpleado.Size = new System.Drawing.Size(176, 32);
            this.Boton_nuevoEmpleado.TabIndex = 35;
            this.Boton_nuevoEmpleado.Text = "Nuevo empleado";
            this.Boton_nuevoEmpleado.UseVisualStyleBackColor = true;
            this.Boton_nuevoEmpleado.Click += new System.EventHandler(this.Boton_nuevoEmpleado_Click);
            // 
            // Boton_nuevoCliente
            // 
            this.Boton_nuevoCliente.Font = new System.Drawing.Font("Futura Lt BT", 12F);
            this.Boton_nuevoCliente.Location = new System.Drawing.Point(93, 469);
            this.Boton_nuevoCliente.Name = "Boton_nuevoCliente";
            this.Boton_nuevoCliente.Size = new System.Drawing.Size(176, 32);
            this.Boton_nuevoCliente.TabIndex = 28;
            this.Boton_nuevoCliente.Text = "Nuevo cliente";
            this.Boton_nuevoCliente.UseVisualStyleBackColor = true;
            this.Boton_nuevoCliente.Click += new System.EventHandler(this.Boton_nuevoCliente_Click);
            // 
            // textBoxNombre
            // 
            this.textBoxNombre.Location = new System.Drawing.Point(94, 243);
            this.textBoxNombre.Name = "textBoxNombre";
            this.textBoxNombre.Size = new System.Drawing.Size(644, 20);
            this.textBoxNombre.TabIndex = 27;
            // 
            // Label_nombre
            // 
            this.Label_nombre.AutoSize = true;
            this.Label_nombre.Font = new System.Drawing.Font("Futura Lt BT", 10F);
            this.Label_nombre.Location = new System.Drawing.Point(92, 227);
            this.Label_nombre.Name = "Label_nombre";
            this.Label_nombre.Size = new System.Drawing.Size(61, 16);
            this.Label_nombre.TabIndex = 26;
            this.Label_nombre.Text = "Dirección";
            // 
            // textBoxUserId
            // 
            this.textBoxUserId.Location = new System.Drawing.Point(94, 191);
            this.textBoxUserId.Name = "textBoxUserId";
            this.textBoxUserId.Size = new System.Drawing.Size(644, 20);
            this.textBoxUserId.TabIndex = 25;
            // 
            // label_IdUsuario
            // 
            this.label_IdUsuario.AutoSize = true;
            this.label_IdUsuario.Font = new System.Drawing.Font("Futura Lt BT", 10F);
            this.label_IdUsuario.Location = new System.Drawing.Point(91, 175);
            this.label_IdUsuario.Name = "label_IdUsuario";
            this.label_IdUsuario.Size = new System.Drawing.Size(58, 16);
            this.label_IdUsuario.TabIndex = 24;
            this.label_IdUsuario.Text = "Teléfono";
            // 
            // RegistrarCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Bisque;
            this.ClientSize = new System.Drawing.Size(829, 676);
            this.Controls.Add(this.Boton_nuevoEmpleado);
            this.Controls.Add(this.Boton_nuevoCliente);
            this.Controls.Add(this.textBoxNombre);
            this.Controls.Add(this.Label_nombre);
            this.Controls.Add(this.textBoxUserId);
            this.Controls.Add(this.label_IdUsuario);
            this.Name = "RegistrarCliente";
            this.Text = "RegistrarCliente";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Boton_nuevoEmpleado;
        private System.Windows.Forms.Button Boton_nuevoCliente;
        private System.Windows.Forms.TextBox textBoxNombre;
        private System.Windows.Forms.Label Label_nombre;
        private System.Windows.Forms.TextBox textBoxUserId;
        private System.Windows.Forms.Label label_IdUsuario;
    }
}