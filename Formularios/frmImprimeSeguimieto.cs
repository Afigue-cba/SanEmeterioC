using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SanEmeterio.Formularios
{
    public partial class frmImprimeSeguimieto : Form
    {
        public frmImprimeSeguimieto()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CargaUsuario()
        {
            cboOperadores.DataSource = Clases.Rutinas.ObtenerUsuario();
            cboOperadores.DisplayMember = "nombre_operadores";
            cboOperadores.ValueMember = "Password";
        }

        private void frmImprimeSeguimieto_Load(object sender, EventArgs e)
        {
            CargaUsuario();
            Limpiar();
        }

        private void Limpiar()
        {
            cboOperadores.Text = "";
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {

        }


    }
}
