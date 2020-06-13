namespace SanEmeterio.Formularios
{
    partial class EligeColor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EligeColor));
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.btnSalir = new System.Windows.Forms.Button();
            this.lblMuestra = new System.Windows.Forms.Label();
            this.btnBoton = new System.Windows.Forms.RadioButton();
            this.btnFondoTexto = new System.Windows.Forms.RadioButton();
            this.btnTexto = new System.Windows.Forms.RadioButton();
            this.btnLetras = new System.Windows.Forms.RadioButton();
            this.btnFondo = new System.Windows.Forms.RadioButton();
            this.txtCaja = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnSalir
            // 
            this.btnSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalir.BackColor = System.Drawing.Color.Turquoise;
            this.btnSalir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSalir.FlatAppearance.BorderSize = 0;
            this.btnSalir.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalir.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalir.Location = new System.Drawing.Point(103, 179);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(141, 45);
            this.btnSalir.TabIndex = 27;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // lblMuestra
            // 
            this.lblMuestra.AutoSize = true;
            this.lblMuestra.Location = new System.Drawing.Point(40, 120);
            this.lblMuestra.Name = "lblMuestra";
            this.lblMuestra.Size = new System.Drawing.Size(92, 13);
            this.lblMuestra.TabIndex = 26;
            this.lblMuestra.Text = "Muestra de Letras";
            // 
            // btnBoton
            // 
            this.btnBoton.AutoSize = true;
            this.btnBoton.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBoton.Location = new System.Drawing.Point(43, 90);
            this.btnBoton.Name = "btnBoton";
            this.btnBoton.Size = new System.Drawing.Size(64, 21);
            this.btnBoton.TabIndex = 25;
            this.btnBoton.TabStop = true;
            this.btnBoton.Text = "Boton";
            this.btnBoton.UseVisualStyleBackColor = true;
            this.btnBoton.CheckedChanged += new System.EventHandler(this.btnBoton_CheckedChanged);
            // 
            // btnFondoTexto
            // 
            this.btnFondoTexto.AutoSize = true;
            this.btnFondoTexto.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFondoTexto.Location = new System.Drawing.Point(119, 63);
            this.btnFondoTexto.Name = "btnFondoTexto";
            this.btnFondoTexto.Size = new System.Drawing.Size(125, 21);
            this.btnFondoTexto.TabIndex = 24;
            this.btnFondoTexto.TabStop = true;
            this.btnFondoTexto.Text = "Fondo de Texto";
            this.btnFondoTexto.UseVisualStyleBackColor = true;
            this.btnFondoTexto.CheckedChanged += new System.EventHandler(this.btnFondoTexto_CheckedChanged);
            // 
            // btnTexto
            // 
            this.btnTexto.AutoSize = true;
            this.btnTexto.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTexto.Location = new System.Drawing.Point(43, 63);
            this.btnTexto.Name = "btnTexto";
            this.btnTexto.Size = new System.Drawing.Size(59, 21);
            this.btnTexto.TabIndex = 23;
            this.btnTexto.TabStop = true;
            this.btnTexto.Text = "Texto";
            this.btnTexto.UseVisualStyleBackColor = true;
            this.btnTexto.CheckedChanged += new System.EventHandler(this.btnTexto_CheckedChanged);
            // 
            // btnLetras
            // 
            this.btnLetras.AutoSize = true;
            this.btnLetras.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLetras.Location = new System.Drawing.Point(119, 36);
            this.btnLetras.Name = "btnLetras";
            this.btnLetras.Size = new System.Drawing.Size(63, 21);
            this.btnLetras.TabIndex = 22;
            this.btnLetras.TabStop = true;
            this.btnLetras.Text = "Letras";
            this.btnLetras.UseVisualStyleBackColor = true;
            this.btnLetras.CheckedChanged += new System.EventHandler(this.btnLetras_CheckedChanged);
            // 
            // btnFondo
            // 
            this.btnFondo.AutoSize = true;
            this.btnFondo.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFondo.Location = new System.Drawing.Point(43, 36);
            this.btnFondo.Name = "btnFondo";
            this.btnFondo.Size = new System.Drawing.Size(67, 21);
            this.btnFondo.TabIndex = 21;
            this.btnFondo.TabStop = true;
            this.btnFondo.Text = "Fondo";
            this.btnFondo.UseVisualStyleBackColor = true;
            this.btnFondo.CheckedChanged += new System.EventHandler(this.btnFondo_CheckedChanged);
            // 
            // txtCaja
            // 
            this.txtCaja.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCaja.Location = new System.Drawing.Point(43, 146);
            this.txtCaja.Name = "txtCaja";
            this.txtCaja.Size = new System.Drawing.Size(201, 20);
            this.txtCaja.TabIndex = 20;
            this.txtCaja.Text = "Texto de Muestra";
            // 
            // EligeColor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.lblMuestra);
            this.Controls.Add(this.btnBoton);
            this.Controls.Add(this.btnFondoTexto);
            this.Controls.Add(this.btnTexto);
            this.Controls.Add(this.btnLetras);
            this.Controls.Add(this.btnFondo);
            this.Controls.Add(this.txtCaja);
            this.Name = "EligeColor";
            this.Text = "EligeColor";
            this.Load += new System.EventHandler(this.EligeColor_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Label lblMuestra;
        private System.Windows.Forms.RadioButton btnBoton;
        private System.Windows.Forms.RadioButton btnFondoTexto;
        private System.Windows.Forms.RadioButton btnTexto;
        private System.Windows.Forms.RadioButton btnLetras;
        private System.Windows.Forms.RadioButton btnFondo;
        private System.Windows.Forms.TextBox txtCaja;
    }
}