namespace SanEmeterio.Formularios
{
    using SanEmeterio.Clases;
    using Microsoft.Win32;
    using System;
    using System.Drawing;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;

    public partial class FormPrincipal : Form
    {
        public FormPrincipal()
        {
            InitializeComponent();
        }

        private string sPanel = "";
        //RESIZE METODO PARA REDIMENCIONAR/CAMBIAR TAMAÑO A FORMULARIO EN TIEMPO DE EJECUCION ----------------------------------------------------------
        private int tolerance = 12;
        private const int WM_NCHITTEST = 132;
        private const int HTBOTTOMRIGHT = 17;
        private Rectangle sizeGripRectangle;

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_NCHITTEST:
                    base.WndProc(ref m);
                    var hitPoint = this.PointToClient(new Point(m.LParam.ToInt32() & 0xffff, m.LParam.ToInt32() >> 16));
                    if (sizeGripRectangle.Contains(hitPoint))
                        m.Result = new IntPtr(HTBOTTOMRIGHT);
                    break;
                default:
                    base.WndProc(ref m);
                    break;
            }
        }
        //----------------DIBUJAR RECTANGULO / EXCLUIR ESQUINA PANEL 
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            var region = new Region(new Rectangle(0, 0, this.ClientRectangle.Width, this.ClientRectangle.Height));

            sizeGripRectangle = new Rectangle(this.ClientRectangle.Width - tolerance, this.ClientRectangle.Height - tolerance, tolerance, tolerance);

            region.Exclude(sizeGripRectangle);
            this.panelContenedor.Region = region;
            this.Invalidate();
        }
        //----------------COLOR Y GRIP DE RECTANGULO INFERIOR
        protected override void OnPaint(PaintEventArgs e)
        {
            SolidBrush blueBrush = new SolidBrush(Color.FromArgb(244, 244, 244));
            e.Graphics.FillRectangle(blueBrush, sizeGripRectangle);

            base.OnPaint(e);
            ControlPaint.DrawSizeGrip(e.Graphics, Color.Transparent, sizeGripRectangle);
        }



        //METODO PARA ARRASTRAR EL FORMULARIO---------------------------------------------------------------------
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void panelBarraTitulo_MouseMove(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }



        //METODO PARA ABRIR FORM DENTRO DE PANEL-----------------------------------------------------
        private void AbrirFormEnPanel<Forms>() where Forms : Form, new()
        {
            Form formulario;
            formulario = panelContenedor.Controls.OfType<Forms>().FirstOrDefault();

            //si el formulario/instancia no existe, creamos nueva instancia y mostramos
            if (formulario == null)
            {
                formulario = new Forms();
                formulario.TopLevel = false;
                formulario.FormBorderStyle = FormBorderStyle.None;
                formulario.Dock = DockStyle.Fill;
                panelContenedor.Controls.Add(formulario);
                panelContenedor.Tag = formulario;
                formulario.Show();

                formulario.BringToFront();
                formulario.FormClosed += new FormClosedEventHandler(CloseForms);
            }
            else
            {

                //si la Formulario/instancia existe, lo traemos a frente
                formulario.BringToFront();

                //Si la instancia esta minimizada mostramos
                if (formulario.WindowState == FormWindowState.Minimized)
                {
                    formulario.WindowState = FormWindowState.Normal;
                }

            }
        }

        private void CloseForms(object sender, FormClosedEventArgs e)
        {
            Rutinas colorform = new Rutinas();
            colorform.BuscarColor();
            ColorForm();
            //if (Application.OpenForms["frmConsultaCarpeta"] == null)
            //    btnTratamiento.BackColor = Color.FromArgb(0, 122, 204);
            //if (Application.OpenForms["frmCargaBsAs"] == null)
            //    btnCargaBsAs.BackColor = Color.FromArgb(0, 122, 204);
            //if (Application.OpenForms["EligeColor"] == null)
            //    btnEligeColor.BackColor = Color.FromArgb(0, 122, 204);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        int lx, ly;
        int sw, sh;

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }


        //private void button2_Click(object sender, EventArgs e)
        //{
        //    AbrirFormEnPanel<Tratamientodeuda>();
        //    button2.BackColor = Color.FromArgb(12, 61, 92);
        //}

        //private void button3_Click(object sender, EventArgs e)
        //{
        //    AbrirFormEnPanel<Form3>();
        //    button3.BackColor = Color.FromArgb(12, 61, 92);
        //}

        private void btnTratamiento_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel<frmConsultaCarpeta>();
            btnTratamiento.BackColor = Color.FromArgb(12, 61, 92);
        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            if (chkAcoplados.Checked )
            {
                VariablesGlobales.Formularios_Acoplados = "S";
            }
            else
            {
                VariablesGlobales.Formularios_Acoplados = "N";
            }
            if (VariablesGlobales.NombreBase == "rombo")
            {
                btnCargaBsAs.Text = "Derivación Rombo";
            }
            else
            {
                btnCargaBsAs.Text = "Derivación Chevrolet";
            }
            lblUsuario.Text = VariablesGlobales.Usuario;
            string ClienteID = "";
            ClienteID = GetTeamviewerID();
            TeamViewerID.Text = " TeamViewer ID: " + ClienteID;
            Rutinas colorform = new Rutinas();
            colorform.BuscarColor();
            ColorForm();
            //Adaptar Formulario a toda la pantalla
            //this.Location = Screen.PrimaryScreen.WorkingArea.Location;
            //this.Size = Screen.PrimaryScreen.WorkingArea.Size;
        }
        public static string GetTeamviewerID()
        {
            var versions = new[] { "4", "5", "5.1", "6", "7", "8", "12" }.Reverse().ToList(); //Reverse to get ClientID of newer version if possible

            foreach (var path in new[] { "SOFTWARE\\TeamViewer", "SOFTWARE\\Wow6432Node\\TeamViewer" })
            {
                if (Registry.LocalMachine.OpenSubKey(path) != null)
                {
                    foreach (var version in versions)
                    {
                        var subKey = path;
                        if (Registry.LocalMachine.OpenSubKey(subKey) != null)
                        {
                            var clientID = Registry.LocalMachine.OpenSubKey(subKey).GetValue("ClientID");
                            if (clientID != null) //found it?
                            {
                                return Convert.ToInt32(clientID).ToString();
                            }
                        }
                    }
                }
            }
            //Not found, return an empty string
            return string.Empty;
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            if (panelMenu.Width == 250)
            {
                panelMenu.Width = 50;
            }
            else
            {
                panelMenu.Width = 250;
            }
        }

        private void Cerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnCargaBsAs_Click(object sender, EventArgs e)
        {
            if (VariablesGlobales.NombreBase == "rombo")
            {
                AbrirFormEnPanel<FrmDerivacionRombo>();
            }
            else
            {
                AbrirFormEnPanel<frmCargaBsAs>();
            }
            btnCargaBsAs.BackColor = Color.FromArgb(12, 61, 92);
        }

        private void btnEligeColor_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel<EligeColor>();
            btnEligeColor.BackColor = Color.FromArgb(12, 61, 92);
        }
        private void ColorForm()
        {
            if (VariablesGlobales.NombreBase == "rombo")
            {
                pbRombo.Visible = true;
                pbChevrolet.Visible = false;
            }
            else if (VariablesGlobales.NombreBase == "chevrolet")
            {
                pbRombo.Visible = false;
                pbChevrolet.Visible = true;
            }
            Rutinas.RecorreControls(this);
            //panelMenu.BackColor = VariablesGlobales.ColorFondo;
            //foreach (Control c in this.Controls)
            //{
            //    foreach (Control controlChild in c.Controls)
            //    {
            //        new Switch(c)
            //         .Case<Button>(action =>
            //         {
            //             c.BackColor = VariablesGlobales.ColorBoton;
            //             // Instrucciones en caso se trate de un TextBox...;
            //         })
            //         .Case<Label>(action =>
            //         {
            //             c.BackColor = VariablesGlobales.ColorLetras;
            //             // Instrucciones en caso se trate de un CheckBox...;
            //         })
            //        .Case<TextBox>(action =>
            //        {
            //            c.BackColor = VariablesGlobales.ColorFondoTexto;
            //            c.ForeColor = VariablesGlobales.ColorTexto;
            //            // Instrucciones en caso se trate de un CheckBox...;
            //        })
            //        .Case<Panel>(action =>
            //        {
            //            c.BackColor = VariablesGlobales.ColorForm;
            //            // Instrucciones en caso se trate de un CheckBox...;
            //        });
            //    }
            //}

            //foreach (Control Ctl in panelMenu.Controls)
            //{
            //    if (Ctl is Button)
            //    {
            //        Ctl.BackColor = VariablesGlobales.ColorBoton;
            //    }
            //    if (Ctl is Label)
            //    {
            //        Ctl.ForeColor = VariablesGlobales.ColorLetras;
            //    }
            //}

        }

        private void siColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sPanel == "Titulo")
            {
                panelBarraTitulo.Tag = "";
            }
            else
            {
                panelFormularios.Tag = "";
            }
            Rutinas.RecorreControls(this);
        }

        private void panelBarraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Right:
                    {
                        rightClickMenuStrip.Show(this, new Point(e.X, e.Y));//places the menu at the pointer position
                        sPanel = "Titulo";
                    }
                    break;
            }
        }

        private void noColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sPanel == "Titulo")
            {
                panelBarraTitulo.Tag = "estono";
            }
            else
            {
                panelFormularios.Tag = "estono";
            }
            Rutinas.RecorreControls(this);
        }

        private void panelFormularios_MouseDown(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Right:
                    {
                        rightClickMenuStrip.Show(this, new Point(e.X, e.Y));//places the menu at the pointer position
                        sPanel = "Formulario";
                    }
                    break;
            }

        }

        //private void btnColor_Click(object sender, EventArgs e)
        //{
        //    AbrirFormEnPanel<EligeColor>();
        //    btnColor.BackColor = Color.FromArgb(12, 61, 92);
        //}

        private void btnMaximizar_Click(object sender, EventArgs e)
        {
            lx = this.Location.X;
            ly = this.Location.Y;
            sw = this.Size.Width;
            sh = this.Size.Height;
            btnMaximizar.Visible = false;
            btnRestaurar.Visible = true;
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            this.Location = Screen.PrimaryScreen.WorkingArea.Location;
        }

        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            btnRestaurar.Visible = false;
            btnMaximizar.Visible = true;
            this.Size = new Size(sw, sh);
            this.Location = new Point(lx, ly);
        }

        private void btnListadoPresentacion_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel<frmListadoCarpetas>();
            btnListadoPresentacion.BackColor = Color.FromArgb(12, 61, 92);
        }

        private void chkAcoplados_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAcoplados.Checked )
            {
                VariablesGlobales.Formularios_Acoplados = "S";
            }
            else
            {
                VariablesGlobales.Formularios_Acoplados = "N";
            }
        }
    }
}
