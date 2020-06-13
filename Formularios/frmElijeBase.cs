namespace SanEmeterio.Formularios
{
    using System;
    using System.Configuration;
    using System.Data;
    using System.Linq;
    using System.Windows.Forms;
    using System.Collections;
    using SanEmeterio.Properties;
    using SanEmeterio.Clases;
    using System.Drawing;

    public partial class frmElijeBase : Form
    {
        //Color ColorFondo = Color.FromKnownColor(ConfigurationManager.AppSettings["Color"].ToString());
        //private string Color= ConfigurationManager.AppSettings["Color"].ToString();
        //Color yourColor = RGB(ConfigurationManager.AppSettings["Color"].ToString());
        //private int miColor = Convert.ToInt32(ConfigurationManager.AppSettings["Color"]);

        private string sBase;

        public frmElijeBase()
        {
            InitializeComponent();
        }

        private void frmElijeBase_Load(object sender, EventArgs e)
        {
            txtIP.Text = ConfigurationManager.AppSettings["IP"].ToString();

            var result = (from config in ((Hashtable)ConfigurationManager.GetSection("DBDatos")).Cast<DictionaryEntry>()
                          select new
                          {
                              key = config.Value,
                              value = config.Key
                          }).ToList();
            cboBase.DisplayMember = "value";
            cboBase.ValueMember = "key";
            cboBase.DataSource = result;

            cboBase.SelectedIndex = 0;

        }

        private void cambiarDatosServer(string localhost, string user, string pass, string namedb)
        {
            String cadenaNueva = "server=" + localhost + ";user id=" + user + ";password=" + pass + ";database=" + namedb + "";
            //abrimos la configuración de nuestro proyecto
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            //hacemos la modificacion de la cadena de conexion (ServerDb es el atributo que tengo en app.config) 
            config.ConnectionStrings.ConnectionStrings["cnx"].ConnectionString = cadenaNueva;
            //config.ConnectionStrings.ConnectionStrings["SanEmeterio.Properties.Settings.Conex"].ConnectionString = cadenaNueva;
            //config.ConnectionStrings.ConnectionStrings["SanEmeterio.Properties.Settings.sanemeterioConnectionString"].ConnectionString = cadenaNueva;
            //config.ConnectionStrings.ConnectionStrings["SanEmeterio.Properties.Settings.cnx"].ConnectionString = cadenaNueva;
            //Cambiamos el modo de guardado
            config.Save(ConfigurationSaveMode.Modified, true);
            // modificamos el guardado 
            Settings.Default.Save();
            ConfigurationManager.RefreshSection("connectionStrings");
            //Podemos revisar en la consola que configuraciones quedaron despues del comando
            //aqui en adelante es opcional        
            ConnectionStringSettingsCollection settings =
            ConfigurationManager.ConnectionStrings;
            if (settings != null)
            {
                foreach (ConnectionStringSettings cs in settings)
                {
                    Console.WriteLine(cs.Name);
                    Console.WriteLine(cs.ProviderName);
                    Console.WriteLine(cs.ConnectionString);
                }
            }
        }
        private void CambiaDatosImpre(string localhost, string user, string pass, string namedb)
        {
            String cadenaNueva = "server=" + localhost + ";user id=" + user + ";password=" + pass + ";database=" + namedb + "";
            //abrimos la configuración de nuestro proyecto
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            //hacemos la modificacion de la cadena de conexion (ServerDb es el atributo que tengo en app.config) 
            //config.ConnectionStrings.ConnectionStrings["cnx"].ConnectionString = cadenaNueva;
            config.ConnectionStrings.ConnectionStrings["SanEmeterio.Properties.Settings.Conex"].ConnectionString = cadenaNueva;
            //config.ConnectionStrings.ConnectionStrings["Estudio.Properties.Settings.sanemeterioConnectionString"].ConnectionString = cadenaNueva;
            //config.ConnectionStrings.ConnectionStrings["Estudio.Properties.Settings.cnx"].ConnectionString = cadenaNueva;
            //Cambiamos el modo de guardado
            config.Save(ConfigurationSaveMode.Modified, true);
            // modificamos el guardado 
            Settings.Default.Save();
            ConfigurationManager.RefreshSection("connectionStrings");
            //Podemos revisar en la consola que configuraciones quedaron despues del comando
            //aqui en adelante es opcional        
            ConnectionStringSettingsCollection settings =
            ConfigurationManager.ConnectionStrings;
            if (settings != null)
            {
                foreach (ConnectionStringSettings cs in settings)
                {
                    Console.WriteLine(cs.Name);
                    Console.WriteLine(cs.ProviderName);
                    Console.WriteLine(cs.ConnectionString);
                }
            }
        }
        private void cboBase_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;

                string key = Convert.ToString(cboBase.SelectedValue);
                string value = ((Hashtable)ConfigurationManager.GetSection("DBDatos"))[key].ToString();

                sBase = value;
                cambiarDatosServer(txtIP.Text, "root", "Mapuch33", sBase);
                CambiaDatosImpre(txtIP.Text, "root", "Mapuch33", sBase);
                //Database.ConnectionString= ConfigurationManager.ConnectionStrings["cnx"].ConnectionString;
                VariablesGlobales.NombreBase = sBase;
                FormPrincipal Princ = new FormPrincipal();
                Princ.Show();
                this.Hide();
            }
        }

        private void txtIP_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;

                cboBase.Focus();
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnRombo_Click(object sender, EventArgs e)
        {
            string key = "rombo";
            string value = ((Hashtable)ConfigurationManager.GetSection("DBDatos"))[key].ToString();

            sBase = value;
            cambiarDatosServer(txtIP.Text, "root", "Mapuch33", sBase);
            CambiaDatosImpre(txtIP.Text, "root", "Mapuch33", sBase);
            VariablesGlobales.NombreBase = sBase;
            FormPrincipal Princ = new FormPrincipal();
            Princ.Show();
            this.Hide();
        }

        private void btnChevrolet_Click(object sender, EventArgs e)
        {
            string key = "Chevrolet";
            string value = ((Hashtable)ConfigurationManager.GetSection("DBDatos"))[key].ToString();

            sBase = value;
            cambiarDatosServer(txtIP.Text, "root", "Mapuch33", sBase);
            CambiaDatosImpre(txtIP.Text, "root", "Mapuch33", sBase);
            VariablesGlobales.NombreBase = sBase;
            FormPrincipal Princ = new FormPrincipal();
            Princ.Show();
            this.Hide();
        }

        private void cboBase_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            e.DrawFocusRectangle();
            if (e.Index >= 0)
            {
                if (e.Index < listImages.Images.Count)
                {
                    Image img = new Bitmap(listImages.Images[e.Index], new Size(32, 32));
                    e.Graphics.DrawImage(img, new PointF(e.Bounds.Left, e.Bounds.Top));
                }
                e.Graphics.DrawString(cboBase.Text
                    , e.Font, new SolidBrush(e.ForeColor)
                    , e.Bounds.Left + 32, e.Bounds.Top);
            }
        }
    }
}
