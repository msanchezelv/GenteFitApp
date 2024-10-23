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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label_IdUsuario = new System.Windows.Forms.Label();
            this.Box_UserId = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.Label_contraseña = new System.Windows.Forms.Label();
            this.Boton_Entrar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // titulopagina
            // 
            this.titulopagina.AutoSize = true;
            this.titulopagina.Font = new System.Drawing.Font("Futura Lt BT", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titulopagina.Location = new System.Drawing.Point(177, 77);
            this.titulopagina.Name = "titulopagina";
            this.titulopagina.Size = new System.Drawing.Size(369, 45);
            this.titulopagina.TabIndex = 0;
            this.titulopagina.Text = "Benvenid@ a GenteFit";
            this.titulopagina.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.titulopagina.Click += new System.EventHandler(this.label1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::GenteFitApp.Properties.Resources.Logo_GenteFit_Negro;
            this.pictureBox1.Location = new System.Drawing.Point(318, 125);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(83, 79);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // label_IdUsuario
            // 
            this.label_IdUsuario.AutoSize = true;
            this.label_IdUsuario.Font = new System.Drawing.Font("Futura Lt BT", 14F);
            this.label_IdUsuario.Location = new System.Drawing.Point(95, 263);
            this.label_IdUsuario.Name = "label_IdUsuario";
            this.label_IdUsuario.Size = new System.Drawing.Size(71, 22);
            this.label_IdUsuario.TabIndex = 2;
            this.label_IdUsuario.Text = "Usuario";
            this.label_IdUsuario.Click += new System.EventHandler(this.label2_Click);
            // 
            // Box_UserId
            // 
            this.Box_UserId.Location = new System.Drawing.Point(172, 263);
            this.Box_UserId.Name = "Box_UserId";
            this.Box_UserId.Size = new System.Drawing.Size(453, 20);
            this.Box_UserId.TabIndex = 4;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(172, 302);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(453, 20);
            this.textBox1.TabIndex = 6;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // Label_contraseña
            // 
            this.Label_contraseña.AutoSize = true;
            this.Label_contraseña.Font = new System.Drawing.Font("Futura Lt BT", 14F);
            this.Label_contraseña.Location = new System.Drawing.Point(64, 298);
            this.Label_contraseña.Name = "Label_contraseña";
            this.Label_contraseña.Size = new System.Drawing.Size(102, 22);
            this.Label_contraseña.TabIndex = 5;
            this.Label_contraseña.Text = "Contraseña";
            this.Label_contraseña.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // Boton_Entrar
            // 
            this.Boton_Entrar.Font = new System.Drawing.Font("Futura Lt BT", 12F);
            this.Boton_Entrar.Location = new System.Drawing.Point(550, 344);
            this.Boton_Entrar.Name = "Boton_Entrar";
            this.Boton_Entrar.Size = new System.Drawing.Size(75, 32);
            this.Boton_Entrar.TabIndex = 7;
            this.Boton_Entrar.Text = "Entrar";
            this.Boton_Entrar.UseVisualStyleBackColor = true;
            this.Boton_Entrar.Click += new System.EventHandler(this.Boton_Entrar_Click);
            // 
            // Inicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PeachPuff;
            this.ClientSize = new System.Drawing.Size(893, 683);
            this.Controls.Add(this.Boton_Entrar);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.Label_contraseña);
            this.Controls.Add(this.Box_UserId);
            this.Controls.Add(this.label_IdUsuario);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.titulopagina);
            this.Name = "Inicio";
            this.Text = "Inicio";
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
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label Label_contraseña;
        private System.Windows.Forms.Button Boton_Entrar;
    }
}