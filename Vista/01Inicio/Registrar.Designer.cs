using System;

namespace GenteFitApp.Vista
{
    partial class Registrar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Registrar));
            this.textBoxNombre = new System.Windows.Forms.TextBox();
            this.Label_nombre = new System.Windows.Forms.Label();
            this.textBoxUserId = new System.Windows.Forms.TextBox();
            this.label_IdUsuario = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.titulopagina = new System.Windows.Forms.Label();
            this.textBoxcontraseña = new System.Windows.Forms.TextBox();
            this.labelcontraseña = new System.Windows.Forms.Label();
            this.textBoxApellidos = new System.Windows.Forms.TextBox();
            this.label_apellidos = new System.Windows.Forms.Label();
            this.textBoxemail = new System.Windows.Forms.TextBox();
            this.labelemail = new System.Windows.Forms.Label();
            this.Boton_nuevoEmpleado = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxNombre
            // 
            this.textBoxNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.textBoxNombre.Location = new System.Drawing.Point(72, 344);
            this.textBoxNombre.Name = "textBoxNombre";
            this.textBoxNombre.Size = new System.Drawing.Size(644, 23);
            this.textBoxNombre.TabIndex = 2;
            // 
            // Label_nombre
            // 
            this.Label_nombre.AutoSize = true;
            this.Label_nombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Label_nombre.Location = new System.Drawing.Point(70, 328);
            this.Label_nombre.Name = "Label_nombre";
            this.Label_nombre.Size = new System.Drawing.Size(58, 17);
            this.Label_nombre.TabIndex = 11;
            this.Label_nombre.Text = "Nombre";
            // 
            // textBoxUserId
            // 
            this.textBoxUserId.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.textBoxUserId.Location = new System.Drawing.Point(72, 292);
            this.textBoxUserId.Name = "textBoxUserId";
            this.textBoxUserId.Size = new System.Drawing.Size(644, 23);
            this.textBoxUserId.TabIndex = 1;
            // 
            // label_IdUsuario
            // 
            this.label_IdUsuario.AutoSize = true;
            this.label_IdUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label_IdUsuario.Location = new System.Drawing.Point(70, 276);
            this.label_IdUsuario.Name = "label_IdUsuario";
            this.label_IdUsuario.Size = new System.Drawing.Size(57, 17);
            this.label_IdUsuario.TabIndex = 9;
            this.label_IdUsuario.Text = "Usuario";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::GenteFitApp.Properties.Resources.Logo_GenteFit_Negro;
            this.pictureBox1.Location = new System.Drawing.Point(319, 102);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(136, 122);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 16;
            this.pictureBox1.TabStop = false;
            // 
            // titulopagina
            // 
            this.titulopagina.AutoSize = true;
            this.titulopagina.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titulopagina.Location = new System.Drawing.Point(213, 54);
            this.titulopagina.Name = "titulopagina";
            this.titulopagina.Size = new System.Drawing.Size(397, 42);
            this.titulopagina.TabIndex = 15;
            this.titulopagina.Text = "Benvenid@ a GenteFit";
            this.titulopagina.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxcontraseña
            // 
            this.textBoxcontraseña.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.textBoxcontraseña.Location = new System.Drawing.Point(71, 502);
            this.textBoxcontraseña.Name = "textBoxcontraseña";
            this.textBoxcontraseña.Size = new System.Drawing.Size(644, 23);
            this.textBoxcontraseña.TabIndex = 5;
            // 
            // labelcontraseña
            // 
            this.labelcontraseña.AutoSize = true;
            this.labelcontraseña.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.labelcontraseña.Location = new System.Drawing.Point(70, 486);
            this.labelcontraseña.Name = "labelcontraseña";
            this.labelcontraseña.Size = new System.Drawing.Size(81, 17);
            this.labelcontraseña.TabIndex = 17;
            this.labelcontraseña.Text = "Contraseña";
            // 
            // textBoxApellidos
            // 
            this.textBoxApellidos.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.textBoxApellidos.Location = new System.Drawing.Point(72, 396);
            this.textBoxApellidos.Name = "textBoxApellidos";
            this.textBoxApellidos.Size = new System.Drawing.Size(644, 23);
            this.textBoxApellidos.TabIndex = 3;
            // 
            // label_apellidos
            // 
            this.label_apellidos.AutoSize = true;
            this.label_apellidos.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label_apellidos.Location = new System.Drawing.Point(70, 380);
            this.label_apellidos.Name = "label_apellidos";
            this.label_apellidos.Size = new System.Drawing.Size(65, 17);
            this.label_apellidos.TabIndex = 19;
            this.label_apellidos.Text = "Apellidos";
            this.label_apellidos.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // textBoxemail
            // 
            this.textBoxemail.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.textBoxemail.Location = new System.Drawing.Point(72, 449);
            this.textBoxemail.Name = "textBoxemail";
            this.textBoxemail.Size = new System.Drawing.Size(644, 23);
            this.textBoxemail.TabIndex = 4;
            this.textBoxemail.TextChanged += new System.EventHandler(this.textBoxemail_TextChanged);
            // 
            // labelemail
            // 
            this.labelemail.AutoSize = true;
            this.labelemail.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.labelemail.Location = new System.Drawing.Point(70, 433);
            this.labelemail.Name = "labelemail";
            this.labelemail.Size = new System.Drawing.Size(47, 17);
            this.labelemail.TabIndex = 21;
            this.labelemail.Text = "E-mail";
            this.labelemail.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Boton_nuevoEmpleado
            // 
            this.Boton_nuevoEmpleado.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Boton_nuevoEmpleado.Location = new System.Drawing.Point(538, 562);
            this.Boton_nuevoEmpleado.Name = "Boton_nuevoEmpleado";
            this.Boton_nuevoEmpleado.Size = new System.Drawing.Size(176, 27);
            this.Boton_nuevoEmpleado.TabIndex = 7;
            this.Boton_nuevoEmpleado.Text = "Registrar";
            this.Boton_nuevoEmpleado.UseVisualStyleBackColor = true;
            this.Boton_nuevoEmpleado.Click += new System.EventHandler(this.Boton_nuevoEmpleado_Click);
            // 
            // Registrar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Bisque;
            this.ClientSize = new System.Drawing.Size(797, 644);
            this.Controls.Add(this.Boton_nuevoEmpleado);
            this.Controls.Add(this.textBoxemail);
            this.Controls.Add(this.labelemail);
            this.Controls.Add(this.textBoxApellidos);
            this.Controls.Add(this.label_apellidos);
            this.Controls.Add(this.textBoxcontraseña);
            this.Controls.Add(this.labelcontraseña);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.titulopagina);
            this.Controls.Add(this.textBoxNombre);
            this.Controls.Add(this.Label_nombre);
            this.Controls.Add(this.textBoxUserId);
            this.Controls.Add(this.label_IdUsuario);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Registrar";
            this.Text = "Registrar";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }



        #endregion
        private System.Windows.Forms.TextBox textBoxNombre;
        private System.Windows.Forms.Label Label_nombre;
        private System.Windows.Forms.TextBox textBoxUserId;
        private System.Windows.Forms.Label label_IdUsuario;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label titulopagina;
        private System.Windows.Forms.TextBox textBoxcontraseña;
        private System.Windows.Forms.Label labelcontraseña;
        private System.Windows.Forms.TextBox textBoxApellidos;
        private System.Windows.Forms.Label label_apellidos;
        private System.Windows.Forms.TextBox textBoxemail;
        private System.Windows.Forms.Label labelemail;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label labelDir;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button Boton_nuevoEmpleado;
    }
}