using System.Windows.Forms;

namespace GenteFitApp.Vista._05ListaEspera
{
    partial class ListaEspera
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ListaEspera));
            this.dataGridViewListaEspera = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewListaEspera)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewListaEspera
            // 
            this.dataGridViewListaEspera.AllowUserToAddRows = false;
            this.dataGridViewListaEspera.AllowUserToDeleteRows = false;
            this.dataGridViewListaEspera.AllowUserToResizeColumns = false;
            this.dataGridViewListaEspera.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            this.dataGridViewListaEspera.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewListaEspera.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewListaEspera.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewListaEspera.BackgroundColor = System.Drawing.Color.Bisque;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Futura Lt BT", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Orange;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewListaEspera.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewListaEspera.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewListaEspera.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridViewListaEspera.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewListaEspera.Name = "dataGridViewListaEspera";
            this.dataGridViewListaEspera.ReadOnly = true;
            this.dataGridViewListaEspera.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dataGridViewListaEspera.RowTemplate.Height = 24;
            this.dataGridViewListaEspera.Size = new System.Drawing.Size(763, 547);
            this.dataGridViewListaEspera.TabIndex = 0;
            // 
            // ListaEspera
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(759, 538);
            this.Controls.Add(this.dataGridViewListaEspera);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ListaEspera";
            this.Text = "Consultar listas de espera";
            this.Load += new System.EventHandler(this.ListaEspera_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewListaEspera)).EndInit();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.DataGridView dataGridViewListaEspera;
    }
}
