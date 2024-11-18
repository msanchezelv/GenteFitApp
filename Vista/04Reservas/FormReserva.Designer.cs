namespace GenteFitApp.Vista._04Reservas
{
    partial class FormReserva
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormReserva));
            this.labelNombreActividad = new System.Windows.Forms.Label();
            this.labelHora = new System.Windows.Forms.Label();
            this.labelFecha = new System.Windows.Forms.Label();
            this.labelMonitor = new System.Windows.Forms.Label();
            this.labelPlazasDisponibles = new System.Windows.Forms.Label();
            this.buttonReservar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelNombreActividad
            // 
            this.labelNombreActividad.AutoSize = true;
            this.labelNombreActividad.Font = new System.Drawing.Font("Futura Lt BT", 14F);
            this.labelNombreActividad.Location = new System.Drawing.Point(39, 60);
            this.labelNombreActividad.Name = "labelNombreActividad";
            this.labelNombreActividad.Size = new System.Drawing.Size(105, 29);
            this.labelNombreActividad.TabIndex = 0;
            this.labelNombreActividad.Text = "Actividad";
            // 
            // labelHora
            // 
            this.labelHora.AutoSize = true;
            this.labelHora.Font = new System.Drawing.Font("Futura Lt BT", 14F);
            this.labelHora.Location = new System.Drawing.Point(39, 106);
            this.labelHora.Name = "labelHora";
            this.labelHora.Size = new System.Drawing.Size(64, 29);
            this.labelHora.TabIndex = 1;
            this.labelHora.Text = "Hora";
            // 
            // labelFecha
            // 
            this.labelFecha.AutoSize = true;
            this.labelFecha.Font = new System.Drawing.Font("Futura Lt BT", 14F);
            this.labelFecha.Location = new System.Drawing.Point(39, 155);
            this.labelFecha.Name = "labelFecha";
            this.labelFecha.Size = new System.Drawing.Size(74, 29);
            this.labelFecha.TabIndex = 2;
            this.labelFecha.Text = "Fecha";
            // 
            // labelMonitor
            // 
            this.labelMonitor.AutoSize = true;
            this.labelMonitor.Font = new System.Drawing.Font("Futura Lt BT", 14F);
            this.labelMonitor.Location = new System.Drawing.Point(39, 203);
            this.labelMonitor.Name = "labelMonitor";
            this.labelMonitor.Size = new System.Drawing.Size(92, 29);
            this.labelMonitor.TabIndex = 3;
            this.labelMonitor.Text = "Monitor";
            // 
            // labelPlazasDisponibles
            // 
            this.labelPlazasDisponibles.AutoSize = true;
            this.labelPlazasDisponibles.Font = new System.Drawing.Font("Futura Lt BT", 14F);
            this.labelPlazasDisponibles.Location = new System.Drawing.Point(39, 255);
            this.labelPlazasDisponibles.Name = "labelPlazasDisponibles";
            this.labelPlazasDisponibles.Size = new System.Drawing.Size(195, 29);
            this.labelPlazasDisponibles.TabIndex = 5;
            this.labelPlazasDisponibles.Text = "Plazas disponibles";
            // 
            // buttonReservar
            // 
            this.buttonReservar.Font = new System.Drawing.Font("Futura Lt BT", 12F);
            this.buttonReservar.Location = new System.Drawing.Point(44, 329);
            this.buttonReservar.Margin = new System.Windows.Forms.Padding(4);
            this.buttonReservar.Name = "buttonReservar";
            this.buttonReservar.Size = new System.Drawing.Size(235, 33);
            this.buttonReservar.TabIndex = 8;
            this.buttonReservar.Text = "Reservar";
            this.buttonReservar.UseVisualStyleBackColor = true;
            this.buttonReservar.Click += new System.EventHandler(this.buttonReservar_Click);
            // 
            // FormReserva
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Bisque;
            this.ClientSize = new System.Drawing.Size(462, 450);
            this.Controls.Add(this.buttonReservar);
            this.Controls.Add(this.labelPlazasDisponibles);
            this.Controls.Add(this.labelMonitor);
            this.Controls.Add(this.labelFecha);
            this.Controls.Add(this.labelHora);
            this.Controls.Add(this.labelNombreActividad);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormReserva";
            this.Text = "Reservar";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelNombreActividad;
        private System.Windows.Forms.Label labelHora;
        private System.Windows.Forms.Label labelFecha;
        private System.Windows.Forms.Label labelMonitor;
        private System.Windows.Forms.Label labelPlazasDisponibles;
        private System.Windows.Forms.Button buttonReservar;
    }
}