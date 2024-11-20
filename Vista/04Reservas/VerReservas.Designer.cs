namespace GenteFitApp.Vista._04Reservas
{
    partial class VerReservas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VerReservas));
            this.dataGridViewReservas = new System.Windows.Forms.DataGridView();
            this.genteFitDataSet1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.genteFitDataSet1 = new GenteFitApp.GenteFitDataSet1();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewReservas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.genteFitDataSet1BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.genteFitDataSet1)).BeginInit();
            this.SuspendLayout();
            this.Load += new System.EventHandler(this.FormVerReservas_Load);
            // 
            // dataGridViewReservas
            // 
            this.dataGridViewReservas.AutoGenerateColumns = false;
            this.dataGridViewReservas.BackgroundColor = System.Drawing.Color.Bisque;
            this.dataGridViewReservas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewReservas.DataSource = this.genteFitDataSet1BindingSource;
            this.dataGridViewReservas.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewReservas.Name = "dataGridViewReservas";
            this.dataGridViewReservas.RowHeadersWidth = 51;
            this.dataGridViewReservas.RowTemplate.Height = 24;
            this.dataGridViewReservas.Size = new System.Drawing.Size(912, 492);
            this.dataGridViewReservas.TabIndex = 0;
            // 
            // genteFitDataSet1BindingSource
            // 
            this.genteFitDataSet1BindingSource.DataSource = this.genteFitDataSet1;
            this.genteFitDataSet1BindingSource.Position = 0;
            // 
            // genteFitDataSet1
            // 
            this.genteFitDataSet1.DataSetName = "GenteFitDataSet1";
            this.genteFitDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // VerReservas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Bisque;
            this.ClientSize = new System.Drawing.Size(926, 503);
            this.Controls.Add(this.dataGridViewReservas);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "VerReservas";
            this.Text = "Mis reservas";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewReservas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.genteFitDataSet1BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.genteFitDataSet1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewReservas;
        private System.Windows.Forms.BindingSource genteFitDataSet1BindingSource;
        private GenteFitDataSet1 genteFitDataSet1;
    }
}