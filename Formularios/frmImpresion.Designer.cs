namespace SanEmeterio.Formularios
{
    partial class frmImpresion
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
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.btnSalir = new System.Windows.Forms.Button();
            this.cboOperadores = new System.Windows.Forms.ComboBox();
            this.chkTodos = new System.Windows.Forms.CheckBox();
            this.fechaSeguimiento = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.cmdFiltrar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "SanEmeterio.rptSeguimieto.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(12, 47);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(912, 532);
            this.reportViewer1.TabIndex = 0;
            // 
            // btnSalir
            // 
            this.btnSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnSalir.FlatAppearance.BorderSize = 0;
            this.btnSalir.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(50)))), ((int)(((byte)(70)))));
            this.btnSalir.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(61)))), ((int)(((byte)(92)))));
            this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalir.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnSalir.Location = new System.Drawing.Point(846, 12);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(78, 29);
            this.btnSalir.TabIndex = 25;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // cboOperadores
            // 
            this.cboOperadores.FormattingEnabled = true;
            this.cboOperadores.Location = new System.Drawing.Point(288, 17);
            this.cboOperadores.Name = "cboOperadores";
            this.cboOperadores.Size = new System.Drawing.Size(186, 21);
            this.cboOperadores.TabIndex = 24;
            // 
            // chkTodos
            // 
            this.chkTodos.AutoSize = true;
            this.chkTodos.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkTodos.Checked = true;
            this.chkTodos.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTodos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkTodos.Location = new System.Drawing.Point(221, 19);
            this.chkTodos.Name = "chkTodos";
            this.chkTodos.Size = new System.Drawing.Size(61, 17);
            this.chkTodos.TabIndex = 23;
            this.chkTodos.Text = "Todos";
            this.chkTodos.UseVisualStyleBackColor = true;
            // 
            // fechaSeguimiento
            // 
            this.fechaSeguimiento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.fechaSeguimiento.Location = new System.Drawing.Point(60, 17);
            this.fechaSeguimiento.Name = "fechaSeguimiento";
            this.fechaSeguimiento.Size = new System.Drawing.Size(100, 20);
            this.fechaSeguimiento.TabIndex = 26;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 27;
            this.label1.Text = "Fecha";
            // 
            // cmdFiltrar
            // 
            this.cmdFiltrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdFiltrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.cmdFiltrar.FlatAppearance.BorderSize = 0;
            this.cmdFiltrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(50)))), ((int)(((byte)(70)))));
            this.cmdFiltrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(61)))), ((int)(((byte)(92)))));
            this.cmdFiltrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdFiltrar.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdFiltrar.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.cmdFiltrar.Location = new System.Drawing.Point(480, 12);
            this.cmdFiltrar.Name = "cmdFiltrar";
            this.cmdFiltrar.Size = new System.Drawing.Size(78, 29);
            this.cmdFiltrar.TabIndex = 28;
            this.cmdFiltrar.Text = "Filtrar";
            this.cmdFiltrar.UseVisualStyleBackColor = false;
            this.cmdFiltrar.Click += new System.EventHandler(this.cmdFiltrar_Click);
            // 
            // frmImpresion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(936, 591);
            this.Controls.Add(this.cmdFiltrar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.fechaSeguimiento);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.cboOperadores);
            this.Controls.Add(this.chkTodos);
            this.Controls.Add(this.reportViewer1);
            this.Name = "frmImpresion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmImpresion";
            this.Load += new System.EventHandler(this.frmImpresion_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.ComboBox cboOperadores;
        private System.Windows.Forms.CheckBox chkTodos;
        private System.Windows.Forms.DateTimePicker fechaSeguimiento;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cmdFiltrar;
    }
}