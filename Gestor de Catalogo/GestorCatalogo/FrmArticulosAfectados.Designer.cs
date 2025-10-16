namespace GestorCatalogo
{
    partial class FrmArticulosAfectados
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
            this.dgvArticulosAfectados = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvArticulosAfectados)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvArticulosAfectados
            // 
            this.dgvArticulosAfectados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvArticulosAfectados.Location = new System.Drawing.Point(12, 12);
            this.dgvArticulosAfectados.Name = "dgvArticulosAfectados";
            this.dgvArticulosAfectados.Size = new System.Drawing.Size(465, 221);
            this.dgvArticulosAfectados.TabIndex = 0;
            // 
            // FrmArticulosAfectados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(489, 301);
            this.Controls.Add(this.dgvArticulosAfectados);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmArticulosAfectados";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmArticulosAfectados";
            this.Load += new System.EventHandler(this.FrmArticulosAfectados_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvArticulosAfectados)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvArticulosAfectados;
    }
}