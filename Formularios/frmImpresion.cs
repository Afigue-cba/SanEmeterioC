using Microsoft.Reporting.WinForms;
using MySql.Data.MySqlClient;
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
    public partial class frmImpresion : Form
    {
        public frmImpresion()
        {
            InitializeComponent();
        }

        private void frmImpresion_Load(object sender, EventArgs e)
        {

            //this.reportViewer1.RefreshReport();
            CargaUsuario();
            Limpiar();
            CambiarReporte("Listado");
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CargaUsuario()
        {
            cboOperadores.DataSource = Clases.Rutinas.ObtenerUsuario();
            cboOperadores.DisplayMember = "nombre_operadores";
            cboOperadores.ValueMember = "Password";
        }
        private void Limpiar()
        {
            cboOperadores.Text = "";
        }

        private void CambiarReporte(string Nombre)
        {
            ReportDataSource NuevaFuenteDatos = new ReportDataSource();
            reportViewer1.LocalReport.ReportEmbeddedResource = "SanEmeterio.Listados.rptSeguimieto.rdlc";
            NuevaFuenteDatos.Name = "DataSet1";
            NuevaFuenteDatos.Value = CalcularDataSet().Tables[0];
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(NuevaFuenteDatos);
            //reportViewer1.LocalReport.ReportPath = "SanEmeterio.Listados.rptReporteDiskette.rdlc";
            reportViewer1.RefreshReport();
        }
        public DataSet CalcularDataSet()
        {
            string sWhere = "";

            if (chkTodos.Checked )
            {

            }
            else
            {
                sWhere = " And agenda.Operador='" + cboOperadores.Text + "'";
            }
            string Anio = fechaSeguimiento.Value.Year.ToString();
            int Mes = Convert.ToInt32(fechaSeguimiento.Value.Month);
            string result = String.Format("{0:00}", Mes);
            string Dia=fechaSeguimiento.Value.Day.ToString();
            string Fecha = Anio + result + Dia;
            string sql = "SELECT agenda.creado AS fecha, agenda.Carpeta, tratamientocarpetas.apellidoynombre_propietario, agenda.Hora, agenda.Tarea, estadocarpetas.Denominacion, agenda.Operador, " +
                  "provincias.letra_provincia, provincias.nombre_provincia, tratamientocarpetas.numero_contrato FROM provincias, tratamientocarpetas, agenda, estadocarpetas WHERE provincias.idprovincia = tratamientocarpetas.idprovinciaS " +
                  "AND (tratamientocarpetas.IDestadocarpetas = estadocarpetas.ID) AND (agenda.Carpeta = tratamientocarpetas.numero_letra) AND (agenda.creado ='" + Fecha + "') " + sWhere + "";


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

        private void cmdFiltrar_Click(object sender, EventArgs e)
        {
            CambiarReporte("Listado");
        }

    }
}
