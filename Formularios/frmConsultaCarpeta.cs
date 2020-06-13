namespace SanEmeterio.Formularios
{
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
    using SanEmeterio.Formularios;
    using MySql.Data.MySqlClient;

    public partial class frmConsultaCarpeta : Form
    {
        int IdCarpeta = 0;
        double dCarpeta = 0;
        string sTitular = "";
        string sContrato = "";
        string INivel = "";
        private int AnchoComentarios = 0;
        ConfigurarGridView config = new ConfigurarGridView();
        List<Entidades.Carpetas> _Carpetas = new List<Entidades.Carpetas>();

        public frmConsultaCarpeta()
        {
            InitializeComponent();
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Buscar_Carpeta(string Campo)
        {
            double.TryParse(txtCarpeta.Text, out dCarpeta);
            sTitular = txtTitular.Text;
            sContrato = txtContrato.Text;
            string sWhere = "";
            if (Campo == "Carpeta")
            {
                sWhere = "numero_letra=@numero_letra";
            }
            else if (Campo == "Titular")
            {
                sWhere = "apellidoynombre_propietario LIKE @apellidoynombre_propietario";
            }
            else
            {
                if (dCarpeta != 0)
                {
                    sWhere = "numero_contrato LIKE @numero_contrato AND numero_letra=@numero_letra";
                }
                else
                {
                    sWhere = "numero_contrato LIKE @numero_contrato";
                }
            }
            string Sqltext = "SELECT id, idcocesionario, iddocumentoG, iddocumentoS, idprovinciaG, idprovinciaS, IDestadocarpetas, numero_letra, numero_contrato, existe, numero_estudio, periodo, apellidoynombre_propietario, " +
                "actual_propietario, domicilio_propietario, localidad_propietario, cp_propietario, telefono_propietario, numerodni_propietario, apellidoynombre_garante, domicilio_garante, localidad_garante, " +
                "cp_garante, telefono_garante, numerodni_garante, p_n_cor, fecha_ingreso, ult_estado, intcap, estado_carpeta, nivel_deuda, cuotas, deuda, estado_comentario, domicilio_ap, " +
                "localidad_ap, cp_ap, idprovincia_ap, email, nivel, CuitDni, CondIva, N_garante, Piso_garante, Dpto_garante, Email_garante " +
                "FROM tratamientocarpetas where " + sWhere;

            _Carpetas.Clear();
            MySqlConnection Conexion = Clases.Database.obtenerConexion(true);
            if (Conexion.State != ConnectionState.Open)
                Conexion.Open();
            MySqlCommand _Comando = new MySqlCommand(Sqltext, Conexion);

            if (Campo == "Carpeta")
            {
                _Comando.Parameters.AddWithValue("@numero_letra", dCarpeta);
            }
            else if (Campo == "Titular")
            {
                _Comando.Parameters.AddWithValue("@apellidoynombre_propietario", "%" + sTitular + "%");
            }
            else
            {
                if (dCarpeta != 0)
                {
                    _Comando.Parameters.AddWithValue("@numero_contrato", sContrato + "%");
                    _Comando.Parameters.AddWithValue("@numero_letra", dCarpeta);
                }
                else
                {
                    _Comando.Parameters.AddWithValue("@numero_contrato", sContrato + "%");
                }
            }

            MySqlDataReader _readerIT = _Comando.ExecuteReader();

            while (_readerIT.Read())
            {
                Entidades.Carpetas p = new Entidades.Carpetas();
                try
                {
                    p.Id = _readerIT.GetInt32("id");
                    if (!_readerIT.IsDBNull(_readerIT.GetOrdinal("idcocesionario")))
                    {
                        p.Idcocesionario = _readerIT.GetInt32("idcocesionario");
                    }
                    if (!_readerIT.IsDBNull(_readerIT.GetOrdinal("iddocumentoG")))
                    {
                        p.IddocumentoG = _readerIT.GetInt32("iddocumentoG");
                    }
                    if (!_readerIT.IsDBNull(_readerIT.GetOrdinal("iddocumentoS")))
                    {
                        p.IddocumentoS = _readerIT.GetInt32("iddocumentoS");
                    }
                    if (!_readerIT.IsDBNull(_readerIT.GetOrdinal("idprovinciaG")))
                    {
                        p.IdprovinciaG = _readerIT.GetInt32("idprovinciaG");
                    }
                    if (!_readerIT.IsDBNull(_readerIT.GetOrdinal("idprovinciaS")))
                    {
                        p.IdprovinciaS = _readerIT.GetInt32("idprovinciaS");
                    }
                    if (!_readerIT.IsDBNull(_readerIT.GetOrdinal("IDestadocarpetas")))
                    {
                        p.IDestadocarpetas = _readerIT.GetInt32("IDestadocarpetas");
                    }
                    if (!_readerIT.IsDBNull(_readerIT.GetOrdinal("numero_letra")))
                    {
                        p.Numero_letra = _readerIT.GetInt32("numero_letra");
                    }
                    if (!_readerIT.IsDBNull(_readerIT.GetOrdinal("numero_contrato")))
                    {
                        p.Numero_contrato = _readerIT.GetString("numero_contrato");
                    }
                    else
                    {
                        p.Numero_contrato = "";
                    }
                    if (!_readerIT.IsDBNull(_readerIT.GetOrdinal("existe")))
                    {
                        p.Existe = _readerIT.GetInt32("existe");
                    }
                    else
                    {
                        p.Existe = 0;
                    }
                    if (!_readerIT.IsDBNull(_readerIT.GetOrdinal("numero_estudio")))
                    {
                        p.Numero_estudio = _readerIT.GetString("numero_estudio");
                    }
                    else
                    {
                        p.Numero_estudio = "";
                    }
                    if (!_readerIT.IsDBNull(_readerIT.GetOrdinal("periodo")))
                    {
                        p.Periodo = _readerIT.GetDateTime("periodo");
                    }
                    if (!_readerIT.IsDBNull(_readerIT.GetOrdinal("apellidoynombre_propietario")))
                    {
                        p.Apellidoynombre_propietario = _readerIT.GetString("apellidoynombre_propietario");
                    }
                    if (!_readerIT.IsDBNull(_readerIT.GetOrdinal("actual_propietario")))
                    {
                        p.Actual_propietario = _readerIT.GetString("actual_propietario");
                    }
                    else
                    {
                        p.Actual_propietario = "";
                    }
                    if (!_readerIT.IsDBNull(_readerIT.GetOrdinal("domicilio_propietario")))
                    {
                        p.Domicilio_propietario = _readerIT.GetString("domicilio_propietario");
                    }
                    if (!_readerIT.IsDBNull(_readerIT.GetOrdinal("localidad_propietario")))
                    {
                        p.Localidad_propietario = _readerIT.GetString("localidad_propietario");
                    }
                    if (!_readerIT.IsDBNull(_readerIT.GetOrdinal("cp_propietario")))
                    {
                        p.Cp_propietario = _readerIT.GetInt32("cp_propietario");
                    }
                    if (!_readerIT.IsDBNull(_readerIT.GetOrdinal("telefono_propietario")))
                    {
                        p.Telefono_propietario = _readerIT.GetString("telefono_propietario");
                    }
                    else
                    {
                        p.Telefono_propietario = "";
                    }
                    if (!_readerIT.IsDBNull(_readerIT.GetOrdinal("numerodni_propietario")))
                    {
                        p.Numerodni_propietario = _readerIT.GetString("numerodni_propietario");
                    }
                    else
                    {
                        p.Numerodni_propietario = "";
                    }
                    if (!_readerIT.IsDBNull(_readerIT.GetOrdinal("apellidoynombre_garante")))
                    {
                        p.Apellidoynombre_garante = _readerIT.GetString("apellidoynombre_garante");
                    }
                    else
                    {
                        p.Apellidoynombre_garante = "";
                    }
                    if (!_readerIT.IsDBNull(_readerIT.GetOrdinal("domicilio_garante")))
                    {
                        p.Domicilio_garante = _readerIT.GetString("domicilio_garante");
                    }
                    else
                    {
                        p.Domicilio_garante = "";
                    }
                    if (!_readerIT.IsDBNull(_readerIT.GetOrdinal("localidad_garante")))
                    {
                        p.Localidad_garante = _readerIT.GetString("localidad_garante");
                    }
                    else
                    {
                        p.Localidad_garante = "";
                    }
                    if (!_readerIT.IsDBNull(_readerIT.GetOrdinal("cp_garante")))
                    {
                        p.Cp_garante = _readerIT.GetInt32("cp_garante");
                    }
                    else
                    {
                        p.Cp_garante = 0;
                    }
                    if (!_readerIT.IsDBNull(_readerIT.GetOrdinal("telefono_garante")))
                    {
                        p.Telefono_garante = _readerIT.GetString("telefono_garante");
                    }
                    else
                    {
                        p.Telefono_garante = "";
                    }
                    if (!_readerIT.IsDBNull(_readerIT.GetOrdinal("numerodni_garante")))
                    {
                        p.Numerodni_garante = _readerIT.GetString("numerodni_garante");
                    }
                    else
                    {
                        p.Numerodni_garante = "";
                    }
                    if (!_readerIT.IsDBNull(_readerIT.GetOrdinal("p_n_cor")))
                    {
                        p.P_n_cor = _readerIT.GetInt32("p_n_cor");
                    }
                    if (!_readerIT.IsDBNull(_readerIT.GetOrdinal("fecha_ingreso")))
                    {
                        p.Fecha_ingreso = _readerIT.GetDateTime("fecha_ingreso");
                    }
                    if (!_readerIT.IsDBNull(_readerIT.GetOrdinal("ult_estado")))
                    {
                        p.Ult_estado = _readerIT.GetDateTime("ult_estado");
                    }
                    if (!_readerIT.IsDBNull(_readerIT.GetOrdinal("intcap")))
                    {
                        p.Intcap = _readerIT.GetString("intcap");
                    }
                    if (!_readerIT.IsDBNull(_readerIT.GetOrdinal("estado_carpeta")))
                    {
                        p.Estado_carpeta = _readerIT.GetString("estado_carpeta");
                    }
                    else
                    {
                        p.Estado_carpeta = "";
                    }
                    if (!_readerIT.IsDBNull(_readerIT.GetOrdinal("nivel_deuda")))
                    {
                        p.Nivel_deuda = _readerIT.GetString("nivel_deuda");
                    }
                    if (!_readerIT.IsDBNull(_readerIT.GetOrdinal("cuotas")))
                    {
                        p.Cuotas = _readerIT.GetString("cuotas");
                    }
                    else
                    {
                        p.Cuotas = "";
                    }
                    if (!_readerIT.IsDBNull(_readerIT.GetOrdinal("deuda")))
                    {
                        p.Deuda = _readerIT.GetString("deuda");
                    }
                    else
                    {
                        p.Deuda = "";
                    }
                    if (!_readerIT.IsDBNull(_readerIT.GetOrdinal("estado_comentario")))
                    {
                        p.Estado_comentario = _readerIT.GetString("estado_comentario");
                    }
                    else
                    {
                        p.Estado_comentario = "";
                    }
                    if (!_readerIT.IsDBNull(_readerIT.GetOrdinal("domicilio_ap")))
                    {
                        p.Domicilio_ap = _readerIT.GetString("domicilio_ap");
                    }
                    else
                    {
                        p.Domicilio_ap = "";
                    }
                    if (!_readerIT.IsDBNull(_readerIT.GetOrdinal("localidad_ap")))
                    {
                        p.Localidad_ap = _readerIT.GetString("localidad_ap");
                    }
                    else
                    {
                        p.Localidad_ap = "";
                    }
                    if (!_readerIT.IsDBNull(_readerIT.GetOrdinal("cp_ap")))
                    {
                        p.Cp_ap = _readerIT.GetInt32("cp_ap");
                    }
                    else
                    {
                        p.Cp_ap = 0;
                    }
                    if (!_readerIT.IsDBNull(_readerIT.GetOrdinal("idprovincia_ap")))
                    {
                        p.Idprovincia_ap = _readerIT.GetInt32("idprovincia_ap");
                    }
                    if (!_readerIT.IsDBNull(_readerIT.GetOrdinal("email")))
                    {
                        p.Email = _readerIT.GetString("email");
                    }
                    else
                    {
                        p.Email = "";
                    }
                    if (!_readerIT.IsDBNull(_readerIT.GetOrdinal("nivel")))
                    {
                        p.Nivel = _readerIT.GetInt32("nivel");
                    }
                    if (!_readerIT.IsDBNull(_readerIT.GetOrdinal("CuitDni")))
                    {
                        p.CuitDni = _readerIT.GetString("CuitDni");
                    }
                    if (!_readerIT.IsDBNull(_readerIT.GetOrdinal("CondIva")))
                    {
                        p.CondIva = _readerIT.GetString("CondIva");
                    }

                    IdCarpeta = p.Id;
                    dCarpeta = p.Numero_letra;
                    sTitular = p.Apellidoynombre_propietario;
                    txtTitular.Text = sTitular;
                    sContrato = p.Numero_contrato;
                    txtContrato.Text = sContrato;
                    INivel = p.Nivel_deuda;
                    _Carpetas.Add(p);
                    dgvConsulta.DataSource = null;
                    dgvConsulta.AutoGenerateColumns = false;
                    dgvConsulta.DataSource = _Carpetas;
                    AnchoComentarios = this.Size.Width;
                    dgvConsulta.Columns[0].Width = AnchoComentarios / 100 * 20;
                    dgvConsulta.Columns[1].Width = AnchoComentarios / 100 * 20;
                    dgvConsulta.Columns[2].Width = AnchoComentarios / 100 * 50;
                    dgvConsulta.Columns[3].Width = AnchoComentarios / 100 * 10;
                    dgvConsulta.Refresh();

                }
                catch (Exception ex)
                {
                    //MessageBox.Show(ex.Message);
                }
            }
            Conexion.Close();
        }

        private void txtCarpeta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                e.Handled = true;
                if (txtCarpeta.Text != "")
                {
                    Buscar_Carpeta("Carpeta");
                }
                SendKeys.Send("{tab}");
            }
        }

        private void txtTitular_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                e.Handled = true;

                if (txtTitular.Text != "")
                {
                    Buscar_Carpeta("Titular");
                }
                SendKeys.Send("{tab}");
            }
        }

        private void txtContrato_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (txtContrato.Text != "")
                {
                    e.Handled = true;
                    if (txtContrato.Text != "")
                    {
                        Buscar_Carpeta("Contrato");
                    }
                    dgvConsulta.Focus();
                }
                //SendKeys.Send("{tab}");
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarForm Limpia = new LimpiarForm();
            Limpia.BorrarCampos(this);
            //Limpiar();
            INivel = "";
            IdCarpeta = 0;
            txtCarpeta.Focus();
        }

        private void Limpiar()
        {
            txtCarpeta.Text = "";
            txtTitular.Text = "";
            txtContrato.Text = "";
            INivel = "";
            IdCarpeta = 0;
            dgvConsulta.DataSource = null;
            txtCarpeta.Focus();
        }

        private void frmConsultaCarpeta_Load(object sender, EventArgs e)
        {
            Rutinas.RecorreControls(this);
            config.ConfigurarGrid(dgvConsulta);
            Limpiar();
        }

        private void dgvConsulta_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            EventoDoubleClick(i);
        }
        private void EventoDoubleClick(int e)
        {
            Tratamientodeuda visualizar = new Tratamientodeuda(_Carpetas);
            if (VariablesGlobales.Formularios_Acoplados == "S")
            {
                AddOwnedForm(visualizar);
                visualizar.FormBorderStyle = FormBorderStyle.None;
                visualizar.TopLevel = false;
                visualizar.Dock = DockStyle.Fill;
                //FormPrincipal.panelFormularios.Controls.Add(visualizar);
                //FormPrincipal.panelFormularios.Tag = visualizar;
                this.Controls.Add(visualizar);
                this.Tag = visualizar;
                visualizar.BringToFront();
            }
            txtCarpeta.Text = dgvConsulta[0, e].Value.ToString();
            txtTitular.Text = dgvConsulta[2, e].Value.ToString();
            txtContrato.Text = dgvConsulta[1, e].Value.ToString();
            INivel = dgvConsulta[4, e].Value.ToString();
            int.TryParse(dgvConsulta[3, e].Value.ToString(), out IdCarpeta);
            visualizar.txtCarpeta.Text = txtCarpeta.Text;
            visualizar.txtContrato.Text = txtContrato.Text;
            //visualizar.txtApellidop.Text = _Carpetas.Find(x => x.id==IdCarpeta).apellidoynombre_propietario.ToString();
            visualizar.Show();
        }
        private void dgvConsulta_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.dgvConsulta.Columns[e.ColumnIndex].Name == "nivel")
            {
                try
                {
                    if (e.Value.GetType() != typeof(System.DBNull))
                    {
                        if (Convert.ToInt32(e.Value) == 1)
                        {
                            e.CellStyle.BackColor = Color.Green;
                            e.CellStyle.ForeColor = Color.Green;
                        }
                        if (Convert.ToInt32(e.Value) == 2)
                        {
                            e.CellStyle.BackColor = Color.Yellow;
                            e.CellStyle.ForeColor = Color.Yellow;
                        }
                        if (Convert.ToInt32(e.Value) == 3)
                        {
                            e.CellStyle.BackColor = Color.Red;
                            e.CellStyle.ForeColor = Color.Red;
                        }
                        if (Convert.ToInt32(e.Value) == 4)
                        {
                            e.CellStyle.BackColor = Color.Beige;
                            e.CellStyle.ForeColor = Color.Beige;
                        }
                        if (Convert.ToInt32(e.Value) == 5)
                        {
                            e.CellStyle.BackColor = Color.Blue;
                            e.CellStyle.ForeColor = Color.Blue;
                        }
                    }
                }
                catch (NullReferenceException ex)
                {
                    MessageBox.Show("" + ex);
                }
            }
        }

        private void dgvConsulta_Resize(object sender, EventArgs e)
        {
            AnchoComentarios = this.Size.Width;
            dgvConsulta.Columns[0].Width = AnchoComentarios / 100 * 20;
            dgvConsulta.Columns[1].Width = AnchoComentarios / 100 * 20;
            dgvConsulta.Columns[2].Width = AnchoComentarios / 100 * 50;
            dgvConsulta.Columns[3].Width = AnchoComentarios / 100 * 10;
            dgvConsulta.Refresh();
        }

        private void dgvConsulta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                EventoDoubleClick(dgvConsulta.CurrentCell.RowIndex);
            }
        }

        private void txtCarpeta_Enter(object sender, EventArgs e)
        {

        }

    }
}
