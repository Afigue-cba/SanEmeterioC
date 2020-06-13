namespace SanEmeterio.Formularios
{
    partial class frmListadoCarpetas
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
            this.label5 = new System.Windows.Forms.Label();
            this.txtCarpetaHasta = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtPorEstado = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtConResumen = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCarpetaDesde = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cboProvincias = new System.Windows.Forms.ComboBox();
            this.chkProvincias = new System.Windows.Forms.CheckBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtCartaSD = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cboCarta = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtCantCuotas = new System.Windows.Forms.TextBox();
            this.cboMayor = new System.Windows.Forms.ComboBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.chkCompleto = new System.Windows.Forms.CheckBox();
            this.chkPasivas = new System.Windows.Forms.CheckBox();
            this.chkActivas = new System.Windows.Forms.CheckBox();
            this.chkTitular = new System.Windows.Forms.CheckBox();
            this.chkNroContrato = new System.Windows.Forms.CheckBox();
            this.chkNroCarpeta = new System.Windows.Forms.CheckBox();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.cnjDatos = new SanEmeterio.CnjDatos();
            this.daReportePresentacionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.daReportePresentacionTableAdapter = new SanEmeterio.CnjDatosTableAdapters.DaReportePresentacionTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.cnjDatos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.daReportePresentacionBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(257, 62);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 13);
            this.label5.TabIndex = 74;
            this.label5.Text = "Hasta";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtCarpetaHasta
            // 
            this.txtCarpetaHasta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCarpetaHasta.Location = new System.Drawing.Point(323, 57);
            this.txtCarpetaHasta.Name = "txtCarpetaHasta";
            this.txtCarpetaHasta.Size = new System.Drawing.Size(111, 22);
            this.txtCarpetaHasta.TabIndex = 7;
            this.txtCarpetaHasta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCarpetaHasta.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCarpetaHasta_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(475, 35);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 13);
            this.label6.TabIndex = 76;
            this.label6.Text = "Por Estado";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(603, 35);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(30, 13);
            this.label7.TabIndex = 77;
            this.label7.Text = "S/N";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtPorEstado
            // 
            this.txtPorEstado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPorEstado.Location = new System.Drawing.Point(578, 31);
            this.txtPorEstado.Name = "txtPorEstado";
            this.txtPorEstado.Size = new System.Drawing.Size(19, 21);
            this.txtPorEstado.TabIndex = 10;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(475, 62);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(89, 13);
            this.label8.TabIndex = 80;
            this.label8.Text = "Con Resumen ";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(603, 62);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(30, 13);
            this.label9.TabIndex = 81;
            this.label9.Text = "S/N";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtConResumen
            // 
            this.txtConResumen.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConResumen.Location = new System.Drawing.Point(578, 58);
            this.txtConResumen.Name = "txtConResumen";
            this.txtConResumen.Size = new System.Drawing.Size(19, 21);
            this.txtConResumen.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(140, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 16);
            this.label2.TabIndex = 71;
            this.label2.Text = "Se Lista";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 16);
            this.label1.TabIndex = 70;
            this.label1.Text = "Ordenado Por";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(254, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 16);
            this.label3.TabIndex = 72;
            this.label3.Text = "Carpetas";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(257, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 73;
            this.label4.Text = "Desde";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtCarpetaDesde
            // 
            this.txtCarpetaDesde.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCarpetaDesde.Location = new System.Drawing.Point(323, 31);
            this.txtCarpetaDesde.Name = "txtCarpetaDesde";
            this.txtCarpetaDesde.Size = new System.Drawing.Size(111, 21);
            this.txtCarpetaDesde.TabIndex = 6;
            this.txtCarpetaDesde.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCarpetaDesde.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCarpetaDesde_KeyPress);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(257, 90);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(60, 13);
            this.label10.TabIndex = 75;
            this.label10.Text = "Provincia";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label10.Click += new System.EventHandler(this.label10_Click);
            // 
            // cboProvincias
            // 
            this.cboProvincias.FormattingEnabled = true;
            this.cboProvincias.Location = new System.Drawing.Point(323, 86);
            this.cboProvincias.Name = "cboProvincias";
            this.cboProvincias.Size = new System.Drawing.Size(211, 21);
            this.cboProvincias.TabIndex = 8;
            this.cboProvincias.SelectedIndexChanged += new System.EventHandler(this.cboProvincias_SelectedIndexChanged);
            // 
            // chkProvincias
            // 
            this.chkProvincias.AutoSize = true;
            this.chkProvincias.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkProvincias.Location = new System.Drawing.Point(540, 87);
            this.chkProvincias.Name = "chkProvincias";
            this.chkProvincias.Size = new System.Drawing.Size(65, 19);
            this.chkProvincias.TabIndex = 9;
            this.chkProvincias.Text = "Todas";
            this.chkProvincias.UseVisualStyleBackColor = true;
            this.chkProvincias.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(660, 35);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(43, 13);
            this.label11.TabIndex = 78;
            this.label11.Text = "Divide";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtCartaSD
            // 
            this.txtCartaSD.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCartaSD.Location = new System.Drawing.Point(715, 31);
            this.txtCartaSD.Name = "txtCartaSD";
            this.txtCartaSD.Size = new System.Drawing.Size(19, 21);
            this.txtCartaSD.TabIndex = 11;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(740, 35);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(30, 13);
            this.label12.TabIndex = 79;
            this.label12.Text = "S/N";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboCarta
            // 
            this.cboCarta.FormattingEnabled = true;
            this.cboCarta.Items.AddRange(new object[] {
            "Simple",
            "Documento",
            "Veras",
            "Todas",
            "Express"});
            this.cboCarta.Location = new System.Drawing.Point(782, 31);
            this.cboCarta.Name = "cboCarta";
            this.cboCarta.Size = new System.Drawing.Size(120, 21);
            this.cboCarta.TabIndex = 12;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(660, 62);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(46, 13);
            this.label13.TabIndex = 82;
            this.label13.Text = "Cuotas";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtCantCuotas
            // 
            this.txtCantCuotas.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCantCuotas.Location = new System.Drawing.Point(715, 58);
            this.txtCantCuotas.Name = "txtCantCuotas";
            this.txtCantCuotas.Size = new System.Drawing.Size(19, 21);
            this.txtCantCuotas.TabIndex = 14;
            // 
            // cboMayor
            // 
            this.cboMayor.FormattingEnabled = true;
            this.cboMayor.Items.AddRange(new object[] {
            ">=",
            "<=",
            "=",
            ">",
            "<"});
            this.cboMayor.Location = new System.Drawing.Point(743, 58);
            this.cboMayor.Name = "cboMayor";
            this.cboMayor.Size = new System.Drawing.Size(47, 21);
            this.cboMayor.TabIndex = 15;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(800, 61);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(15, 14);
            this.checkBox2.TabIndex = 16;
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // btnSalir
            // 
            this.btnSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnSalir.FlatAppearance.BorderSize = 0;
            this.btnSalir.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
            this.btnSalir.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSalir.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnSalir.Location = new System.Drawing.Point(879, 90);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(98, 26);
            this.btnSalir.TabIndex = 18;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnImprimir
            // 
            this.btnImprimir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImprimir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnImprimir.FlatAppearance.BorderSize = 0;
            this.btnImprimir.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
            this.btnImprimir.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.btnImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnImprimir.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImprimir.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnImprimir.Location = new System.Drawing.Point(775, 90);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(98, 26);
            this.btnImprimir.TabIndex = 17;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.UseVisualStyleBackColor = false;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // chkCompleto
            // 
            this.chkCompleto.AutoSize = true;
            this.chkCompleto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkCompleto.Location = new System.Drawing.Point(143, 87);
            this.chkCompleto.Name = "chkCompleto";
            this.chkCompleto.Size = new System.Drawing.Size(87, 19);
            this.chkCompleto.TabIndex = 5;
            this.chkCompleto.Text = "Completo";
            this.chkCompleto.UseVisualStyleBackColor = true;
            this.chkCompleto.CheckedChanged += new System.EventHandler(this.chkCompleto_CheckedChanged);
            // 
            // chkPasivas
            // 
            this.chkPasivas.AutoSize = true;
            this.chkPasivas.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkPasivas.Location = new System.Drawing.Point(143, 59);
            this.chkPasivas.Name = "chkPasivas";
            this.chkPasivas.Size = new System.Drawing.Size(75, 19);
            this.chkPasivas.TabIndex = 4;
            this.chkPasivas.Text = "Pasivas";
            this.chkPasivas.UseVisualStyleBackColor = true;
            this.chkPasivas.CheckedChanged += new System.EventHandler(this.chkPasivas_CheckedChanged);
            // 
            // chkActivas
            // 
            this.chkActivas.AutoSize = true;
            this.chkActivas.Checked = true;
            this.chkActivas.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkActivas.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkActivas.Location = new System.Drawing.Point(143, 32);
            this.chkActivas.Name = "chkActivas";
            this.chkActivas.Size = new System.Drawing.Size(70, 19);
            this.chkActivas.TabIndex = 3;
            this.chkActivas.Text = "Activas";
            this.chkActivas.UseVisualStyleBackColor = true;
            this.chkActivas.CheckedChanged += new System.EventHandler(this.chkActivas_CheckedChanged);
            // 
            // chkTitular
            // 
            this.chkTitular.AutoSize = true;
            this.chkTitular.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkTitular.Location = new System.Drawing.Point(18, 87);
            this.chkTitular.Name = "chkTitular";
            this.chkTitular.Size = new System.Drawing.Size(67, 19);
            this.chkTitular.TabIndex = 2;
            this.chkTitular.Text = "Titular";
            this.chkTitular.UseVisualStyleBackColor = true;
            this.chkTitular.CheckedChanged += new System.EventHandler(this.chkTitular_CheckedChanged);
            // 
            // chkNroContrato
            // 
            this.chkNroContrato.AutoSize = true;
            this.chkNroContrato.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkNroContrato.Location = new System.Drawing.Point(18, 59);
            this.chkNroContrato.Name = "chkNroContrato";
            this.chkNroContrato.Size = new System.Drawing.Size(111, 19);
            this.chkNroContrato.TabIndex = 1;
            this.chkNroContrato.Text = "Nro. Contrato";
            this.chkNroContrato.UseVisualStyleBackColor = true;
            this.chkNroContrato.CheckedChanged += new System.EventHandler(this.chkNroContrato_CheckedChanged);
            // 
            // chkNroCarpeta
            // 
            this.chkNroCarpeta.AutoSize = true;
            this.chkNroCarpeta.Checked = true;
            this.chkNroCarpeta.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkNroCarpeta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkNroCarpeta.Location = new System.Drawing.Point(18, 32);
            this.chkNroCarpeta.Name = "chkNroCarpeta";
            this.chkNroCarpeta.Size = new System.Drawing.Size(107, 19);
            this.chkNroCarpeta.TabIndex = 0;
            this.chkNroCarpeta.Text = "Nro. Carpeta";
            this.chkNroCarpeta.UseVisualStyleBackColor = true;
            this.chkNroCarpeta.CheckedChanged += new System.EventHandler(this.chkNroCarpeta_CheckedChanged);
            // 
            // reportViewer1
            // 
            this.reportViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.daReportePresentacionBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "SanEmeterio.Listados.rptListadoPres.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(12, 122);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(965, 431);
            this.reportViewer1.TabIndex = 83;
            // 
            // cnjDatos
            // 
            this.cnjDatos.DataSetName = "CnjDatos";
            this.cnjDatos.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // daReportePresentacionBindingSource
            // 
            this.daReportePresentacionBindingSource.DataMember = "DaReportePresentacion";
            this.daReportePresentacionBindingSource.DataSource = this.cnjDatos;
            // 
            // daReportePresentacionTableAdapter
            // 
            this.daReportePresentacionTableAdapter.ClearBeforeFill = true;
            // 
            // frmListadoCarpetas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(989, 565);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.chkNroCarpeta);
            this.Controls.Add(this.chkNroContrato);
            this.Controls.Add(this.chkTitular);
            this.Controls.Add(this.chkActivas);
            this.Controls.Add(this.chkPasivas);
            this.Controls.Add(this.chkCompleto);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.cboMayor);
            this.Controls.Add(this.txtCantCuotas);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.cboCarta);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtCartaSD);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.chkProvincias);
            this.Controls.Add(this.cboProvincias);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtConResumen);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtPorEstado);
            this.Controls.Add(this.txtCarpetaHasta);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtCarpetaDesde);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Name = "frmListadoCarpetas";
            this.Text = "frmListadoCarpetas";
            this.Load += new System.EventHandler(this.frmListadoCarpetas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cnjDatos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.daReportePresentacionBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCarpetaHasta;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtPorEstado;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtConResumen;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCarpetaDesde;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cboProvincias;
        private System.Windows.Forms.CheckBox chkProvincias;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtCartaSD;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cboCarta;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtCantCuotas;
        private System.Windows.Forms.ComboBox cboMayor;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.CheckBox chkCompleto;
        private System.Windows.Forms.CheckBox chkPasivas;
        private System.Windows.Forms.CheckBox chkActivas;
        private System.Windows.Forms.CheckBox chkTitular;
        private System.Windows.Forms.CheckBox chkNroContrato;
        private System.Windows.Forms.CheckBox chkNroCarpeta;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private CnjDatos cnjDatos;
        private System.Windows.Forms.BindingSource daReportePresentacionBindingSource;
        private CnjDatosTableAdapters.DaReportePresentacionTableAdapter daReportePresentacionTableAdapter;

    }
}