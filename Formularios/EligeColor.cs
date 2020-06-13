namespace SanEmeterio.Formularios
{
    using SanEmeterio.Clases;
    using SanEmeterio.Properties;
    using System;
    using System.Windows.Forms;

    public partial class EligeColor : Form
    {
        public EligeColor()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            ColorDialog colorForm = new ColorDialog();
            colorForm.ShowDialog();
            BackColor = colorForm.Color;

            //Mandamos el color al archivo de configuraciones
            if (VariablesGlobales.NombreBase == "rombo")
            {
                Settings.Default.ColorFondoRombo = colorForm.Color;
            }
            else if (VariablesGlobales.NombreBase == "chevrolet")
            {
                Settings.Default.ColorFondoChev = colorForm.Color;
            }

            //Usamos el metodo Save() de la clase Settings para guardar el valor fijado a la Key MyColor
            Settings.Default.Save();
            this.Close();
        }

        private void EligeColor_Load(object sender, EventArgs e)
        {
            if (VariablesGlobales.NombreBase == "rombo")
            {
                this.BackColor = Settings.Default.ColorFondoRombo;
                btnSalir.BackColor = Settings.Default.ColorBotonRombo;
                lblMuestra.ForeColor = Settings.Default.ColorEtiquetaRombo;
                txtCaja.ForeColor = Settings.Default.ColorTextoRombo;
                txtCaja.BackColor = Settings.Default.ColorFondoTextoRombo;
            }
            else if (VariablesGlobales.NombreBase == "chevrolet")
            {
                this.BackColor = Settings.Default.ColorFondoChev;
                btnSalir.BackColor = Settings.Default.ColorBotonChev;
                lblMuestra.ForeColor = Settings.Default.ColorEtiquetaChev;
                txtCaja.ForeColor = Settings.Default.ColorTextoChev;
                txtCaja.BackColor = Settings.Default.colorFondoTextoChev;
            }
        }

        private void btnFondo_CheckedChanged(object sender, EventArgs e)
        {
            ColorDialog colorForm = new ColorDialog();
            colorForm.ShowDialog();
            BackColor = colorForm.Color;

            //Mandamos el color al archivo de configuraciones
            if (VariablesGlobales.NombreBase == "rombo")
            {
                Settings.Default.ColorFondoRombo = colorForm.Color;
            }
            else if (VariablesGlobales.NombreBase == "chevrolet")
            {
                Settings.Default.ColorFondoChev = colorForm.Color;
            }

            //Usamos el metodo Save() de la clase Settings para guardar el valor fijado a la Key MyColor
            Settings.Default.Save();
        }

        private void btnLetras_CheckedChanged(object sender, EventArgs e)
        {
            ColorDialog colorForm = new ColorDialog();
            colorForm.ShowDialog();
            lblMuestra.ForeColor = colorForm.Color;

            //Mandamos el color al archivo de configuraciones
            if (VariablesGlobales.NombreBase == "rombo")
            {
                Settings.Default.ColorEtiquetaRombo = colorForm.Color;
            }
            else if (VariablesGlobales.NombreBase == "chevrolet")
            {
                Settings.Default.ColorEtiquetaChev = colorForm.Color;
            }

            //Usamos el metodo Save() de la clase Settings para guardar el valor fijado a la Key MyColor
            Settings.Default.Save();
        }

        private void btnTexto_CheckedChanged(object sender, EventArgs e)
        {
            ColorDialog colorForm = new ColorDialog();
            colorForm.ShowDialog();
            txtCaja.ForeColor = colorForm.Color;

            //Mandamos el color al archivo de configuraciones
            if (VariablesGlobales.NombreBase == "rombo")
            {
                Settings.Default.ColorTextoRombo = colorForm.Color;
            }
            else if (VariablesGlobales.NombreBase == "chevrolet")
            {
                Settings.Default.ColorTextoChev = colorForm.Color;
            }

            //Usamos el metodo Save() de la clase Settings para guardar el valor fijado a la Key MyColor
            Settings.Default.Save();

        }

        private void btnFondoTexto_CheckedChanged(object sender, EventArgs e)
        {
            ColorDialog colorForm = new ColorDialog();
            colorForm.ShowDialog();
            txtCaja.BackColor = colorForm.Color;

            //Mandamos el color al archivo de configuraciones
            if (VariablesGlobales.NombreBase == "rombo")
            {
                Settings.Default.ColorFondoTextoRombo = colorForm.Color;
            }
            else if (VariablesGlobales.NombreBase == "chevrolet")
            {
                Settings.Default.colorFondoTextoChev = colorForm.Color;
            }

            //Usamos el metodo Save() de la clase Settings para guardar el valor fijado a la Key MyColor
            Settings.Default.Save();

        }

        private void btnBoton_CheckedChanged(object sender, EventArgs e)
        {
            ColorDialog colorForm = new ColorDialog();
            colorForm.ShowDialog();
            btnSalir.BackColor = colorForm.Color;

            //Mandamos el color al archivo de configuraciones
            if (VariablesGlobales.NombreBase == "rombo")
            {
                Settings.Default.ColorBotonRombo = colorForm.Color;
            }
            else if (VariablesGlobales.NombreBase == "chevrolet")
            {
                Settings.Default.ColorBotonChev = colorForm.Color;
            }

            //Usamos el metodo Save() de la clase Settings para guardar el valor fijado a la Key MyColor
            Settings.Default.Save();

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
