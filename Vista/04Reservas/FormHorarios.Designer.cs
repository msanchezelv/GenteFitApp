namespace GenteFitApp.Vista._06Horarios
{
    partial class FormHorarios
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormHorarios));
            this.horarioBindingSource3 = new System.Windows.Forms.BindingSource(this.components);
            this.genteFitDataSet1 = new GenteFitApp.GenteFitDataSet1();
            this.horarioTableAdapter1 = new GenteFitApp.GenteFitDataSet1TableAdapters.HorarioTableAdapter();
            this.horarioBindingSource4 = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridViewHorarios = new System.Windows.Forms.DataGridView();
            this.tabControlHorarios = new System.Windows.Forms.TabControl();
            this.tabPageLunes = new System.Windows.Forms.TabPage();
            this.tabPageMartes = new System.Windows.Forms.TabPage();
            this.tabPageMiercoles = new System.Windows.Forms.TabPage();
            this.tabPageJueves = new System.Windows.Forms.TabPage();
            this.tabPageViernes = new System.Windows.Forms.TabPage();
            this.tabPageSabado = new System.Windows.Forms.TabPage();
            this.tabPageDomingo = new System.Windows.Forms.TabPage();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.perfilToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reservasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consultarReservasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consultarListaDeEsperaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.comprasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sobreNosotrosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.horarioBindingSource3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.genteFitDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.horarioBindingSource4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHorarios)).BeginInit();
            this.tabControlHorarios.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // horarioBindingSource3
            // 
            this.horarioBindingSource3.DataMember = "Horario";
            this.horarioBindingSource3.DataSource = this.genteFitDataSet1;
            // 
            // genteFitDataSet1
            // 
            this.genteFitDataSet1.DataSetName = "GenteFitDataSet1";
            this.genteFitDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // horarioTableAdapter1
            // 
            this.horarioTableAdapter1.ClearBeforeFill = true;
            // 
            // horarioBindingSource4
            // 
            this.horarioBindingSource4.DataMember = "Horario";
            this.horarioBindingSource4.DataSource = this.genteFitDataSet1;
            // 
            // dataGridViewHorarios
            // 
            this.dataGridViewHorarios.BackgroundColor = System.Drawing.Color.Bisque;
            this.dataGridViewHorarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewHorarios.Location = new System.Drawing.Point(1, 45);
            this.dataGridViewHorarios.Name = "dataGridViewHorarios";
            this.dataGridViewHorarios.RowHeadersWidth = 51;
            this.dataGridViewHorarios.RowTemplate.Height = 24;
            this.dataGridViewHorarios.Size = new System.Drawing.Size(910, 386);
            this.dataGridViewHorarios.TabIndex = 0;
            this.dataGridViewHorarios.Visible = false;
            // 
            // tabControlHorarios
            // 
            this.tabControlHorarios.Controls.Add(this.tabPageLunes);
            this.tabControlHorarios.Controls.Add(this.tabPageMartes);
            this.tabControlHorarios.Controls.Add(this.tabPageMiercoles);
            this.tabControlHorarios.Controls.Add(this.tabPageJueves);
            this.tabControlHorarios.Controls.Add(this.tabPageViernes);
            this.tabControlHorarios.Controls.Add(this.tabPageSabado);
            this.tabControlHorarios.Controls.Add(this.tabPageDomingo);
            this.tabControlHorarios.Font = new System.Drawing.Font("Futura Lt BT", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControlHorarios.Location = new System.Drawing.Point(2, 45);
            this.tabControlHorarios.Margin = new System.Windows.Forms.Padding(4);
            this.tabControlHorarios.Name = "tabControlHorarios";
            this.tabControlHorarios.SelectedIndex = 0;
            this.tabControlHorarios.Size = new System.Drawing.Size(909, 545);
            this.tabControlHorarios.TabIndex = 1;
            // 
            // tabPageLunes
            // 
            this.tabPageLunes.BackColor = System.Drawing.Color.Bisque;
            this.tabPageLunes.Location = new System.Drawing.Point(4, 25);
            this.tabPageLunes.Margin = new System.Windows.Forms.Padding(4);
            this.tabPageLunes.Name = "tabPageLunes";
            this.tabPageLunes.Padding = new System.Windows.Forms.Padding(4);
            this.tabPageLunes.Size = new System.Drawing.Size(901, 516);
            this.tabPageLunes.TabIndex = 0;
            this.tabPageLunes.Text = "Lunes";
            // 
            // tabPageMartes
            // 
            this.tabPageMartes.BackColor = System.Drawing.Color.Bisque;
            this.tabPageMartes.Location = new System.Drawing.Point(4, 25);
            this.tabPageMartes.Margin = new System.Windows.Forms.Padding(4);
            this.tabPageMartes.Name = "tabPageMartes";
            this.tabPageMartes.Padding = new System.Windows.Forms.Padding(4);
            this.tabPageMartes.Size = new System.Drawing.Size(901, 516);
            this.tabPageMartes.TabIndex = 1;
            this.tabPageMartes.Text = "Martes";
            // 
            // tabPageMiercoles
            // 
            this.tabPageMiercoles.BackColor = System.Drawing.Color.Bisque;
            this.tabPageMiercoles.Location = new System.Drawing.Point(4, 25);
            this.tabPageMiercoles.Margin = new System.Windows.Forms.Padding(4);
            this.tabPageMiercoles.Name = "tabPageMiercoles";
            this.tabPageMiercoles.Size = new System.Drawing.Size(901, 516);
            this.tabPageMiercoles.TabIndex = 2;
            this.tabPageMiercoles.Text = "Miércoles";
            // 
            // tabPageJueves
            // 
            this.tabPageJueves.BackColor = System.Drawing.Color.Bisque;
            this.tabPageJueves.Location = new System.Drawing.Point(4, 25);
            this.tabPageJueves.Margin = new System.Windows.Forms.Padding(4);
            this.tabPageJueves.Name = "tabPageJueves";
            this.tabPageJueves.Size = new System.Drawing.Size(901, 516);
            this.tabPageJueves.TabIndex = 3;
            this.tabPageJueves.Text = "Jueves";
            // 
            // tabPageViernes
            // 
            this.tabPageViernes.BackColor = System.Drawing.Color.Bisque;
            this.tabPageViernes.Location = new System.Drawing.Point(4, 25);
            this.tabPageViernes.Margin = new System.Windows.Forms.Padding(4);
            this.tabPageViernes.Name = "tabPageViernes";
            this.tabPageViernes.Size = new System.Drawing.Size(901, 516);
            this.tabPageViernes.TabIndex = 4;
            this.tabPageViernes.Text = "Viernes";
            // 
            // tabPageSabado
            // 
            this.tabPageSabado.BackColor = System.Drawing.Color.Bisque;
            this.tabPageSabado.Location = new System.Drawing.Point(4, 25);
            this.tabPageSabado.Margin = new System.Windows.Forms.Padding(4);
            this.tabPageSabado.Name = "tabPageSabado";
            this.tabPageSabado.Size = new System.Drawing.Size(901, 516);
            this.tabPageSabado.TabIndex = 5;
            this.tabPageSabado.Text = "Sábado";
            // 
            // tabPageDomingo
            // 
            this.tabPageDomingo.BackColor = System.Drawing.Color.Bisque;
            this.tabPageDomingo.Location = new System.Drawing.Point(4, 25);
            this.tabPageDomingo.Margin = new System.Windows.Forms.Padding(4);
            this.tabPageDomingo.Name = "tabPageDomingo";
            this.tabPageDomingo.Size = new System.Drawing.Size(901, 516);
            this.tabPageDomingo.TabIndex = 6;
            this.tabPageDomingo.Text = "Domingo";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.perfilToolStripMenuItem,
            this.reservasToolStripMenuItem,
            this.comprasToolStripMenuItem,
            this.sobreNosotrosToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(904, 30);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // perfilToolStripMenuItem
            // 
            this.perfilToolStripMenuItem.Name = "perfilToolStripMenuItem";
            this.perfilToolStripMenuItem.Size = new System.Drawing.Size(56, 26);
            this.perfilToolStripMenuItem.Text = "Perfil";
            // 
            // reservasToolStripMenuItem
            // 
            this.reservasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.consultarReservasToolStripMenuItem,
            this.consultarListaDeEsperaToolStripMenuItem});
            this.reservasToolStripMenuItem.Name = "reservasToolStripMenuItem";
            this.reservasToolStripMenuItem.Size = new System.Drawing.Size(80, 26);
            this.reservasToolStripMenuItem.Text = "Reservas";
            // 
            // consultarReservasToolStripMenuItem
            // 
            this.consultarReservasToolStripMenuItem.Name = "consultarReservasToolStripMenuItem";
            this.consultarReservasToolStripMenuItem.Size = new System.Drawing.Size(254, 26);
            this.consultarReservasToolStripMenuItem.Text = "Consultar reservas";
            // 
            // consultarListaDeEsperaToolStripMenuItem
            // 
            this.consultarListaDeEsperaToolStripMenuItem.Name = "consultarListaDeEsperaToolStripMenuItem";
            this.consultarListaDeEsperaToolStripMenuItem.Size = new System.Drawing.Size(254, 26);
            this.consultarListaDeEsperaToolStripMenuItem.Text = "Consultar lista de espera";
            // 
            // comprasToolStripMenuItem
            // 
            this.comprasToolStripMenuItem.Name = "comprasToolStripMenuItem";
            this.comprasToolStripMenuItem.Size = new System.Drawing.Size(82, 26);
            this.comprasToolStripMenuItem.Text = "Compras";
            // 
            // sobreNosotrosToolStripMenuItem
            // 
            this.sobreNosotrosToolStripMenuItem.Name = "sobreNosotrosToolStripMenuItem";
            this.sobreNosotrosToolStripMenuItem.Size = new System.Drawing.Size(123, 26);
            this.sobreNosotrosToolStripMenuItem.Text = "Sobre nosotros";
            // 
            // FormHorarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Bisque;
            this.ClientSize = new System.Drawing.Size(904, 583);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.tabControlHorarios);
            this.Controls.Add(this.dataGridViewHorarios);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormHorarios";
            this.Text = "Horarios";
            this.Load += new System.EventHandler(this.FormHorarios_Load);
            ((System.ComponentModel.ISupportInitialize)(this.horarioBindingSource3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.genteFitDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.horarioBindingSource4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHorarios)).EndInit();
            this.tabControlHorarios.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private GenteFitDataSet1 genteFitDataSet1;
        private System.Windows.Forms.BindingSource horarioBindingSource3;
        private GenteFitDataSet1TableAdapters.HorarioTableAdapter horarioTableAdapter1;
        private System.Windows.Forms.DataGridViewTextBoxColumn diaSemanaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn horaInicioDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idActividadDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn salaDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource horarioBindingSource4;
        private System.Windows.Forms.DataGridView dataGridViewHorarios;
        private System.Windows.Forms.TabControl tabControlHorarios;
        private System.Windows.Forms.TabPage tabPageLunes;
        private System.Windows.Forms.TabPage tabPageMartes;
        private System.Windows.Forms.TabPage tabPageMiercoles;
        private System.Windows.Forms.TabPage tabPageJueves;
        private System.Windows.Forms.TabPage tabPageViernes;
        private System.Windows.Forms.TabPage tabPageSabado;
        private System.Windows.Forms.TabPage tabPageDomingo;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem perfilToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reservasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consultarReservasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consultarListaDeEsperaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem comprasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sobreNosotrosToolStripMenuItem;
    }
}