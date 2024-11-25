namespace GenteFitApp.Vista._01Inicio
{
    partial class RegistrarMonitor
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegistrarMonitor));
            this.groupBoxMonitores = new System.Windows.Forms.GroupBox();
            this.buttonCargar = new System.Windows.Forms.Button();
            this.dataGridViewMonitores = new System.Windows.Forms.DataGridView();
            this.buttonGuardar = new System.Windows.Forms.Button();
            this.buttonEliminar = new System.Windows.Forms.Button();
            this.labelIdMonitor = new System.Windows.Forms.Label();
            this.textBoxIdMonitor = new System.Windows.Forms.TextBox();
            this.textBoxApellidos = new System.Windows.Forms.TextBox();
            this.labelNombre = new System.Windows.Forms.Label();
            this.labelApellidos = new System.Windows.Forms.Label();
            this.textBoxNombre = new System.Windows.Forms.TextBox();
            this.groupBoxMonitores.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMonitores)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxMonitores
            // 
            this.groupBoxMonitores.BackColor = System.Drawing.Color.Bisque;
            this.groupBoxMonitores.Controls.Add(this.buttonCargar);
            this.groupBoxMonitores.Controls.Add(this.dataGridViewMonitores);
            this.groupBoxMonitores.Controls.Add(this.buttonGuardar);
            this.groupBoxMonitores.Controls.Add(this.buttonEliminar);
            this.groupBoxMonitores.Controls.Add(this.labelIdMonitor);
            this.groupBoxMonitores.Controls.Add(this.textBoxIdMonitor);
            this.groupBoxMonitores.Controls.Add(this.textBoxApellidos);
            this.groupBoxMonitores.Controls.Add(this.labelNombre);
            this.groupBoxMonitores.Controls.Add(this.labelApellidos);
            this.groupBoxMonitores.Controls.Add(this.textBoxNombre);
            this.groupBoxMonitores.Font = new System.Drawing.Font("Futura Lt BT", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxMonitores.Location = new System.Drawing.Point(32, 18);
            this.groupBoxMonitores.Margin = new System.Windows.Forms.Padding(4);
            this.groupBoxMonitores.Name = "groupBoxMonitores";
            this.groupBoxMonitores.Padding = new System.Windows.Forms.Padding(4);
            this.groupBoxMonitores.Size = new System.Drawing.Size(1069, 623);
            this.groupBoxMonitores.TabIndex = 12;
            this.groupBoxMonitores.TabStop = false;
            this.groupBoxMonitores.Text = "Gestión de monitores";
            // 
            // buttonCargar
            // 
            this.buttonCargar.Font = new System.Drawing.Font("Futura Lt BT", 12F);
            this.buttonCargar.Location = new System.Drawing.Point(129, 79);
            this.buttonCargar.Margin = new System.Windows.Forms.Padding(4);
            this.buttonCargar.Name = "buttonCargar";
            this.buttonCargar.Size = new System.Drawing.Size(235, 39);
            this.buttonCargar.TabIndex = 49;
            this.buttonCargar.Text = "Cargar";
            this.buttonCargar.UseVisualStyleBackColor = true;
            // 
            // dataGridViewMonitores
            // 
            this.dataGridViewMonitores.AllowUserToAddRows = false;
            this.dataGridViewMonitores.AllowUserToDeleteRows = false;
            this.dataGridViewMonitores.AllowUserToResizeColumns = false;
            this.dataGridViewMonitores.AllowUserToResizeRows = false;
            this.dataGridViewMonitores.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewMonitores.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewMonitores.BackgroundColor = System.Drawing.Color.Bisque;
            this.dataGridViewMonitores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMonitores.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridViewMonitores.GridColor = System.Drawing.Color.Bisque;
            this.dataGridViewMonitores.Location = new System.Drawing.Point(33, 126);
            this.dataGridViewMonitores.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridViewMonitores.Name = "dataGridViewMonitores";
            this.dataGridViewMonitores.ReadOnly = true;
            this.dataGridViewMonitores.RowHeadersWidth = 51;
            this.dataGridViewMonitores.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            this.dataGridViewMonitores.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewMonitores.Size = new System.Drawing.Size(1001, 239);
            this.dataGridViewMonitores.TabIndex = 43;
            // 
            // buttonGuardar
            // 
            this.buttonGuardar.Font = new System.Drawing.Font("Futura Lt BT", 12F);
            this.buttonGuardar.Location = new System.Drawing.Point(33, 554);
            this.buttonGuardar.Margin = new System.Windows.Forms.Padding(4);
            this.buttonGuardar.Name = "buttonGuardar";
            this.buttonGuardar.Size = new System.Drawing.Size(235, 39);
            this.buttonGuardar.TabIndex = 38;
            this.buttonGuardar.Text = "Guardar";
            this.buttonGuardar.UseVisualStyleBackColor = true;
            // 
            // buttonEliminar
            // 
            this.buttonEliminar.Font = new System.Drawing.Font("Futura Lt BT", 12F);
            this.buttonEliminar.Location = new System.Drawing.Point(799, 554);
            this.buttonEliminar.Margin = new System.Windows.Forms.Padding(4);
            this.buttonEliminar.Name = "buttonEliminar";
            this.buttonEliminar.Size = new System.Drawing.Size(235, 39);
            this.buttonEliminar.TabIndex = 24;
            this.buttonEliminar.Text = "Eliminar";
            this.buttonEliminar.UseVisualStyleBackColor = true;
            // 
            // labelIdMonitor
            // 
            this.labelIdMonitor.AutoSize = true;
            this.labelIdMonitor.Font = new System.Drawing.Font("Futura Lt BT", 10F);
            this.labelIdMonitor.Location = new System.Drawing.Point(32, 59);
            this.labelIdMonitor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelIdMonitor.Name = "labelIdMonitor";
            this.labelIdMonitor.Size = new System.Drawing.Size(76, 20);
            this.labelIdMonitor.TabIndex = 23;
            this.labelIdMonitor.Text = "idMonitor";
            // 
            // textBoxIdMonitor
            // 
            this.textBoxIdMonitor.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.textBoxIdMonitor.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.textBoxIdMonitor.Location = new System.Drawing.Point(33, 79);
            this.textBoxIdMonitor.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxIdMonitor.Multiline = true;
            this.textBoxIdMonitor.Name = "textBoxIdMonitor";
            this.textBoxIdMonitor.Size = new System.Drawing.Size(71, 38);
            this.textBoxIdMonitor.TabIndex = 24;
            // 
            // textBoxApellidos
            // 
            this.textBoxApellidos.Font = new System.Drawing.Font("Futura Lt BT", 10F);
            this.textBoxApellidos.Location = new System.Drawing.Point(33, 471);
            this.textBoxApellidos.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxApellidos.Multiline = true;
            this.textBoxApellidos.Name = "textBoxApellidos";
            this.textBoxApellidos.Size = new System.Drawing.Size(479, 32);
            this.textBoxApellidos.TabIndex = 30;
            // 
            // labelNombre
            // 
            this.labelNombre.AutoSize = true;
            this.labelNombre.Font = new System.Drawing.Font("Futura Lt BT", 10F);
            this.labelNombre.Location = new System.Drawing.Point(29, 387);
            this.labelNombre.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelNombre.Name = "labelNombre";
            this.labelNombre.Size = new System.Drawing.Size(66, 20);
            this.labelNombre.TabIndex = 25;
            this.labelNombre.Text = "Nombre";
            // 
            // labelApellidos
            // 
            this.labelApellidos.AutoSize = true;
            this.labelApellidos.Font = new System.Drawing.Font("Futura Lt BT", 10F);
            this.labelApellidos.Location = new System.Drawing.Point(30, 451);
            this.labelApellidos.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelApellidos.Name = "labelApellidos";
            this.labelApellidos.Size = new System.Drawing.Size(72, 20);
            this.labelApellidos.TabIndex = 29;
            this.labelApellidos.Text = "Apellidos";
            this.labelApellidos.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // textBoxNombre
            // 
            this.textBoxNombre.Font = new System.Drawing.Font("Futura Lt BT", 10F);
            this.textBoxNombre.Location = new System.Drawing.Point(33, 407);
            this.textBoxNombre.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxNombre.Multiline = true;
            this.textBoxNombre.Name = "textBoxNombre";
            this.textBoxNombre.Size = new System.Drawing.Size(479, 30);
            this.textBoxNombre.TabIndex = 26;
            // 
            // RegistrarMonitor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Bisque;
            this.ClientSize = new System.Drawing.Size(1125, 665);
            this.Controls.Add(this.groupBoxMonitores);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "RegistrarMonitor";
            this.Text = "Registrar Monitor";
            this.groupBoxMonitores.ResumeLayout(false);
            this.groupBoxMonitores.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMonitores)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxMonitores;
        private System.Windows.Forms.Button buttonCargar;
        private System.Windows.Forms.DataGridView dataGridViewMonitores;
        private System.Windows.Forms.Button buttonGuardar;
        private System.Windows.Forms.Button buttonEliminar;
        private System.Windows.Forms.Label labelIdMonitor;
        private System.Windows.Forms.TextBox textBoxIdMonitor;
        private System.Windows.Forms.TextBox textBoxApellidos;
        private System.Windows.Forms.Label labelNombre;
        private System.Windows.Forms.Label labelApellidos;
        private System.Windows.Forms.TextBox textBoxNombre;
    }
}