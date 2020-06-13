using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SanEmeterio.Clases;

namespace SanEmeterio.Formularios
{
    public partial class frmSaldo : Form
    {
        private string sSaldo = "";
        public frmSaldo()
        {
            InitializeComponent();
        }

        private void frmSaldo_Load(object sender, EventArgs e)
        {
            this.Text = "Aplicar Saldo";
            mensaje.Text = "¿Que desea Hacer?";
            BOT1.Text = "Saldo";
            BOT2.Text = "Parcial";
            BOT3.Text = "Cancelar";
            sSaldo = "";

        }

        private void BOT1_Click(object sender, EventArgs e)
        {
            VariablesGlobales.sSaldo = "Saldo de Cuota";
            this.Close();
        }

        private void BOT2_Click(object sender, EventArgs e)
        {
            VariablesGlobales.sSaldo = "a cuenta de Cuota";
            this.Close();
        }

        private void BOT3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
