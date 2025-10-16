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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvMarca = new System.Windows.Forms.DataGridView();
            this.dgvCategoria = new System.Windows.Forms.DataGridView();
            this.lblMarca = new System.Windows.Forms.Label();
            this.lblCategoria = new System.Windows.Forms.Label();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.txtFiltroMarca = new System.Windows.Forms.TextBox();
            this.txtFiltroCategoria = new System.Windows.Forms.TextBox();
            this.btnActualizarMarca = new System.Windows.Forms.Button();
            this.btnActualizarCategoria = new System.Windows.Forms.Button();
            this.lblXMarca = new System.Windows.Forms.Label();
            this.lblXCategoria = new System.Windows.Forms.Label();
            this.txtAgregarMarca = new System.Windows.Forms.TextBox();
            this.btnAgregarMarca = new System.Windows.Forms.Button();
            this.btnAgregarCategoria = new System.Windows.Forms.Button();
            this.txtAgregarCategoria = new System.Windows.Forms.TextBox();
            this.txtModificarMarca = new System.Windows.Forms.TextBox();
            this.btnModificarMarca = new System.Windows.Forms.Button();
            this.txtModificarCategoria = new System.Windows.Forms.TextBox();
            this.btnModificarCategoria = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.lblArticulosAfectados = new System.Windows.Forms.Label();
            this.lblWarning = new System.Windows.Forms.Label();
            this.btnArticulosAfectados = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMarca)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategoria)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvMarca
            // 
            this.dgvMarca.AllowUserToResizeColumns = false;
            this.dgvMarca.AllowUserToResizeRows = false;
            this.dgvMarca.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMarca.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMarca.ColumnHeadersVisible = false;
            this.dgvMarca.Location = new System.Drawing.Point(88, 77);
            this.dgvMarca.MultiSelect = false;
            this.dgvMarca.Name = "dgvMarca";
            this.dgvMarca.ReadOnly = true;
            this.dgvMarca.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvMarca.RowTemplate.Height = 30;
            this.dgvMarca.RowTemplate.ReadOnly = true;
            this.dgvMarca.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvMarca.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMarca.Size = new System.Drawing.Size(184, 411);
            this.dgvMarca.TabIndex = 10;
            this.dgvMarca.SelectionChanged += new System.EventHandler(this.dgvMarca_SelectionChanged);
            // 
            // dgvCategoria
            // 
            this.dgvCategoria.AllowUserToResizeColumns = false;
            this.dgvCategoria.AllowUserToResizeRows = false;
            this.dgvCategoria.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCategoria.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCategoria.ColumnHeadersVisible = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCategoria.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvCategoria.Location = new System.Drawing.Point(402, 77);
            this.dgvCategoria.MultiSelect = false;
            this.dgvCategoria.Name = "dgvCategoria";
            this.dgvCategoria.ReadOnly = true;
            this.dgvCategoria.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvCategoria.RowTemplate.Height = 30;
            this.dgvCategoria.RowTemplate.ReadOnly = true;
            this.dgvCategoria.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvCategoria.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCategoria.Size = new System.Drawing.Size(187, 411);
            this.dgvCategoria.TabIndex = 11;
            this.dgvCategoria.SelectionChanged += new System.EventHandler(this.dgvCategoria_SelectionChanged);
            // 
            // lblMarca
            // 
            this.lblMarca.AutoSize = true;
            this.lblMarca.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMarca.Location = new System.Drawing.Point(144, 13);
            this.lblMarca.Name = "lblMarca";
            this.lblMarca.Size = new System.Drawing.Size(67, 21);
            this.lblMarca.TabIndex = 2;
            this.lblMarca.Text = "MARCA";
            // 
            // lblCategoria
            // 
            this.lblCategoria.AutoSize = true;
            this.lblCategoria.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCategoria.Location = new System.Drawing.Point(443, 13);
            this.lblCategoria.Name = "lblCategoria";
            this.lblCategoria.Size = new System.Drawing.Size(97, 21);
            this.lblCategoria.TabIndex = 3;
            this.lblCategoria.Text = "CATEGORÍA";
            // 
            // btnEliminar
            // 
            this.btnEliminar.Enabled = false;
            this.btnEliminar.Location = new System.Drawing.Point(300, 237);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(75, 23);
            this.btnEliminar.TabIndex = 12;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // txtFiltroMarca
            // 
            this.txtFiltroMarca.Location = new System.Drawing.Point(88, 51);
            this.txtFiltroMarca.MaxLength = 100;
            this.txtFiltroMarca.Name = "txtFiltroMarca";
            this.txtFiltroMarca.Size = new System.Drawing.Size(148, 22);
            this.txtFiltroMarca.TabIndex = 0;
            this.txtFiltroMarca.TextChanged += new System.EventHandler(this.txtFiltroMarca_TextChanged);
            // 
            // txtFiltroCategoria
            // 
            this.txtFiltroCategoria.Location = new System.Drawing.Point(402, 50);
            this.txtFiltroCategoria.MaxLength = 100;
            this.txtFiltroCategoria.Name = "txtFiltroCategoria";
            this.txtFiltroCategoria.Size = new System.Drawing.Size(150, 22);
            this.txtFiltroCategoria.TabIndex = 3;
            this.txtFiltroCategoria.TextChanged += new System.EventHandler(this.txtFiltroCategoria_TextChanged);
            // 
            // btnActualizarMarca
            // 
            this.btnActualizarMarca.Font = new System.Drawing.Font("Segoe UI Symbol", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActualizarMarca.Location = new System.Drawing.Point(239, 50);
            this.btnActualizarMarca.Name = "btnActualizarMarca";
            this.btnActualizarMarca.Size = new System.Drawing.Size(33, 23);
            this.btnActualizarMarca.TabIndex = 2;
            this.btnActualizarMarca.Text = "🔄 ";
            this.btnActualizarMarca.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnActualizarMarca.UseVisualStyleBackColor = true;
            this.btnActualizarMarca.Click += new System.EventHandler(this.btnActualizarMarca_Click);
            // 
            // btnActualizarCategoria
            // 
            this.btnActualizarCategoria.Font = new System.Drawing.Font("Segoe UI Symbol", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActualizarCategoria.Location = new System.Drawing.Point(556, 49);
            this.btnActualizarCategoria.Name = "btnActualizarCategoria";
            this.btnActualizarCategoria.Size = new System.Drawing.Size(33, 23);
            this.btnActualizarCategoria.TabIndex = 5;
            this.btnActualizarCategoria.Text = "🔄 ";
            this.btnActualizarCategoria.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnActualizarCategoria.UseVisualStyleBackColor = true;
            this.btnActualizarCategoria.Click += new System.EventHandler(this.btnActualizarCategoria_Click);
            // 
            // lblXMarca
            // 
            this.lblXMarca.AutoSize = true;
            this.lblXMarca.BackColor = System.Drawing.SystemColors.Window;
            this.lblXMarca.Enabled = false;
            this.lblXMarca.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblXMarca.Location = new System.Drawing.Point(222, 55);
            this.lblXMarca.Name = "lblXMarca";
            this.lblXMarca.Size = new System.Drawing.Size(13, 13);
            this.lblXMarca.TabIndex = 1;
            this.lblXMarca.Text = "X";
            this.lblXMarca.Visible = false;
            this.lblXMarca.Click += new System.EventHandler(this.lblXMarca_Click);
            // 
            // lblXCategoria
            // 
            this.lblXCategoria.AutoSize = true;
            this.lblXCategoria.BackColor = System.Drawing.SystemColors.Window;
            this.lblXCategoria.Enabled = false;
            this.lblXCategoria.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblXCategoria.Location = new System.Drawing.Point(538, 54);
            this.lblXCategoria.Name = "lblXCategoria";
            this.lblXCategoria.Size = new System.Drawing.Size(13, 13);
            this.lblXCategoria.TabIndex = 4;
            this.lblXCategoria.Text = "X";
            this.lblXCategoria.Visible = false;
            this.lblXCategoria.Click += new System.EventHandler(this.lblXCategoria_Click);
            // 
            // txtAgregarMarca
            // 
            this.txtAgregarMarca.Location = new System.Drawing.Point(87, 500);
            this.txtAgregarMarca.Name = "txtAgregarMarca";
            this.txtAgregarMarca.Size = new System.Drawing.Size(148, 22);
            this.txtAgregarMarca.TabIndex = 6;
            // 
            // btnAgregarMarca
            // 
            this.btnAgregarMarca.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarMarca.Location = new System.Drawing.Point(241, 499);
            this.btnAgregarMarca.Name = "btnAgregarMarca";
            this.btnAgregarMarca.Size = new System.Drawing.Size(31, 23);
            this.btnAgregarMarca.TabIndex = 7;
            this.btnAgregarMarca.Text = " +";
            this.btnAgregarMarca.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgregarMarca.UseVisualStyleBackColor = true;
            this.btnAgregarMarca.Click += new System.EventHandler(this.btnAgregarMarca_Click);
            // 
            // btnAgregarCategoria
            // 
            this.btnAgregarCategoria.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarCategoria.Location = new System.Drawing.Point(558, 499);
            this.btnAgregarCategoria.Name = "btnAgregarCategoria";
            this.btnAgregarCategoria.Size = new System.Drawing.Size(31, 23);
            this.btnAgregarCategoria.TabIndex = 9;
            this.btnAgregarCategoria.Text = " +";
            this.btnAgregarCategoria.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgregarCategoria.UseVisualStyleBackColor = true;
            this.btnAgregarCategoria.Click += new System.EventHandler(this.btnAgregarCategoria_Click);
            // 
            // txtAgregarCategoria
            // 
            this.txtAgregarCategoria.Location = new System.Drawing.Point(402, 500);
            this.txtAgregarCategoria.Name = "txtAgregarCategoria";
            this.txtAgregarCategoria.Size = new System.Drawing.Size(148, 22);
            this.txtAgregarCategoria.TabIndex = 8;
            // 
            // txtModificarMarca
            // 
            this.txtModificarMarca.Enabled = false;
            this.txtModificarMarca.Location = new System.Drawing.Point(71, 527);
            this.txtModificarMarca.Name = "txtModificarMarca";
            this.txtModificarMarca.Size = new System.Drawing.Size(149, 22);
            this.txtModificarMarca.TabIndex = 14;
            this.txtModificarMarca.TextChanged += new System.EventHandler(this.txtModificarMarca_TextChanged);
            // 
            // btnModificarMarca
            // 
            this.btnModificarMarca.Enabled = false;
            this.btnModificarMarca.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModificarMarca.Location = new System.Drawing.Point(226, 526);
            this.btnModificarMarca.Name = "btnModificarMarca";
            this.btnModificarMarca.Size = new System.Drawing.Size(64, 23);
            this.btnModificarMarca.TabIndex = 15;
            this.btnModificarMarca.Text = "Modificar";
            this.btnModificarMarca.UseVisualStyleBackColor = true;
            this.btnModificarMarca.Click += new System.EventHandler(this.btnModificarMarca_Click);
            // 
            // txtModificarCategoria
            // 
            this.txtModificarCategoria.Enabled = false;
            this.txtModificarCategoria.Location = new System.Drawing.Point(386, 525);
            this.txtModificarCategoria.Name = "txtModificarCategoria";
            this.txtModificarCategoria.Size = new System.Drawing.Size(148, 22);
            this.txtModificarCategoria.TabIndex = 16;
            this.txtModificarCategoria.TextChanged += new System.EventHandler(this.txtModificarCategoria_TextChanged);
            // 
            // btnModificarCategoria
            // 
            this.btnModificarCategoria.Enabled = false;
            this.btnModificarCategoria.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModificarCategoria.Location = new System.Drawing.Point(542, 524);
            this.btnModificarCategoria.Name = "btnModificarCategoria";
            this.btnModificarCategoria.Size = new System.Drawing.Size(64, 23);
            this.btnModificarCategoria.TabIndex = 17;
            this.btnModificarCategoria.Text = "Modificar";
            this.btnModificarCategoria.UseVisualStyleBackColor = true;
            this.btnModificarCategoria.Click += new System.EventHandler(this.btnModificarCategoria_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(300, 279);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(75, 23);
            this.btnModificar.TabIndex = 13;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // lblArticulosAfectados
            // 
            this.lblArticulosAfectados.AutoSize = true;
            this.lblArticulosAfectados.Font = new System.Drawing.Font("Segoe UI Symbol", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblArticulosAfectados.Location = new System.Drawing.Point(32, 577);
            this.lblArticulosAfectados.Name = "lblArticulosAfectados";
            this.lblArticulosAfectados.Size = new System.Drawing.Size(110, 15);
            this.lblArticulosAfectados.TabIndex = 18;
            this.lblArticulosAfectados.Text = "Articulos Afectados";
            // 
            // lblWarning
            // 
            this.lblWarning.AutoSize = true;
            this.lblWarning.BackColor = System.Drawing.SystemColors.Window;
            this.lblWarning.Font = new System.Drawing.Font("Segoe UI Symbol", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWarning.ForeColor = System.Drawing.Color.Red;
            this.lblWarning.Location = new System.Drawing.Point(3, 568);
            this.lblWarning.Name = "lblWarning";
            this.lblWarning.Size = new System.Drawing.Size(29, 28);
            this.lblWarning.TabIndex = 19;
            this.lblWarning.Text = "⚠️";
            // 
            // btnArticulosAfectados
            // 
            this.btnArticulosAfectados.Location = new System.Drawing.Point(143, 573);
            this.btnArticulosAfectados.Name = "btnArticulosAfectados";
            this.btnArticulosAfectados.Size = new System.Drawing.Size(40, 23);
            this.btnArticulosAfectados.TabIndex = 20;
            this.btnArticulosAfectados.Text = "0";
            this.btnArticulosAfectados.UseVisualStyleBackColor = true;
            this.btnArticulosAfectados.Click += new System.EventHandler(this.btnArticulosAfectados_Click);
            // 
            // FrmMarcaCategoria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(679, 601);
            this.Controls.Add(this.btnArticulosAfectados);
            this.Controls.Add(this.lblWarning);
            this.Controls.Add(this.lblArticulosAfectados);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnModificarCategoria);
            this.Controls.Add(this.txtModificarCategoria);
            this.Controls.Add(this.btnModificarMarca);
            this.Controls.Add(this.txtModificarMarca);
            this.Controls.Add(this.txtAgregarCategoria);
            this.Controls.Add(this.btnAgregarCategoria);
            this.Controls.Add(this.btnAgregarMarca);
            this.Controls.Add(this.txtAgregarMarca);
            this.Controls.Add(this.lblXCategoria);
            this.Controls.Add(this.lblXMarca);
            this.Controls.Add(this.btnActualizarCategoria);
            this.Controls.Add(this.btnActualizarMarca);
            this.Controls.Add(this.txtFiltroCategoria);
            this.Controls.Add(this.txtFiltroMarca);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.lblCategoria);
            this.Controls.Add(this.lblMarca);
            this.Controls.Add(this.dgvCategoria);
            this.Controls.Add(this.dgvMarca);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmMarcaCategoria";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FrmMarcaCategoria_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMarca)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategoria)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvMarca;
        private System.Windows.Forms.DataGridView dgvCategoria;
        private System.Windows.Forms.Label lblMarca;
        private System.Windows.Forms.Label lblCategoria;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.TextBox txtFiltroMarca;
        private System.Windows.Forms.TextBox txtFiltroCategoria;
        private System.Windows.Forms.Button btnActualizarMarca;
        private System.Windows.Forms.Button btnActualizarCategoria;
        private System.Windows.Forms.Label lblXMarca;
        private System.Windows.Forms.Label lblXCategoria;
        private System.Windows.Forms.TextBox txtAgregarMarca;
        private System.Windows.Forms.Button btnAgregarMarca;
        private System.Windows.Forms.Button btnAgregarCategoria;
        private System.Windows.Forms.TextBox txtAgregarCategoria;
        private System.Windows.Forms.TextBox txtModificarMarca;
        private System.Windows.Forms.Button btnModificarMarca;
        private System.Windows.Forms.TextBox txtModificarCategoria;
        private System.Windows.Forms.Button btnModificarCategoria;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Label lblArticulosAfectados;
        private System.Windows.Forms.Label lblWarning;
        private System.Windows.Forms.Button btnArticulosAfectados;
    }
}