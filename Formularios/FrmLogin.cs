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
    using SanEmeterio.Clases;
    using SanEmeterio.Properties;
    using System;
    using System.Configuration;
    using System.Drawing;
    using System.Windows.Forms;

    public partial class FrmLogin : Form
    {
        public static string ActualUsuario;
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void txtUser_Enter(object sender, EventArgs e)
        {
            if (txtUser.Text == "USUARIO")
            {
                txtUser.Text = "";
                txtUser.ForeColor = Color.LightGray;
            }
        }

        private void txtUser_Leave(object sender, EventArgs e)
        {
            if (txtUser.Text == "")
            {
                txtUser.Text = "USUARIO";
                txtUser.ForeColor = Color.DimGray;
            }
        }

        private void txtPass_Enter(object sender, EventArgs e)
        {
            if (txtPass.Text == "PASSWORD")
            {
                txtPass.Text = "";
                txtPass.ForeColor = Color.LightGray;
                txtPass.UseSystemPasswordChar = true;
            }
            else
            {
                btnLogin.Focus();
            }
        }

        private void txtPass_Leave(object sender, EventArgs e)
        {
            if (txtPass.Text == "")
            {
                txtPass.Text = "PASSWORD";
                txtPass.ForeColor = Color.DimGray;
                txtPass.UseSystemPasswordChar = false;
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            LeeGravIni ini = new LeeGravIni();
            Color iColor = new Color();

            //iColor.ToArgb(ini.GetSetting(VariablesGlobales.Camino + "\\Configuracion.config", "PARAMETRO", "Color", "Default"));

            //cambiarDatosServer("192.168.1.88", "root", "Mapuch33", "sanemeterio");
            //panel1.BackColor = VariablesGlobales.ColorForm;
            //panel2.BackColor = VariablesGlobales.ColorForm;
            CargaUsuario();
            Limpiar();
        }

        private void CargaUsuario()
        {
            txtUser.DataSource = Clases.Rutinas.ObtenerUsuario();
            txtUser.DisplayMember = "nombre_operadores";
            txtUser.ValueMember = "Password";
        }
        private void Limpiar()
        {
            txtUser.Text = "";
        }
        private void Encuentra()
        {
            if (Rutinas.EncuentraUsuario(txtUser.Text, txtPass.Text))
            {
                string txtIP = ConfigurationManager.AppSettings["IP"].ToString();
                VariablesGlobales.Usuario = txtUser.Text;
                Parametros();
                string sBase=VariablesGlobales.NombreBase;

                sBase = VariablesGlobales.NombreBase;
                cambiarDatosServer(txtIP, "root", "Mapuch33", sBase);
                CambiaDatosImpre(txtIP, "root", "Mapuch33", sBase);
                //Database.ConnectionString= ConfigurationManager.ConnectionStrings["cnx"].ConnectionString;
                VariablesGlobales.NombreBase = sBase;
                FormPrincipal Princ = new FormPrincipal();
                Princ.Show();
                this.Hide();

                //Formularios.frmElijeBase eBase = new frmElijeBase();
                //eBase.Show();
                //this.Hide();
                //Formularios.frmMain Principal = new frmMain();
                //Principal.Show();
            }
            else
            {
                MessageBox.Show("Usuario o Password Incorectos, Reintente..!");
            }
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            Encuentra();
        }

        private void Parametros()
        {
            // declaro esto
            LeeGravIni Ini = new LeeGravIni();

            //para usarla uso estas funciones
            //salvar
            VariablesGlobales.NombreBase = Ini.GetSetting(VariablesGlobales.Camino + "\\Configuracion.config", "PARAMETRO", "BASE", "Default");
            Ini.SaveSetting(VariablesGlobales.Camino + "\\Configuracion.config", "PARAMETRO", "Usuario", txtUser.Text);

            //esto genera este texto dentro del archivo
            // [KEY]
            // Value=data

            //Ahora Leemos
            VariablesGlobales.Usuario = Ini.GetSetting(VariablesGlobales.Camino + "\\Configuracion.config", "PARAMETRO", "Usuario", "Default");
            ActualUsuario = VariablesGlobales.Usuario;
            //VariablesGlobales.ColorForm=Ini.GetSetting(VariablesGlobales.Camino + "\\Configuracion.config", "PARAMETRO", "Color", "Default");
            // valor = Data // si existe esa key y ese value dentro de esa key de lo contrario devuelve Default

            //solo el valor de DATA es case sencitive, el de key y value no 😉
        }

        private void txtUser_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                btnLogin.Focus();
            }
        }

        private void txtUser_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                txtPass.Focus();
            }
        }

        private void txtPass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                Encuentra();
                //btnLogin.Focus();
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


        private void cambiarDatosServer(string localhost, string user, string pass, string namedb)
        {
            String cadenaNueva = "server=" + localhost + ";user id=" + user + ";password=" + pass + ";database=" + namedb + "";
            //abrimos la configuración de nuestro proyecto
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            //hacemos la modificacion de la cadena de conexion (ServerDb es el atributo que tengo en app.config) 
            config.ConnectionStrings.ConnectionStrings["cnx"].ConnectionString = cadenaNueva;
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

    }
}
