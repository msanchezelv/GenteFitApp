namespace GenteFitApp.Vista
{
    partial class Inicio
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
            this.titulopagina = new System.Windows.Forms.Label();
            this.label_IdUsuario = new System.Windows.Forms.Label();
            this.Box_UserId = new System.Windows.Forms.TextBox();
            this.BoxPassword = new System.Windows.Forms.TextBox();
            this.Label_contraseña = new System.Windows.Forms.Label();
            this.Boton_Entrar = new System.Windows.Forms.Button();
            this.linkContraseñaOlvidada = new System.Windows.Forms.LinkLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // titulopagina
            // 
            this.titulopagina.AutoSize = true;
            this.titulopagina.Font = new System.Drawing.Font("Futura Lt BT", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titulopagina.Location = new System.Drawing.Point(305, 95);
            this.titulopagina.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.titulopagina.Name = "titulopagina";
            this.titulopagina.Size = new System.Drawing.Size(467, 56);
            this.titulopagina.TabIndex = 0;
            this.titulopagina.Text = "Benvenid@ a GenteFit";
            this.titulopagina.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            
            // 
            // label_IdUsuario
            // 
            this.label_IdUsuario.AutoSize = true;
            this.label_IdUsuario.Font = new System.Drawing.Font("Futura Lt BT", 14F);
            this.label_IdUsuario.Location = new System.Drawing.Point(128, 316);
            this.label_IdUsuario.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_IdUsuario.Name = "label_IdUsuario";
            this.label_IdUsuario.Size = new System.Drawing.Size(92, 29);
            this.label_IdUsuario.TabIndex = 2;
            this.label_IdUsuario.Text = "Usuario";
            // 
            // Box_UserId
            // 
            this.Box_UserId.Font = new System.Drawing.Font("Futura Lt BT", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Box_UserId.Location = new System.Drawing.Point(133, 347);
            this.Box_UserId.Margin = new System.Windows.Forms.Padding(4);
            this.Box_UserId.Name = "Box_UserId";
            this.Box_UserId.Size = new System.Drawing.Size(857, 24);
            this.Box_UserId.TabIndex = 4;
            // 
            // BoxPassword
            // 
            this.BoxPassword.Font = new System.Drawing.Font("Futura Lt BT", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BoxPassword.Location = new System.Drawing.Point(133, 431);
            this.BoxPassword.Margin = new System.Windows.Forms.Padding(4);
            this.BoxPassword.Name = "BoxPassword";
            this.BoxPassword.Size = new System.Drawing.Size(857, 24);
            this.BoxPassword.TabIndex = 6;
            // 
            // Label_contraseña
            // 
            this.Label_contraseña.AutoSize = true;
            this.Label_contraseña.Font = new System.Drawing.Font("Futura Lt BT", 14F);
            this.Label_contraseña.Location = new System.Drawing.Point(128, 400);
            this.Label_contraseña.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label_contraseña.Name = "Label_contraseña";
            this.Label_contraseña.Size = new System.Drawing.Size(130, 29);
            this.Label_contraseña.TabIndex = 5;
            this.Label_contraseña.Text = "Contraseña";
            // 
            // Boton_Entrar
            // 
            this.Boton_Entrar.Font = new System.Drawing.Font("Futura Lt BT", 12F);
            this.Boton_Entrar.Location = new System.Drawing.Point(757, 489);
            this.Boton_Entrar.Margin = new System.Windows.Forms.Padding(4);
            this.Boton_Entrar.Name = "Boton_Entrar";
            this.Boton_Entrar.Size = new System.Drawing.Size(235, 39);
            this.Boton_Entrar.TabIndex = 7;
            this.Boton_Entrar.Text = "Entrar";
            this.Boton_Entrar.UseVisualStyleBackColor = true;
            this.Boton_Entrar.Click += new System.EventHandler(this.Boton_Entrar_Click);
            // 
            // linkContraseñaOlvidada
            // 
            this.linkContraseñaOlvidada.AutoSize = true;
            this.linkContraseñaOlvidada.Location = new System.Drawing.Point(129, 459);
            this.linkContraseñaOlvidada.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.linkContraseñaOlvidada.Name = "linkContraseñaOlvidada";
            this.linkContraseñaOlvidada.Size = new System.Drawing.Size(186, 16);
            this.linkContraseñaOlvidada.TabIndex = 8;
            this.linkContraseñaOlvidada.TabStop = true;
            this.linkContraseñaOlvidada.Text = "¿Has olvidado la contraseña?";
            this.linkContraseñaOlvidada.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkContraseñaOlvidada_LinkClicked);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::GenteFitApp.Properties.Resources.Logo_GenteFit_Negro;
            this.pictureBox1.Location = new System.Drawing.Point(447, 154);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(181, 150);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // Inicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Bisque;
            this.ClientSize = new System.Drawing.Size(1124, 826);
            this.Controls.Add(this.linkContraseñaOlvidada);
            this.Controls.Add(this.Boton_Entrar);
            this.Controls.Add(this.BoxPassword);
            this.Controls.Add(this.Label_contraseña);
            this.Controls.Add(this.Box_UserId);
            this.Controls.Add(this.label_IdUsuario);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.titulopagina);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Inicio";
            this.Text = "Gente Fit";
            this.Load += new System.EventHandler(this.Inicio_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label titulopagina;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label_IdUsuario;
        private System.Windows.Forms.TextBox Box_UserId;
        private System.Windows.Forms.TextBox BoxPassword;
        private System.Windows.Forms.Label Label_contraseña;
        private System.Windows.Forms.Button Boton_Entrar;
        private System.Windows.Forms.LinkLabel linkContraseñaOlvidada;
    }
}