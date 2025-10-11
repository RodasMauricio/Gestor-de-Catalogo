namespace GestorCatalogo
{
    partial class FrmMarcaCategoria
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
            this.dgvMarca = new System.Windows.Forms.DataGridView();
            this.dgvCategoria = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMarca)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategoria)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvMarca
            // 
            this.dgvMarca.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMarca.Location = new System.Drawing.Point(71, 41);
            this.dgvMarca.Name = "dgvMarca";
            this.dgvMarca.Size = new System.Drawing.Size(240, 150);
            this.dgvMarca.TabIndex = 0;
            // 
            // dgvCategoria
            // 
            this.dgvCategoria.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCategoria.Location = new System.Drawing.Point(398, 41);
            this.dgvCategoria.Name = "dgvCategoria";
            this.dgvCategoria.Size = new System.Drawing.Size(240, 150);
            this.dgvCategoria.TabIndex = 1;
            // 
            // FrmMarcaCategoria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 249);
            this.Controls.Add(this.dgvCategoria);
            this.Controls.Add(this.dgvMarca);
            this.Name = "FrmMarcaCategoria";
            this.Text = "FrmMarcaCategoria";
            this.Load += new System.EventHandler(this.FrmMarcaCategoria_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMarca)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategoria)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvMarca;
        private System.Windows.Forms.DataGridView dgvCategoria;
    }
}