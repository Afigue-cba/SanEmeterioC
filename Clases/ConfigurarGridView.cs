using SanEmeterio.Entidades;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using SanEmeterio.CapaNegocio;

namespace SanEmeterio.Clases
{
    public class ConfigurarGridView
    {
        private DataTable dtAgenda;
        private DataTable dtCom;
        private DataTable dtDeuda;
        private List<Entidades.parametrocuotas> _parametrocuotas = new List<Entidades.parametrocuotas>();

        public void ConfigurarGrid(DataGridView dgv)
        {
            dgv.RowHeadersVisible = false;
            dgv.AutoGenerateColumns = false;
            dgv.RowHeadersWidth = 10;
            dgv.AllowUserToAddRows = false;
            dgv.BackgroundColor = Color.WhiteSmoke;
            dgv.DefaultCellStyle.BackColor = Color.White;
            dgv.DefaultCellStyle.ForeColor = Color.Black;
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGreen;
            dgv.MultiSelect = false;
            dgv.ReadOnly = true;
            dgv.ClearSelection();
            //dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
        public void ConfigurarGrdAgenda(DataGridView dGV, string sContrato)
        {
            dtAgenda = new DataTable();

            dtAgenda.Columns.Add("Estado");
            dtAgenda.Columns.Add("Fecha", typeof(DateTime));
            dtAgenda.Columns.Add("Tarea");

            dGV.DataSource = null;
            dtAgenda.Clear();
            DataRow rowAgenda = dtAgenda.NewRow();


            List<Agenda> _Agenda = new List<Agenda>();
            string sWhere = " contrato=@contrato";
            MySqlConnection cnxAgenda = Database.obtenerConexion(true);
            if (cnxAgenda.State != ConnectionState.Open)
                cnxAgenda.Open();
            MySqlCommand _BuscaAgenda = new MySqlCommand("Select * from Agenda where " + sWhere, cnxAgenda);
            _BuscaAgenda.Parameters.AddWithValue("@contrato", sContrato);
            MySqlDataReader _LeerAgenda = _BuscaAgenda.ExecuteReader();
            while (_LeerAgenda.Read())
            {
                Entidades.Agenda pAgenda = new Entidades.Agenda();
                rowAgenda["Estado"] = _LeerAgenda.GetString("Estado");
                rowAgenda["Fecha"] = _LeerAgenda.GetDateTime("Fecha");
                rowAgenda["Tarea"] = _LeerAgenda.GetString("Tarea");
                dtAgenda.Rows.Add(rowAgenda);
                rowAgenda = dtAgenda.NewRow();
            }
            dGV.DataSource = dtAgenda;

            int AnchoGrilla = dGV.Width + 35;
            dGV.Columns["Estado"].Width = AnchoGrilla / 100 * 15;
            dGV.Columns["Fecha"].Width = AnchoGrilla / 100 * 25;
            dGV.Columns["Tarea"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            ConfigurarGrid(dGV);

            dGV.Refresh();
            cnxAgenda.Close();
        }
        public void configurarGrdComentarios(DataGridView dGV, string sContrato)
        {
            dtCom = new DataTable();

            dtCom.Columns.Add("Fecha", typeof(DateTime));
            dtCom.Columns.Add("Comentario");
            dtCom.Columns.Add("Operador");
            dtCom.Columns.Add("ID");

            dGV.DataSource = null;
            dtCom.Clear();

            DataRow row = dtCom.NewRow();

            List<Comentarios> _Comentarios = new List<Comentarios>();
            string sWhere = "";
            MySqlConnection cnxComentarios = Database.obtenerConexion(true);
            if (cnxComentarios.State != ConnectionState.Open)
                cnxComentarios.Open();
            sWhere = " contrato=@Campo";
            MySqlCommand _LeerComentarios = new MySqlCommand("Select * from comentarios where" + sWhere, cnxComentarios);
            _LeerComentarios.Parameters.AddWithValue("@Campo", sContrato);
            MySqlDataReader _ReadComentarios = _LeerComentarios.ExecuteReader();
            while (_ReadComentarios.Read())
            {
                Comentarios pComentarios = new Comentarios();

                row["Fecha"] = _ReadComentarios.GetDateTime("comentarios_Fecha");
                row["Comentario"] = _ReadComentarios.GetString("comentarios_Comentario");
                row["Operador"] = _ReadComentarios.GetString("comentarios_Operador");
                row["ID"] = _ReadComentarios.GetInt32("comentarios_Id");

                dtCom.Rows.Add(row);
                row = dtCom.NewRow();
            }
            dGV.DataSource = dtCom;

            int AnchoGrilla = dGV.Width + 25;
            dGV.Columns["Fecha"].Width = AnchoGrilla / 100 * 15;
            dGV.Columns["Comentario"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dGV.Columns["Operador"].Width = AnchoGrilla / 100 * 25;
            dGV.Columns["ID"].Visible = false;

            ConfigurarGrid(dGV);

            dGV.Refresh();
            cnxComentarios.Close();
        }
        public void configurarDgvDeuda(DataGridView dGV, int sContrato, double Intereses)
        {

            dtDeuda = new DataTable();

            dtDeuda.Columns.Add("CHK", typeof(Boolean));
            dtDeuda.Columns.Add("Fecha Ven.", typeof(DateTime));
            dtDeuda.Columns.Add("Cuota");
            dtDeuda.Columns.Add("Capital");
            dtDeuda.Columns.Add("Interes");
            dtDeuda.Columns.Add("Dias");
            dtDeuda.Columns.Add("A la Fecha");
            dtDeuda.Columns.Add("Total");
            dtDeuda.Columns.Add("Manual");

            dGV.DataSource = null;
            dtDeuda.Clear();

            DataRow row = dtDeuda.NewRow();
            DateTime fecha1 = new DateTime();
            DateTime fecha2 = new DateTime();
            TimeSpan dias = new TimeSpan();
            double SumaTotal = 0;

            List<Entidades.Cargacuota> _Cuotas = new List<Entidades.Cargacuota>();
            string sWhere = "";
            MySqlConnection cnxCuotas = Clases.Database.obtenerConexion(true);
            if (cnxCuotas.State != ConnectionState.Open)
                cnxCuotas.Open();
            sWhere = " id=@id";
            MySqlCommand _LeerCuotas = new MySqlCommand("SELECT id, cargacuota_fecliquidacion, cargacuota_fecvto, cargacuota_cta, cargacuota_capital, cargacuota_interes, cargacuota_estado, cargacuota_total, numero_contrato, Manual FROM cargacuota where " + sWhere, cnxCuotas);
            _LeerCuotas.Parameters.AddWithValue("@id", sContrato);
            MySqlDataReader _ReadCuotas = _LeerCuotas.ExecuteReader();
            while (_ReadCuotas.Read())
            {
                Entidades.Cargacuota pCuotas = new Entidades.Cargacuota();

                //pCuotas.id = _ReadCuotas.GetInt32("id");
                DataGridViewCheckBoxColumn dgvChekBox = new DataGridViewCheckBoxColumn();

                if (_ReadCuotas.GetString("cargacuota_estado") == "S")
                {

                    row["CHK"] = true;
                }
                else
                {
                    row["CHK"] = false;
                }
                row["Fecha Ven."] = _ReadCuotas.GetDateTime("cargacuota_fecvto");
                row["Cuota"] = _ReadCuotas.GetInt32("cargacuota_cta");
                row["Capital"] = Math.Round(_ReadCuotas.GetDouble("cargacuota_capital"), 2);
                row["Interes"] = Math.Round(_ReadCuotas.GetDouble("cargacuota_interes"), 2);
                double dInteres = Math.Round(_ReadCuotas.GetDouble("cargacuota_interes"), 2);
                if (_ReadCuotas.GetDateTime("cargacuota_fecvto") > _ReadCuotas.GetDateTime("cargacuota_fecliquidacion"))
                {
                    fecha1 = _ReadCuotas.GetDateTime("cargacuota_fecvto");
                    fecha2 = Convert.ToDateTime(DateTime.Now);
                    dias = fecha2.Subtract(fecha1);
                    row["Dias"] = dias.Days.ToString();
                }
                else
                {
                    fecha1 = _ReadCuotas.GetDateTime("cargacuota_fecliquidacion");
                    fecha2 = Convert.ToDateTime(DateTime.Now);
                    dias = fecha2.Subtract(fecha1);
                    row["Dias"] = dias.Days.ToString();
                }
                double capital = _ReadCuotas.GetDouble("cargacuota_capital");
                double interesdos = ((capital * Intereses) / 100) / 30;
                interesdos = interesdos * dias.Days;
                row["A la Fecha"] = Math.Round(interesdos, 2);
                if (_ReadCuotas.GetString("cargacuota_estado") == "S")
                {
                    SumaTotal = SumaTotal + capital + dInteres + Math.Round(interesdos, 2);
                    row["Total"] = Math.Round(SumaTotal, 2);
                }
                else
                {
                    row["CHK"] = false;
                    row["Total"] = 0;
                }


                if (!_ReadCuotas.IsDBNull(_ReadCuotas.GetOrdinal("Manual")))
                {
                    row["Manual"] = _ReadCuotas.GetString("Manual");
                }
                else
                {
                    row["Manual"] = "";
                }
                dtDeuda.Rows.Add(row);
                row = dtDeuda.NewRow();
            }

            dGV.DataSource = dtDeuda;

            dGV.Columns["CHK"].Width = 20;
            dGV.Columns["Fecha Ven."].Width = 65;
            dGV.Columns["Cuota"].Width = 35;
            dGV.Columns["Capital"].Width = 60;
            dGV.Columns["Interes"].Width = 60;
            dGV.Columns["Dias"].Width = 35;
            dGV.Columns["A la Fecha"].Width = 65;
            dGV.Columns["Total"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dGV.Columns["Manual"].Width = 0;
            dGV.Columns["Manual"].Visible = false;

            dGV.Columns["Cuota"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dGV.Columns["Dias"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dGV.Columns["Capital"].DefaultCellStyle.Format = "###0.00";
            dGV.Columns["Capital"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dGV.Columns["Interes"].DefaultCellStyle.Format = "###0.00";
            dGV.Columns["Interes"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dGV.Columns["A la Fecha"].DefaultCellStyle.Format = "###0.00";
            dGV.Columns["A la Fecha"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dGV.Columns["Total"].DefaultCellStyle.Format = "###0.00";
            dGV.Columns["Total"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            cnxCuotas.Close();
            dGV.RowHeadersVisible = false;
            dGV.AutoGenerateColumns = false;
            dGV.RowHeadersWidth = 10;
            dGV.AllowUserToAddRows = false;
            dGV.MultiSelect = false;
            dGV.ReadOnly = true;
            dGV.ClearSelection();
            //ConfigurarGrid(dGV);
            //RowColor(dGV);
            //dGV.AllowUserToAddRows = false;
            //dGV.Refresh();
        }
        public void configurarDgvTentativa(DataGridView dGV, int sContrato, double Intereses)
        {
            _parametrocuotas = Rutinas.ObtenetParametros();
            double txtInteres = Math.Round(Convert.ToDouble(_parametrocuotas[0].PC_Intmensual.ToString()), 2);
            double txtGastos = Math.Round(Convert.ToDouble(_parametrocuotas[0].PC_Gastosadmin.ToString()), 2);
            double txtBancario = Math.Round(Convert.ToDouble(_parametrocuotas[0].PC_Gtosbanco.ToString()), 2);
            double txtHonorarios = Math.Round(Convert.ToDouble(_parametrocuotas[0].PC_Honarios.ToString()), 2);
            double txtIva = Math.Round(Convert.ToDouble(_parametrocuotas[0].PC_IVAInsc.ToString()), 2);

            dtDeuda = new DataTable();

            dtDeuda.Columns.Add("", typeof(Boolean));
            dtDeuda.Columns.Add("Fecha Ven.", typeof(DateTime));
            dtDeuda.Columns.Add("Cuota");
            dtDeuda.Columns.Add("Capital");
            dtDeuda.Columns.Add("Punitorio");
            dtDeuda.Columns.Add("F. Pago", typeof(DateTime));
            dtDeuda.Columns.Add("Int. Fin.");
            dtDeuda.Columns.Add("Gastos");
            dtDeuda.Columns.Add("Total");

            dGV.DataSource = null;
            dtDeuda.Clear();

            DataRow row = dtDeuda.NewRow();
            DateTime fecha1 = new DateTime();
            DateTime fecha2 = new DateTime();
            TimeSpan dias = new TimeSpan();
            double SumaTotal = 0;

            List<Entidades.Cargacuota> _Cuotas = new List<Entidades.Cargacuota>();
            string sWhere = "";
            MySqlConnection cnxCuotas = Clases.Database.obtenerConexion(true);
            if (cnxCuotas.State != ConnectionState.Open)
                cnxCuotas.Open();
            sWhere = " id=@id";
            MySqlCommand _LeerCuotas = new MySqlCommand("SELECT id, cargacuota_fecliquidacion, cargacuota_fecvto, cargacuota_cta, cargacuota_capital, cargacuota_interes, cargacuota_estado, cargacuota_total, numero_contrato, Manual FROM cargacuota where " + sWhere, cnxCuotas);
            _LeerCuotas.Parameters.AddWithValue("@id", sContrato);
            MySqlDataReader _ReadCuotas = _LeerCuotas.ExecuteReader();
            while (_ReadCuotas.Read())
            {
                Entidades.Cargacuota pCuotas = new Entidades.Cargacuota();

                //pCuotas.id = _ReadCuotas.GetInt32("id");
                DataGridViewCheckBoxColumn dgvChekBox = new DataGridViewCheckBoxColumn();

                if (_ReadCuotas.GetString("cargacuota_estado") == "S")
                {

                    row[0] = true;
                }
                else
                {
                    row[0] = false;
                }
                row["Fecha Ven."] = _ReadCuotas.GetDateTime("cargacuota_fecvto");
                row["Cuota"] = _ReadCuotas.GetInt32("cargacuota_cta");
                row["Capital"] = Math.Round(_ReadCuotas.GetDouble("cargacuota_capital"), 2);


                double dInteres = Math.Round(_ReadCuotas.GetDouble("cargacuota_interes"), 2);
                double capital = _ReadCuotas.GetDouble("cargacuota_capital");
                double interesdos = ((capital * Intereses) / 100) / 30;
                if (_ReadCuotas.GetDateTime("cargacuota_fecvto") > _ReadCuotas.GetDateTime("cargacuota_fecliquidacion"))
                {
                    fecha1 = _ReadCuotas.GetDateTime("cargacuota_fecvto");
                    fecha2 = Convert.ToDateTime(DateTime.Now);
                    dias = fecha2.Subtract(fecha1);
                }
                else
                {
                    fecha1 = _ReadCuotas.GetDateTime("cargacuota_fecliquidacion");
                    fecha2 = Convert.ToDateTime(DateTime.Now);
                    dias = fecha2.Subtract(fecha1);
                }

                interesdos = interesdos * dias.Days;
                double dIntFin = 0;
                row["Punitorio"] = dInteres + Math.Round(interesdos, 2);
                row["F. Pago"] = DateTime.Now.Date;
                row["Int. Fin."] = Math.Round(dIntFin, 2);
                row["Gastos"] = Math.Round((capital + dInteres + Math.Round(interesdos, 2)) * txtGastos / 100, 2);
                if (_ReadCuotas.GetString("cargacuota_estado") == "S")
                {
                    SumaTotal = capital + dInteres + Math.Round(interesdos, 2) + dIntFin + ((capital + dInteres + interesdos) * txtGastos / 100);
                    row["Total"] = Math.Round(SumaTotal, 2);
                }
                else
                {
                    row["Total"] = 0;
                }
                dtDeuda.Rows.Add(row);
                row = dtDeuda.NewRow();
            }

            dGV.DataSource = dtDeuda;

            dGV.Columns[0].Width = 15;
            dGV.Columns["Fecha Ven."].Width = 70;
            dGV.Columns["Cuota"].Width = 35;
            dGV.Columns["Capital"].Width = 55;
            dGV.Columns["Punitorio"].Width = 45;
            dGV.Columns["F. Pago"].Width = 70;
            dGV.Columns["Int. Fin."].Width = 45;
            dGV.Columns["Gastos"].Width = 45;
            dGV.Columns["Total"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dGV.Columns["Cuota"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //dGV.Columns["Dias"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dGV.Columns["Capital"].DefaultCellStyle.Format = "###0.00";
            dGV.Columns["Capital"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dGV.Columns["Punitorio"].DefaultCellStyle.Format = "###0.00";
            dGV.Columns["Punitorio"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //dGV.Columns["A la Fecha"].DefaultCellStyle.Format = "###0.00";
            //dGV.Columns["A la Fecha"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dGV.Columns["Total"].DefaultCellStyle.Format = "###0.00";
            dGV.Columns["Total"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            cnxCuotas.Close();
            dGV.RowHeadersVisible = false;
            dGV.AutoGenerateColumns = false;
            dGV.RowHeadersWidth = 10;
            dGV.AllowUserToAddRows = false;
            dGV.MultiSelect = false;
            dGV.ReadOnly = false;
            dGV.ClearSelection();
            //ConfigurarGrid(dGV);
            //RowColor(dGV);
            //dGV.AllowUserToAddRows = false;
            //dGV.Refresh();
        }

        public void RowColor(DataGridView dGv)
        {
            for (int i = 1; i < dGv.Rows.Count; i++)
            {
                if ((bool)dGv.Rows[i].Cells[0].Value)
                {
                    dGv.Rows[i].DefaultCellStyle.BackColor = Color.Green;
                    dGv.Rows[i].DefaultCellStyle.ForeColor = Color.WhiteSmoke;
                }
            }
            dGv.Refresh();
        }
    }

}
