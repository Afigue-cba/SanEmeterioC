using Microsoft.Reporting.WinForms;
using MySql.Data.MySqlClient;
using SanEmeterio.Clases;
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
    public partial class frmListadoCarpetas : Form
    {
        public frmListadoCarpetas()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void chkNroCarpeta_CheckedChanged(object sender, EventArgs e)
        {
            if (chkNroCarpeta.Checked )
            {
                chkNroContrato.Checked = false;
                chkTitular.Checked = false;
            }
        }

        private void chkNroContrato_CheckedChanged(object sender, EventArgs e)
        {
            if (chkNroContrato.Checked )
            {
                chkNroCarpeta.Checked = false;
                chkTitular.Checked = false;
            }
        }

        private void chkTitular_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTitular.Checked )
            {
                chkNroCarpeta.Checked = false;
                chkNroContrato.Checked = false;
            }
        }

        private void chkActivas_CheckedChanged(object sender, EventArgs e)
        {
            if (chkActivas.Checked )
            {
                chkPasivas.Checked = false;
                chkCompleto.Checked = false;
            }
        }

        private void chkPasivas_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPasivas.Checked )
            {
                chkActivas.Checked = false;
                chkCompleto.Checked = false;
            }
        }

        private void chkCompleto_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCompleto.Checked )
            {
                chkActivas.Checked = false;
                chkPasivas.Checked = false;
            }
        }

        private void txtCarpetaDesde_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                e.Handled = true;
                if (txtCarpetaDesde.Text != "")
                {
                    //Buscar_Carpeta("Carpeta");
                }
                SendKeys.Send("{tab}");
            }
        }

        private void txtCarpetaHasta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                e.Handled = true;
                if (txtCarpetaHasta.Text != "")
                {
                    //Buscar_Carpeta("Carpeta");
                }
                SendKeys.Send("{tab}");
            }

        }

        private void BuscarProvincia()
        {
            cboProvincias.DataSource = Rutinas.ObtenerProvincia();
            cboProvincias.DisplayMember = "nombre_provincia";
            cboProvincias.ValueMember = "idprovincia";
        }

        private void frmListadoCarpetas_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'cnjDatos.DaReportePresentacion' Puede moverla o quitarla según sea necesario.
            //this.daReportePresentacionTableAdapter.Fill(this.cnjDatos.DaReportePresentacion);
            BuscarProvincia();
            CambiarReporte("Estado");
            //this.reportViewer1.RefreshReport();
        }
        private void CambiarReporte(string Nombre)
        {
            ReportDataSource NuevaFuenteDatos = new ReportDataSource();
            switch (Nombre)
            {
                case "Listado":
                    reportViewer1.LocalReport.ReportEmbeddedResource = "SanEmeterio.Listados.rptListadoPres.rdlc";
                    break;
                case "Estado":
                    reportViewer1.LocalReport.ReportEmbeddedResource = "SanEmeterio.Listados.rptListadoPreCta.rdlc";
                    break;
            }
            NuevaFuenteDatos.Name = "DataSet1";
            NuevaFuenteDatos.Value = CalcularDataSet().Tables[0];
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(NuevaFuenteDatos);
            //reportViewer1.LocalReport.ReportPath = "SanEmeterio.Listados.rptReporteDiskette.rdlc";
            reportViewer1.RefreshReport();
        }
        public DataSet CalcularDataSet()
        {
            string sWhere, sWhere1, sLetra, sConector, sqlText, sOrden;
            sConector = "AND ";
            sWhere = "";
            sWhere1 = "";
            sOrden = "";
            if (chkNroCarpeta.Checked)
            {
                sOrden = " Order by Tr.numero_letra ";
            }
            else if (chkNroContrato.Checked)
            {
                sOrden = " Order by Tr.numero_contrato ";
            }
            else if (chkTitular.Checked)
            {
                sOrden = " Order by Tr.apellidoynombre_propietario ";
            }
            if (chkActivas.Checked)
            {
                sWhere = " AND Ec.AI ='Activo'";
                sWhere1 = " AND Ec.AI ='Activo'";
                sConector = " AND ";
            }
            else if (chkPasivas.Checked)
            {
                sWhere = " AND Ec.AI ='Pasivo'";
                sWhere1 = " AND Ec.AI ='Pasivo'";
                sConector = " AND ";
            }
            if (txtCarpetaDesde.Text != "" || txtCarpetaHasta.Text != "")
            {
                sWhere = sWhere + sConector + "Tr.numero_letra BETWEEN '" + Convert.ToInt32(txtCarpetaDesde.Text) + "' AND '" + Convert.ToInt32(txtCarpetaHasta.Text) + "'";
                sWhere1 = sWhere1 + sConector + "Tr.numero_letra BETWEEN '" + Convert.ToInt32(txtCarpetaDesde.Text) + "' AND '" + Convert.ToInt32(txtCarpetaHasta.Text) + "'";
                sConector = " AND ";
            }

            if (chkProvincias.Checked  == false)
            {
                if (cboProvincias.Text != "")
                {
                    sWhere = sWhere + sConector + "Pr.nombre_provincia like '" + cboProvincias.Text + "%'";
                    sWhere1 = sWhere1 + sConector + "Pr.nombre_provincia like '" + cboProvincias.Text + "%'";
                }
            }
            if (txtCartaSD.Text == "S")
            {
                if (cboCarta.Text == "Simple")
                {
                    sWhere = sWhere + sConector + "(Tr.nivel_deuda='2')";
                }
                else if (cboCarta.Text == "Documento")
                {
                    sWhere = sWhere + sConector + "(Tr.nivel_deuda='1')";
                }
                else if (cboCarta.Text == "Veraz")
                {
                    sWhere = sWhere + sConector + "(Tr.nivel_deuda='4')";
                }
                else if (cboCarta.Text == "Express")
                {
                    sWhere = sWhere + sConector + "(Tr.nivel_deuda='5')";
                }
                else
                {
                    sWhere = sWhere + sConector + "(Tr.nivel_deuda='1' or Tr.nivel_deuda='2' or Tr.nivel_deuda='4' or Tr.nivel_deuda='5')";
                }
            }

            //string SqlText = "select count(*) as cuenta From tratamientocarpetas As Tr Inner Join letracarpetas AS L ON Tr.idletracarpetas = L.id Inner Join provincias AS Pr ON Pr.idprovincia = Tr.idprovinciaS Inner Join estadocarpetas AS Ec ON Ec.ID = Tr.IDestadocarpetas " + sWhere + " ";

            //MySqlConnection cnxMax = Database.obtenerConexion(true);
            //if (cnxMax.State != ConnectionState.Open)
            //    cnxMax.Open();
            //MySqlCommand _Comando = new MySqlCommand(SqlText, cnxMax);

            //MySqlDataReader _ReadPar = _Comando.ExecuteReader();
            //while (_ReadPar.Read())
            //{
                if (VariablesGlobales.NombreBase == "chevrolet")
                {
                    if (cboMayor.Text == ">=")
                    {
                        sWhere = sWhere + sConector + " cargacuota_cta >='" + Convert.ToInt32(txtCantCuotas.Text) + "'";
                    }
                    else if (cboMayor.Text == "<=")
                    {
                        sWhere = sWhere + sConector + " cargacuota_cta <='" + Convert.ToInt32(txtCantCuotas.Text) + "'";
                    }
                    else if (cboMayor.Text == ">")
                    {
                        sWhere = sWhere + sConector + " cargacuota_cta >'" + Convert.ToInt32(txtCantCuotas.Text) + "'";
                    }
                    else if (cboMayor.Text == "<")
                    {
                        sWhere = sWhere + sConector + " cargacuota_cta <'" + Convert.ToInt32(txtCantCuotas.Text) + "'";
                    }
                    else if (cboMayor.Text == "=")
                    {
                        sWhere = sWhere + sConector + " cargacuota_cta ='" + Convert.ToInt32(txtCantCuotas.Text) + "'";
                    }
                    sqlText = "SELECT Tr.numero_letra, Tr.numero_contrato, Tr.apellidoynombre_propietario, Tr.estado_carpeta, Tr.nivel_deuda, Tr.apellidoynombre_garante, Pr.nombre_provincia, " +
                                        "Pr.letra_provincia, L.denominacion, Ec.Denominacion, max(Cta.cargacuota_cta) As cargacuota_cta, Ec.Codigo " +
                                        "From tratamientocarpetas As Tr, provincias AS Pr, letracarpetas AS L , estadocarpetas AS Ec, cargacuota AS Cta " +
                                        "Where Tr.idprovinciaS =  Pr.idprovincia AND Tr.IDestadocarpetas =  Ec.ID AND Tr.idletracarpetas =  L.id AND Tr.id = Cta.id AND Cta.cargacuota_estado='S' " + sWhere +
                                        "Group By Tr.numero_letra, Tr.numero_contrato, Tr.apellidoynombre_propietario, Tr.estado_carpeta, Tr.nivel_deuda, Tr.apellidoynombre_garante, Pr.nombre_provincia, Pr.letra_provincia, L.denominacion, " +
                                        " Ec.Codigo, Ec.denominacion " + sOrden;
                }
                else if (VariablesGlobales.NombreBase == "rombo")
                {
                    sqlText = "SELECT Tr.numero_letra, Tr.numero_contrato, Tr.apellidoynombre_propietario, Tr.estado_carpeta, Tr.nivel_deuda, Tr.apellidoynombre_garante, Pr.nombre_provincia, " +
                                        "Pr.letra_provincia, L.denominacion, Ec.Denominacion, Ec.Codigo " +
                                        "From tratamientocarpetas As Tr, provincias AS Pr, letracarpetas AS L , estadocarpetas AS Ec " +
                                        "Where Tr.idprovinciaS =  Pr.idprovincia AND Tr.IDestadocarpetas =  Ec.ID AND Tr.idletracarpetas =  L.id " + sWhere +
                                        "Group By Tr.numero_letra, Tr.numero_contrato, Tr.apellidoynombre_propietario, Tr.estado_carpeta, Tr.nivel_deuda, Tr.apellidoynombre_garante, Pr.nombre_provincia, Pr.letra_provincia, L.denominacion, " +
                                        " Ec.Codigo, Ec.denominacion " + sOrden;
                }
                else
                {
                    sqlText = "SELECT Tr.numero_letra, Tr.numero_contrato, Tr.apellidoynombre_propietario, Tr.estado_carpeta, Tr.nivel_deuda, Tr.apellidoynombre_garante, Pr.nombre_provincia, Pr.letra_provincia, L.denominacion, Ec.Denominacion, Ec.Codigo, MAX(Cta.cargacuota_cta) AS cargacuota_cta  FROM tratamientocarpetas Tr, provincias Pr, estadocarpetas Ec, letracarpetas L, cargacuota Cta WHERE Tr.idprovinciaS = Pr.idprovincia AND Tr.IDestadocarpetas = Ec.ID AND Tr.idletracarpetas = L.id AND Tr.id = Cta.id " + sWhere + " GROUP BY Tr.numero_letra, Tr.numero_contrato, Tr.apellidoynombre_propietario, Tr.estado_carpeta, Tr.nivel_deuda, Tr.apellidoynombre_garante, Pr.nombre_provincia, Pr.letra_provincia, L.denominacion, Ec.Denominacion, Ec.Codigo " + sOrden + "";
                }
            //}

            //cnxMax.Close();

            //sqlText = "Select Tr.numero_letra, Tr.numero_contrato, Tr.apellidoynombre_propietario, Tr.estado_carpeta, Pr.nombre_provincia, Pr.letra_provincia, Ec.Codigo, Ec.Denominacion, Ec.AI, L.letra, l.denominacion, MAX(Cta.cargacuota_cta) AS cargacuota_cta From tratamientocarpetas As Tr Inner Join provincias AS Pr ON Tr.idprovinciaG = Pr.idprovincia Left Join estadocarpetas AS Ec ON Tr.IDestadocarpetas = Ec.ID Inner Join letracarpetas AS L ON Tr.idletracarpetas = L.id " + sWhere + " " + sOrden + "";


            MySqlConnection Conexion = Clases.Database.obtenerConexion(true);
            if (Conexion.State != ConnectionState.Open)
                Conexion.Open();

            MySqlCommand cmd = new MySqlCommand(sqlText, Conexion);

            MySqlDataAdapter da = new MySqlDataAdapter();
            da.SelectCommand = cmd;

            //Conexion.Open();

            DataSet ds = new DataSet();
            da.Fill(ds, "Reporte");

            Conexion.Close();
            return ds;

        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (txtPorEstado.Text =="S")
            {
                CambiarReporte("Estado");
            }
            else
            {
                CambiarReporte("Listado");
            }
            //string sWhere, sWhere1, sLetra, sConector, sqlText, sOrden;
            //sConector = "AND ";
            //sWhere = "";
            //sWhere1 = "";
            //sOrden = "";
            //if (chkNroCarpeta.Checked )
            //{
            //    sOrden = " Order by Tr.numero_letra ";
            //}
            //else if (chkNroContrato.Checked )
            //{
            //    sOrden = " Order by Tr.numero_contrato ";
            //}
            //else if(chkTitular.Checked )
            //{
            //    sOrden = " Order by Tr.apellidoynombre_propietario ";
            //}
            //if (chkActivas.Checked )
            //{
            //    sWhere = " AND eC.AI ='Activo'";
            //    sWhere1 = " AND eC.AI ='Activo'";
            //    sConector = " AND ";
            //}
            //else if (chkPasivas.Checked )
            //{
            //    sWhere = " AND eC.AI ='Pasivo'";
            //    sWhere1 = " AND eC.AI ='Pasivo'";
            //    sConector = " AND ";
            //}
            //if (txtCarpetaDesde.Text != "" || txtCarpetaHasta.Text != "")
            //{
            //    sWhere = sWhere + sConector + "Tr.numero_letra BETWEEN '" + Convert.ToInt32(txtCarpetaDesde.Text) + "' AND '" + Convert.ToInt32(txtCarpetaHasta.Text)  + "'";
            //    sWhere1 = sWhere1 + sConector + "Tr.numero_letra BETWEEN '" + Convert.ToInt32(txtCarpetaDesde.Text) + "' AND '" + Convert.ToInt32(txtCarpetaHasta.Text) + "'";
            //    sConector = " AND ";
            //}

            //if (chkCompleto.Checked==false )
            //{
            //    if (cboProvincias.Text!="")
            //    {
            //        sWhere = sWhere + sConector + "Pr.nombre_provincia like '" + cboProvincias.Text + "%'";
            //        sWhere1 = sWhere1 + sConector + "Pr.nombre_provincia like '" + cboProvincias.Text + "%'";
            //    }
            //}
            //if (txtCartaSD.Text =="S")
            //{
            //    if (cboCarta.Text =="Simple")
            //    {
            //        sWhere = sWhere + sConector + "(Tr.nivel_deuda='2')";
            //    }
            //    else if (cboCarta.Text=="Documento")
            //    {
            //        sWhere = sWhere + sConector + "(Tr.nivel_deuda='1')";
            //    }
            //    else if (cboCarta.Text=="Veraz")
            //    {
            //        sWhere = sWhere + sConector + "(Tr.nivel_deuda='4')";
            //    }
            //    else if (cboCarta.Text=="Express")
            //    {
            //        sWhere = sWhere + sConector + "(Tr.nivel_deuda='5')";
            //    }
            //    else
            //    {
            //        sWhere = sWhere + sConector + "(Tr.nivel_deuda='1' or Tr.nivel_deuda='2' or Tr.nivel_deuda='4' or Tr.nivel_deuda='5')";
            //    }
            //}

            //string SqlText = "select count(*) as cuenta From tratamientocarpetas As Tr Inner Join letracarpetas AS L ON Tr.idletracarpetas = L.id Inner Join provincias AS Pr ON Pr.idprovincia = Tr.idprovinciaS Inner Join estadocarpetas AS Ec ON Ec.ID = Tr.IDestadocarpetas " + sWhere + " ";

            //MySqlConnection cnxMax = Database.obtenerConexion(true);
            //if (cnxMax.State != ConnectionState.Open)
            //    cnxMax.Open();
            //MySqlCommand _Comando = new MySqlCommand(SqlText, cnxMax);

            //MySqlDataReader _ReadPar = _Comando.ExecuteReader();
            //while (_ReadPar.Read())
            //{
            //    if (VariablesGlobales.NombreBase=="chevrolet")
            //    {
            //        if (cboMayor.Text ==">=")
            //        {
            //            sWhere = sWhere + sConector + " cargacuota_cta >='" + Convert.ToInt32(txtCantCuotas.Text ) + "'";
            //        }
            //        else if (cboMayor.Text=="<=")
            //        {
            //            sWhere = sWhere + sConector + " cargacuota_cta <='" + Convert.ToInt32(txtCantCuotas.Text ) + "'";
            //        }
            //        else if (cboMayor.Text==">")
            //        {
            //            sWhere = sWhere + sConector + " cargacuota_cta >'" + Convert.ToInt32(txtCantCuotas.Text ) + "'";
            //        }
            //        else if (cboMayor.Text=="<")
            //        {
            //            sWhere = sWhere + sConector + " cargacuota_cta <'" + Convert.ToInt32(txtCantCuotas.Text ) + "'";
            //        }
            //        else if (cboMayor.Text=="=")
            //        {
            //            sWhere = sWhere + sConector + " cargacuota_cta ='" + Convert.ToInt32(txtCantCuotas.Text ) + "'";
            //        }
            //    }
            //}

            //cnxMax.Close();


            //sqlText = "Select Tr.numero_letra, Tr.numero_contrato, Tr.apellidoynombre_propietario, Tr.estado_carpeta, Pr.nombre_provincia, Pr.letra_provincia, Ec.Codigo, Ec.Denominacion, Ec.AI, L.letra, l.denominacion From tratamientocarpetas As Tr Inner Join provincias AS Pr ON Tr.idprovinciaG = Pr.idprovincia Left Join estadocarpetas AS Ec ON Tr.IDestadocarpetas = Ec.ID Inner Join letracarpetas AS L ON Tr.idletracarpetas = L.id " + sWhere + " " + sOrden + "";

            
    
//    If txtEstado.Text = "S" Then
//        If DeDatos.rscnxListPres.State Then DeDatos.rscnxListPres.Close
//        If sLetra <> "G" Then
//'            sLetra = " and Tr.nivel_deuda<3 "
//        Else
//'            sLetra = ""
//        End If
//'        Pr.idprovincia = Tr.idprovinciag And Tr.idletracarpetas = l.id
//        If sLetra = "C" Then
//            With DeDatos
//                ' Close connections and recordsets
//                If .rscnxListPres.State = 1 Then
//                    .rscnxListPres.Close
//                End If
//                .cn.Close
//                .cn.CursorLocation = adUseClient
//                .cn.ConnectionString = "dsn=" & sBase
//                .cn.Open
//'                .rscnxListPres.Source = "Select Tr.numero_letra, Tr.numero_contrato, Tr.apellidoynombre_propietario, Tr.estado_carpeta, Tr.nivel_deuda, Pr.nombre_provincia, Pr.letra_provincia, Ec.Codigo, Ec.Denominacion, L.letra, l.denominacion, Tr.nivel_deuda, Tr.apellidoynombre_garante From tratamientocarpetas As Tr Inner Join provincias AS Pr ON Tr.idprovinciaS = Pr.idprovincia Left Join estadocarpetas AS Ec ON Tr.IDestadocarpetas = Ec.ID Inner Join letracarpetas AS L ON Tr.idletracarpetas = L.id " & sWhere & sOrden & ""
//                .rscnxListPres.Source = "SELECT Tr.numero_letra, Tr.numero_contrato, Tr.apellidoynombre_propietario, Tr.estado_carpeta, Tr.nivel_deuda, Tr.apellidoynombre_garante, Pr.nombre_provincia, " & _
//                                        "Pr.letra_provincia, L.denominacion, Ec.Denominacion, max(Cta.cargacuota_cta) As cargacuota_cta, Ec.Codigo " & _
//                                        "From tratamientocarpetas As Tr, provincias AS Pr, letracarpetas AS L , estadocarpetas AS Ec, cargacuota AS Cta " & _
//                                        "Where Tr.idprovinciaS =  Pr.idprovincia AND Tr.IDestadocarpetas =  Ec.ID AND Tr.idletracarpetas =  L.id AND Tr.id = Cta.id AND Cta.cargacuota_estado='S' " & sWhere & _
//                                        "Group By Tr.numero_letra, Tr.numero_contrato, Tr.apellidoynombre_propietario, Tr.estado_carpeta, Tr.nivel_deuda, Tr.apellidoynombre_garante, Pr.nombre_provincia, Pr.letra_provincia, L.denominacion, " & _
//                                        " Ec.Codigo, Ec.denominacion " & sOrden
//                .rscnxListPres.ActiveConnection = .cn
//                .rscnxListPres.Open
//            End With
//'        ElseIf sLetra = "R" Then
//'            With DeDatos
//'                If .rscnxListPres.State = 1 Then
//'                    .rscnxListPres.Close
//'                End If
//'                .cn.Close
//'                .cn.CursorLocation = adUseClient
//'                .cn.ConnectionString = "dsn=" & sBase
//'                .cn.Open
//'                .rscnxListPres.Source = "SELECT Tr.numero_letra, Tr.numero_contrato, Tr.apellidoynombre_propietario, Tr.estado_carpeta, Tr.nivel_deuda, Tr.apellidoynombre_garante, Pr.nombre_provincia, " & _
//'                                        "Pr.letra_provincia, L.denominacion, Ec.Denominacion, Count(Cta.cargacuota_cta) As cargacuota_cta, Ec.Codigo " & _
//'                                        "From tratamientocarpetas As Tr, provincias AS Pr, letracarpetas AS L , estadocarpetas AS Ec, cargacuota AS Cta " & _
//'                                        "Where Tr.idprovinciaS =  Pr.idprovincia AND Tr.IDestadocarpetas =  Ec.ID AND Tr.idletracarpetas =  L.id AND Tr.id = Cta.id " & sWhere & _
//'                                        "Group By Tr.numero_letra, Tr.numero_contrato, Tr.apellidoynombre_propietario, Tr.estado_carpeta, Tr.nivel_deuda, Tr.apellidoynombre_garante, Pr.nombre_provincia, Pr.letra_provincia, L.denominacion, " & _
//'                                        " Ec.Codigo, Ec.denominacion" & sOrden
//'''                .rscnxListPres.Source = "SELECT Tr.numero_letra, Tr.numero_contrato, Tr.apellidoynombre_propietario, Tr.estado_carpeta, Tr.nivel_deuda, Tr.apellidoynombre_garante, Pr.nombre_provincia, " & _
//'''                                        "Pr.letra_provincia, L.denominacion, Ec.Denominacion, Count(Cta.cargacuota_cta) As cargacuota_cta, Ec.Codigo " & _
//'''                                        "From tratamientocarpetas As Tr, provincias AS Pr, letracarpetas AS L , estadocarpetas AS Ec, cargacuota AS Cta " & _
//'''                                        "Where Tr.idprovinciaS =  Pr.idprovincia AND Tr.IDestadocarpetas =  Ec.ID AND Tr.idletracarpetas =  L.id AND Tr.id = Cta.id " & sWhere & _
//'''                                        "Group By Tr.numero_letra, Tr.numero_contrato, Tr.apellidoynombre_propietario, Tr.estado_carpeta, Tr.nivel_deuda, Tr.apellidoynombre_garante, Pr.nombre_provincia, Pr.letra_provincia, L.denominacion, " & _
//'''                                        " Ec.Codigo, Ec.denominacion Having cargacuota_cta " & cboMayor.Text & CDbl(txtCantCuotas) & sLetra & sOrden
//''                .rscnxListPres.Source = "SELECT Tr.numero_letra, Tr.numero_contrato, Tr.apellidoynombre_propietario, Tr.estado_carpeta, Pr.nombre_provincia, Pr.letra_provincia, Ec.Codigo, " & _
//''                                        "Ec.Denominacion, L.letra, L.denominacion, Tr.nivel_deuda, Tr.apellidoynombre_garante , Count(Cta.cargacuota_cta) as cargacuota_cta " & _
//''                                        "FROM cargacuota Cta, letracarpetas L, provincias Pr, tratamientocarpetas Tr LEFT OUTER JOIN " & _
//''                                        "estadocarpetas Ec ON Tr.IDestadocarpetas = Ec.ID " & _
//''                                        "WHERE Tr.idletracarpetas = L.id AND Tr.idprovinciag = Pr.idprovincia And (Cta.id = Tr.id) " & _
//''                                        "" & sWhere & _
//''                                        "GROUP BY Tr.numero_letra, Tr.numero_contrato, Tr.apellidoynombre_propietario, Tr.estado_carpeta, Pr.nombre_provincia, Pr.letra_provincia, Ec.Codigo, " & _
//''                                        "Ec.Denominacion, L.letra, L.denominacion, Tr.nivel_deuda, Tr.apellidoynombre_garante" & sLetra & sOrden
//'                .rscnxListPres.ActiveConnection = .cn
//'                .rscnxListPres.Open
//'            End With
//        ElseIf sLetra = "R" Then
//            With DeDatos
//                If .rscnxListPres.State = 1 Then
//                    .rscnxListPres.Close
//                End If
//                .cn.Close
//                .cn.CursorLocation = adUseClient
//                .cn.ConnectionString = "dsn=" & sBase
//                .cn.Open
//                .rscnxListPres.Source = "SELECT Tr.numero_letra, Tr.numero_contrato, Tr.apellidoynombre_propietario, Tr.estado_carpeta, Tr.nivel_deuda, Tr.apellidoynombre_garante, Pr.nombre_provincia, " & _
//                                        "Pr.letra_provincia, L.denominacion, Ec.Denominacion, Ec.Codigo " & _
//                                        "From tratamientocarpetas As Tr, provincias AS Pr, letracarpetas AS L , estadocarpetas AS Ec " & _
//                                        "Where Tr.idprovinciaS =  Pr.idprovincia AND Tr.IDestadocarpetas =  Ec.ID AND Tr.idletracarpetas =  L.id " & sWhere & _
//                                        "Group By Tr.numero_letra, Tr.numero_contrato, Tr.apellidoynombre_propietario, Tr.estado_carpeta, Tr.nivel_deuda, Tr.apellidoynombre_garante, Pr.nombre_provincia, Pr.letra_provincia, L.denominacion, " & _
//                                        " Ec.Codigo, Ec.denominacion " & sOrden
//                .rscnxListPres.ActiveConnection = .cn
//                .rscnxListPres.Open
//            End With
//        Else
//            With DeDatos
//                If .rscnxListPres.State = 1 Then
//                    .rscnxListPres.Close
//                End If
//                .cn.Close
//                .cn.CursorLocation = adUseClient
//                .cn.ConnectionString = "dsn=" & sBase
//                .cn.Open
//                .rscnxListPres.Source = "SELECT Tr.numero_letra, Tr.numero_contrato, Tr.apellidoynombre_propietario, Tr.estado_carpeta, Tr.nivel_deuda, Tr.apellidoynombre_garante, Pr.nombre_provincia, " & _
//                                        "Pr.letra_provincia, L.denominacion, Ec.Denominacion, Count(Cta.cargacuota_cta) As cargacuota_cta, Ec.Codigo " & _
//                                        "From tratamientocarpetas As Tr, provincias AS Pr, letracarpetas AS L , estadocarpetas AS Ec, cargacuota AS Cta " & _
//                                        "Where Tr.idprovinciaS =  Pr.idprovincia AND Tr.IDestadocarpetas =  Ec.ID AND Tr.idletracarpetas =  L.id AND Tr.id = Cta.id " & sWhere & _
//                                        "Group By Tr.numero_letra, Tr.numero_contrato, Tr.apellidoynombre_propietario, Tr.estado_carpeta, Tr.nivel_deuda, Tr.apellidoynombre_garante, Pr.nombre_provincia, Pr.letra_provincia, L.denominacion, " & _
//                                        " Ec.Codigo, Ec.denominacion Having cargacuota_cta " & cboMayor.Text & CDbl(txtCantCuotas) & sOrden
//                .rscnxListPres.ActiveConnection = .cn
//                .rscnxListPres.Open
//            End With
        
//        End If
//        If txtCartaSD.Text = "S" Then
//            txtCartaSD.Text = "S"
//        Else
//            txtCartaSD.Text = "N"
//        End If
//        If sLetra <> "C" Then
//            rptListadoPresentacion.DiscardSavedData
//            rptListadoPresentacion.Database.SetDataSource DeDatos.rscnxListPres, 3, 1
//            rptListadoPresentacion.ParameterFields(2).AddCurrentValue (txtCartaSD)
//            rptListadoPresentacion.ParameterFields(3).AddCurrentValue (IIf(chkCuotas.Value = 1, "S", "N"))
//            rptListadoPresentacion.ParameterFields(4).AddCurrentValue (sLetra)
//            rptListadoPresentacion.VerifyOnEveryPrint = True
//            ReporteLetraxProvincia.CRViewer1.ReportSource = rptListadoPresentacion
//        Else
//            rptListadoPreCta.DiscardSavedData
//            rptListadoPreCta.Database.SetDataSource DeDatos.rscnxListPres, 3, 1
//            rptListadoPreCta.ParameterFields(1).AddCurrentValue (cboMayor)
//            rptListadoPreCta.ParameterFields(2).AddCurrentValue (txtEstado)
//            rptListadoPreCta.ParameterFields(3).AddCurrentValue (txtCartaSD)
//            rptListadoPreCta.ParameterFields(4).AddCurrentValue (sLetra)
//            rptListadoPreCta.VerifyOnEveryPrint = True
//            ReporteLetraxProvincia.CRViewer1.ReportSource = rptListadoPreCta
//        End If
//    Else
//        With DeDatos
//            ' Close connections and recordsets
//            If .rscnxPresenta.State = 1 Then
//                .rscnxPresenta.Close
//            End If
//            .cn.Close
//            .cn.CursorLocation = adUseClient
//            .cn.ConnectionString = "dsn=" & sBase
//            .cn.Open
//            ' Set the source for the Command to the new table.
//            .rscnxPresenta.Source = "Select Tr.numero_letra, Tr.numero_contrato, Tr.apellidoynombre_propietario, Tr.estado_carpeta, Tr.nivel_deuda, Pr.nombre_provincia, Pr.letra_provincia, Ec.Codigo, Ec.Denominacion, L.letra, L.denominacion, Tr.nivel_deuda From tratamientocarpetas As Tr Inner Join provincias AS Pr ON Tr.idprovinciaS = Pr.idprovincia Left Join estadocarpetas AS Ec ON Tr.IDestadocarpetas = Ec.ID Inner Join letracarpetas AS L ON Tr.idletracarpetas = L.id " & sWhere & " and Tr.nivel_deuda<3 " & sOrden & ""
//            .rscnxPresenta.ActiveConnection = .cn
//            .rscnxPresenta.Open
//        End With
    
//'        If DeDatos.rscnxPresenta.State Then DeDatos.rscnxPresenta.Close
//'        DeDatos.rscnxPresenta.Open "Select Tr.numero_letra, Tr.numero_contrato, Tr.apellidoynombre_propietario, Tr.estado_carpeta, Tr.nivel_deuda, Pr.nombre_provincia, Pr.letra_provincia, Ec.Codigo, Ec.Denominacion, L.letra, l.denominacion, Tr.nivel_deuda From tratamientocarpetas As Tr Inner Join provincias AS Pr ON Tr.idprovinciaS = Pr.idprovincia Left Join estadocarpetas AS Ec ON Tr.IDestadocarpetas = Ec.ID Inner Join letracarpetas AS L ON Tr.idletracarpetas = L.id " & sWhere & " and Tr.nivel_deuda<3 " & sOrden & "", cn, adOpenStatic, adLockOptimistic
        
//        CrystalReport9.DiscardSavedData
//        CrystalReport9.Database.SetDataSource DeDatos.rscnxPresenta, 3, 1
//        CrystalReport9.ParameterFields(1).AddCurrentValue (sLetra)
        
//        CrystalReport9.VerifyOnEveryPrint = True
//        ReporteLetraxProvincia.CRViewer1.ReportSource = CrystalReport9
//    End If
//    ReporteLetraxProvincia.CRViewer1.ViewReport
//    ReporteLetraxProvincia.Show vbModal
    
//    If txtDetalle.Text = "S" Then
        
//        rptResumen.DiscardSavedData
//        rptResumen.Database.SetDataSource DeDatos.rscnxListPres, 3, 1
//        rptResumen.VerifyOnEveryPrint = True

//        ReporteLetraxProvincia.CRViewer1.ReportSource = rptResumen
//        ReporteLetraxProvincia.CRViewer1.ViewReport
//        ReporteLetraxProvincia.Show vbModal
//    End If
//End If
        }

        private void cboProvincias_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

    }
}
