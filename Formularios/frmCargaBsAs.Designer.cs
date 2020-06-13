namespace SanEmeterio.Formularios
{
    partial class frmCargaBsAs
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
            this.btnSalir = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNombreHoja = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.chkPE = new System.Windows.Forms.CheckBox();
            this.chkPG = new System.Windows.Forms.CheckBox();
            this.chkCSV = new System.Windows.Forms.CheckBox();
            this.lblCS = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCantidadRegCS = new System.Windows.Forms.TextBox();
            this.lblCD = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCantidadRegCD = new System.Windows.Forms.TextBox();
            this.dgvCartaS = new System.Windows.Forms.DataGridView();
            this.btnImportar = new System.Windows.Forms.Button();
            this.chkFila = new System.Windows.Forms.CheckBox();
            this.dgvCartaD = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCartaS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCartaD)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSalir
            // 
            this.btnSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnSalir.FlatAppearance.BorderSize = 0;
            this.btnSalir.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(50)))), ((int)(((byte)(70)))));
            this.btnSalir.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(61)))), ((int)(((byte)(92)))));
            this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalir.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnSalir.Location = new System.Drawing.Point(679, 515);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(121, 36);
            this.btnSalir.TabIndex = 69;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(406, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 13);
            this.label1.TabIndex = 68;
            this.label1.Text = "Ingrese Nombre de la Hoja";
            this.label1.Visible = false;
            // 
            // txtNombreHoja
            // 
            this.txtNombreHoja.Location = new System.Drawing.Point(545, 22);
            this.txtNombreHoja.Name = "txtNombreHoja";
            this.txtNombreHoja.Size = new System.Drawing.Size(149, 20);
            this.txtNombreHoja.TabIndex = 67;
            this.txtNombreHoja.Visible = false;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(700, 21);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(61, 21);
            this.btnBuscar.TabIndex = 66;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Visible = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAgregar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnAgregar.FlatAppearance.BorderSize = 0;
            this.btnAgregar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(50)))), ((int)(((byte)(70)))));
            this.btnAgregar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(61)))), ((int)(((byte)(92)))));
            this.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregar.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregar.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnAgregar.Location = new System.Drawing.Point(552, 515);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(121, 36);
            this.btnAgregar.TabIndex = 65;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = false;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // chkPE
            // 
            this.chkPE.AutoSize = true;
            this.chkPE.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkPE.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkPE.Location = new System.Drawing.Point(352, 521);
            this.chkPE.Name = "chkPE";
            this.chkPE.Size = new System.Drawing.Size(107, 20);
            this.chkPE.TabIndex = 64;
            this.chkPE.Text = "Plan Express";
            this.chkPE.UseVisualStyleBackColor = true;
            // 
            // chkPG
            // 
            this.chkPG.AutoSize = true;
            this.chkPG.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkPG.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkPG.Location = new System.Drawing.Point(200, 521);
            this.chkPG.Name = "chkPG";
            this.chkPG.Size = new System.Drawing.Size(120, 20);
            this.chkPG.TabIndex = 63;
            this.chkPG.Text = "Plan Gobierno";
            this.chkPG.UseVisualStyleBackColor = true;
            // 
            // chkCSV
            // 
            this.chkCSV.AutoSize = true;
            this.chkCSV.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkCSV.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkCSV.Location = new System.Drawing.Point(12, 521);
            this.chkCSV.Name = "chkCSV";
            this.chkCSV.Size = new System.Drawing.Size(159, 20);
            this.chkCSV.TabIndex = 62;
            this.chkCSV.Text = "Cartas Simple Veraz";
            this.chkCSV.UseVisualStyleBackColor = true;
            // 
            // lblCS
            // 
            this.lblCS.AutoSize = true;
            this.lblCS.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCS.Location = new System.Drawing.Point(349, 487);
            this.lblCS.Name = "lblCS";
            this.lblCS.Size = new System.Drawing.Size(183, 17);
            this.lblCS.TabIndex = 61;
            this.lblCS.Text = "Cantidad Cartas Simples :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(13, 487);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(156, 17);
            this.label3.TabIndex = 60;
            this.label3.Text = "Cantidad de Registros";
            // 
            // txtCantidadRegCS
            // 
            this.txtCantidadRegCS.Location = new System.Drawing.Point(175, 486);
            this.txtCantidadRegCS.Name = "txtCantidadRegCS";
            this.txtCantidadRegCS.Size = new System.Drawing.Size(117, 20);
            this.txtCantidadRegCS.TabIndex = 59;
            // 
            // lblCD
            // 
            this.lblCD.AutoSize = true;
            this.lblCD.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCD.Location = new System.Drawing.Point(349, 261);
            this.lblCD.Name = "lblCD";
            this.lblCD.Size = new System.Drawing.Size(210, 17);
            this.lblCD.TabIndex = 58;
            this.lblCD.Text = "Cantidad Cartas Documento :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 261);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(156, 17);
            this.label2.TabIndex = 57;
            this.label2.Text = "Cantidad de Registros";
            // 
            // txtCantidadRegCD
            // 
            this.txtCantidadRegCD.Location = new System.Drawing.Point(175, 260);
            this.txtCantidadRegCD.Name = "txtCantidadRegCD";
            this.txtCantidadRegCD.Size = new System.Drawing.Size(117, 20);
            this.txtCantidadRegCD.TabIndex = 56;
            // 
            // dgvCartaS
            // 
            this.dgvCartaS.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCartaS.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCartaS.Location = new System.Drawing.Point(12, 286);
            this.dgvCartaS.Name = "dgvCartaS";
            this.dgvCartaS.Size = new System.Drawing.Size(788, 194);
            this.dgvCartaS.TabIndex = 55;
            // 
            // btnImportar
            // 
            this.btnImportar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnImportar.FlatAppearance.BorderSize = 0;
            this.btnImportar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(50)))), ((int)(((byte)(70)))));
            this.btnImportar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(61)))), ((int)(((byte)(92)))));
            this.btnImportar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImportar.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImportar.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnImportar.Location = new System.Drawing.Point(12, 12);
            this.btnImportar.Name = "btnImportar";
            this.btnImportar.Size = new System.Drawing.Size(121, 36);
            this.btnImportar.TabIndex = 54;
            this.btnImportar.Text = "Buscar Datos";
            this.btnImportar.UseVisualStyleBackColor = false;
            this.btnImportar.Click += new System.EventHandler(this.btnImportar_Click);
            // 
            // chkFila
            // 
            this.chkFila.AutoSize = true;
            this.chkFila.Checked = true;
            this.chkFila.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkFila.Location = new System.Drawing.Point(171, 26);
            this.chkFila.Name = "chkFila";
            this.chkFila.Size = new System.Drawing.Size(202, 17);
            this.chkFila.TabIndex = 53;
            this.chkFila.Text = "Primera Fila Encabezado de Columna";
            this.chkFila.UseVisualStyleBackColor = true;
            // 
            // dgvCartaD
            // 
            this.dgvCartaD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCartaD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCartaD.Location = new System.Drawing.Point(12, 60);
            this.dgvCartaD.Name = "dgvCartaD";
            this.dgvCartaD.Size = new System.Drawing.Size(788, 194);
            this.dgvCartaD.TabIndex = 52;
            // 
            // frmCargaBsAs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(812, 563);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNombreHoja);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.chkPE);
            this.Controls.Add(this.chkPG);
            this.Controls.Add(this.chkCSV);
            this.Controls.Add(this.lblCS);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtCantidadRegCS);
            this.Controls.Add(this.lblCD);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCantidadRegCD);
            this.Controls.Add(this.dgvCartaS);
            this.Controls.Add(this.btnImportar);
            this.Controls.Add(this.chkFila);
            this.Controls.Add(this.dgvCartaD);
            this.Name = "frmCargaBsAs";
            this.Text = "frmCargaBsAs";
            this.Load += new System.EventHandler(this.frmCargaBsAs_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCartaS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCartaD)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNombreHoja;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.CheckBox chkPE;
        private System.Windows.Forms.CheckBox chkPG;
        private System.Windows.Forms.CheckBox chkCSV;
        private System.Windows.Forms.Label lblCS;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox txtCantidadRegCS;
        private System.Windows.Forms.Label lblCD;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox txtCantidadRegCD;
        private System.Windows.Forms.DataGridView dgvCartaS;
        private System.Windows.Forms.Button btnImportar;
        private System.Windows.Forms.CheckBox chkFila;
        private System.Windows.Forms.DataGridView dgvCartaD;
    }
}