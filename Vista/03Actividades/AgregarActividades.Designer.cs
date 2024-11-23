using System;

namespace GenteFitApp.Vista
{
    partial class AgregarActividades
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
            this.components = new System.ComponentModel.Container();
            this.groupBoxClientes = new System.Windows.Forms.GroupBox();
            this.buttonCargar = new System.Windows.Forms.Button();
            this.buttonModificar = new System.Windows.Forms.Button();
            this.textBoxIdSala = new System.Windows.Forms.TextBox();
            this.labelIdSala = new System.Windows.Forms.Label();
            this.textBoxIdMonitor = new System.Windows.Forms.TextBox();
            this.labelIdMonitor = new System.Windows.Forms.Label();
            this.dataGridViewActividades = new System.Windows.Forms.DataGridView();
            this.idActividadDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombreDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nivelIntensidadDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.salaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.plazasDisponiblesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idMonitorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.actividadBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.genteFitDataSet1 = new GenteFitApp.GenteFitDataSet1();
            this.comboBoxSala = new System.Windows.Forms.ComboBox();
            this.buttonVolver = new System.Windows.Forms.Button();
            this.comboBoxMonitor = new System.Windows.Forms.ComboBox();
            this.comboBoxNivel = new System.Windows.Forms.ComboBox();
            this.buttonUpdateActividad = new System.Windows.Forms.Button();
            this.ButtonEliminarActividad = new System.Windows.Forms.Button();
            this.labelMonitor = new System.Windows.Forms.Label();
            this.textBoxPlazasDisponibles = new System.Windows.Forms.TextBox();
            this.labelPlazasDisponibles = new System.Windows.Forms.Label();
            this.label_IdUsuario = new System.Windows.Forms.Label();
            this.labeleintensidad = new System.Windows.Forms.Label();
            this.textBoxIdActividad = new System.Windows.Forms.TextBox();
            this.textBoxDescripcion = new System.Windows.Forms.TextBox();
            this.Label_nombre = new System.Windows.Forms.Label();
            this.label_descripcion = new System.Windows.Forms.Label();
            this.textBoxNombreActividad = new System.Windows.Forms.TextBox();
            this.labelsala = new System.Windows.Forms.Label();
            this.actividadTableAdapter = new GenteFitApp.GenteFitDataSet1TableAdapters.ActividadTableAdapter();
            this.groupBoxClientes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewActividades)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.actividadBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.genteFitDataSet1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxClientes
            // 
            this.groupBoxClientes.BackColor = System.Drawing.Color.SandyBrown;
            this.groupBoxClientes.Controls.Add(this.buttonCargar);
            this.groupBoxClientes.Controls.Add(this.buttonModificar);
            this.groupBoxClientes.Controls.Add(this.textBoxIdSala);
            this.groupBoxClientes.Controls.Add(this.labelIdSala);
            this.groupBoxClientes.Controls.Add(this.textBoxIdMonitor);
            this.groupBoxClientes.Controls.Add(this.labelIdMonitor);
            this.groupBoxClientes.Controls.Add(this.dataGridViewActividades);
            this.groupBoxClientes.Controls.Add(this.comboBoxSala);
            this.groupBoxClientes.Controls.Add(this.buttonVolver);
            this.groupBoxClientes.Controls.Add(this.comboBoxMonitor);
            this.groupBoxClientes.Controls.Add(this.comboBoxNivel);
            this.groupBoxClientes.Controls.Add(this.buttonUpdateActividad);
            this.groupBoxClientes.Controls.Add(this.ButtonEliminarActividad);
            this.groupBoxClientes.Controls.Add(this.labelMonitor);
            this.groupBoxClientes.Controls.Add(this.textBoxPlazasDisponibles);
            this.groupBoxClientes.Controls.Add(this.labelPlazasDisponibles);
            this.groupBoxClientes.Controls.Add(this.label_IdUsuario);
            this.groupBoxClientes.Controls.Add(this.labeleintensidad);
            this.groupBoxClientes.Controls.Add(this.textBoxIdActividad);
            this.groupBoxClientes.Controls.Add(this.textBoxDescripcion);
            this.groupBoxClientes.Controls.Add(this.Label_nombre);
            this.groupBoxClientes.Controls.Add(this.label_descripcion);
            this.groupBoxClientes.Controls.Add(this.textBoxNombreActividad);
            this.groupBoxClientes.Controls.Add(this.labelsala);
            this.groupBoxClientes.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.groupBoxClientes.Location = new System.Drawing.Point(24, 65);
            this.groupBoxClientes.Name = "groupBoxClientes";
            this.groupBoxClientes.Size = new System.Drawing.Size(774, 609);
            this.groupBoxClientes.TabIndex = 11;
            this.groupBoxClientes.TabStop = false;
            this.groupBoxClientes.Text = "Agregar actividad";
            this.groupBoxClientes.Enter += new System.EventHandler(this.groupBoxClientes_Enter);
            // 
            // buttonCargar
            // 
            this.buttonCargar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.buttonCargar.Location = new System.Drawing.Point(97, 64);
            this.buttonCargar.Name = "buttonCargar";
            this.buttonCargar.Size = new System.Drawing.Size(176, 32);
            this.buttonCargar.TabIndex = 49;
            this.buttonCargar.Text = "Cargar";
            this.buttonCargar.UseVisualStyleBackColor = true;
            this.buttonCargar.Click += new System.EventHandler(this.buttonCargar_Click);
            // 
            // buttonModificar
            // 
            this.buttonModificar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.buttonModificar.Location = new System.Drawing.Point(209, 543);
            this.buttonModificar.Name = "buttonModificar";
            this.buttonModificar.Size = new System.Drawing.Size(176, 32);
            this.buttonModificar.TabIndex = 48;
            this.buttonModificar.Text = "Modficar";
            this.buttonModificar.UseVisualStyleBackColor = true;
            this.buttonModificar.Click += new System.EventHandler(this.buttonModificar_Click);
            // 
            // textBoxIdSala
            // 
            this.textBoxIdSala.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.textBoxIdSala.Location = new System.Drawing.Point(155, 427);
            this.textBoxIdSala.Multiline = true;
            this.textBoxIdSala.Name = "textBoxIdSala";
            this.textBoxIdSala.Size = new System.Drawing.Size(48, 24);
            this.textBoxIdSala.TabIndex = 47;
            // 
            // labelIdSala
            // 
            this.labelIdSala.AutoSize = true;
            this.labelIdSala.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.labelIdSala.Location = new System.Drawing.Point(152, 402);
            this.labelIdSala.Name = "labelIdSala";
            this.labelIdSala.Size = new System.Drawing.Size(51, 17);
            this.labelIdSala.TabIndex = 46;
            this.labelIdSala.Text = "Id Sala";
            // 
            // textBoxIdMonitor
            // 
            this.textBoxIdMonitor.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.textBoxIdMonitor.Location = new System.Drawing.Point(291, 482);
            this.textBoxIdMonitor.Multiline = true;
            this.textBoxIdMonitor.Name = "textBoxIdMonitor";
            this.textBoxIdMonitor.Size = new System.Drawing.Size(71, 24);
            this.textBoxIdMonitor.TabIndex = 45;
            this.textBoxIdMonitor.TextChanged += new System.EventHandler(this.textBoxIdMonitor_TextChanged);
            // 
            // labelIdMonitor
            // 
            this.labelIdMonitor.AutoSize = true;
            this.labelIdMonitor.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.labelIdMonitor.Location = new System.Drawing.Point(288, 457);
            this.labelIdMonitor.Name = "labelIdMonitor";
            this.labelIdMonitor.Size = new System.Drawing.Size(70, 17);
            this.labelIdMonitor.TabIndex = 44;
            this.labelIdMonitor.Text = "Id Monitor";
            // 
            // dataGridViewActividades
            // 
            this.dataGridViewActividades.AllowUserToAddRows = false;
            this.dataGridViewActividades.AllowUserToDeleteRows = false;
            this.dataGridViewActividades.AutoGenerateColumns = false;
            this.dataGridViewActividades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewActividades.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idActividadDataGridViewTextBoxColumn,
            this.nombreDataGridViewTextBoxColumn,
            this.descripcionDataGridViewTextBoxColumn,
            this.nivelIntensidadDataGridViewTextBoxColumn,
            this.salaDataGridViewTextBoxColumn,
            this.plazasDisponiblesDataGridViewTextBoxColumn,
            this.idMonitorDataGridViewTextBoxColumn});
            this.dataGridViewActividades.DataSource = this.actividadBindingSource;
            this.dataGridViewActividades.Location = new System.Drawing.Point(25, 102);
            this.dataGridViewActividades.Name = "dataGridViewActividades";
            this.dataGridViewActividades.ReadOnly = true;
            this.dataGridViewActividades.Size = new System.Drawing.Size(723, 135);
            this.dataGridViewActividades.TabIndex = 43;
            this.dataGridViewActividades.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewActividades_CellContentClick);
            // 
            // idActividadDataGridViewTextBoxColumn
            // 
            this.idActividadDataGridViewTextBoxColumn.DataPropertyName = "idActividad";
            this.idActividadDataGridViewTextBoxColumn.HeaderText = "idActividad";
            this.idActividadDataGridViewTextBoxColumn.Name = "idActividadDataGridViewTextBoxColumn";
            this.idActividadDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nombreDataGridViewTextBoxColumn
            // 
            this.nombreDataGridViewTextBoxColumn.DataPropertyName = "nombre";
            this.nombreDataGridViewTextBoxColumn.HeaderText = "nombre";
            this.nombreDataGridViewTextBoxColumn.Name = "nombreDataGridViewTextBoxColumn";
            this.nombreDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // descripcionDataGridViewTextBoxColumn
            // 
            this.descripcionDataGridViewTextBoxColumn.DataPropertyName = "descripcion";
            this.descripcionDataGridViewTextBoxColumn.HeaderText = "descripcion";
            this.descripcionDataGridViewTextBoxColumn.Name = "descripcionDataGridViewTextBoxColumn";
            this.descripcionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nivelIntensidadDataGridViewTextBoxColumn
            // 
            this.nivelIntensidadDataGridViewTextBoxColumn.DataPropertyName = "nivelIntensidad";
            this.nivelIntensidadDataGridViewTextBoxColumn.HeaderText = "nivelIntensidad";
            this.nivelIntensidadDataGridViewTextBoxColumn.Name = "nivelIntensidadDataGridViewTextBoxColumn";
            this.nivelIntensidadDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // salaDataGridViewTextBoxColumn
            // 
            this.salaDataGridViewTextBoxColumn.DataPropertyName = "sala";
            this.salaDataGridViewTextBoxColumn.HeaderText = "sala";
            this.salaDataGridViewTextBoxColumn.Name = "salaDataGridViewTextBoxColumn";
            this.salaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // plazasDisponiblesDataGridViewTextBoxColumn
            // 
            this.plazasDisponiblesDataGridViewTextBoxColumn.DataPropertyName = "plazasDisponibles";
            this.plazasDisponiblesDataGridViewTextBoxColumn.HeaderText = "plazasDisponibles";
            this.plazasDisponiblesDataGridViewTextBoxColumn.Name = "plazasDisponiblesDataGridViewTextBoxColumn";
            this.plazasDisponiblesDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // idMonitorDataGridViewTextBoxColumn
            // 
            this.idMonitorDataGridViewTextBoxColumn.DataPropertyName = "idMonitor";
            this.idMonitorDataGridViewTextBoxColumn.HeaderText = "idMonitor";
            this.idMonitorDataGridViewTextBoxColumn.Name = "idMonitorDataGridViewTextBoxColumn";
            this.idMonitorDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // actividadBindingSource
            // 
            this.actividadBindingSource.DataMember = "Actividad";
            this.actividadBindingSource.DataSource = this.genteFitDataSet1;
            // 
            // genteFitDataSet1
            // 
            this.genteFitDataSet1.DataSetName = "GenteFitDataSet1";
            this.genteFitDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // comboBoxSala
            // 
            this.comboBoxSala.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.comboBoxSala.FormattingEnabled = true;
            this.comboBoxSala.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            this.comboBoxSala.Location = new System.Drawing.Point(23, 427);
            this.comboBoxSala.Name = "comboBoxSala";
            this.comboBoxSala.Size = new System.Drawing.Size(126, 24);
            this.comboBoxSala.TabIndex = 42;
            this.comboBoxSala.Text = "Elegir sala";
            this.comboBoxSala.SelectedIndexChanged += new System.EventHandler(this.comboBoxSala_SelectedIndexChanged);
            // 
            // buttonVolver
            // 
            this.buttonVolver.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.buttonVolver.Location = new System.Drawing.Point(23, 543);
            this.buttonVolver.Name = "buttonVolver";
            this.buttonVolver.Size = new System.Drawing.Size(176, 32);
            this.buttonVolver.TabIndex = 41;
            this.buttonVolver.Text = "Volver";
            this.buttonVolver.UseVisualStyleBackColor = true;
            this.buttonVolver.Click += new System.EventHandler(this.buttonVolver_Click);
            // 
            // comboBoxMonitor
            // 
            this.comboBoxMonitor.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.comboBoxMonitor.FormattingEnabled = true;
            this.comboBoxMonitor.Location = new System.Drawing.Point(23, 482);
            this.comboBoxMonitor.Name = "comboBoxMonitor";
            this.comboBoxMonitor.Size = new System.Drawing.Size(262, 24);
            this.comboBoxMonitor.TabIndex = 40;
            this.comboBoxMonitor.Text = "Elegir monitor";
            this.comboBoxMonitor.SelectedIndexChanged += new System.EventHandler(this.comboBoxMonitor_SelectedIndexChanged);
            // 
            // comboBoxNivel
            // 
            this.comboBoxNivel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.comboBoxNivel.FormattingEnabled = true;
            this.comboBoxNivel.Items.AddRange(new object[] {
            "BAJO",
            "MEDIO",
            "ALTO"});
            this.comboBoxNivel.Location = new System.Drawing.Point(25, 375);
            this.comboBoxNivel.Name = "comboBoxNivel";
            this.comboBoxNivel.Size = new System.Drawing.Size(121, 24);
            this.comboBoxNivel.TabIndex = 39;
            this.comboBoxNivel.Text = "Elegir nivel";
            this.comboBoxNivel.SelectedIndexChanged += new System.EventHandler(this.comboBoxNivel_SelectedIndexChanged);
            // 
            // buttonUpdateActividad
            // 
            this.buttonUpdateActividad.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.buttonUpdateActividad.Location = new System.Drawing.Point(391, 543);
            this.buttonUpdateActividad.Name = "buttonUpdateActividad";
            this.buttonUpdateActividad.Size = new System.Drawing.Size(176, 32);
            this.buttonUpdateActividad.TabIndex = 38;
            this.buttonUpdateActividad.Text = "Guardar";
            this.buttonUpdateActividad.UseVisualStyleBackColor = true;
            this.buttonUpdateActividad.Click += new System.EventHandler(this.buttonUpdateActividad_Click);
            // 
            // ButtonEliminarActividad
            // 
            this.ButtonEliminarActividad.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.ButtonEliminarActividad.Location = new System.Drawing.Point(573, 543);
            this.ButtonEliminarActividad.Name = "ButtonEliminarActividad";
            this.ButtonEliminarActividad.Size = new System.Drawing.Size(176, 32);
            this.ButtonEliminarActividad.TabIndex = 24;
            this.ButtonEliminarActividad.Text = "Eliminar";
            this.ButtonEliminarActividad.UseVisualStyleBackColor = true;
            this.ButtonEliminarActividad.Click += new System.EventHandler(this.buttonEliminarActividad_Click);
            // 
            // labelMonitor
            // 
            this.labelMonitor.AutoSize = true;
            this.labelMonitor.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.labelMonitor.Location = new System.Drawing.Point(22, 462);
            this.labelMonitor.Name = "labelMonitor";
            this.labelMonitor.Size = new System.Drawing.Size(55, 17);
            this.labelMonitor.TabIndex = 35;
            this.labelMonitor.Text = "Monitor";
            // 
            // textBoxPlazasDisponibles
            // 
            this.textBoxPlazasDisponibles.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.textBoxPlazasDisponibles.Location = new System.Drawing.Point(212, 427);
            this.textBoxPlazasDisponibles.Multiline = true;
            this.textBoxPlazasDisponibles.Name = "textBoxPlazasDisponibles";
            this.textBoxPlazasDisponibles.Size = new System.Drawing.Size(71, 24);
            this.textBoxPlazasDisponibles.TabIndex = 34;
            // 
            // labelPlazasDisponibles
            // 
            this.labelPlazasDisponibles.AutoSize = true;
            this.labelPlazasDisponibles.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.labelPlazasDisponibles.Location = new System.Drawing.Point(209, 402);
            this.labelPlazasDisponibles.Name = "labelPlazasDisponibles";
            this.labelPlazasDisponibles.Size = new System.Drawing.Size(125, 17);
            this.labelPlazasDisponibles.TabIndex = 33;
            this.labelPlazasDisponibles.Text = "Plazas disponibles";
            // 
            // label_IdUsuario
            // 
            this.label_IdUsuario.AutoSize = true;
            this.label_IdUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label_IdUsuario.Location = new System.Drawing.Point(21, 44);
            this.label_IdUsuario.Name = "label_IdUsuario";
            this.label_IdUsuario.Size = new System.Drawing.Size(160, 17);
            this.label_IdUsuario.TabIndex = 23;
            this.label_IdUsuario.Text = "idActividad (No rellenar)";
            this.label_IdUsuario.Click += new System.EventHandler(this.label_IdUsuario_Click);
            // 
            // labeleintensidad
            // 
            this.labeleintensidad.AutoSize = true;
            this.labeleintensidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.labeleintensidad.Location = new System.Drawing.Point(22, 355);
            this.labeleintensidad.Name = "labeleintensidad";
            this.labeleintensidad.Size = new System.Drawing.Size(128, 17);
            this.labeleintensidad.TabIndex = 31;
            this.labeleintensidad.Text = "Nivel de intensidad";
            this.labeleintensidad.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // textBoxIdActividad
            // 
            this.textBoxIdActividad.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.textBoxIdActividad.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.textBoxIdActividad.Location = new System.Drawing.Point(23, 64);
            this.textBoxIdActividad.Multiline = true;
            this.textBoxIdActividad.Name = "textBoxIdActividad";
            this.textBoxIdActividad.Size = new System.Drawing.Size(54, 25);
            this.textBoxIdActividad.TabIndex = 24;
            this.textBoxIdActividad.TextChanged += new System.EventHandler(this.textBoxIdActividad_TextChanged);
            // 
            // textBoxDescripcion
            // 
            this.textBoxDescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.textBoxDescripcion.Location = new System.Drawing.Point(25, 312);
            this.textBoxDescripcion.Multiline = true;
            this.textBoxDescripcion.Name = "textBoxDescripcion";
            this.textBoxDescripcion.Size = new System.Drawing.Size(727, 40);
            this.textBoxDescripcion.TabIndex = 30;
            this.textBoxDescripcion.TextChanged += new System.EventHandler(this.textBoxDescripcion_TextChanged);
            // 
            // Label_nombre
            // 
            this.Label_nombre.AutoSize = true;
            this.Label_nombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Label_nombre.Location = new System.Drawing.Point(22, 240);
            this.Label_nombre.Name = "Label_nombre";
            this.Label_nombre.Size = new System.Drawing.Size(118, 17);
            this.Label_nombre.TabIndex = 25;
            this.Label_nombre.Text = "Nombre actividad";
            // 
            // label_descripcion
            // 
            this.label_descripcion.AutoSize = true;
            this.label_descripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label_descripcion.Location = new System.Drawing.Point(22, 292);
            this.label_descripcion.Name = "label_descripcion";
            this.label_descripcion.Size = new System.Drawing.Size(142, 17);
            this.label_descripcion.TabIndex = 29;
            this.label_descripcion.Text = "Descripcion actividad";
            this.label_descripcion.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // textBoxNombreActividad
            // 
            this.textBoxNombreActividad.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.textBoxNombreActividad.Location = new System.Drawing.Point(25, 260);
            this.textBoxNombreActividad.Multiline = true;
            this.textBoxNombreActividad.Name = "textBoxNombreActividad";
            this.textBoxNombreActividad.Size = new System.Drawing.Size(726, 25);
            this.textBoxNombreActividad.TabIndex = 26;
            this.textBoxNombreActividad.TextChanged += new System.EventHandler(this.textBoxNombreActividad_TextChanged);
            // 
            // labelsala
            // 
            this.labelsala.AutoSize = true;
            this.labelsala.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.labelsala.Location = new System.Drawing.Point(21, 410);
            this.labelsala.Name = "labelsala";
            this.labelsala.Size = new System.Drawing.Size(36, 17);
            this.labelsala.TabIndex = 27;
            this.labelsala.Text = "Sala";
            // 
            // actividadTableAdapter
            // 
            this.actividadTableAdapter.ClearBeforeFill = true;
            // 
            // AgregarActividades
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Bisque;
            this.ClientSize = new System.Drawing.Size(812, 691);
            this.Controls.Add(this.groupBoxClientes);
            this.Name = "AgregarActividades";
            this.Text = "Nueva actividad";
            this.Load += new System.EventHandler(this.AgregarActividades_Load);
            this.groupBoxClientes.ResumeLayout(false);
            this.groupBoxClientes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewActividades)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.actividadBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.genteFitDataSet1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxClientes;
        private System.Windows.Forms.Label label_IdUsuario;
        private System.Windows.Forms.Label labeleintensidad;
        private System.Windows.Forms.TextBox textBoxIdActividad;
        private System.Windows.Forms.TextBox textBoxDescripcion;
        private System.Windows.Forms.Label Label_nombre;
        private System.Windows.Forms.Label label_descripcion;
        private System.Windows.Forms.TextBox textBoxNombreActividad;
        private System.Windows.Forms.Label labelsala;
        private System.Windows.Forms.TextBox textBoxPlazasDisponibles;
        private System.Windows.Forms.Label labelPlazasDisponibles;
        private System.Windows.Forms.Label labelMonitor;
        private System.Windows.Forms.Button ButtonEliminarActividad;
        private System.Windows.Forms.Button buttonUpdateActividad;
        private System.Windows.Forms.ComboBox comboBoxNivel;
        private System.Windows.Forms.ComboBox comboBoxMonitor;
        private System.Windows.Forms.ComboBox comboBoxSala;
        private System.Windows.Forms.Button buttonVolver;
        private System.Windows.Forms.DataGridView dataGridViewActividades;
        private GenteFitDataSet1 genteFitDataSet1;
        private System.Windows.Forms.BindingSource actividadBindingSource;
        private GenteFitDataSet1TableAdapters.ActividadTableAdapter actividadTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn idActividadDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nivelIntensidadDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn salaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn plazasDisponiblesDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idMonitorDataGridViewTextBoxColumn;
        private System.Windows.Forms.TextBox textBoxIdMonitor;
        private System.Windows.Forms.Label labelIdMonitor;
        private System.Windows.Forms.TextBox textBoxIdSala;
        private System.Windows.Forms.Label labelIdSala;
        private System.Windows.Forms.Button buttonCargar;
        private System.Windows.Forms.Button buttonModificar;
    }
}