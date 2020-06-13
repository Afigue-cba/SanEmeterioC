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
using MySql.Data.MySqlClient;

namespace SanEmeterio.Formularios
{
    public partial class frmTentativa : Form
    {
        private List<Entidades.numerorecibos> _NrosRecibo = new List<Entidades.numerorecibos>();
        private List<Entidades.Carpetas> _listaRecibida = new List<Entidades.Carpetas>();
        List<Entidades.EstadoCarpetas> _EstadoCarpeta = new List<Entidades.EstadoCarpetas>();
        private List<Entidades.parametrocuotas> _parametrocuotas = new List<Entidades.parametrocuotas>();
        ConfigurarGridView config = new ConfigurarGridView();
        DateTimePicker dtp = new DateTimePicker();
        TextBox textCapital = new TextBox();
        Rectangle _Rectangulo;

        private string sEstadoCarpeta = "";
        private string txtEscribeCuotas = "";
        private int iEstadoCarpeta = 0;
        private int iProvincia = 0;
        private int iDocumento = 0;
        private int ActualFila = 0;
        private int MaxIDTen = 0;
        private string sSaldo = "";

        public frmTentativa()
        {
        }

        public frmTentativa(List<Entidades.Carpetas> _listaEnviada)
        {
            InitializeComponent();
            _listaRecibida = _listaEnviada;
            dgvDeuda.Controls.Add(dtp);
            dgvDeuda.Controls.Add(textCapital);
            //dgvDeuda.EditMode = false;
            textCapital.Visible = false;
            this.textCapital.Enter += new System.EventHandler(this.textCapital_Enter);
            this.textCapital.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textCapital_KeyPress);
            this.textCapital.Leave += new System.EventHandler(this.textCapital_Leave);
            //textCapital.Enter += new EventHandler(textCapital_Enter);
            dtp.Visible = false;
            dtp.Format = DateTimePickerFormat.Short;
            dtp.TextChanged += new EventHandler(dtp_TextChange);
        }
        //private void CargaUsuario()
        //{
        //    cboNombreUsuario.DataSource = Clases.Rutinas.ObtenerUsuario();
        //    cboNombreUsuario.DisplayMember = "nombre_operadores";
        //    cboNombreUsuario.ValueMember = "Password";
        //}


        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmTentativa_Load(object sender, EventArgs e)
        {
            //Rutinas.RecorreControls(this);
            //int NroTentativa = 0;
            //_NrosRecibo = Rutinas.ObtenerNumeros();
            //NroTentativa = _NrosRecibo[0].Numero_recibos+1;
            Limpiar();
            BuscaEstado();
            if (optTentativa.Checked)
            {
                this.Width = 480;
            }
            else
            {
                this.Width = 850;
            }
            sSaldo = VariablesGlobales.sSaldo;
            txtNumero.Text = _listaRecibida[0].Numero_letra.ToString();
            txtContrato.Text = _listaRecibida[0].Numero_contrato.ToString();
            int.TryParse(_listaRecibida.Find(x => x.Numero_letra == Convert.ToInt32(txtNumero.Text)).IDestadocarpetas.ToString(), out iEstadoCarpeta);
            cboEstadoCarpeta.Text = Rutinas.BuscaEstadoCarpeta(iEstadoCarpeta, "");
            cboEstadoCarpeta.Text = "CONTACTO CON DEUDOR";
            chkComentarios.Checked = true;
            txtApellidoyNombre.Text = _listaRecibida[0].Apellidoynombre_propietario.ToString();
            txtActualProp.Text = _listaRecibida[0].Actual_propietario.ToString();
            int.TryParse(_listaRecibida.Find(x => x.Numero_contrato == txtContrato.Text).IddocumentoS.ToString(), out iDocumento);
            cboCondIva.Text = Rutinas.BuscarDocumento(iDocumento);
            txtCuitDni.Text = _listaRecibida.Find(x => x.Numero_contrato == txtContrato.Text).Numerodni_propietario;

            _parametrocuotas = Rutinas.ObtenetParametros();
            txtInteres.Text = DoFormat(Convert.ToDouble(_parametrocuotas[0].PC_Intmensual.ToString()));
            txtGastos.Text = DoFormat(Convert.ToDouble(_parametrocuotas[0].PC_Gastosadmin.ToString()));
            txtBancario.Text = DoFormat(Convert.ToDouble(_parametrocuotas[0].PC_Gtosbanco.ToString()));
            txtHonorarios.Text = DoFormat(Convert.ToDouble(_parametrocuotas[0].PC_Honarios.ToString()));
            txtIva.Text = DoFormat(Convert.ToDouble(_parametrocuotas[0].PC_IVAInsc.ToString()));
            config.configurarDgvTentativa(dgvDeuda, _listaRecibida[0].Id, Convert.ToDouble(txtInteres.Text));
            config.RowColor(dgvDeuda);
            CargaUsuario();
            CalculaDeuda();
        }
        public static string DoFormat(double myNumber)
        {
            var s = string.Format("{0:0.00}", myNumber);

            if (s.EndsWith("00"))
            {
                return ((int)myNumber).ToString();
            }
            else
            {
                return s;
            }
        }
        private void CargaUsuario()
        {
            cboRealizado.DataSource = Clases.Rutinas.ObtenerUsuario();
            cboRealizado.DisplayMember = "nombre_operadores";
            cboRealizado.ValueMember = "Password";
        }

        public void BuscarTentativaRecio(string TipoComprobante, int NroComprobante, int NroCarpeta)
        {
            txtNroTentativa.Text = NroComprobante.ToString();

            if (TipoComprobante == "Recibo" || TipoComprobante == "ConTent")
            {
                chkFacElec.Visible = true;
                optRecibo.Checked = true;
                optTentativa.Checked = false;
                this.Text = "Recibo";
                this.Width = 800;
            }
            else
            {
                chkFacElec.Visible = false;
                optRecibo.Checked = false;
                optTentativa.Checked = true;
                this.Text = "Tentativa";
                this.Width = 480;
                //txtComentario.Width = 5000;
                //this.Width = 7150;
            }
        }

        private void BuscaEstado()
        {
            cboEstadoCarpeta.DataSource = Rutinas.ObtenerEstadoCarpeta();
            cboEstadoCarpeta.DisplayMember = "Denominacion";
            cboEstadoCarpeta.ValueMember = "Codigo";
        }
        private void CalculaDeuda()
        {
            double SumaCapital = 0;
            double SumaPunitorio = 0;
            double SumaIntereses = 0;
            double SumaGastos = 0;
            double SumaTotal = 0;
            double rowCapital = 0;
            double rowPunitorio = 0;
            double rowIntereses = 0;
            double rowGastos = 0;
            double rowTotal = 0;
            double Intereses = Convert.ToDouble(txtInteres.Text);
            double Gastos = Convert.ToDouble(txtGastos.Text);
            double Bancario = Convert.ToDouble(txtBancario.Text);
            double Iva = Convert.ToDouble(txtIva.Text);
            double Honorarios = Convert.ToDouble(txtHonorarios.Text);
            DateTimePicker dtpCompare = new DateTimePicker();
            DateTime fecha1 = new DateTime();
            DateTime fecha2 = new DateTime();
            TimeSpan dias = new TimeSpan();
            txtEscribeCuotas = string.Empty;
            for (int i = 0; i < dgvDeuda.Rows.Count; i++)
            {
                bool checkedCell = (bool)dgvDeuda.Rows[i].Cells[0].Value;
                if (checkedCell == true)
                {
                    dgvDeuda.Rows[i].DefaultCellStyle.BackColor = Color.Green;
                    dgvDeuda.Rows[i].DefaultCellStyle.ForeColor = Color.WhiteSmoke;
                    txtEscribeCuotas = txtEscribeCuotas + "- " + dgvDeuda.Rows[i].Cells[2].Value.ToString();
                    rowCapital = Convert.ToDouble(dgvDeuda.Rows[i].Cells[3].Value);
                    SumaCapital = SumaCapital + rowCapital;
                    rowPunitorio = Convert.ToDouble(dgvDeuda.Rows[i].Cells[4].Value);
                    SumaPunitorio = SumaPunitorio + rowPunitorio;
                    dtpCompare.Value = Convert.ToDateTime(dgvDeuda.Rows[i].Cells[5].Value);
                    dtpCompare.Format = DateTimePickerFormat.Short;
                    fecha1 = Convert.ToDateTime(dgvDeuda.Rows[i].Cells[5].Value);
                    fecha2 = Convert.ToDateTime(DateTime.Now);
                    dias = fecha1.Subtract(fecha2);
                    if (dias.Days > 0)
                    {
                        //Calculo Intereses
                        dgvDeuda.Rows[i].Cells[6].Value = Math.Round((rowCapital * Intereses / 100) / 30 * (dias.Days + 1), 2);
                    }
                    else
                    {
                        //dgvDeuda.Rows[i].Cells[6].Value = 0;
                    }
                    rowIntereses = Convert.ToDouble(dgvDeuda.Rows[i].Cells[6].Value);
                    SumaIntereses = SumaIntereses + rowIntereses;
                    rowGastos = Convert.ToDouble(dgvDeuda.Rows[i].Cells[7].Value);
                    SumaGastos = SumaGastos + rowGastos;
                    rowTotal = rowCapital + rowPunitorio + rowIntereses + rowGastos;
                    dgvDeuda.Rows[i].Cells[8].Value = Math.Round(rowTotal, 2);
                    SumaTotal = SumaTotal + rowTotal;
                    txtSumaCapital.Text = DoFormat(SumaCapital);
                    txtSumaPunitorio.Text = DoFormat(SumaPunitorio);
                    txtSumaFinanciero.Text = DoFormat(SumaIntereses);
                    txtSumaGastos.Text = DoFormat(SumaGastos);
                    txtTotalGral.Text = DoFormat(SumaTotal);
                }
                txtHonorario.Text = DoFormat((SumaTotal * Honorarios / 100) * (1 + (Iva / 100)));
                txtSumaGral.Text = DoFormat((SumaTotal + Convert.ToDouble(txtHonorario.Text)));
            }
            //dgvDeuda.Refresh();
        }

        private void dgvDeuda_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((bool)dgvDeuda.Rows[e.RowIndex].Cells[0].Value == true)
            {
                ActualFila = e.RowIndex;
                textBoxCapital.Text = DoFormat(Convert.ToDouble(dgvDeuda.CurrentRow.Cells[3].Value));
                textBoxPunitorio.Text = DoFormat(Convert.ToDouble(dgvDeuda.CurrentRow.Cells[4].Value));
                textBoxIntereses.Text = DoFormat(Convert.ToDouble(dgvDeuda.CurrentRow.Cells[6].Value));
                textBoxGastos.Text = DoFormat(Convert.ToDouble(dgvDeuda.CurrentRow.Cells[7].Value));
                textBoxTotal.Text = dgvDeuda.CurrentRow.Cells[8].Value.ToString();
                dateTimePickerFecha.Value = Convert.ToDateTime(dgvDeuda.CurrentRow.Cells[5].Value);
                grboxCalculos.Visible = true;
                textBoxCapital.Focus();
                //switch (dgvDeuda.Columns[e.ColumnIndex].Name)
                //{
                //    case "F. Pago":
                //        _Rectangulo = dgvDeuda.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                //        dtp.Size = new Size(_Rectangulo.Width, _Rectangulo.Height);
                //        dtp.Location = new Point(_Rectangulo.X, _Rectangulo.Y);
                //        dtp.Visible = true;
                //        textCapital.Visible = false;
                //        break;
                //    case "Capital":
                //        //_Rectangulo = dgvDeuda.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                //        //textCapital.Size = new System.Drawing.Size(_Rectangulo.Width, _Rectangulo.Height);
                //        //textCapital.Location = new Point(_Rectangulo.X, _Rectangulo.Y);
                //        //textCapital.Text = dgvDeuda.CurrentCell.Value.ToString();
                //        //textCapital.Visible = true;
                //        //textCapital.Focus();
                //        //dtp.Visible = false;
                //        break;
                //    case "Punitorio":
                //        dtp.Visible = false;
                //        textCapital.Visible = false;
                //        break;
                //}
            }
        }
        private void textCapital_Enter(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textCapital.Text))
            {
                textCapital.ForeColor = Color.White;
                textCapital.BackColor = Color.Blue;
                textCapital.Select(textCapital.Text.Length, 0);
            }

        }
        private void textCapital_Leave(object sender, EventArgs e)
        {
            textCapital.Visible = false;
            txtHonorario.Focus();
        }
        private void textCapital_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Divide))
            {
                dgvDeuda.CurrentCell.Value = textCapital.Text;
                CalculaDeuda();
                e.KeyChar = (char)0;
                textCapital.Visible = false;
                txtHonorarios.Focus();
            }
        }
        private void dtp_TextChange(object sender, EventArgs e)
        {
            dgvDeuda.CurrentCell.Value = dtp.Text.ToString();
            CalculaDeuda();
        }
        private void dgvDeuda_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            dtp.Visible = false;
        }

        private void dgvDeuda_Scroll(object sender, ScrollEventArgs e)
        {
            //dtp.Visible = false;
        }
        private void txtInteres_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                CalculaDeuda();
            }
        }

        private void dgvDeuda_KeyDown(object sender, KeyEventArgs e)
        {
            if ((bool)dgvDeuda.CurrentRow.Cells[0].Value == true)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                DataGridViewCell cell = dgvDeuda.CurrentRow.Cells[3];
                dgvDeuda.CurrentCell = cell;
                dgvDeuda.BeginEdit(true);

            }
        }

        private void dgvDeuda_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //if ((bool)dgvDeuda.Rows[e.RowIndex].Cells[0].Value == true)
            //{
            //    switch (dgvDeuda.Columns[e.ColumnIndex].Name)
            //    {
            //        case "Capital":
            //            _Rectangulo = dgvDeuda.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
            //            textCapital.Size = new System.Drawing.Size(_Rectangulo.Width, _Rectangulo.Height);
            //            textCapital.Location = new Point(_Rectangulo.X, _Rectangulo.Y);
            //            textCapital.Text = dgvDeuda.CurrentCell.Value.ToString();
            //            textCapital.Visible = true;
            //            textCapital.Focus();
            //            dtp.Visible = false;
            //            break;
            //    }
            //}
        }

        private void btnCanGrilla_Click(object sender, EventArgs e)
        {
            grboxCalculos.Visible = false;
            txtHonorario.Focus();
        }

        private void textBoxCapital_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (sSaldo != "")
                {
                    //Desido sobre el saldo
                    frmSaldo Saldo = new frmSaldo();
                    Saldo.ShowDialog();
                    sSaldo = VariablesGlobales.sSaldo;
                    textBoxCapital.Text = "(" + sSaldo + " " + dgvDeuda.Rows[ActualFila].Cells[2].Value.ToString() + "$" + DoFormat(Convert.ToDouble(textBoxCapital.Text));
                }
                else
                {
                    textBoxCapital.Text = DoFormat(Convert.ToDouble(textBoxCapital.Text));
                }
                Recalculo();
                textBoxPunitorio.Focus();
            }
        }
        private void Recalculo()
        {
            double dCapital = double.Parse(textBoxCapital.Text);
            double dPunitorio = double.Parse(textBoxPunitorio.Text);
            double dIntereses = double.Parse(textBoxIntereses.Text);
            double dGastos = double.Parse(textBoxGastos.Text);
            textBoxTotal.Text = DoFormat(dCapital + dPunitorio + dIntereses + dGastos);
        }

        private void textBoxPunitorio_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBoxPunitorio.Text = DoFormat(Convert.ToDouble(textBoxPunitorio.Text));
                Recalculo();
                dateTimePickerFecha.Focus();
            }
        }

        private void textBoxIntereses_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBoxIntereses.Text = DoFormat(Convert.ToDouble(textBoxIntereses.Text));
                Recalculo();
                textBoxGastos.Focus();
            }
        }

        private void textBoxGastos_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBoxGastos.Text = DoFormat(Convert.ToDouble(textBoxGastos.Text));
                Recalculo();
                btnModGrilla.Focus();
            }
        }

        private void btnModGrilla_Click(object sender, EventArgs e)
        {
            DialogResult Resultado = MessageBox.Show("Modifica la Cuota .?", "Tratamiento de Carpetas", MessageBoxButtons.YesNo);
            if (Resultado == DialogResult.Yes)
            {
                dgvDeuda.Rows[ActualFila].Cells[3].Value = textBoxCapital.Text;
                dgvDeuda.Rows[ActualFila].Cells[4].Value = textBoxPunitorio.Text;
                dgvDeuda.Rows[ActualFila].Cells[5].Value = dateTimePickerFecha.Text.ToString();
                dgvDeuda.Rows[ActualFila].Cells[7].Value = textBoxGastos.Text;
                dgvDeuda.Rows[ActualFila].Cells[6].Value = textBoxIntereses.Text;
                grboxCalculos.Visible = false;
                CalculaDeuda();
            }
        }

        private void dateTimePickerFecha_ValueChanged(object sender, EventArgs e)
        {
            Recalculo();
        }

        private void dateTimePickerFecha_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DateTimePicker dtpCompare = new DateTimePicker();
                DateTime fecha1 = new DateTime();
                DateTime fecha2 = new DateTime();
                TimeSpan dias = new TimeSpan();
                double Intereses = Convert.ToDouble(txtInteres.Text);
                double dCapital = Convert.ToDouble(textBoxCapital.Text);
                double dIntereses = double.Parse(textBoxIntereses.Text);
                dtpCompare.Value = dateTimePickerFecha.Value;
                dtpCompare.Format = DateTimePickerFormat.Short;
                fecha1 = dateTimePickerFecha.Value;
                fecha2 = Convert.ToDateTime(DateTime.Now);
                dias = fecha1.Subtract(fecha2);
                if (dias.Days > 0)
                {
                    //Calculo Intereses
                    dIntereses = Math.Round((dCapital * Intereses / 100) / 30 * (dias.Days + 1), 2);
                }
                else
                {
                    dIntereses = 0;
                }
                textBoxIntereses.Text = DoFormat(dIntereses);
                Recalculo();
                textBoxIntereses.Focus();
            }
        }

        private void txtHonorario_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtHonorario.Text = DoFormat(Convert.ToDouble(txtHonorario.Text));
                txtSumaGral.Text = DoFormat(Convert.ToDouble(txtTotalGral.Text) + Convert.ToDouble(txtHonorario.Text));
            }
        }
        private void Limpiar()
        {
            txtHonorario.Text = DoFormat(0);
            txtImporteCheques.Text = DoFormat(0);
            txtImporteEf.Text = DoFormat(0);
            txtSumaCapital.Text = DoFormat(0);
            txtSumaPunitorio.Text = DoFormat(0);
            txtSumaFinanciero.Text = DoFormat(0);
            txtSumaGastos.Text = DoFormat(0);
            txtInteres.Text = DoFormat(0);
            txtGastos.Text = DoFormat(0);
            txtBancario.Text = DoFormat(0);
            txtIva.Text = DoFormat(0);
            txtHonorarios.Text = DoFormat(0);

        }
        private void btnGrabar_Click(object sender, EventArgs e)
        {
            DateTime fechaDia = DateTime.Now;
            int lnId = _listaRecibida[0].Id;
            MySqlConnection cnxGrabar = Clases.Database.obtenerConexion(true);
            // objeto transaccional
            MySqlTransaction tran = null;
            // string para transaccion
            string strSQL = "";
            // objeto command para ejecucion del query
            MySqlCommand command = new MySqlCommand();
            if (optRecibo.Checked == true)
            {

            }
            else
            {
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

                    // preparamos Insert Pedido
                    strSQL = "Insert Into tentativaenc (pactadoFecha, nroTentativa, carpetaNombre, contrato, comentario, realizadoPor, Id, Numero_Letra, Honorarios, Cheques, Efectivo, Capital, Punitorios, Interes, Gastos, PorInteres, PorGastos, PorBancario, PorIva, PorHonorario, ChkEfectivo) values (@pactadoFecha, @nroTentativa, @carpetaNombre, @contrato, @comentario, @realizadoPor, @Id, @Numero_Letra, @Honorarios, @Cheques, @Efectivo, @Capital, @Punitorios, @Interes, @Gastos, @PorInteres, @PorGastos, @PorBancario, @PorIva, @PorHonorario, @ChkEfectivo)";
                    // reasignamos el string sql al command
                    command.Parameters.Clear();
                    command.CommandText = strSQL;
                    command.Parameters.AddWithValue("@pactadoFecha", fechaDia);
                    command.Parameters.AddWithValue("@nroTentativa", Rutinas.ConvertirStr(txtNroTentativa.Text,"I"));
                    command.Parameters.AddWithValue("@carpetaNombre", txtApellidoyNombre.Text);
                    command.Parameters.AddWithValue("@contrato", txtContrato.Text);
                    command.Parameters.AddWithValue("@comentario", txtComentario.Text);
                    command.Parameters.AddWithValue("@realizadoPor", VariablesGlobales.Usuario);
                    command.Parameters.AddWithValue("@Id", lnId);
                    command.Parameters.AddWithValue("@Numero_Letra", Rutinas.ConvertirStr(txtNumero.Text,"I"));
                    command.Parameters.AddWithValue("@Honorarios", Rutinas.ConvertirStr(txtHonorario.Text,"D"));
                    command.Parameters.AddWithValue("@Cheques", Rutinas.ConvertirStr(txtImporteCheques.Text, "D"));
                    command.Parameters.AddWithValue("@Efectivo", Rutinas.ConvertirStr(txtImporteEf.Text, "D"));
                    command.Parameters.AddWithValue("@Capital", Rutinas.ConvertirStr(txtSumaCapital.Text, "D"));
                    command.Parameters.AddWithValue("@Punitorios", Rutinas.ConvertirStr(txtSumaPunitorio.Text, "D"));
                    command.Parameters.AddWithValue("@Interes", Rutinas.ConvertirStr(txtSumaFinanciero.Text, "D"));
                    command.Parameters.AddWithValue("@Gastos", Rutinas.ConvertirStr(txtSumaGastos.Text, "D"));
                    command.Parameters.AddWithValue("@PorInteres", Rutinas.ConvertirStr(txtInteres.Text, "D"));
                    command.Parameters.AddWithValue("@PorGastos", Rutinas.ConvertirStr(txtGastos.Text, "D"));
                    command.Parameters.AddWithValue("@PorBancario", Rutinas.ConvertirStr(txtBancario.Text, "D"));
                    command.Parameters.AddWithValue("@PorIva", Rutinas.ConvertirStr(txtIva.Text, "D"));
                    command.Parameters.AddWithValue("@PorHonorario", Rutinas.ConvertirStr(txtHonorarios.Text, "D"));
                    command.Parameters.AddWithValue("@ChkEfectivo", "N");
                    // ejecutamos Insert
                    command.ExecuteNonQuery();

                    // si todo salio bien commiteamos los cambios
                    tran.Commit();
                    // emitimos el aviso exitoso
                    //MessageBox.Show("Actualizado");
                }
                catch (Exception ex)
                {
                    // si algo fallo deshacemos todo
                    tran.Rollback();
                    // mostramos el mensaje del error
                    //MessageBox.Show(ex.Message);
                }
                finally
                {
                    MaxIDTen = Rutinas.LastId();
                    // cerramos la conexion
                    //if (cnxGrabar.State != ConnectionState.Closed)
                    //    cnxGrabar.Close();
                    // destruimos la conexion
                    //cnxGrabar.Dispose();
                }

                if (txtComentario.Text != string.Empty)
                {
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

                        // preparamos Insert Pedido
                        strSQL = "Insert into comentarios (comentarios_Fecha, comentarios_Comentario, comentarios_Operador, contrato, carpeta) values (@comentarios_Fecha, @comentarios_Comentario, @comentarios_Operador, @contrato, @carpeta)";
                        // reasignamos el string sql al command
                        command.Parameters.Clear();
                        command.CommandText = strSQL;
                        command.Parameters.AddWithValue("@comentarios_Fecha", fechaDia);
                        command.Parameters.AddWithValue("@comentarios_Comentario", txtComentario.Text);
                        command.Parameters.AddWithValue("@comentarios_Operador", VariablesGlobales.Usuario);
                        command.Parameters.AddWithValue("@contrato", txtContrato.Text);
                        command.Parameters.AddWithValue("@carpeta", txtNumero.Text);
                        // ejecutamos Insert
                        command.ExecuteNonQuery();

                        // si todo salio bien commiteamos los cambios
                        tran.Commit();
                        // emitimos el aviso exitoso
                        //MessageBox.Show("Actualizado");
                    }
                    catch (Exception ex)
                    {
                        // si algo fallo deshacemos todo
                        tran.Rollback();
                        // mostramos el mensaje del error
                        //MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        // cerramos la conexion
                        //if (cnxGrabar.State != ConnectionState.Closed)
                        //    cnxGrabar.Close();
                        // destruimos la conexion
                        //cnxGrabar.Dispose();
                    }
                    txtComentario.Text = "";
                }
                int IdEstadoC = Rutinas.BuscarEstado(cboEstadoCarpeta.Text);
                UpdateTra(IdEstadoC);
                string sRT = "R";
                string strReciboT="Recibo";
                if (optRecibo.Checked==true)
                {
                    sRT = "R";
                    strReciboT="Recibo";
                }
                else
                {
                    sRT = "T";
                    strReciboT="Tentativa";
                }
                string sComentarioTentativa = "Se realizo " + strReciboT + " Nro.:" + txtNroTentativa.Text + " Capital=" + txtSumaCapital.Text + " Interes=" + (Convert.ToDouble(txtSumaPunitorio.Text) + Convert.ToDouble(txtSumaFinanciero.Text)) + " Gastos=" +  Convert.ToDouble(txtSumaGastos.Text) + " Total=" + Convert.ToDouble(txtTotalGral.Text) + " Honorarios=" + txtHonorario.Text + " de cuota/s=" + txtEscribeCuotas;
                InsertaCom(DateTime.Now, sComentarioTentativa, VariablesGlobales.Usuario, txtContrato.Text, Convert.ToInt32(txtNumero.Text));
                //Reccorro cuotas
                string rowCuota = "";
                double rowCapital = 0;
                double rowPunitorio = 0;
                double rowIntereses = 0;
                double rowGastos = 0;
                double rowTotal = 0;
                bool bolCuotas=false;
                DateTimePicker dtpCompare = new DateTimePicker();
                DateTime dtFechaVenc = new DateTime();
                for (int i = 0; i < dgvDeuda.Rows.Count; i++)
                {
                    bool checkedCell = (bool)dgvDeuda.Rows[i].Cells[0].Value;
                    if (checkedCell == true)
                    {
                        dtFechaVenc = Convert.ToDateTime(dgvDeuda.Rows[i].Cells[1].Value.ToString());
                        rowCuota = dgvDeuda.Rows[i].Cells[2].Value.ToString();
                        rowCapital = Convert.ToDouble(dgvDeuda.Rows[i].Cells[3].Value);
                        rowPunitorio = Convert.ToDouble(dgvDeuda.Rows[i].Cells[4].Value);
                        dtpCompare.Value = Convert.ToDateTime(dgvDeuda.Rows[i].Cells[5].Value);
                        rowIntereses = Convert.ToDouble(dgvDeuda.Rows[i].Cells[6].Value);
                        rowGastos = Convert.ToDouble(dgvDeuda.Rows[i].Cells[7].Value);
                        rowTotal = Convert.ToDouble(dgvDeuda.Rows[i].Cells[8].Value);
                        bolCuotas = Rutinas.InsertaCuota(MaxIDTen, rowCuota, dtFechaVenc, dtpCompare.Value, rowCapital, rowPunitorio, rowIntereses, rowGastos, 0, 0);
                    }
                }
                btnGrabar.Enabled = false;
                btnImprimir.Enabled = true;
            }
        }

        private void InsertaCom(DateTime dtFecha, string sComentario, string sOperador,string sContacto, int iCarpeta)
        {
            DateTime fechaDia = dtFecha;
            MySqlConnection cnxUpdTr = Clases.Database.obtenerConexion(true);
            // objeto transaccional
            MySqlTransaction tran = null;
            // string para transaccion
            string strSQL = "";
            // objeto command para ejecucion del query
            MySqlCommand command = new MySqlCommand();
            command.Connection = cnxUpdTr;
            command.CommandType = CommandType.Text;
            command.CommandTimeout = 0;

            try
            {
                // abrir la conexion
                if (cnxUpdTr.State != ConnectionState.Open)
                    cnxUpdTr.Open();
                // comenzamos la transaccion
                tran = cnxUpdTr.BeginTransaction();
                // asignamos transaccion al command
                command.Transaction = tran;

                // preparamos Insert Pedido
                strSQL = "Insert into comentarios (comentarios_Fecha, comentarios_Comentario, comentarios_Operador, contrato, carpeta) values (@comentarios_Fecha, @comentarios_Comentario, @comentarios_Operador, @contrato, @carpeta)";
                // reasignamos el string sql al command
                command.Parameters.Clear();
                command.CommandText = strSQL;
                command.Parameters.AddWithValue("@comentarios_Fecha", fechaDia);
                command.Parameters.AddWithValue("@comentarios_Comentario", sComentario);
                command.Parameters.AddWithValue("@comentarios_Operador", sOperador);
                command.Parameters.AddWithValue("@contrato", sContacto);
                command.Parameters.AddWithValue("@carpeta", iCarpeta);
                // ejecutamos Insert
                command.ExecuteNonQuery();

                // si todo salio bien commiteamos los cambios
                tran.Commit();
                // emitimos el aviso exitoso
                //MessageBox.Show("Actualizado");
            }
            catch (Exception ex)
            {
                // si algo fallo deshacemos todo
                tran.Rollback();
                // mostramos el mensaje del error
                //MessageBox.Show(ex.Message);
            }
            finally
            {
                // cerramos la conexion
                if (cnxUpdTr.State != ConnectionState.Closed)
                    cnxUpdTr.Close();
                // destruimos la conexion
                cnxUpdTr.Dispose();
            }

        }

        private void UpdateTra(int IdestadoC)
        {
            DateTime fechaDia = DateTime.Now;
            MySqlConnection cnxUpdTr = Clases.Database.obtenerConexion(true);
            // objeto transaccional
            MySqlTransaction tran = null;
            // string para transaccion
            string strSQL = "";
            // objeto command para ejecucion del query
            MySqlCommand command = new MySqlCommand();
            command.Connection = cnxUpdTr;
            command.CommandType = CommandType.Text;
            command.CommandTimeout = 0;

            try
            {
                // abrir la conexion
                if (cnxUpdTr.State != ConnectionState.Open)
                    cnxUpdTr.Open();
                // comenzamos la transaccion
                tran = cnxUpdTr.BeginTransaction();
                // asignamos transaccion al command
                command.Transaction = tran;

                // preparamos Insert Pedido
                strSQL = "update tratamientocarpetas set IDestadocarpetas=@IDestadocarpetas, ult_estado=@ult_estado Where numero_letra=@Numero_Letra and numero_contrato=@numero_contrato";
                // reasignamos el string sql al command
                command.Parameters.Clear();
                command.CommandText = strSQL;
                command.Parameters.AddWithValue("@IDestadocarpetas", IdestadoC);
                command.Parameters.AddWithValue("@ult_estado", fechaDia);
                command.Parameters.AddWithValue("@Numero_Letra", txtNumero.Text);
                command.Parameters.AddWithValue("@numero_contrato", txtContrato.Text);
                // ejecutamos Insert
                command.ExecuteNonQuery();

                // si todo salio bien commiteamos los cambios
                tran.Commit();
                // emitimos el aviso exitoso
                //MessageBox.Show("Actualizado");
            }
            catch (Exception ex)
            {
                // si algo fallo deshacemos todo
                tran.Rollback();
                // mostramos el mensaje del error
                //MessageBox.Show(ex.Message);
            }
            finally
            {
                // cerramos la conexion
                if (cnxUpdTr.State != ConnectionState.Closed)
                    cnxUpdTr.Close();
                // destruimos la conexion
                cnxUpdTr.Dispose();
            }

        }
    }
}
