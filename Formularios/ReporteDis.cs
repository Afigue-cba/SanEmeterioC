using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace SanEmeterio.Formularios
{
    public partial class ReporteDis : Form
    {
        public ReporteDis()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ReporteDis_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'cnjDatos.reporte_diskette' Puede moverla o quitarla según sea necesario.
            this.reporte_disketteTableAdapter.Fill(this.cnjDatos.reporte_diskette);
            // TODO: esta línea de código carga datos en la tabla 'cnjDatos.reporte_diskette' Puede moverla o quitarla según sea necesario.
            this.reporte_disketteTableAdapter.Fill(this.cnjDatos.reporte_diskette);
            CambiarReporte("Listado");
            //this.reportViewer1.RefreshReport();
        }

        private void CambiarReporte(string Nombre)
        {
            ReportDataSource NuevaFuenteDatos = new ReportDataSource();
            reportViewer1.LocalReport.ReportEmbeddedResource = "SanEmeterio.Listados.rptReporteDiskette.rdlc";
            NuevaFuenteDatos.Name = "DataSet1";
            NuevaFuenteDatos.Value = CalcularDataSet().Tables[0];
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(NuevaFuenteDatos);
            //reportViewer1.LocalReport.ReportPath = "SanEmeterio.Listados.rptReporteDiskette.rdlc";
            reportViewer1.RefreshReport();
        }
        public DataSet CalcularDataSet()
        {
            string sql = "SELECT rd.letra_carpeta, rd.numero_carpeta, rd.apellidoynombre, rd.numero_contrato, rd.existe, rd.domicilio, rd.ver_campo, rd.carpeta_anterior, rd.Modifico FROM reporte_diskette AS rd";

            MySqlConnection Conexion = Clases.Database.obtenerConexion(true);
            if (Conexion.State != ConnectionState.Open)
                Conexion.Open();

            MySqlCommand cmd = new MySqlCommand(sql, Conexion);

            MySqlDataAdapter da = new MySqlDataAdapter();
            da.SelectCommand = cmd;

            //Conexion.Open();

            DataSet ds = new DataSet();
            da.Fill(ds, "Reporte");

            Conexion.Close();
            return ds;

        }
    }
}
