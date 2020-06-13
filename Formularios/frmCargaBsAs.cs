
namespace SanEmeterio.Formularios
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.IO;
    using System.Linq;
    using System.Text;
    using Excel;
    using Excel.Core;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using SanEmeterio.Clases;

    public partial class frmCargaBsAs : Form
    {
        private string ruta = "";
        private string HojaTrabajo = "";

        public frmCargaBsAs()
        {
            InitializeComponent();
        }
        private void Guardar(DataGridView ElGrid)
        {
            try
            {
                int NCol = ElGrid.ColumnCount;
                int NRow = ElGrid.RowCount;
                int Fila = 0;
                int Columna = 0;

                for (Fila = 0; Fila <= NCol - 1; Fila++)
                {
                    for (Columna = 0; Columna <= NRow - 1; Columna++)
                    {
                        //Aca Grabo
                    }
                }
            }
            catch
            {

            }

        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openfile1 = new OpenFileDialog();
                openfile1.Filter = "Excel Files |*.xls";
                openfile1.Title = "Seleccione el archivo de Excel";
                if (openfile1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    if (openfile1.FileName.Equals("") == false)
                    {
                        ruta = openfile1.FileName;
                        txtNombreHoja.Focus();
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void txtNombreHoja_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnImportar.Enabled = true;
                HojaTrabajo = Convert.ToString(txtNombreHoja.Text);
                btnImportar.Focus();
            }
        }

        private void btnImportar_Click(object sender, EventArgs e)
        {
            OpenFileDialog fdArchivo = new OpenFileDialog();
            fdArchivo.DefaultExt = "*.xls";
            fdArchivo.Filter = "Archivos de importación|*.xls;*.xlsx;*.xml";
            if (fdArchivo.ShowDialog() == DialogResult.OK)
            {
                this.Cursor = Cursors.WaitCursor;

                IExcelDataReader excelReader = null;
                FileStream stream = null;
                DataSet result = null;

                string[] _arch = fdArchivo.FileName.Split('.');
                string _ext = _arch[_arch.Length - 1].ToLower();
                try
                {
                    switch (_ext)
                    {
                        case "xls":
                            //1. Reading from a binary Excel file ('97-2003 format; *.xls)
                            stream = File.Open(fdArchivo.FileName, FileMode.Open, FileAccess.Read);
                            excelReader = ExcelReaderFactory.CreateBinaryReader(stream);
                            result = excelReader.AsDataSet();
                            excelReader.IsFirstRowAsColumnNames = true;
                            break;
                        case "xlsx":
                            //1. Reading from a Excel file ('2007 format; *.xlsx)
                            stream = File.Open(fdArchivo.FileName, FileMode.Open, FileAccess.Read);
                            excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);
                            result = excelReader.AsDataSet();
                            excelReader.IsFirstRowAsColumnNames = true;
                            break;

                        case "xml":
                            result = new DataSet();
                            result.ReadXml(fdArchivo.FileName);

                            break;

                        default:
                            throw new Exception("El nombre del archivo no es correcto, debe tener extensión *.xls o *.xlsx");
                        //break;
                    }
                    if (result == null)
                        MessageBox.Show("Se produjo el siguente error al intentar abrir el archivo.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }
                catch (Exception ex)
                {
                    if (stream != null)
                        stream.Close();
                    if (excelReader != null)
                        excelReader.Close();
                    result = null;
                    MessageBox.Show(ex.Message);
                    //Notify(new LogManager.Mensaje("Gestión_Productos.frmImportaExcel", "btnImportar_Click(object, EventArgs)", 0, "Problema al intentar abrir el archivo.", "", ex.Message, true, LogManager.EMensaje.Critico, ex.StackTrace));
                }

                if (result != null)
                {
                    if (result.Tables.Count > 0)
                    {
                        int CD = 0;
                        int CS = 0;
                        dgvCartaD.DataSource = result.Tables[1];
                        int.TryParse(dgvCartaD.Rows.Count.ToString(), out CD);
                        txtCantidadRegCD.Text = (CD - 1).ToString();
                        dgvCartaS.DataSource = result.Tables[0];
                        int.TryParse(dgvCartaS.Rows.Count.ToString(), out CS);
                        txtCantidadRegCS.Text = (CS - 1).ToString();

                        //CargaCboGrilla();
                        //importarDatos(result.Tables[0]);
                    }
                    else
                    {
                        MessageBox.Show("No pude abrir correctamente el archivo.\n\nPor favor, al guardar el archivo asegurese de estar posicionado sobre la hoja que contiene los datos.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }

                    excelReader.Close();
                }

                if (stream != null)
                    stream.Close();

            }



            this.Cursor = Cursors.Default;

            //try
            //{

            //    string Conexion = "Provider=Microsoft.Jet.OleDb.4.0; Data Source=" + ruta + "; Extended Properties=\"Excel 8.0; HDR=Yes\"";

            //    OleDbConnection origen = default(OleDbConnection);
            //    origen = new OleDbConnection(Conexion);

            //    OleDbCommand Seleccion = default(OleDbCommand);
            //    Seleccion = new OleDbCommand("Select * from [" + HojaTrabajo + "$]", origen);

            //    OleDbDataAdapter adaptador = new OleDbDataAdapter();
            //    adaptador.SelectCommand = Seleccion;

            //    DataSet ds = new DataSet();

            //    adaptador.Fill(ds);

            //    dgvExcell.DataSource = ds.Tables[0];

            //    origen.Close();
            //    CargaCboGrilla();

            //    //MySqlConnection Conexion_Destino = DAL.Database.obtenerConexion();
            //    //Conexion_Destino.Open();

            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.ToString());
            //}

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Grabar()
        {
            string sNivel = "";
            string SqlText = "SELECT cd.Grupo, cd.Orden, cd.Contrato, cd.Modelo, cd.Plan, cd.Suscriptor, cd.Doc_Gire, cd.Domicilio, cd.NRO, cd.Piso, cd.Dpto, cd.Cod_Postal, cd.Localidad, " +
            "cd.Cod_Provincia, cd.Provincia, cd.Telefono, cd.Email, cd.CuotasPagadas, cd.Cuotasvencidas, cd.FechaultPagos, cd.TotalDeudavencida, cd.SitCobro, " +
            "cd.Cod, cd.Concesionario, cd.Garante_suscriptor, cd.Dni_garante, cd.Domicilio_garante, cd.N_garante, cd.Piso_garante, cd.Dpto_garante, cd.Cp_garante, " +
            "cd.Localidad_garante , cd.Telefono_garante, cd.Email_garante, p.idProvincia " +
            "FROM provincias AS p INNER JOIN cartas_documento AS cd ON p.letra_provincia = cd.Cod_Provincia " +
            "GROUP BY cd.Grupo, cd.Orden";
            //If rsExcelCD.State Then rsExcelCD.Close
            //With rsExcelCD
            //    .ActiveConnection = cn
            //    .CursorType = adOpenDynamic
            //    .CursorLocation = adUseClient
            //    .Source = SqlText
            //    .Open
            //End With
            SqlText = "SELECT Cs.Grupo, Cs.Orden, Cs.Contrato, Cs.Modelo, Cs.Plan, Cs.Suscriptor, Cs.Doc_Gire, Cs.Domicilio, Cs.NRO, Cs.Piso, Cs.Dpto, Cs.Cod_Postal, Cs.Localidad, " +
                        "Cs.Cod_Provincia, Cs.Provincia, Cs.Telefono, Cs.Email, Cs.CuotasPagadas, Cs.Cuotasvencidas, Cs.FechaultPagos, Cs.TotalDeudavencida, Cs.SitCobro, " +
                        "Cs.Cod, Cs.Concesionario, Cs.Garante_suscriptor, Cs.Dni_garante, Cs.Domicilio_garante, Cs.N_garante, Cs.Piso_garante, Cs.Dpto_garante, Cs.Cp_garante, " +
                        "Cs.Localidad_garante , Cs.Telefono_garante, Cs.Email_garante, P.idProvincia " +
                        "FROM cartas_simples AS Cs " +
                        "INNER JOIN provincias AS P ON P.letra_provincia = Cs.Cod_Provincia " +
                        "GROUP BY Cs.Grupo, Cs.Orden, Cs.Contrato";
            //If rsExcelCS.State Then rsExcelCS.Close
            //With rsExcelCS
            //    .ActiveConnection = cn
            //    .CursorType = adOpenDynamic
            //    .CursorLocation = adUseClient
            //    .Source = SqlText
            //'    .Source = "SELECT cs.Status, cs.Grupo, cs.Orden, cs.Solicitud, cs.Nombre_Apellido, cs.Domicilio, cs.Nro, cs.Piso, cs.Dto, cs.Cod_Postal_CN, cs.Codigo_Postal, cs.Telefono, cs.Localidad, cs.Nro_Documento, cs.Doc_Gire, cs.Tipo_cpte, p.idprovincia From cartas_simples AS cs Inner Join provincias AS p ON p.letra_provincia= cs.Cod_Postal_CN Group By cs.Status, cs.Grupo, cs.Orden, cs.Solicitud"
            //    .Open
            //End With
            SqlText = "SELECT cs.Grupo, cs.Orden, cs.Contrato, cs.Modelo, cs.Plan, cs.Suscriptor, cs.Domicilio, cs.NRO, cs.Piso, cs.Dpto, cs.Cod_Postal, cs.Localidad, " +
                        "cs.Cod_Provincia, cs.Provincia, cs.Telefono, cs.Email, cs.CuotasPagadas, cs.Cuotasvencidas, cs.FechaultPagos, cs.TotalDeudavencida, " +
                        "cs.SitCobro, cs.Cod, cs.Concesionario, cs.Garante_suscriptor, cs.Dni_garante, cs.Domicilio_garante, cs.N_garante, cs.Piso_garante, cs.Dpto_garante, " +
                        "cs.Cp_garante , cs.Localidad_garante, cs.Telefono_garante, cs.Email_garante " +
                        "FROM cartas_simples AS cs";
            //If rsexcelCsComp.State Then rsexcelCsComp.Close
            //With rsexcelCsComp
            //    .ActiveConnection = cn
            //    .CursorType = adOpenDynamic
            //    .CursorLocation = adUseClient
            //    .Source = "SELECT cs.Grupo, cs.Orden, cs.Contrato, cs.Modelo, cs.Plan, cs.Suscriptor, cs.Domicilio, cs.NRO, cs.Piso, cs.Dpto, cs.Cod_Postal, cs.Localidad, " & _
            //            "cs.Cod_Provincia, cs.Provincia, cs.Telefono, cs.Email, cs.CuotasPagadas, cs.Cuotasvencidas, cs.FechaultPagos, cs.TotalDeudavencida, " & _
            //            "cs.SitCobro, cs.Cod, cs.Concesionario, cs.Garante_suscriptor, cs.Dni_garante, cs.Domicilio_garante, cs.N_garante, cs.Piso_garante, cs.Dpto_garante, " & _
            //            "cs.Cp_garante , cs.Localidad_garante, cs.Telefono_garante, cs.Email_garante " & _
            //            "FROM cartas_simples AS cs"
            //    .Open
            //End With
            string sContrato, sDomicilio, sContratoBus, sDomicilioG;
            int iCuentas, iDNI;
            DateTime fecha = DateTime.Now;
            SqlText = "Select max(numero_letra) as Mayor from tratamientocarpetas";
            //fecha = Format$(Date, "yyyyMMdd")
            //If rs.State Then rs.Close
            //With rs
            //    .ActiveConnection = cn
            //    .CursorType = adOpenDynamic
            //    .CursorLocation = adUseClient
            //    .Source = "Select max(numero_letra) as Mayor from tratamientocarpetas"
            //    .Open
            //End With
            //If IsNull(rs!mayor) Then
            //    iCuenta = 1
            //Else
            //    iCuenta = rs!mayor + 1
            //End If
            //rs.Close
            //If Not rsExcelCD.EOF Then
            //    rsExcelCD.MoveFirst
            //Else
            //End If
            foreach (Entidades.Carpetas item in dgvCartaD.Rows)
            {
                sContrato = "";
                sContratoBus = "";
                sContrato = Rutinas.ConCeros(dgvCartaD.Columns[1].ToString(), 5) + Rutinas.ConCeros(dgvCartaD.Columns[2].ToString(), 3) + Rutinas.ConCeros(dgvCartaD.Columns[3].ToString(), 7);
                item.Numero_contrato = sContrato;
            }





            //While Not rsExcelCD.EOF
            //    sContrato = ""
            //    sContratoBus = ""
            //    sContrato = ConCeros(rsExcelCD!Grupo, 5) + ConCeros(rsExcelCD!Orden, 3) + ConCeros(rsExcelCD!contrato, 7)
            //    sContratoBus = ConCeros(rsExcelCD!Grupo, 5) + ConCeros(rsExcelCD!Orden, 3)
            //    iDNI = IIf(Trim(rsExcelCD!Doc_Gire) = "DNI", 1, 5)
            //    sDomicilio = Trim(rsExcelCD!Domicilio) + " " + IIf(IsNull(rsExcelCD!nro), "", Trim(rsExcelCD!nro)) + " " + IIf(IsNull(rsExcelCD!Piso), "", Trim(rsExcelCD!Piso)) + " " + IIf(IsNull(rsExcelCD!Dpto), "", Trim(rsExcelCD!Dpto))
            //    sDomicilio = EliminarEspeciales(sDomicilio)
            //    If IsNull(rsExcelCD!domicilio_garante) Or Trim(rsExcelCD!domicilio_garante) = "" Then
            //        sDomicilioG = ""
            //    Else
            //        sDomicilioG = Trim(rsExcelCD!domicilio_garante) + " " + IIf(IsNull(rsExcelCD!N_garante), "", Trim(rsExcelCD!N_garante)) + " " + IIf(IsNull(rsExcelCD!Piso_garante), "", Trim(rsExcelCD!Piso_garante)) + " " + IIf(IsNull(rsExcelCD!Dpto_garante), "", Trim(rsExcelCD!Dpto_garante))
            //        sDomicilioG = EliminarEspeciales(sDomicilioG)
            //    End If
            //    a = CorrigeComAge(sContrato, sContratoBus)
            //    If rs.State Then rs.Close
            //    With rs
            //        .ActiveConnection = cn
            //        .CursorType = adOpenDynamic
            //        .CursorLocation = adUseClient
            //        .Source = "Select numero_contrato, id from tratamientocarpetas where numero_contrato like '" & sContratoBus & "%'"
            //        .Open
            //    End With
            //    If chkVeraz.Value = 1 Then
            //        sNivel = "4"
            //    ElseIf ChkPE.Value = 1 Then
            //        sNivel = "5"
            //    Else
            //        sNivel = "1"
            //    End If

            //    If rs.RecordCount = 0 Then
            //        If chkPG.Value = 1 Then
            //            cn.Execute "insert into tratamientocarpetas (iddocumentoS, idprovinciaS, idletracarpetas, numero_contrato, apellidoynombre_propietario, actual_propietario, domicilio_propietario, localidad_propietario, numerodni_propietario, nivel_deuda, numero_estudio, numero_letra, fecha_ingreso, periodo, ult_estado, estado_carpeta, cp_propietario, telefono_propietario, IDestadocarpetas, email, apellidoynombre_garante, domicilio_garante, localidad_garante, cp_garante, telefono_garante, numerodni_garante, N_garante, Piso_garante, Dpto_garante, Email_garante) values " & _
            //            "('" & iDNI & "','" & rsExcelCD!idProvincia & "',2,'" & sContrato & "','" & EliminarEspeciales(rsExcelCD!Suscriptor) & "','" & EliminarEspeciales(rsExcelCD!Suscriptor) & "','" & Replace(sDomicilio, "'", "\'") & "','" & EliminarEspeciales(Trim(rsExcelCD!localidad)) & "','" & Trim(rsExcelCD!Doc_Gire) & "','" & sNivel & "','814'," & iCuenta & ",'" & fecha & "','" & fecha & "','" & fecha & "','S','" & Trim(rsExcelCD!Cod_Postal) & "','" & Replace(IIf(IsNull(rsExcelCD!Telefono), "", rsExcelCD!Telefono), "'", "\'") & "', 9, " & _
            //            "'" & IIf(IsNull(rsExcelCD!Email), "", rsExcelCD!Email) & "', '" & IIf(IsNull(rsExcelCD!Garante_Suscriptor), "", rsExcelCD!Garante_Suscriptor) & "','" & Replace(sDomicilioG, "'", "\'") & "', '" & IIf(IsNull(rsExcelCD!localidad_garante), "", rsExcelCD!localidad_garante) & "', '" & IIf(IsNull(rsExcelCD!cp_garante), "", rsExcelCD!cp_garante) & "','" & Replace(rsExcelCD!telefono_garante, "'", "\'") & "', '" & IIf(IsNull(rsExcelCD!dni_garante), "", rsExcelCD!dni_garante) & "', '" & IIf(IsNull(rsExcelCD!N_garante), "", rsExcelCD!N_garante) & "', '" & IIf(IsNull(rsExcelCD!Piso_garante), "", rsExcelCD!Piso_garante) & "', '" & IIf(IsNull(rsExcelCD!Dpto_garante), "", rsExcelCD!Dpto_garante) & "', '" & IIf(IsNull(rsExcelCD!Email_garante), "", rsExcelCD!Email_garante) & "')"
            //        ElseIf ChkPE.Value = 1 Then
            //            cn.Execute "insert into tratamientocarpetas (iddocumentoS, idprovinciaS, idletracarpetas, numero_contrato, apellidoynombre_propietario, actual_propietario, domicilio_propietario, localidad_propietario, numerodni_propietario, nivel_deuda, numero_estudio, numero_letra, fecha_ingreso, periodo, ult_estado, estado_carpeta, cp_propietario, telefono_propietario, IDestadocarpetas, email, apellidoynombre_garante, domicilio_garante, localidad_garante, cp_garante, telefono_garante, numerodni_garante, N_garante, Piso_garante, Dpto_garante, Email_garante) values " & _
            //            "('" & iDNI & "','" & rsExcelCD!idProvincia & "',2,'" & sContrato & "','" & EliminarEspeciales(rsExcelCD!Suscriptor) & "','" & EliminarEspeciales(rsExcelCD!Suscriptor) & "','" & Replace(sDomicilio, "'", "\'") & "','" & EliminarEspeciales(Trim(rsExcelCD!localidad)) & "','" & Trim(rsExcelCD!Doc_Gire) & "','" & sNivel & "','814'," & iCuenta & ",'" & fecha & "','" & fecha & "','" & fecha & "','S','" & Trim(rsExcelCD!Cod_Postal) & "','" & Replace(IIf(IsNull(rsExcelCD!Telefono), "", rsExcelCD!Telefono), "'", "\'") & "', 10, " & _
            //            "'" & IIf(IsNull(rsExcelCD!Email), "", rsExcelCD!Email) & "', '" & IIf(IsNull(rsExcelCD!Garante_Suscriptor), "", rsExcelCD!Garante_Suscriptor) & "','" & Replace(sDomicilioG, "'", "\'") & "', '" & IIf(IsNull(rsExcelCD!localidad_garante), "", rsExcelCD!localidad_garante) & "', '" & IIf(IsNull(rsExcelCD!cp_garante), "", rsExcelCD!cp_garante) & "','" & Replace(rsExcelCD!telefono_garante, "'", "\'") & "', '" & IIf(IsNull(rsExcelCD!dni_garante), "", rsExcelCD!dni_garante) & "', '" & IIf(IsNull(rsExcelCD!N_garante), "", rsExcelCD!N_garante) & "', '" & IIf(IsNull(rsExcelCD!Piso_garante), "", rsExcelCD!Piso_garante) & "', '" & IIf(IsNull(rsExcelCD!Dpto_garante), "", rsExcelCD!Dpto_garante) & "', '" & IIf(IsNull(rsExcelCD!Email_garante), "", rsExcelCD!Email_garante) & "')"
            //        Else
            //            cn.Execute "insert into tratamientocarpetas (iddocumentoS, idprovinciaS, idletracarpetas, numero_contrato, apellidoynombre_propietario, actual_propietario, domicilio_propietario, localidad_propietario, numerodni_propietario, nivel_deuda, numero_estudio, numero_letra, fecha_ingreso, periodo, ult_estado, estado_carpeta, cp_propietario, telefono_propietario, IDestadocarpetas, email, apellidoynombre_garante, domicilio_garante, localidad_garante, cp_garante, telefono_garante, numerodni_garante, N_garante, Piso_garante, Dpto_garante, Email_garante) values " & _
            //            "('" & iDNI & "','" & rsExcelCD!idProvincia & "',2,'" & sContrato & "','" & EliminarEspeciales(rsExcelCD!Suscriptor) & "','" & EliminarEspeciales(rsExcelCD!Suscriptor) & "','" & Replace(sDomicilio, "'", "\'") & "','" & EliminarEspeciales(Trim(rsExcelCD!localidad)) & "','" & Trim(rsExcelCD!Doc_Gire) & "','" & sNivel & "','814'," & iCuenta & ",'" & fecha & "','" & fecha & "','" & fecha & "','S','" & Trim(rsExcelCD!Cod_Postal) & "','" & Replace(IIf(IsNull(rsExcelCD!Telefono), "", rsExcelCD!Telefono), "'", "\'") & "', 1, " & _
            //            "'" & IIf(IsNull(rsExcelCD!Email), "", rsExcelCD!Email) & "', '" & IIf(IsNull(rsExcelCD!Garante_Suscriptor), "", rsExcelCD!Garante_Suscriptor) & "','" & Replace(sDomicilioG, "'", "\'") & "', '" & IIf(IsNull(rsExcelCD!localidad_garante), "", rsExcelCD!localidad_garante) & "', '" & IIf(IsNull(rsExcelCD!cp_garante), "", rsExcelCD!cp_garante) & "','" & Replace(IIf(IsNull(rsExcelCD!telefono_garante), "", rsExcelCD!telefono_garante), "'", "\'") & "', '" & IIf(IsNull(rsExcelCD!dni_garante), "", rsExcelCD!dni_garante) & "', '" & IIf(IsNull(rsExcelCD!N_garante), "", rsExcelCD!N_garante) & "', '" & IIf(IsNull(rsExcelCD!Piso_garante), "", rsExcelCD!Piso_garante) & "', '" & IIf(IsNull(rsExcelCD!Dpto_garante), "", rsExcelCD!Dpto_garante) & "', '" & IIf(IsNull(rsExcelCD!Email_garante), "", rsExcelCD!Email_garante) & "')"
            //        End If
            //        If rsTemp.State Then rsTemp.Close
            //        With rsTemp
            //            .ActiveConnection = cn
            //            .CursorType = adOpenDynamic
            //            .CursorLocation = adUseClient
            //            .Source = "Select max(id) as Maximo from tratamientocarpetas"
            //            .Open
            //        End With


            //        If rsExcelCdComp.State Then rsExcelCdComp.Close
            //        With rsExcelCdComp
            //            .ActiveConnection = cn
            //            .CursorType = adOpenDynamic
            //            .CursorLocation = adUseClient
            //            .Source = "SELECT cd.Grupo, cd.Orden, cd.Contrato, cd.Modelo, cd.Plan, cd.Suscriptor, cd.Domicilio, cd.NRO, cd.Piso, cd.Dpto, cd.Cod_Postal, cd.Localidad, cd.Cod_Provincia, cd.Provincia, " & _
            //                    "cd.Telefono, cd.Email, cd.CuotasPagadas, cd.Cuotasvencidas, cd.FechaultPagos, cd.TotalDeudavencida, cd.SitCobro, cd.Cod, cd.Concesionario, cd.Garante_suscriptor, " & _
            //                    "cd.Dni_garante , cd.Domicilio_garante, cd.N_garante, cd.Piso_garante, cd.Dpto_garante, cd.Cp_garante, cd.Localidad_garante, cd.Telefono_garante, cd.Email_garante " & _
            //                    "FROM cartas_documento AS cd where cd.grupo='" & rsExcelCD!Grupo & "' and cd.Orden='" & rsExcelCD!Orden & "'"
            //            .Open
            //        End With
            //        iCuenta = iCuenta + 1
            //        For i = 0 To rsExcelCdComp.RecordCount - 1
            //            Dim fechaliq As String
            //            Dim FechaVto As String
            //            fechaliq = Format$("01/01/2050", "yyyy/MM/dd")
            //            FechaVto = Format$(rsExcelCdComp!FechaultPagos, "yyyy/MM/dd")
            //            cn.Execute "insert into cargacuota (id, cargacuota_fecliquidacion, cargacuota_fecvto, cargacuota_cta, cargacuota_capital, cargacuota_interes, cargacuota_estado, cargacuota_total) values ('" & rsTemp!maximo & "','" & fechaliq & "','" & FechaVto & "','" & rsExcelCdComp!Cuotasvencidas & "', '" & Replace(rsExcelCdComp!TotalDeudavencida, ",", ".") & "',0,'S','" & Replace(rsExcelCdComp!TotalDeudavencida, ",", ".") & "')"
            //            rsExcelCdComp.MoveNext
            //        Next i
            //    Else
            //        IdTrata = rs!id
            //        cn.Execute "update tratamientocarpetas, estadocarpetas set tratamientocarpetas.nivel_deuda='" & sNivel & "',tratamientocarpetas.existe=tratamientocarpetas.existe+1 where tratamientocarpetas.numero_contrato='" & sContrato & "' and estadocarpetas.id=tratamientocarpetas.IDestadocarpetas"
            //        If chkPG.Value = 1 Then
            //            cn.Execute "update tratamientocarpetas, estadocarpetas set tratamientocarpetas.IDestadocarpetas=9 , tratamientocarpetas.ult_estado='" & fechaHoy & "' where tratamientocarpetas.numero_contrato='" & sContrato & "' and estadocarpetas.id=tratamientocarpetas.IDestadocarpetas" ' and estadocarpetas.AI='Pasivo'"
            //        ElseIf ChkPE.Value = 1 Then
            //            cn.Execute "update tratamientocarpetas, estadocarpetas set tratamientocarpetas.IDestadocarpetas=10 , tratamientocarpetas.ult_estado='" & fechaHoy & "' where tratamientocarpetas.numero_contrato='" & sContrato & "' and estadocarpetas.id=tratamientocarpetas.IDestadocarpetas" ' and estadocarpetas.AI='Pasivo'"
            //        Else
            //            cn.Execute "update tratamientocarpetas, estadocarpetas set tratamientocarpetas.IDestadocarpetas=1 , tratamientocarpetas.ult_estado='" & fechaHoy & "' where tratamientocarpetas.numero_contrato='" & sContrato & "' and estadocarpetas.id=tratamientocarpetas.IDestadocarpetas" ' and estadocarpetas.AI='Pasivo'"
            //        End If
            //        If rsExcelCdComp.State Then rsExcelCdComp.Close
            //        With rsExcelCdComp
            //            .ActiveConnection = cn
            //            .CursorType = adOpenDynamic
            //            .CursorLocation = adUseClient
            //            .Source = "SELECT cd.Grupo, cd.Orden, cd.Contrato, cd.Modelo, cd.Plan, cd.Suscriptor, cd.Domicilio, cd.NRO, cd.Piso, cd.Dpto, cd.Cod_Postal, cd.Localidad, cd.Cod_Provincia, cd.Provincia, " & _
            //                    "cd.Telefono, cd.Email, cd.CuotasPagadas, cd.Cuotasvencidas, cd.FechaultPagos, cd.TotalDeudavencida, cd.SitCobro, cd.Cod, cd.Concesionario, cd.Garante_suscriptor, " & _
            //                    "cd.Dni_garante , cd.Domicilio_garante, cd.N_garante, cd.Piso_garante, cd.Dpto_garante, cd.Cp_garante, cd.Localidad_garante, cd.Telefono_garante, cd.Email_garante " & _
            //                    "FROM cartas_documento AS cd where grupo='" & rsExcelCD!Grupo & "' and Orden='" & rsExcelCD!Orden & "'"
            //            .Open
            //        End With
            //'        icuenta = icuenta + 1
            //        For i = 0 To rsExcelCdComp.RecordCount - 1
            //'            Dim fechaliq As String
            //'            Dim fechavto As String
            //            fechaliq = Format$("01/01/2050", "yyyy/MM/dd")
            //            FechaVto = Format$(rsExcelCdComp!FechaultPagos, "yyyy/MM/dd")
            //            If rsTemporal.State Then rsTemporal.Close
            //            With rsTemporal
            //                .ActiveConnection = cn
            //                .CursorType = adOpenDynamic
            //                .CursorLocation = adUseClient
            //                .Source = "Select * from cargacuota where numero_contrato='" & sContrato & "' and cargacuota_cta='" & rsExcelCdComp!Cuotasvencidas & "'"
            //                .Open
            //            End With
            //            If rsTemporal.RecordCount <> 0 Then
            //                If CDbl(rsTemporal!cargacuota_capital) >= CDbl(Replace(rsExcelCdComp!TotalDeudavencida, ",", ".")) Then
            //'                    If rstemporal!cargacuota_estado = "S" Then
            //                        cn.Execute "update cargacuota set cargacuota_estado = 'S', cargacuota_capital='" & Replace(rsExcelCdComp!TotalDeudavencida, ",", ".") & "' where cargacuota.id='" & rsTemporal!id & "' and cargacuota_cta='" & rsExcelCdComp!Cuotasvencidas & "'"
            //'                    Else
            //'                    End If
            //'                    cn.Execute "insert into cargacuota (id, cargacuota_fecliquidacion, cargacuota_fecvto, cargacuota_cta, cargacuota_capital, cargacuota_interes, cargacuota_estado, cargacuota_total) values ('" & rsTemp!maximo & "','" & fechaliq & "','" & fechavto & "','" & rsExcelCdComp!nro_cuota & "', '" & Replace(rsExcelCdComp!importe, ",", ".") & "',0,'S','" & Replace(rsExcelCdComp!importe, ",", ".") & "')"
            //                ElseIf CDbl(rsTemporal!cargacuota_capital) < CDbl(Replace(rsExcelCdComp!TotalDeudavencida, ",", ".")) Then
            //'                    If rstemporal!cargacuota_estado = "S" Then
            //                        cn.Execute "update cargacuota set cargacuota_estado = 'S', cargacuota_capital='" & Replace(rsExcelCdComp!TotalDeudavencida, ",", ".") & "' where cargacuota.id='" & rsTemporal!id & "' and cargacuota_cta='" & rsExcelCdComp!Cuotasvencidas & "'"
            //'                    Else
            //'                    End If
            //                End If
            //            Else
            //                cn.Execute "insert into cargacuota (id, cargacuota_fecliquidacion, cargacuota_fecvto, cargacuota_cta, cargacuota_capital, cargacuota_interes, cargacuota_estado, cargacuota_total) values ('" & IdTrata & "','" & fechaliq & "','" & FechaVto & "','" & rsExcelCdComp!Cuotasvencidas & "', '" & Replace(rsExcelCdComp!TotalDeudavencida, ",", ".") & "',0,'S','" & Replace(rsExcelCdComp!TotalDeudavencida, ",", ".") & "')"
            //            End If
            //            rsTemporal.Close
            //            rsExcelCdComp.MoveNext
            //        Next i

            //    End If
            //    rs.Close
            //    rsExcelCD.MoveNext
            //Wend
            //If rs.State Then rs.Close
            //With rs
            //    .ActiveConnection = cn
            //    .CursorType = adOpenDynamic
            //    .CursorLocation = adUseClient
            //    .Source = "Select max(numero_letra) as Mayor from tratamientocarpetas"
            //    .Open
            //End With
            //iCuenta = rs!mayor + 1
            //rs.Close
            //rsExcelCS.MoveFirst
            //a = rsExcelCS.RecordCount

            //While Not rsExcelCS.EOF
            //    sContrato = ""
            //    sContratoBus = ""
            //    sContrato = ConCeros(rsExcelCS!Grupo, 5) + ConCeros(rsExcelCS!Orden, 3) + ConCeros(rsExcelCS!contrato, 7)
            //    sContratoBus = ConCeros(rsExcelCS!Grupo, 5) + ConCeros(rsExcelCS!Orden, 3)
            //    iDNI = IIf(Trim(rsExcelCS!Doc_Gire) = "DNI", 1, 5)
            //    sDomicilio = Trim(rsExcelCS!Domicilio) + " " + IIf(IsNull(rsExcelCS!nro), "", Trim(rsExcelCS!nro)) + " " + IIf(IsNull(rsExcelCS!Piso), "", Trim(rsExcelCS!Piso)) + " " + IIf(IsNull(rsExcelCS!Dpto), "", Trim(rsExcelCS!Dpto))
            //    sDomicilio = EliminarEspeciales(sDomicilio)
            //    If IsNull(rsExcelCS!domicilio_garante) Or Trim(rsExcelCS!domicilio_garante) = "" Then
            //        sDomicilioG = ""
            //    Else
            //        sDomicilioG = Trim(rsExcelCS!domicilio_garante) + " " + IIf(IsNull(rsExcelCS!N_garante), "", Trim(rsExcelCS!N_garante)) + " " + IIf(IsNull(rsExcelCS!Piso_garante), "", Trim(rsExcelCS!Piso_garante)) + " " + IIf(IsNull(rsExcelCS!Dpto_garante), "", Trim(rsExcelCS!Dpto_garante))
            //        sDomicilioG = EliminarEspeciales(sDomicilioG)
            //    End If
            //    a = CorrigeComAge(sContrato, sContratoBus)
            //    If rs.State Then rs.Close
            //    With rs
            //        .ActiveConnection = cn
            //        .CursorType = adOpenDynamic
            //        .CursorLocation = adUseClient
            //        .Source = "Select numero_contrato, id from tratamientocarpetas where numero_contrato LIKE '" & sContratoBus & "%'"
            //        .Open
            //    End With
            //    If chkVeraz.Value = 1 Then
            //        sNivel = "4"
            //    ElseIf ChkPE.Value = 1 Then
            //        sNivel = "5"
            //    Else
            //        sNivel = "2"
            //    End If


            //    If rs.RecordCount = 0 Then

            //        If chkPG.Value = 1 Then                     '
            //           cn.Execute "insert into tratamientocarpetas (iddocumentoS, idprovinciaS, idletracarpetas, numero_contrato, apellidoynombre_propietario, actual_propietario, domicilio_propietario, localidad_propietario, numerodni_propietario, nivel_deuda, numero_estudio, numero_letra, fecha_ingreso, periodo, ult_estado, estado_carpeta, cp_propietario, telefono_propietario, IDestadocarpetas, email, apellidoynombre_garante, domicilio_garante, localidad_garante, cp_garante, telefono_garante, numerodni_garante, N_garante, Piso_garante, Dpto_garante, Email_garante) values " & _
            //           "('" & iDNI & "','" & rsExcelCS!idProvincia & "',2,'" & sContrato & "','" & EliminarEspeciales(rsExcelCS!Suscriptor) & "','" & EliminarEspeciales(rsExcelCS!Suscriptor) & "','" & Replace(sDomicilio, "'", "\'") & "','" & EliminarEspeciales(Trim(rsExcelCS!localidad)) & "','" & Trim(rsExcelCS!Doc_Gire) & "','" & sNivel & "','814'," & iCuenta & ",'" & fecha & "','" & fecha & "','" & fecha & "','S','" & Trim(rsExcelCS!Cod_Postal) & "','" & Replace(IIf(IsNull(rsExcelCS!Telefono), "", rsExcelCS!Telefono), "'", "\'") & "', 9, " & _
            //            "'" & IIf(IsNull(rsExcelCS!Email), "", rsExcelCS!Email) & "', '" & IIf(IsNull(rsExcelCS!Garante_Suscriptor), "", rsExcelCS!Garante_Suscriptor) & "','" & Replace(sDomicilioG, "'", "\'") & "', '" & IIf(IsNull(rsExcelCS!localidad_garante), "", rsExcelCS!localidad_garante) & "', '" & IIf(IsNull(rsExcelCS!cp_garante), "", rsExcelCS!cp_garante) & "','" & Replace(IIf(IsNull(rsExcelCS!telefono_garante), "", rsExcelCS!telefono_garante), "'", "\'") & "', '" & IIf(IsNull(rsExcelCS!dni_garante), "", rsExcelCS!dni_garante) & "', '" & IIf(IsNull(rsExcelCS!N_garante), "", rsExcelCS!N_garante) & "', '" & IIf(IsNull(rsExcelCS!Piso_garante), "", rsExcelCS!Piso_garante) & "', '" & IIf(IsNull(rsExcelCS!Dpto_garante), "", rsExcelCS!Dpto_garante) & "', '" & IIf(IsNull(rsExcelCS!Email_garante), "", rsExcelCS!Email_garante) & "')"
            //        ElseIf ChkPE.Value = 1 Then
            //           cn.Execute "insert into tratamientocarpetas (iddocumentoS, idprovinciaS, idletracarpetas, numero_contrato, apellidoynombre_propietario, actual_propietario, domicilio_propietario, localidad_propietario, numerodni_propietario, nivel_deuda, numero_estudio, numero_letra, fecha_ingreso, periodo, ult_estado, estado_carpeta, cp_propietario, telefono_propietario, IDestadocarpetas, email, apellidoynombre_garante, domicilio_garante, localidad_garante, cp_garante, telefono_garante, numerodni_garante, N_garante, Piso_garante, Dpto_garante, Email_garante) values " & _
            //           "('" & iDNI & "','" & rsExcelCS!idProvincia & "',2,'" & sContrato & "','" & EliminarEspeciales(rsExcelCS!Suscriptor) & "','" & EliminarEspeciales(rsExcelCS!Suscriptor) & "','" & Replace(sDomicilio, "'", "\'") & "','" & EliminarEspeciales(Trim(rsExcelCS!localidad)) & "','" & Trim(rsExcelCS!Doc_Gire) & "','" & sNivel & "','814'," & iCuenta & ",'" & fecha & "','" & fecha & "','" & fecha & "','S','" & Trim(rsExcelCS!Cod_Postal) & "','" & Replace(IIf(IsNull(rsExcelCS!Telefono), "", rsExcelCS!Telefono), "'", "\'") & "', 10, " & _
            //            "'" & IIf(IsNull(rsExcelCS!Email), "", rsExcelCS!Email) & "', '" & IIf(IsNull(rsExcelCS!Garante_Suscriptor), "", rsExcelCS!Garante_Suscriptor) & "','" & Replace(sDomicilioG, "'", "\'") & "', '" & IIf(IsNull(rsExcelCS!localidad_garante), "", rsExcelCS!localidad_garante) & "', '" & IIf(IsNull(rsExcelCS!cp_garante), "", rsExcelCS!cp_garante) & "','" & Replace(IIf(IsNull(rsExcelCS!telefono_garante), "", rsExcelCS!telefono_garante), "'", "\'") & "', '" & IIf(IsNull(rsExcelCS!dni_garante), "", rsExcelCS!dni_garante) & "', '" & IIf(IsNull(rsExcelCS!N_garante), "", rsExcelCS!N_garante) & "', '" & IIf(IsNull(rsExcelCS!Piso_garante), "", rsExcelCS!Piso_garante) & "', '" & IIf(IsNull(rsExcelCS!Dpto_garante), "", rsExcelCS!Dpto_garante) & "', '" & IIf(IsNull(rsExcelCS!Email_garante), "", rsExcelCS!Email_garante) & "')"
            //        Else
            //           cn.Execute "insert into tratamientocarpetas (iddocumentoS, idprovinciaS, idletracarpetas, numero_contrato, apellidoynombre_propietario, actual_propietario, domicilio_propietario, localidad_propietario, numerodni_propietario, nivel_deuda, numero_estudio, numero_letra, fecha_ingreso, periodo, ult_estado, estado_carpeta, cp_propietario, telefono_propietario, IDestadocarpetas, email, apellidoynombre_garante, domicilio_garante, localidad_garante, cp_garante, telefono_garante, numerodni_garante, N_garante, Piso_garante, Dpto_garante, Email_garante) values " & _
            //           "('" & iDNI & "','" & rsExcelCS!idProvincia & "',2,'" & sContrato & "','" & EliminarEspeciales(rsExcelCS!Suscriptor) & "','" & EliminarEspeciales(rsExcelCS!Suscriptor) & "','" & Replace(sDomicilio, "'", "\'") & "','" & EliminarEspeciales(Trim(rsExcelCS!localidad)) & "','" & Trim(rsExcelCS!Doc_Gire) & "','" & sNivel & "','814'," & iCuenta & ",'" & fecha & "','" & fecha & "','" & fecha & "','S','" & Trim(rsExcelCS!Cod_Postal) & "','" & Replace(IIf(IsNull(rsExcelCS!Telefono), "", rsExcelCS!Telefono), "'", "\'") & "', 1, " & _
            //            "'" & IIf(IsNull(rsExcelCS!Email), "", rsExcelCS!Email) & "', '" & IIf(IsNull(rsExcelCS!Garante_Suscriptor), "", rsExcelCS!Garante_Suscriptor) & "','" & Replace(sDomicilioG, "'", "\'") & "', '" & IIf(IsNull(rsExcelCS!localidad_garante), "", rsExcelCS!localidad_garante) & "', '" & IIf(IsNull(rsExcelCS!cp_garante), "", rsExcelCS!cp_garante) & "','" & Replace(IIf(IsNull(rsExcelCS!telefono_garante), "", rsExcelCS!telefono_garante), "'", "\'") & "', '" & IIf(IsNull(rsExcelCS!dni_garante), "", rsExcelCS!dni_garante) & "', '" & IIf(IsNull(rsExcelCS!N_garante), "", rsExcelCS!N_garante) & "', '" & IIf(IsNull(rsExcelCS!Piso_garante), "", rsExcelCS!Piso_garante) & "', '" & IIf(IsNull(rsExcelCS!Dpto_garante), "", rsExcelCS!Dpto_garante) & "', '" & IIf(IsNull(rsExcelCS!Email_garante), "", rsExcelCS!Email_garante) & "')"
            //        End If
            //        If rsTemp.State Then rsTemp.Close
            //        With rsTemp
            //            .ActiveConnection = cn
            //            .CursorType = adOpenDynamic
            //            .CursorLocation = adUseClient
            //            .Source = "Select max(id) as Maximo from tratamientocarpetas"
            //            .Open
            //        End With


            //        If rsexcelCsComp.State Then rsexcelCsComp.Close
            //        With rsexcelCsComp
            //            .ActiveConnection = cn
            //            .CursorType = adOpenDynamic
            //            .CursorLocation = adUseClient
            //            .Source = "SELECT cs.Grupo, cs.Orden, cs.Contrato, cs.Modelo, cs.Plan, cs.Suscriptor, cs.Domicilio, cs.NRO, cs.Piso, cs.Dpto, cs.Cod_Postal, cs.Localidad, " & _
            //                    "cs.Cod_Provincia, cs.Provincia, cs.Telefono, cs.Email, cs.CuotasPagadas, cs.Cuotasvencidas, cs.FechaultPagos, cs.TotalDeudavencida, cs.SitCobro, " & _
            //                    "cs.Cod, cs.Concesionario, cs.Garante_suscriptor, cs.Dni_garante, cs.Domicilio_garante, cs.N_garante, cs.Piso_garante, cs.Dpto_garante, cs.Cp_garante, " & _
            //                    "cs.Localidad_garante , cs.Telefono_garante, cs.Email_garante " & _
            //                    "FROM cartas_simples AS cs where grupo='" & rsExcelCS!Grupo & "' and Orden='" & rsExcelCS!Orden & "'" ' and Solicitud='" & rsExcelCS!Solicitud & "'"
            //            .Open
            //        End With
            //        iCuenta = iCuenta + 1
            //        For i = 0 To rsexcelCsComp.RecordCount - 1
            //            'Dim fechaliq As String
            //            fechaliq = Format$("01/01/2050", "yyyy/MM/dd")
            //            FechaVto = Format$(rsexcelCsComp!FechaultPagos, "yyyy/MM/dd")
            //            'fechaliq = Format$(rsexcelCsComp!F_vencimiento, "yyyy/MM/dd")
            //            cn.Execute "insert into cargacuota (id, cargacuota_fecliquidacion, cargacuota_fecvto, cargacuota_cta, cargacuota_capital, cargacuota_interes, cargacuota_estado, cargacuota_total) values ('" & rsTemp!maximo & "','" & fechaliq & "','" & FechaVto & "','" & rsexcelCsComp!Cuotasvencidas & "', '" & Replace(rsexcelCsComp!TotalDeudavencida, ",", ".") & "',0,'S','" & Replace(rsexcelCsComp!TotalDeudavencida, ",", ".") & "')"
            //            rsexcelCsComp.MoveNext
            //        Next i
            //    Else
            //        cn.Execute "update tratamientocarpetas, estadocarpetas set tratamientocarpetas.nivel_deuda='" & sNivel & "' where tratamientocarpetas.numero_contrato like'" & sContratoBus & "%' and estadocarpetas.id=tratamientocarpetas.IDestadocarpetas"
            //        If chkPG.Value = 1 Then
            //            cn.Execute "update tratamientocarpetas, estadocarpetas set tratamientocarpetas.IDestadocarpetas=9 , tratamientocarpetas.ult_estado='" & Format$(fechaHoy, "yyyyMMdd") & "' where tratamientocarpetas.numero_contrato like '" & sContratoBus & "%' and estadocarpetas.id=tratamientocarpetas.IDestadocarpetas" ' and estadocarpetas.AI='Pasivo'"
            //        ElseIf ChkPE.Value = 1 Then
            //            cn.Execute "update tratamientocarpetas, estadocarpetas set tratamientocarpetas.IDestadocarpetas=10 , tratamientocarpetas.ult_estado='" & Format$(fechaHoy, "yyyyMMdd") & "' where tratamientocarpetas.numero_contrato like '" & sContratoBus & "%' and estadocarpetas.id=tratamientocarpetas.IDestadocarpetas" ' and estadocarpetas.AI='Pasivo'"
            //        Else
            //            cn.Execute "update tratamientocarpetas, estadocarpetas set tratamientocarpetas.IDestadocarpetas=1 , tratamientocarpetas.ult_estado='" & Format$(fechaHoy, "yyyyMMdd") & "' where tratamientocarpetas.numero_contrato like '" & sContratoBus & "%' and estadocarpetas.id=tratamientocarpetas.IDestadocarpetas" ' and estadocarpetas.AI='Pasivo'"
            //        End If
            //        If rsexcelCsComp.State Then rsexcelCsComp.Close
            //        With rsexcelCsComp
            //            .ActiveConnection = cn
            //            .CursorType = adOpenDynamic
            //            .CursorLocation = adUseClient
            //            .Source = "SELECT cs.Grupo, cs.Orden, cs.Contrato, cs.Modelo, cs.Plan, cs.Suscriptor, cs.Domicilio, cs.NRO, cs.Piso, cs.Dpto, cs.Cod_Postal, cs.Localidad, " & _
            //                    "cs.Cod_Provincia, cs.Provincia, cs.Telefono, cs.Email, cs.CuotasPagadas, cs.Cuotasvencidas, cs.FechaultPagos, cs.TotalDeudavencida, cs.SitCobro, " & _
            //                    "cs.Cod, cs.Concesionario, cs.Garante_suscriptor, cs.Dni_garante, cs.Domicilio_garante, cs.N_garante, cs.Piso_garante, cs.Dpto_garante, cs.Cp_garante, " & _
            //                    "cs.Localidad_garante , cs.Telefono_garante, cs.Email_garante " & _
            //                    "FROM cartas_simples AS cs where grupo='" & rsExcelCS!Grupo & "' and Orden='" & rsExcelCS!Orden & "'"
            //            .Open
            //        End With
            //'        icuenta = icuenta + 1
            //        For i = 0 To rsexcelCsComp.RecordCount - 1
            //'            Dim fechaliq As String
            //'            Dim fechavto As String
            //            fechaliq = Format$("01/01/2050", "yyyy/MM/dd")
            //            FechaVto = Format$(rsexcelCsComp!FechaultPagos, "yyyy/MM/dd")
            //            If rsTemporal.State Then rsTemporal.Close
            //            With rsTemporal
            //                .ActiveConnection = cn
            //                .CursorType = adOpenDynamic
            //                .CursorLocation = adUseClient
            //                .Source = "Select * from cargacuota where numero_contrato like '" & sContratoBus & "%' and cargacuota_cta='" & rsexcelCsComp!Cuotasvencidas & "'"
            //                .Open
            //            End With
            //            If rsTemporal.RecordCount <> 0 Then
            //                If CDbl(rsTemporal!cargacuota_capital) >= CDbl(Replace(rsexcelCsComp!TotalDeudavencida, ",", ".")) Then
            //'                    If rstemporal!cargacuota_estado = "S" Then
            //                        cn.Execute "update cargacuota set cargacuota_estado = 'S', cargacuota_capital='" & Replace(rsexcelCsComp!TotalDeudavencida, ",", ".") & "' where cargacuota.id='" & rsTemporal!id & "' and cargacuota_cta='" & rsexcelCsComp!Cuotasvencidas & "'"
            //'                    Else
            //'                    End If
            //'                    cn.Execute "insert into cargacuota (id, cargacuota_fecliquidacion, cargacuota_fecvto, cargacuota_cta, cargacuota_capital, cargacuota_interes, cargacuota_estado, cargacuota_total) values ('" & rsTemp!maximo & "','" & fechaliq & "','" & fechavto & "','" & rsExcelCdComp!nro_cuota & "', '" & Replace(rsExcelCdComp!importe, ",", ".") & "',0,'S','" & Replace(rsExcelCdComp!importe, ",", ".") & "')"
            //                ElseIf CDbl(rsTemporal!cargacuota_capital) < CDbl(Replace(rsexcelCsComp!TotalDeudavencida, ",", ".")) Then
            //'                    If rstemporal!cargacuota_estado = "S" Then
            //                        cn.Execute "update cargacuota set cargacuota_estado = 'S', cargacuota_capital='" & Replace(rsexcelCsComp!TotalDeudavencida, ",", ".") & "' where cargacuota.id='" & rsTemporal!id & "' and cargacuota_cta='" & rsexcelCsComp!Cuotasvencidas & "'"
            //'                    Else
            //'                    End If
            //                End If
            //            Else
            //                rsTemporal.Close
            //                With rsTemporal
            //                    .ActiveConnection = cn
            //                    .CursorType = adOpenDynamic
            //                    .CursorLocation = adUseClient
            //                    .Source = "Select * from cargacuota where numero_contrato ='" & sContrato & "'"
            //                    .Open
            //                End With
            //                If rsTemporal.RecordCount <> 0 Then
            //                    cn.Execute "insert into cargacuota (id, cargacuota_fecliquidacion, cargacuota_fecvto, cargacuota_cta, cargacuota_capital, cargacuota_interes, cargacuota_estado, cargacuota_total) values ('" & rsTemporal!id & "','" & fechaliq & "','" & FechaVto & "','" & rsexcelCsComp!Cuotasvencidas & "', '" & Replace(rsexcelCsComp!TotalDeudavencida, ",", ".") & "',0,'S','" & Replace(rsexcelCsComp!TotalDeudavencida, ",", ".") & "')"
            //                Else
            //                    cn.Execute "insert into cargacuota (id, cargacuota_fecliquidacion, cargacuota_fecvto, cargacuota_cta, cargacuota_capital, cargacuota_interes, cargacuota_estado, cargacuota_total) values ('" & rs!id & "','" & fechaliq & "','" & FechaVto & "','" & rsexcelCsComp!Cuotasvencidas & "', '" & Replace(rsexcelCsComp!TotalDeudavencida, ",", ".") & "',0,'S','" & Replace(rsexcelCsComp!TotalDeudavencida, ",", ".") & "')"
            //                End If
            //            End If
            //            rsTemporal.Close
            //            rsexcelCsComp.MoveNext
            //        Next i


            //    End If
            //    rsExcelCS.MoveNext
            //Wend
            //cn.Execute("Update cargacuota, Tratamientocarpetas set cargacuota.numero_contrato=Tratamientocarpetas.numero_contrato where cargacuota.id=Tratamientocarpetas.id")
            //cmdAgregar.Enabled = True
            //cmdActualiza.Enabled = True
            //End Sub

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string sContrato, sDomicilio, sContratoBus, sDomicilioG, sNivel;
            string sSuscriptor = "";
            string sLocalidadP = "";

            int iCuentas, iDNI;
            if (chkCSV.Checked == true)
            {
                sNivel = "4";
            }
            else if (chkPE.Checked == true)
            {
                sNivel = "5";
            }
            else
            {
                sNivel = "1";
            }
            for (int fila = 1; fila < dgvCartaD.Rows.Count - 1; fila++)
            {
                sContrato = Rutinas.ConCeros(dgvCartaD.Rows[fila].Cells[0].Value.ToString(), 5) + Rutinas.ConCeros(dgvCartaD.Rows[fila].Cells[1].Value.ToString(), 3) + Rutinas.ConCeros(dgvCartaD.Rows[fila].Cells[2].Value.ToString(), 7);
                sContratoBus = Rutinas.ConCeros(dgvCartaD.Rows[fila].Cells[0].Value.ToString(), 5) + Rutinas.ConCeros(dgvCartaD.Rows[fila].Cells[1].Value.ToString(), 3);
                sDomicilio = dgvCartaD.Rows[fila].Cells[7].Value.ToString() + " " + dgvCartaD.Rows[fila].Cells[8].Value.ToString() + " " + dgvCartaD.Rows[fila].Cells[9].Value.ToString() + " " + dgvCartaD.Rows[fila].Cells[10].Value.ToString();
                sDomicilioG = dgvCartaD.Rows[fila].Cells[26].Value.ToString() + " " + dgvCartaD.Rows[fila].Cells[27].Value.ToString() + " " + dgvCartaD.Rows[fila].Cells[28].Value.ToString() + " " + dgvCartaD.Rows[fila].Cells[29].Value.ToString();
                sSuscriptor = dgvCartaD.Rows[fila].Cells[5].Value.ToString();
                if (dgvCartaD.Rows[fila].Cells[6].Value.ToString() == "DNI")
                {
                    iDNI = 1;
                }
                else
                {
                    iDNI = 5;
                }
                double dCPProp = 0;
                double.TryParse(dgvCartaD.Rows[fila].Cells[11].Value.ToString(), out dCPProp);

                sLocalidadP = dgvCartaD.Rows[fila].Cells[12].Value.ToString();

                string cod_Provincia_prop = dgvCartaD.Rows[fila].Cells[13].Value.ToString();
                int IdProvinciaProp = Convert.ToInt32(Rutinas.BuscaProvincia(0, cod_Provincia_prop, "ID"));

                string Provincia_prop = dgvCartaD.Rows[fila].Cells[14].Value.ToString();
                string Telefono_prop = dgvCartaD.Rows[fila].Cells[15].Value.ToString();
                string Email_prop = dgvCartaD.Rows[fila].Cells[16].Value.ToString();

                double CuotasPagadas = 0;
                double.TryParse(dgvCartaD.Rows[fila].Cells[17].Value.ToString(), out CuotasPagadas);

                double CuotasVencidas = 0;
                double.TryParse(dgvCartaD.Rows[fila].Cells[18].Value.ToString(), out CuotasVencidas);

                double valorOLE = Convert.ToDouble(dgvCartaD.Rows[fila].Cells[19].Value.ToString());
                DateTime FechaUltPago = DateTime.FromOADate(valorOLE);

                double TotalDeuVenc = 0;
                double.TryParse(dgvCartaD.Rows[fila].Cells[20].Value.ToString(), out TotalDeuVenc);

                string Garante_Suscriptor = dgvCartaD.Rows[fila].Cells[24].Value.ToString();
                string DNI_Garante = dgvCartaD.Rows[fila].Cells[25].Value.ToString();

                double CP_Garante = 0;
                double.TryParse(dgvCartaD.Rows[fila].Cells[30].Value.ToString(), out CP_Garante);

                string Localidad_Garante = dgvCartaD.Rows[fila].Cells[31].Value.ToString();
                string Telefono_Garante = dgvCartaD.Rows[fila].Cells[32].Value.ToString();
                string Email_Garante = dgvCartaD.Rows[fila].Cells[33].Value.ToString();
            }

        }

        private void frmCargaBsAs_Load(object sender, EventArgs e)
        {
            Rutinas.RecorreControls(this);
        }
    }
}
