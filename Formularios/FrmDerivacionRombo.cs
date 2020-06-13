namespace SanEmeterio.Formularios
{
    using SanEmeterio.Clases;
    using MySql.Data.MySqlClient;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.IO;
    using System.Windows.Forms;

    public partial class FrmDerivacionRombo : Form
    {
        //Instancia de la clase Leer
        LeerTxt l = new LeerTxt();
        //Alamcena la ruta del archivo .txt
        private string ARCHIVO = "";
        private string NUEVOS = "";
        private DataTable CarpetaEncontrada;
        public List<string> listaNuevos = new List<string>();
        private int UltimaCarpeta = 0;
        private List<Entidades.Carpetas> _listaRecibida = new List<Entidades.Carpetas>();
        private bool Cargo = false;


        public FrmDerivacionRombo()
        {
            InitializeComponent();
        }

        private void FrmDerivacionRombo_Load(object sender, EventArgs e)
        {
            BuscaEstado();
            btnGuardar.Enabled = false;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //private void MaxNroLetra()
        //{
        //    string SqlText = "SELECT Max(Tr.numero_letra) AS Maximo FROM tratamientocarpetas AS Tr";

        //    MySqlConnection cnxMax = Database.obtenerConexion(true);
        //    if (cnxMax.State != ConnectionState.Open)
        //        cnxMax.Open();
        //    MySqlCommand _Comando = new MySqlCommand(SqlText, cnxMax);

        //    MySqlDataReader _ReadPar = _Comando.ExecuteReader();
        //    while (_ReadPar.Read())
        //    {
        //        UltimaCarpeta = _ReadPar.GetInt32("Maximo") + 1;
        //        txtNroCar.Text = UltimaCarpeta.ToString();
        //    }
        //    cnxMax.Close();
        //}
        public void cargarArchivo()
        {
            UltimaCarpeta = Rutinas.MaxNroLetra("S", "");
            txtNroCar.Text = Convert.ToString(UltimaCarpeta);
            try
            {
                openFileDialog1.Filter = "txt files (*.txt)|*.txt";
                openFileDialog1.Multiselect = true;
                openFileDialog1.ShowDialog();
                if (!string.IsNullOrEmpty(this.openFileDialog1.FileName))
                {
                    int pos = openFileDialog1.FileNames[0].IndexOf("Nuevos", 0);
                    if (pos == -1)
                    {
                        ARCHIVO = this.openFileDialog1.FileNames[0];
                        NUEVOS = openFileDialog1.FileNames[1];
                    }
                    else
                    {
                        ARCHIVO = this.openFileDialog1.FileNames[1];
                        NUEVOS = openFileDialog1.FileNames[0];
                    }
                    l.lecturaArchivo(dgvDerivacion, ',', ARCHIVO);
                    using (StreamReader objReader = new StreamReader(NUEVOS))
                    {
                        string line;
                        while ((line = objReader.ReadLine()) != null)
                        {
                            listaNuevos.Add(line); // Add to list.
                        }
                        objReader.Close();
                    }
                    Cargo = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.ToString());
                Cargo = false;
            }
        }
        private void btnCargar_Click(object sender, EventArgs e)
        {
            //Abre el openFileDialog y captura la ruta del bloc de notas'
            cargarArchivo();
            if (Cargo)
            {
                btnGuardar.Enabled = true;
            }
        }
        private void BuscaEstado()
        {
            cboEstadoCarpeta.DataSource = Rutinas.ObtenerEstadoCarpeta();
            cboEstadoCarpeta.DisplayMember = "Denominacion";
            cboEstadoCarpeta.ValueMember = "Codigo";
        }

        private void txtNroCar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(txtNroCar.Text) < UltimaCarpeta)
            {
                MessageBox.Show("No puede repetir el nro de carpeta, Reintente con otro Nro.!!!");
                txtNroCar.Text = UltimaCarpeta.ToString();
                txtNroCar.Refresh();
            }
        }
        private int BuscarNuevo(string contrato)
        {
            int Encuentra = 0;
            List<string> resultFindAll = listaNuevos.FindAll(s => s.Equals(contrato));
            if (resultFindAll.Count > 0)
            {
                Encuentra = resultFindAll.Count;
            }
            return Encuentra;
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Cargo == false)
            {
                MessageBox.Show("Debe cargar los Archivos de Derivación");
                return;
            }
            if (txtNroCar.Text == "")
            {
                MessageBox.Show("Debe completar el Nro. de Carpeta");
                txtNroCar.Focus();
                return;
            }
            string numerocontratonuevo = "";
            int numerocuotanuevo = 0;
            string numero_contrato = "";
            string contrato = "";
            int cuota = 0;
            int numeroletra = 0;
            int repitenro = 0;
            int idtratamiento = 0;
            if (cboEstadoCarpeta.Text == "")
            {
                MessageBox.Show("Tiene que elegir un ESTADO DE CARPETAS, Reintente...!");
                cboEstadoCarpeta.Focus();
                return;
            }

            numeroletra = Rutinas.MaxNroLetra("N", "");

            if (Convert.ToInt32(txtNroCar.Text) < numeroletra)
            {
                MessageBox.Show("El Nro. de Carpeta no se puede Repetir");
                txtNroCar.Focus();
                return;
            }
            string sNivel = "2";
            Rutinas.UpdateCuotas();
            Rutinas.BorraReporte();
            for (int i = 0; i < dgvDerivacion.Rows.Count - 1; i++)
            {
                int IdCarpeta = 0;
                //Aca cargo las variables de los campos de la grilla
                string sEstudio = dgvDerivacion.Rows[i].Cells[0].ToString();
                numero_contrato = dgvDerivacion.Rows[i].Cells[1].Value.ToString();
                numerocontratonuevo = dgvDerivacion.Rows[i].Cells[1].Value.ToString();
                string sNombreSolicitante = dgvDerivacion.Rows[i].Cells[2].Value.ToString();
                string sDireccionSolicitante = dgvDerivacion.Rows[i].Cells[3].Value.ToString();
                string sLocalidadSolicitante = dgvDerivacion.Rows[i].Cells[4].Value.ToString();
                string sProvinciaSolicitante = dgvDerivacion.Rows[i].Cells[5].Value.ToString();
                string sReplaceProv = Rutinas.Reemplaza(dgvDerivacion.Rows[i].Cells[5].Value.ToString());
                DataTable dtIdProvSol = CapaNegocio.nProvincias.BuscarProvinciaN(sReplaceProv);
                int iDProvinciaS = Convert.ToInt32(dtIdProvSol.Rows[0]["idprovincia"]);
                string sLetraProv = dtIdProvSol.Rows[0]["letra_provincia"].ToString();
                DateTime dFechaCuota = new DateTime(Convert.ToInt32(dgvDerivacion.Rows[i].Cells[6].Value.ToString().Substring(4, 4)), Convert.ToInt32(dgvDerivacion.Rows[i].Cells[6].Value.ToString().Substring(2, 2)), Convert.ToInt32(dgvDerivacion.Rows[i].Cells[6].Value.ToString().Substring(0, 2)));
                cuota = Convert.ToInt32(dgvDerivacion.Rows[i].Cells[7].Value.ToString());
                double dImporteCuota = Convert.ToDouble(dgvDerivacion.Rows[i].Cells[8].Value.ToString()) / 100;
                double dInteresCuot = Convert.ToDouble(dgvDerivacion.Rows[i].Cells[9].Value.ToString()) / 100;
                double dTotalCota = Convert.ToDouble(dgvDerivacion.Rows[i].Cells[10].Value.ToString()) / 100;
                int iCp_Solicitante = Convert.ToInt32(dgvDerivacion.Rows[i].Cells[11].Value.ToString().Substring(1, 4));
                DataTable dtIdDocumentoS = CapaNegocio.nDocumento.BuscarDocumentoN(dgvDerivacion.Rows[i].Cells[12].Value.ToString().Trim());
                if (dtIdDocumentoS.Rows.Count == 0)
                {
                    CapaNegocio.nDocumento.Insertar(0, 0, dgvDerivacion.Rows[i].Cells[12].Value.ToString());
                    dtIdDocumentoS = CapaNegocio.nDocumento.BuscarDocumentoN(dgvDerivacion.Rows[i].Cells[12].Value.ToString());
                }
                int iDDocumentoS = Convert.ToInt32(dtIdDocumentoS.Rows[0]["iddocumento"]);
                //Buscar Tipo Documento dgvDerivacion.Rows[i].Cells[12].Value.ToString()
                string sDniSolicitante = dgvDerivacion.Rows[i].Cells[13].Value.ToString();
                string sTelefonoSoli = dgvDerivacion.Rows[i].Cells[14].Value.ToString();
                string sNombreGarante = dgvDerivacion.Rows[i].Cells[22].Value.ToString();
                string sDireccionGarante = "";
                string sLocalidadGarante = "";
                int iIdProvinciaG = 1;
                int iCp_Garante = 0;
                int iDDocumentoG = 1;
                string sDniGarante = "";
                string sTelefonoGara = "";
                if ((sNombreGarante).Trim().Length != 0)
                {
                    sDireccionGarante = dgvDerivacion.Rows[i].Cells[23].Value.ToString();
                    sLocalidadGarante = dgvDerivacion.Rows[i].Cells[24].Value.ToString();
                    DataTable dtProvGarante = CapaNegocio.nProvincias.BuscarProvinciaN(dgvDerivacion.Rows[i].Cells[25].Value.ToString().Trim());
                    iIdProvinciaG = Convert.ToInt32(dtProvGarante.Rows[0]["idprovincia"]);
                    iCp_Garante = Convert.ToInt32(dgvDerivacion.Rows[i].Cells[26].Value.ToString().Substring(1, 4));
                    DataTable dtIdDocumentoG = CapaNegocio.nDocumento.BuscarDocumentoN(dgvDerivacion.Rows[i].Cells[30].Value.ToString().Trim());
                    if (dtIdDocumentoG.Rows.Count == 0)
                    {
                        CapaNegocio.nDocumento.Insertar(0, 0, dgvDerivacion.Rows[i].Cells[30].Value.ToString());
                        dtIdDocumentoG = CapaNegocio.nDocumento.BuscarDocumentoN(dgvDerivacion.Rows[i].Cells[30].Value.ToString());
                    }
                    iDDocumentoG = Convert.ToInt32(dtIdDocumentoS.Rows[0]["iddocumento"]);
                    sDniGarante = dgvDerivacion.Rows[i].Cells[31].Value.ToString();
                    sTelefonoGara = dgvDerivacion.Rows[i].Cells[32].Value.ToString();
                }


                string fecperiodo = fecpunitorio.Value.ToShortDateString();
                string ano = "";
                string mes = "";
                string dia = "";
                ano = fecperiodo.Substring(6);
                mes = fecperiodo.Substring(3, 2);
                dia = fecperiodo.Substring(0, 2);
                //fecperiodo = ano + mes + dia;
                DateTime dtFechaPer = Convert.ToDateTime(fecperiodo);
                _listaRecibida = Rutinas.Buscar_Carpeta("Contrato", 0, "", numero_contrato);

                int numeroexiste = _listaRecibida.Count;
                numeroletra = Rutinas.MaxNroLetra("N", " Where Tr.numero_contrato='" + numero_contrato + "'");

                //Rutinas.UpdateTratamiento(numero_contrato);
                int idEstadoCarpeta = Convert.ToInt32(CapaNegocio.nEstadoCarpetas.BuscarEstadoCarpeta(cboEstadoCarpeta.Text).Rows[0]["Id"].ToString());
                double sLetra = 0;
                int numero_cuota = 0;
                string fecliquidacion = "";
                string fecvencimiento = "";
                double importe = 0;
                double interes = 0;
                double total = 0;
                int iExiste = CapaNegocio.TratamientoDeuda.Contar_Carpeta(numero_contrato);
                DateTime fecingreso = Convert.ToDateTime(fecperiodo);
                DateTime fecestado = Convert.ToDateTime(fecperiodo);

                string punitorio = fecpunitorio.Value.ToShortDateString();
                ano = punitorio.Substring(6);
                mes = punitorio.Substring(3, 2);
                dia = punitorio.Substring(0, 2);
                //punitorio = ano + mes + dia;
                //numeroletra = CapaNegocio.TratamientoDeuda.MaxNroLetraContrato(numero_contrato, "");
                numeroexiste = iExiste;

                Rutinas.UpdateTratamiento(numero_contrato);
                string sModifico = "";
                string sEstadoCarpeta = "S";
                string sWhere = " AND estado_carpeta = 'N'";
                int carpetaanterior = CapaNegocio.TratamientoDeuda.MaxNroLetraContrato(numero_contrato, sWhere);
                if (carpetaanterior != 0)
                {
                    CarpetaEncontrada = CapaNegocio.TratamientoDeuda.BuscarCarpeta(carpetaanterior);
                    sNombreSolicitante = CarpetaEncontrada.Rows[0]["apellidoynombre_propietario"].ToString();
                    sDireccionSolicitante = CarpetaEncontrada.Rows[0]["domicilio_propietario"].ToString();
                    sLocalidadSolicitante = CarpetaEncontrada.Rows[0]["localidad_propietario"].ToString();
                    iCp_Solicitante = Convert.ToInt32(CarpetaEncontrada.Rows[0]["cp_propietario"].ToString());
                    sTelefonoSoli = CarpetaEncontrada.Rows[0]["telefono_propietario"].ToString();
                    sDniSolicitante = CarpetaEncontrada.Rows[0]["numerodni_propietario"].ToString();
                    sNombreGarante = CarpetaEncontrada.Rows[0]["apellidoynombre_garante"].ToString();
                    if (sNombreGarante.Trim().Length != 0)
                    {
                        sDireccionGarante = CarpetaEncontrada.Rows[0]["domicilio_garante"].ToString();
                        sLocalidadGarante = CarpetaEncontrada.Rows[0]["localidad_garante"].ToString();
                        iCp_Garante = Convert.ToInt32(CarpetaEncontrada.Rows[0]["cp_garante"].ToString());
                        sTelefonoGara = CarpetaEncontrada.Rows[0]["telefono_garante"].ToString();
                        sDniGarante = CarpetaEncontrada.Rows[0]["numerodni_garante"].ToString();
                    }
                    else
                    {
                        sDireccionGarante = null;
                        sLocalidadGarante = null;
                        iCp_Garante = 0;
                        sTelefonoGara = null;
                        sDniGarante = null;
                    }

                    iExiste = CapaNegocio.TratamientoDeuda.Contar_Carpeta(numero_contrato);
                }
                if (repitenro != numeroletra)
                {
                    if (BuscarNuevo(numero_contrato) != 0)
                    {
                        numeroletra = Rutinas.MaxNroLetra("S", "");
                        CapaNegocio.TratamientoDeuda.InsertarTratamiento(0, iDDocumentoG, iDDocumentoS, iIdProvinciaG, iDProvinciaS, idEstadoCarpeta, 1, numeroletra, numero_contrato, iExiste, "814", dtFechaPer, sNombreSolicitante, sDireccionSolicitante, sLocalidadSolicitante, iCp_Solicitante, sTelefonoSoli, sDniSolicitante, sNombreGarante, sDireccionGarante, sLocalidadGarante, iCp_Garante, sTelefonoGara, sDniGarante, fecingreso, fecestado, "S", sNivel);
                        bool Gravo = false;
                        Gravo = Entidades.Reporte_Diskette.InsertarReporteDiskette("R", numeroletra, sNombreSolicitante, numero_contrato, iExiste, sDireccionSolicitante, sLetraProv, carpetaanterior, sModifico);
                    }
                    else
                    {
                        bool Actualizo = false;
                        Actualizo = CapaNegocio.TratamientoDeuda.ActualizaTratamiento(idEstadoCarpeta, numeroletra, numero_contrato, iExiste, dtFechaPer, sNombreSolicitante, sDireccionSolicitante, sLocalidadSolicitante, iCp_Solicitante, sTelefonoSoli, sDniSolicitante, sNombreGarante, sDireccionGarante, sLocalidadGarante, iCp_Garante, sTelefonoGara, sDniGarante, fecestado, sEstadoCarpeta, sNivel);
                    }
                }
                IdCarpeta = CapaNegocio.TratamientoDeuda.BuscarIdCarpeta(numeroletra);
                // Actualizo Cuotas
                repitenro = numeroletra;
                DataTable BuscaCuota = CapaNegocio.nCargaCuota.BuscarCuota(IdCarpeta, cuota, numero_contrato);
                if (BuscaCuota.Rows.Count > 0)
                {
                    CapaNegocio.nCargaCuota.Editar(IdCarpeta, dtFechaPer, dFechaCuota, cuota, dImporteCuota, dInteresCuot, "S", dTotalCota, numero_contrato);
                }
                else
                {
                    CapaNegocio.nCargaCuota.Insertar(IdCarpeta, dtFechaPer, dFechaCuota, cuota, dImporteCuota, dInteresCuot, "S", dTotalCota, numero_contrato);
                }
                btnGuardar.Enabled = false;
            }
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            ReporteDis visualizar = new ReporteDis();
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
            //visualizar.txtApellidop.Text = _Carpetas.Find(x => x.id==IdCarpeta).apellidoynombre_propietario.ToString();
            visualizar.Show();
        }
    }
}
