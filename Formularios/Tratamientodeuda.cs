namespace SanEmeterio.Formularios
{
    using SanEmeterio.Clases;
    using SanEmeterio.CapaNegocio;
    using MySql.Data.MySqlClient;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Drawing;
    using System.Windows.Forms;

    public partial class Tratamientodeuda : Form
    {
        private List<Entidades.Carpetas> _listaRecibida = new List<Entidades.Carpetas>();
        private List<Entidades.numerorecibos> _NrosRecibo = new List<Entidades.numerorecibos>();

        private List<Entidades.parametrocuotas> _parametrocuotas = new List<Entidades.parametrocuotas>();
        private List<Entidades.Agenda> _Agenda = new List<Entidades.Agenda>();

        List<Entidades.EstadoCarpetas> _EstadoCarpeta = new List<Entidades.EstadoCarpetas>();
        ConfigurarGridView config = new ConfigurarGridView();

        private string sEstadoCarpeta = "";
        private int iEstadoCarpeta = 0;
        private int iProvincia = 0;
        private int iDocumento = 0;
        private Int32 AnchoComentarios = 0;
        private Boolean ModificaComentario = false;
        private int iDComentario = 0;

        public Tratamientodeuda()
        {

        }
        public Tratamientodeuda(List<Entidades.Carpetas> _listaEnviada)
        {
            InitializeComponent();
            _listaRecibida = _listaEnviada;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Limpiar()
        {
            txtCarpeta.Text = "";
            txtContrato.Text = "";
            txtExiste.Text = "0";
            txtActualP.Text = "";
            txtDomicilioP.Text = "";
            txtLocalidadP.Text = "";
            txtCodigoPostalP.Text = "";
            txtTelefonoP.Text = "";
            txtNroDocumentoP.Text = "";
            txtEmail.Text = "";
            dtFechaIngreso.Text = DateTime.Now.ToString();
            dtUltimoEstado.Text = DateTime.Now.ToString();
            txtApellidoG.Text = "";
            txtDomicilioG.Text = "";
            txtEmailG.Text = "";
            txtLocalidadG.Text = "";
            txtProvinciaG.Text = "";
            txtTelefonoG.Text = "";
            txtComentarios.Text = "";

            chkActiva.Checked = false;
            dgvDeuda.DataSource = null;
            dgvComentarios.DataSource = null;
            dgvAgenda.DataSource = null;
            txtCarpeta.Focus();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void txtCarpeta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                BuscaCarpeta("Carpeta", txtCarpeta.Text);
            }
        }
        private void CalculaDeuda()
        {
            double SumaCapital = 0;
            for (int i = 0; i < dgvDeuda.Rows.Count; i++)
            {
                bool checkedCell = (bool)dgvDeuda.Rows[i].Cells[0].Value;
                if (checkedCell==true)
                {
                    dgvDeuda.Rows[i].DefaultCellStyle.BackColor = Color.Green;
                    dgvDeuda.Rows[i].DefaultCellStyle.ForeColor = Color.WhiteSmoke;
                    SumaCapital = SumaCapital + Convert.ToDouble(dgvDeuda.Rows[i].Cells[3].Value);
                }
            }
            //dgvDeuda.Refresh();
        }
        private void Tratamientodeuda_Load(object sender, EventArgs e)
        {
            BuscaCarpeta("Carpeta", txtCarpeta.Text);
            config.RowColor(dgvDeuda);
        }

        private void BuscaCarpeta(string sCampo, string sDato)
        {
            double dCarpeta = 0;
            string sTitular = "";
            string sContrato = "";
            if (sCampo == "Carpeta")
            {
                double.TryParse(sDato, out dCarpeta);
            }
            else if (sCampo == "Titular")
            {
                sTitular = sDato;
            }
            else if (sCampo == "Contrato")
            {
                sContrato = sDato;
            }
            _listaRecibida = Rutinas.Buscar_Carpeta(sCampo, dCarpeta, sTitular, sContrato);
            txtContrato.Text = _listaRecibida[0].Numero_contrato;
            txtCarpeta.Text = _listaRecibida[0].Numero_letra.ToString();
            BuscaEstado();
            BuscaDocumento();
            BuscarProvincia();
            AsignaParametros();
            config.configurarGrdComentarios(dgvComentarios, txtContrato.Text);
            config.ConfigurarGrdAgenda(dgvAgenda, txtContrato.Text);
            //dgvDeuda.DataSource = null;
            _parametrocuotas = Rutinas.ObtenetParametros();
            txtIntereses.Text = _parametrocuotas[0].PC_Intmensual.ToString();
            config.configurarDgvDeuda(dgvDeuda, _listaRecibida[0].Id, Convert.ToDouble(txtIntereses.Text));
            txtGsAdmin.Text = _parametrocuotas[0].PC_Gastosadmin.ToString();
            txtGsBan.Text = _parametrocuotas[0].PC_Gtosbanco.ToString();
            txtHonorarios.Text = _parametrocuotas[0].PC_Honarios.ToString();
            txtIva.Text = _parametrocuotas[0].PC_IVAInsc.ToString();
            //config.RowColor(dgvDeuda);
            //dgvDeuda.Refresh();
            //CargaCuotas();
            CalculaDeuda();
            txtCarpeta.Focus();
        }
        private void AsignaParametros()
        {
            txtApellidop.Text = _listaRecibida.Find(x => x.Numero_contrato == txtContrato.Text).Apellidoynombre_propietario;
            if (!string.IsNullOrEmpty(_listaRecibida.Find(x => x.Numero_contrato == txtContrato.Text).Existe.ToString()))
            {
                txtExiste.Text = "0";
            }
            else
            {
                txtExiste.Text = _listaRecibida.Find(x => x.Numero_contrato == txtContrato.Text).Existe.ToString();
            }
            dtPeriodo.Text = _listaRecibida.Find(x => x.Numero_contrato == txtContrato.Text).Periodo.ToString();
            if (string.IsNullOrEmpty(_listaRecibida.Find(x => x.Numero_contrato == txtContrato.Text).Actual_propietario))
            {
                txtActualP.Text = "";
            }
            else
            {
                txtActualP.Text = _listaRecibida.Find(x => x.Numero_contrato == txtContrato.Text).Actual_propietario;
            }
            sEstadoCarpeta = _listaRecibida.Find(x => x.Numero_contrato == txtContrato.Text).Estado_carpeta;
            if (sEstadoCarpeta == "S")
            {
                chkActiva.Checked = true;
            }
            else
            {
                chkActiva.Checked = false;
            }
            int.TryParse(_listaRecibida.Find(x => x.Numero_contrato == txtContrato.Text).IDestadocarpetas.ToString(), out iEstadoCarpeta);
            int.TryParse(_listaRecibida.Find(x => x.Numero_contrato == txtContrato.Text).IdprovinciaS.ToString(), out iProvincia);
            int.TryParse(_listaRecibida.Find(x => x.Numero_contrato == txtContrato.Text).IddocumentoS.ToString(), out iDocumento);
            cboTipoDocumentoP.Text = Rutinas.BuscarDocumento(iDocumento);
            cboEstadoCarpeta.Text = Rutinas.BuscaEstadoCarpeta(iEstadoCarpeta, "");
            cboProvinciaP.SelectedValue = iProvincia;
            txtDomicilioP.Text = _listaRecibida.Find(x => x.Numero_contrato == txtContrato.Text).Domicilio_propietario;
            txtLocalidadP.Text = _listaRecibida.Find(x => x.Numero_contrato == txtContrato.Text).Localidad_propietario;
            txtCodigoPostalP.Text = _listaRecibida.Find(x => x.Numero_contrato == txtContrato.Text).Cp_propietario.ToString();
            txtTelefonoP.Text = _listaRecibida.Find(x => x.Numero_contrato == txtContrato.Text).Telefono_propietario;
            txtNroDocumentoP.Text = _listaRecibida.Find(x => x.Numero_contrato == txtContrato.Text).Numerodni_propietario;
            txtEmail.Text = _listaRecibida.Find(x => x.Numero_contrato == txtContrato.Text).Email;
            dtFechaIngreso.Text = _listaRecibida.Find(x => x.Numero_contrato == txtContrato.Text).Fecha_ingreso.ToString();
            dtUltimoEstado.Text = _listaRecibida.Find(x => x.Numero_contrato == txtContrato.Text).Ult_estado.ToString();
            if (!string.IsNullOrEmpty(_listaRecibida.Find(x => x.Numero_contrato == txtContrato.Text).Apellidoynombre_garante))
            {
                txtApellidoG.Text = _listaRecibida.Find(x => x.Numero_contrato == txtContrato.Text).Apellidoynombre_garante.ToString();
            }
            else
            {
                txtApellidoG.Text = "";
            }
            if (!string.IsNullOrEmpty(_listaRecibida.Find(x => x.Numero_contrato == txtContrato.Text).Domicilio_garante))
            {
                txtDomicilioG.Text = _listaRecibida.Find(x => x.Numero_contrato == txtContrato.Text).Domicilio_garante.ToString();
            }
            else
            {
                txtDomicilioG.Text = "";
            }
            if (!string.IsNullOrEmpty(_listaRecibida.Find(x => x.Numero_contrato == txtContrato.Text).Email_garante))
            {
                txtEmailG.Text = _listaRecibida.Find(x => x.Numero_contrato == txtContrato.Text).Email_garante.ToString();
            }
            else
            {
                txtEmailG.Text = "";
            }
            if (!string.IsNullOrEmpty(_listaRecibida.Find(x => x.Numero_contrato == txtContrato.Text).Localidad_garante))
            {
                txtLocalidadG.Text = _listaRecibida.Find(x => x.Numero_contrato == txtContrato.Text).Localidad_garante.ToString();
            }
            else
            {
                txtLocalidadG.Text = "";
            }
            if (!string.IsNullOrEmpty(_listaRecibida.Find(x => x.Numero_contrato == txtContrato.Text).IdprovinciaG.ToString()))
            {
                txtProvinciaG.Text = Rutinas.BuscaProvincia(Convert.ToInt32(_listaRecibida.Find(x => x.Numero_contrato == txtContrato.Text).IdprovinciaG.ToString()), "", "NOMBRE");
            }
            else
            {
                txtProvinciaG.Text = "";
            }
            if (!string.IsNullOrEmpty(_listaRecibida.Find(x => x.Numero_contrato == txtContrato.Text).Telefono_garante))
            {
                txtTelefonoG.Text = _listaRecibida.Find(x => x.Numero_contrato == txtContrato.Text).Telefono_garante.ToString();
            }
            else
            {
                txtTelefonoG.Text = "";
            }
        }

        private void BuscarProvincia()
        {
            cboProvinciaP.DataSource = Rutinas.ObtenerProvincia();
            cboProvinciaP.DisplayMember = "nombre_provincia";
            cboProvinciaP.ValueMember = "idprovincia";
        }

        private void BuscaDocumento()
        {
            cboTipoDocumentoP.DataSource = Rutinas.ObtenerDocumento();
            cboTipoDocumentoP.DisplayMember = "nombre_documento";
            cboTipoDocumentoP.ValueMember = "iddocumento";
        }

        private void BuscaEstado()
        {
            cboEstadoCarpeta.DataSource = Rutinas.ObtenerEstadoCarpeta();
            cboEstadoCarpeta.DisplayMember = "Denominacion";
            cboEstadoCarpeta.ValueMember = "Codigo";
        }

        private void dgvComentarios_Resize(object sender, EventArgs e)
        {
            //AnchoComentarios = panelComentarios.Width + 15;
            //dgvComentarios.Columns[0].Width = AnchoComentarios / 100 * 15;
            //dgvComentarios.Columns[1].Width = AnchoComentarios / 100 * 60;
            //dgvComentarios.Columns[2].Width = AnchoComentarios / 100 * 25;
            //dgvComentarios.Refresh();
        }

        private void dgvComentarios_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            if (e.ColumnIndex == 1)
            {
                ModificaComentario = true;
                txtComentarios.Text = dgvComentarios[1, i].Value.ToString();
                int.TryParse(dgvComentarios[3, i].Value.ToString(), out iDComentario);
                txtComentarios.Focus();
            }
        }

        private void btnAddComent_Click(object sender, EventArgs e)
        {

            DialogResult Resultado = MessageBox.Show("Actualiza Comentarios", "Comentarios", MessageBoxButtons.YesNo);
            if (Resultado == DialogResult.Yes)
            {
                //string sProv = cboProveedor.SelectedValue.ToString();
                DateTime fechaDia = DateTime.Now;
                MySqlConnection cnxGrabar = Clases.Database.obtenerConexion(true);
                // objeto transaccional
                MySqlTransaction tran = null;
                // string para transaccion
                string strSQL = "";
                // objeto command para ejecucion del query
                MySqlCommand command = new MySqlCommand();
                // seteo de atributos del command
                command.Connection = cnxGrabar;
                command.CommandType = CommandType.Text;
                command.CommandTimeout = 0;

                try
                {
                    // abrir la conexion
                    if (cnxGrabar.State != ConnectionState.Open)
                        cnxGrabar.Open();
                    // comenzamos la transaccion
                    tran = cnxGrabar.BeginTransaction();
                    // asignamos transaccion al command
                    command.Transaction = tran;

                    if (iDComentario != 0)
                    {
                        strSQL = "Update comentarios set comentarios_Comentario=@comentarios_Comentario Where comentarios_Id=@comentarios_Id";
                        // reasignamos el string sql al command
                        command.Parameters.Clear();
                        command.CommandText = strSQL;
                        command.Parameters.AddWithValue("@comentarios_Id", iDComentario);
                        command.Parameters.AddWithValue("@comentarios_Comentario", txtComentarios.Text);
                        // ejecutamos Insert
                        command.ExecuteNonQuery();

                    }
                    else
                    {
                        // preparamos Insert Pedido
                        strSQL = "Insert into comentarios (comentarios_Fecha, comentarios_Comentario, comentarios_Operador, contrato, carpeta) values (@comentarios_Fecha, @comentarios_Comentario, @comentarios_Operador, @contrato, @carpeta)";
                        // reasignamos el string sql al command
                        command.Parameters.Clear();
                        command.CommandText = strSQL;
                        command.Parameters.AddWithValue("@comentarios_Fecha", fechaDia);
                        command.Parameters.AddWithValue("@comentarios_Comentario", txtComentarios.Text);
                        command.Parameters.AddWithValue("@comentarios_Operador", VariablesGlobales.Usuario);
                        command.Parameters.AddWithValue("@contrato", txtContrato.Text);
                        command.Parameters.AddWithValue("@carpeta", txtCarpeta.Text);
                        // ejecutamos Insert
                        command.ExecuteNonQuery();

                    }
                    // si todo salio bien commiteamos los cambios
                    tran.Commit();
                    // emitimos el aviso exitoso
                    MessageBox.Show("Actualizado");
                    iDComentario = 0;
                }
                catch (Exception ex)
                {
                    // si algo fallo deshacemos todo
                    tran.Rollback();
                    // mostramos el mensaje del error
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    // cerramos la conexion
                    if (cnxGrabar.State != ConnectionState.Closed)
                        cnxGrabar.Close();
                    // destruimos la conexion
                    cnxGrabar.Dispose();
                }
                txtComentarios.Text = "";
                dgvComentarios.Refresh();
                dgvComentarios.Rows[dgvComentarios.Rows.Count - 1].Selected = true;
                dgvComentarios.Refresh();
            }
        }

        private void txtContrato_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                BuscaCarpeta("Contrato", txtContrato.Text);
            }
        }

        private void dgvDeuda_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            if (e.ColumnIndex == 0)
            {
                if ((bool)dgvDeuda.Rows[i].Cells[0].Value)
                {
                    dgvDeuda.Rows[i].Cells[0].Value = false;
                }
                else
                {
                    dgvDeuda.Rows[i].Cells[0].Value = true;
                }
                dgvDeuda.Refresh();

                int IID = _listaRecibida.Find(x => x.Numero_contrato == txtContrato.Text).Id;
                string sEstado = "";
                string sManual = "";
                int iCuota = 0;

                if ((bool)dgvDeuda.Rows[i].Cells[0].Value)
                {
                    sEstado = "S";
                    sManual = "N";
                }
                else
                {
                    sEstado = "N";
                    sManual = "S";
                }
                iCuota = Convert.ToInt32(dgvDeuda.Rows[i].Cells[2].Value);
                DialogResult Resultado = MessageBox.Show("Actualiza el Estado de la Cuota", "Cuotas", MessageBoxButtons.YesNo);
                if (Resultado == DialogResult.Yes)
                {
                    //string sProv = cboProveedor.SelectedValue.ToString();

                    MySqlConnection cnxGrabar = Database.obtenerConexion(true);
                    // objeto transaccional
                    MySqlTransaction tran = null;
                    // string para transaccion
                    string strSQL = "";
                    // objeto command para ejecucion del query
                    MySqlCommand command = new MySqlCommand();
                    // seteo de atributos del command
                    command.Connection = cnxGrabar;
                    command.CommandType = CommandType.Text;
                    command.CommandTimeout = 0;

                    try
                    {
                        // abrir la conexion
                        if (cnxGrabar.State != ConnectionState.Open)
                            cnxGrabar.Open();
                        // comenzamos la transaccion
                        tran = cnxGrabar.BeginTransaction();
                        // asignamos transaccion al command
                        command.Transaction = tran;

                        strSQL = "Update cargacuota set cargacuota_estado=@cargacuota_estado , Manual=@Manual where id=@id and cargacuota_cta=@cargacuota_cta";
                        // reasignamos el string sql al command
                        command.Parameters.Clear();
                        command.CommandText = strSQL;
                        command.Parameters.AddWithValue("@id", IID);
                        command.Parameters.AddWithValue("@cargacuota_estado", sEstado);
                        command.Parameters.AddWithValue("@Manual", sManual);
                        command.Parameters.AddWithValue("@cargacuota_cta", iCuota);
                        // ejecutamos Insert
                        command.ExecuteNonQuery();

                        // si todo salio bien commiteamos los cambios
                        tran.Commit();
                        // emitimos el aviso exitoso
                        MessageBox.Show("> Transaccion Exitosa");
                    }
                    catch (Exception ex)
                    {
                        // si algo fallo deshacemos todo
                        tran.Rollback();
                        // mostramos el mensaje del error
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        // cerramos la conexion
                        if (cnxGrabar.State != ConnectionState.Closed)
                            cnxGrabar.Close();
                        // destruimos la conexion
                        cnxGrabar.Dispose();
                    }
                }
                config.configurarDgvDeuda(dgvDeuda, _listaRecibida[0].Id, Convert.ToDouble(txtIntereses.Text));
            }
        }

        private void dgvAgenda_Resize(object sender, EventArgs e)
        {
            Int32 AnchoGrilla = dgvAgenda.Width;
            //dgvAgenda.Columns[0].Width = AnchoGrilla / 100 * 15;
            //dgvAgenda.Columns[1].Width = AnchoGrilla / 100 * 25;
            //dgvAgenda.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            //dgvAgenda.Refresh();
        }

        private void btnSeguimiento_Click(object sender, EventArgs e)
        {
            DialogResult Resultado = MessageBox.Show("Actualiza Agenda", "Tarea", MessageBoxButtons.YesNo);
            if (Resultado == DialogResult.Yes)
            {
                string esHora = DateTime.Now.Hour.ToString();
                string resp = nAgenda.Insertar(txtContrato.Text, dtFecha.Value, esHora, txtComentarios.Text.ToUpper(), "S", VariablesGlobales.Usuario, txtCarpeta.Text, DateTime.Now, "");
            }
            txtComentarios.Text = string.Empty;
            config.ConfigurarGrdAgenda(dgvAgenda, txtContrato.Text);
        }

        private void btnImpSeg_Click(object sender, EventArgs e)
        {
            frmImpresion visualizar = new frmImpresion();
            if (VariablesGlobales.Formularios_Acoplados=="S")
            {
                AddOwnedForm(visualizar);
                visualizar.FormBorderStyle = FormBorderStyle.None;
                visualizar.TopLevel = false;
                visualizar.Dock = DockStyle.Fill;
                this.Controls.Add(visualizar);
                this.Tag = visualizar;
                visualizar.BringToFront();
            }
            visualizar.Show();
        }

        private void btnTentativa_Click(object sender, EventArgs e)
        {
            frmTentativa visualizar = new frmTentativa(_listaRecibida);
            //if (VariablesGlobales.Formularios_Acoplados=="S")
            //{
            //    AddOwnedForm(visualizar);
            //    visualizar.FormBorderStyle = FormBorderStyle.None;
            //    visualizar.TopLevel = false;
            //    visualizar.Dock = DockStyle.Fill;
            //    this.Controls.Add(visualizar);
            //    this.Tag = visualizar;
            //    visualizar.BringToFront();
            //}
            int NroTentativa = 0;
            _NrosRecibo = Rutinas.ObtenerNumeros();
            NroTentativa = _NrosRecibo[0].Numero_recibos + 1;
            visualizar.optTentativa.Checked = true;
            visualizar.BuscarTentativaRecio("Tentativa", NroTentativa, Convert.ToInt32(txtCarpeta.Text));
            visualizar.Show();

        }

        private void btnRecibo_Click(object sender, EventArgs e)
        {
            frmTentativa visualizar = new frmTentativa(_listaRecibida);
            //if (VariablesGlobales.Formularios_Acoplados=="S")
            //{
            //    AddOwnedForm(visualizar);
            //    visualizar.FormBorderStyle = FormBorderStyle.None;
            //    visualizar.TopLevel = false;
            //    visualizar.Dock = DockStyle.Fill;
            //    this.Controls.Add(visualizar);
            //    this.Tag = visualizar;
            //    visualizar.BringToFront();
            //}
            int NroTentativa = 0;
            _NrosRecibo = Rutinas.ObtenerNumeros();
            NroTentativa = _NrosRecibo[2].Numero_recibos + 1;
            visualizar.optRecibo.Checked = true;
            visualizar.BuscarTentativaRecio("Recibo", NroTentativa, Convert.ToInt32(txtCarpeta.Text));
            visualizar.Show();

        }

        private void txtCarpeta_Enter(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCarpeta.Text))
            {
                txtCarpeta.ForeColor = Color.Red;
                txtCarpeta.BackColor = Color.Black;
                txtCarpeta.Select(txtCarpeta.Text.Length, 0);
            }
        }

        private void txtCarpeta_Leave(object sender, EventArgs e)
        {
            txtCarpeta.ForeColor = Color.Black;
            txtCarpeta.BackColor = Color.WhiteSmoke;
            txtCarpeta.Select(0, 0);
        }
    }
}
