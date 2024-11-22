namespace GenteFitApp.Vista._02Clientes
{
    partial class CambiarPassword
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CambiarPassword));
            this.textBoxContraseñaActual = new System.Windows.Forms.TextBox();
            this.labelContraseñaActual = new System.Windows.Forms.Label();
            this.textBoxContraseñaNueva = new System.Windows.Forms.TextBox();
            this.labelNuevaContraseña = new System.Windows.Forms.Label();
            this.textBoxConfirmarContraseña = new System.Windows.Forms.TextBox();
            this.labelConfirmarContraseña = new System.Windows.Forms.Label();
            this.buttonActualizar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxContraseñaActual
            // 
            this.textBoxContraseñaActual.Font = new System.Drawing.Font("Futura Lt BT", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxContraseñaActual.Location = new System.Drawing.Point(29, 62);
            this.textBoxContraseñaActual.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxContraseñaActual.Name = "textBoxContraseñaActual";
            this.textBoxContraseñaActual.Size = new System.Drawing.Size(256, 28);
            this.textBoxContraseñaActual.TabIndex = 18;
            // 
            // labelContraseñaActual
            // 
            this.labelContraseñaActual.AutoSize = true;
            this.labelContraseñaActual.Font = new System.Drawing.Font("Futura Lt BT", 10F);
            this.labelContraseñaActual.Location = new System.Drawing.Point(26, 40);
            this.labelContraseñaActual.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelContraseñaActual.Name = "labelContraseñaActual";
            this.labelContraseñaActual.Size = new System.Drawing.Size(137, 20);
            this.labelContraseñaActual.TabIndex = 19;
            this.labelContraseñaActual.Text = "Contraseña actual";
            // 
            // textBoxContraseñaNueva
            // 
            this.textBoxContraseñaNueva.Font = new System.Drawing.Font("Futura Lt BT", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxContraseñaNueva.Location = new System.Drawing.Point(29, 135);
            this.textBoxContraseñaNueva.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxContraseñaNueva.Name = "textBoxContraseñaNueva";
            this.textBoxContraseñaNueva.Size = new System.Drawing.Size(256, 28);
            this.textBoxContraseñaNueva.TabIndex = 20;
            // 
            // labelNuevaContraseña
            // 
            this.labelNuevaContraseña.AutoSize = true;
            this.labelNuevaContraseña.Font = new System.Drawing.Font("Futura Lt BT", 10F);
            this.labelNuevaContraseña.Location = new System.Drawing.Point(26, 113);
            this.labelNuevaContraseña.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelNuevaContraseña.Name = "labelNuevaContraseña";
            this.labelNuevaContraseña.Size = new System.Drawing.Size(140, 20);
            this.labelNuevaContraseña.TabIndex = 21;
            this.labelNuevaContraseña.Text = "Nueva Contraseña";
            // 
            // textBoxConfirmarContraseña
            // 
            this.textBoxConfirmarContraseña.Font = new System.Drawing.Font("Futura Lt BT", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxConfirmarContraseña.Location = new System.Drawing.Point(29, 203);
            this.textBoxConfirmarContraseña.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxConfirmarContraseña.Name = "textBoxConfirmarContraseña";
            this.textBoxConfirmarContraseña.Size = new System.Drawing.Size(256, 28);
            this.textBoxConfirmarContraseña.TabIndex = 22;
            // 
            // labelConfirmarContraseña
            // 
            this.labelConfirmarContraseña.AutoSize = true;
            this.labelConfirmarContraseña.Font = new System.Drawing.Font("Futura Lt BT", 10F);
            this.labelConfirmarContraseña.Location = new System.Drawing.Point(26, 181);
            this.labelConfirmarContraseña.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelConfirmarContraseña.Name = "labelConfirmarContraseña";
            this.labelConfirmarContraseña.Size = new System.Drawing.Size(207, 20);
            this.labelConfirmarContraseña.TabIndex = 23;
            this.labelConfirmarContraseña.Text = "Confirmar nueva contraseña";
            // 
            // buttonActualizar
            // 
            this.buttonActualizar.Font = new System.Drawing.Font("Futura Lt BT", 12F);
            this.buttonActualizar.Location = new System.Drawing.Point(30, 273);
            this.buttonActualizar.Margin = new System.Windows.Forms.Padding(4);
            this.buttonActualizar.Name = "buttonActualizar";
            this.buttonActualizar.Size = new System.Drawing.Size(256, 33);
            this.buttonActualizar.TabIndex = 24;
            this.buttonActualizar.Text = "Actualizar";
            this.buttonActualizar.UseVisualStyleBackColor = true;
            this.buttonActualizar.Click += new System.EventHandler(this.buttonActualizar_Click);
            // 
            // CambiarPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Bisque;
            this.ClientSize = new System.Drawing.Size(360, 345);
            this.Controls.Add(this.buttonActualizar);
            this.Controls.Add(this.textBoxConfirmarContraseña);
            this.Controls.Add(this.labelConfirmarContraseña);
            this.Controls.Add(this.textBoxContraseñaNueva);
            this.Controls.Add(this.labelNuevaContraseña);
            this.Controls.Add(this.textBoxContraseñaActual);
            this.Controls.Add(this.labelContraseñaActual);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CambiarPassword";
            this.Text = "Cambiar contraseña";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxContraseñaActual;
        private System.Windows.Forms.Label labelContraseñaActual;
        private System.Windows.Forms.TextBox textBoxContraseñaNueva;
        private System.Windows.Forms.Label labelNuevaContraseña;
        private System.Windows.Forms.TextBox textBoxConfirmarContraseña;
        private System.Windows.Forms.Label labelConfirmarContraseña;
        private System.Windows.Forms.Button buttonActualizar;
    }
}