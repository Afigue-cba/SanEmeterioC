namespace SanEmeterio.Formularios
{
    partial class frmSaldo
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
            this.BOT1 = new System.Windows.Forms.Button();
            this.BOT2 = new System.Windows.Forms.Button();
            this.BOT3 = new System.Windows.Forms.Button();
            this.mensaje = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // BOT1
            // 
            this.BOT1.Location = new System.Drawing.Point(12, 87);
            this.BOT1.Name = "BOT1";
            this.BOT1.Size = new System.Drawing.Size(75, 23);
            this.BOT1.TabIndex = 0;
            this.BOT1.Text = "button1";
            this.BOT1.UseVisualStyleBackColor = true;
            this.BOT1.Click += new System.EventHandler(this.BOT1_Click);
            // 
            // BOT2
            // 
            this.BOT2.Location = new System.Drawing.Point(123, 87);
            this.BOT2.Name = "BOT2";
            this.BOT2.Size = new System.Drawing.Size(75, 23);
            this.BOT2.TabIndex = 1;
            this.BOT2.Text = "button2";
            this.BOT2.UseVisualStyleBackColor = true;
            this.BOT2.Click += new System.EventHandler(this.BOT2_Click);
            // 
            // BOT3
            // 
            this.BOT3.Location = new System.Drawing.Point(231, 87);
            this.BOT3.Name = "BOT3";
            this.BOT3.Size = new System.Drawing.Size(75, 23);
            this.BOT3.TabIndex = 2;
            this.BOT3.Text = "button3";
            this.BOT3.UseVisualStyleBackColor = true;
            this.BOT3.Click += new System.EventHandler(this.BOT3_Click);
            // 
            // mensaje
            // 
            this.mensaje.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.mensaje.Location = new System.Drawing.Point(13, 40);
            this.mensaje.Name = "mensaje";
            this.mensaje.Size = new System.Drawing.Size(294, 23);
            this.mensaje.TabIndex = 3;
            this.mensaje.Text = "Mensaje";
            this.mensaje.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmSaldo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(316, 122);
            this.Controls.Add(this.mensaje);
            this.Controls.Add(this.BOT3);
            this.Controls.Add(this.BOT2);
            this.Controls.Add(this.BOT1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmSaldo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmSaldo_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BOT1;
        private System.Windows.Forms.Button BOT2;
        private System.Windows.Forms.Button BOT3;
        private System.Windows.Forms.Label mensaje;
    }
}