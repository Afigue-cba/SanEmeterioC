namespace SanEmeterio.Formularios
{
    partial class ReporteDis
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.btnSalir = new System.Windows.Forms.Button();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.cnjDatos = new SanEmeterio.CnjDatos();
            this.reportedisketteBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reporte_disketteTableAdapter = new SanEmeterio.CnjDatosTableAdapters.reporte_disketteTableAdapter();
            this.reporte_disketteBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.cnjDatos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reportedisketteBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reporte_disketteBindingSource)).BeginInit();
            this.SuspendLayout();
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
            this.btnSalir.Location = new System.Drawing.Point(869, 12);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(78, 29);
            this.btnSalir.TabIndex = 6;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // reportViewer1
            // 
            this.reportViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.reporte_disketteBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "SanEmeterio.Listados.rptReporteDiskette.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(12, 47);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(935, 539);
            this.reportViewer1.TabIndex = 7;
            // 
            // cnjDatos
            // 
            this.cnjDatos.DataSetName = "CnjDatos";
            this.cnjDatos.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportedisketteBindingSource
            // 
            this.reportedisketteBindingSource.DataMember = "reporte_diskette";
            this.reportedisketteBindingSource.DataSource = this.cnjDatos;
            // 
            // reporte_disketteTableAdapter
            // 
            this.reporte_disketteTableAdapter.ClearBeforeFill = true;
            // 
            // reporte_disketteBindingSource
            // 
            this.reporte_disketteBindingSource.DataMember = "reporte_diskette";
            this.reporte_disketteBindingSource.DataSource = this.cnjDatos;
            // 
            // ReporteDis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(959, 598);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.btnSalir);
            this.Name = "ReporteDis";
            this.Text = "ReporteDis";
            this.Load += new System.EventHandler(this.ReporteDis_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cnjDatos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reportedisketteBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reporte_disketteBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSalir;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private CnjDatos cnjDatos;
        private System.Windows.Forms.BindingSource reportedisketteBindingSource;
        private CnjDatosTableAdapters.reporte_disketteTableAdapter reporte_disketteTableAdapter;
        private System.Windows.Forms.BindingSource reporte_disketteBindingSource;
    }
}