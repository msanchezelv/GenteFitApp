namespace GenteFitApp.Vista._04Reservas
{
    partial class MisReservas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MisReservas));
            this.dataGridViewReservas = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewReservas)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewReservas
            // 
            this.dataGridViewReservas.BackgroundColor = System.Drawing.Color.Bisque;
            this.dataGridViewReservas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewReservas.GridColor = System.Drawing.Color.Bisque;
            this.dataGridViewReservas.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewReservas.Name = "dataGridViewReservas";
            this.dataGridViewReservas.RowHeadersWidth = 51;
            this.dataGridViewReservas.RowTemplate.Height = 24;
            this.dataGridViewReservas.Size = new System.Drawing.Size(848, 452);
            this.dataGridViewReservas.TabIndex = 0;
            this.dataGridViewReservas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewReservas_CellContentClick);
            // 
            // MisReservas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Bisque;
            this.ClientSize = new System.Drawing.Size(846, 450);
            this.Controls.Add(this.dataGridViewReservas);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MisReservas";
            this.Text = "Mis Reservas";
            this.Load += new System.EventHandler(this.FormMisReservas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewReservas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewReservas;
    }
}