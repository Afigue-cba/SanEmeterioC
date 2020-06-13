namespace SanEmeterio.Entidades
{
    using MySql.Data.MySqlClient;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Cargacuota
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private DateTime cargacuota_fecliquidacion;

        public DateTime Cargacuota_fecliquidacion
        {
            get { return cargacuota_fecliquidacion; }
            set { cargacuota_fecliquidacion = value; }
        }
        private DateTime cargacuota_fecvto;

        public DateTime Cargacuota_fecvto
        {
            get { return cargacuota_fecvto; }
            set { cargacuota_fecvto = value; }
        }
        private int cargacuota_cta;

        public int Cargacuota_cta
        {
            get { return cargacuota_cta; }
            set { cargacuota_cta = value; }
        }
        private double cargacuota_capital;

        public double Cargacuota_capital
        {
            get { return cargacuota_capital; }
            set { cargacuota_capital = value; }
        }
        private double cargacuota_interes;

        public double Cargacuota_interes
        {
            get { return cargacuota_interes; }
            set { cargacuota_interes = value; }
        }
        private string cargacuota_estado;

        public string Cargacuota_estado
        {
            get { return cargacuota_estado; }
            set { cargacuota_estado = value; }
        }
        private double cargacuota_total;

        public double Cargacuota_total
        {
            get { return cargacuota_total; }
            set { cargacuota_total = value; }
        }
        private string numero_contrato;

        public string Numero_contrato
        {
            get { return numero_contrato; }
            set { numero_contrato = value; }
        }
        private string manual;

        public string Manual
        {
            get { return manual; }
            set { manual = value; }
        }
        private string textoabuscar;

        public string Textoabuscar
        {
            get { return textoabuscar; }
            set { textoabuscar = value; }
        }

        //public int Id { get => id; set => id = value; }
        //public DateTime Cargacuota_fecliquidacion { get => cargacuota_fecliquidacion; set => cargacuota_fecliquidacion = value; }
        //public DateTime Cargacuota_fecvto { get => cargacuota_fecvto; set => cargacuota_fecvto = value; }
        //public int Cargacuota_cta { get => cargacuota_cta; set => cargacuota_cta = value; }
        //public double Cargacuota_capital { get => cargacuota_capital; set => cargacuota_capital = value; }
        //public double Cargacuota_interes { get => cargacuota_interes; set => cargacuota_interes = value; }
        //public string Cargacuota_estado { get => cargacuota_estado; set => cargacuota_estado = value; }
        //public double Cargacuota_total { get => cargacuota_total; set => cargacuota_total = value; }
        //public string Numero_contrato { get => numero_contrato; set => numero_contrato = value; }
        //public string Manual { get => manual; set => manual = value; }
        //public string Textoabuscar { get => textoabuscar; set => textoabuscar = value; }

        public Cargacuota()
        {

        }

        public Cargacuota(int id, DateTime cargacuota_fecliquidacion, DateTime cargacuota_fecvto, int cargacuota_cta, double cargacuota_capital, double cargacuota_interes, string cargacuota_estado, double cargacuota_total, string numero_contrato, string manual, string textoabuscar)
        {
            this.Id = id;
            this.Cargacuota_fecliquidacion = cargacuota_fecliquidacion;
            this.Cargacuota_fecvto = cargacuota_fecvto;
            this.Cargacuota_cta = cargacuota_cta;
            this.Cargacuota_capital = cargacuota_capital;
            this.Cargacuota_interes = cargacuota_interes;
            this.Cargacuota_estado = cargacuota_estado;
            this.Cargacuota_total = cargacuota_total;
            this.Numero_contrato = numero_contrato;
            this.Manual = manual;
            this.Textoabuscar = textoabuscar;
        }

        //Metodo Insertar
        public string Insertar(Cargacuota dCargacuota)
        {
            string rpta = "";
            MySqlConnection Conexion = Clases.Database.obtenerConexion(true);
            try
            {
                //Codigo
                if (Conexion.State != ConnectionState.Open)
                    Conexion.Open();
                //Establecer Comando
                MySqlCommand SqlCmd = new MySqlCommand();
                SqlCmd.Connection = Conexion;
                SqlCmd.CommandText = "sp_Agregar_cargacuota";
                SqlCmd.CommandType = CommandType.StoredProcedure;
                //Aqui Parametros
                //                  p_id, p_cargacuota_fecliquidacion, p_cargacuota_fecvto, p_cargacuota_cta, 
                //                  p_cargacuota_capital, p_cargacuota_interes, p_cargacuota_estado, p_cargacuota_total, 
                //                  p_numero_contrato, p_Manual
                SqlCmd.Parameters.AddWithValue("@p_id", dCargacuota.Id);
                SqlCmd.Parameters.AddWithValue("@p_cargacuota_fecliquidacion", dCargacuota.Cargacuota_fecliquidacion);
                SqlCmd.Parameters.AddWithValue("@p_cargacuota_fecvto", dCargacuota.Cargacuota_fecvto);
                SqlCmd.Parameters.AddWithValue("@p_cargacuota_cta", dCargacuota.Cargacuota_cta);
                SqlCmd.Parameters.AddWithValue("@p_cargacuota_capital", dCargacuota.Cargacuota_capital);
                SqlCmd.Parameters.AddWithValue("@p_cargacuota_interes", dCargacuota.Cargacuota_interes);
                SqlCmd.Parameters.AddWithValue("@p_cargacuota_estado", dCargacuota.Cargacuota_estado);
                SqlCmd.Parameters.AddWithValue("@p_cargacuota_total", dCargacuota.Cargacuota_total);
                SqlCmd.Parameters.AddWithValue("@p_numero_contrato", dCargacuota.Numero_contrato);
                //Ejecutar comando
                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se agrego el Registro";

            }
            catch (System.Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                if (Conexion.State == ConnectionState.Open)
                    Conexion.Close();
            }
            return rpta;
        }

        //Metodo Editar
        public string Editar(Cargacuota dCargacuota)
        {
            string rpta = "";
            MySqlConnection Conexion = Clases.Database.obtenerConexion(true);
            try
            {
                //Codigo
                if (Conexion.State != ConnectionState.Open)
                    Conexion.Open();
                //Establecer Comando
                MySqlCommand SqlCmd = new MySqlCommand();
                SqlCmd.Connection = Conexion;
                SqlCmd.CommandText = "sp_Actualizar_cargacuota";
                SqlCmd.CommandType = CommandType.StoredProcedure;
                //Aqui Parametros
                SqlCmd.Parameters.AddWithValue("@p_id", dCargacuota.Id);
                SqlCmd.Parameters.AddWithValue("@p_cargacuota_fecliquidacion", dCargacuota.Cargacuota_fecliquidacion);
                SqlCmd.Parameters.AddWithValue("@p_cargacuota_fecvto", dCargacuota.Cargacuota_fecvto);
                SqlCmd.Parameters.AddWithValue("@p_cargacuota_cta", dCargacuota.Cargacuota_cta);
                SqlCmd.Parameters.AddWithValue("@p_cargacuota_capital", dCargacuota.Cargacuota_capital);
                SqlCmd.Parameters.AddWithValue("@p_cargacuota_interes", dCargacuota.Cargacuota_interes);
                SqlCmd.Parameters.AddWithValue("@p_cargacuota_estado", dCargacuota.Cargacuota_estado);
                SqlCmd.Parameters.AddWithValue("@p_cargacuota_total", dCargacuota.Cargacuota_total);
                SqlCmd.Parameters.AddWithValue("@p_numero_contrato", dCargacuota.Numero_contrato);
                //Ejecutar comando
                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se editó el Registro";

            }
            catch (System.Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                if (Conexion.State == ConnectionState.Open)
                    Conexion.Close();
            }
            return rpta;
        }

        //Metodo Eliminar
        public string Eliminar(Cargacuota dCargacuota)
        {
            string rpta = "";
            MySqlConnection Conexion = Clases.Database.obtenerConexion(true);
            try
            {
                //Codigo
                if (Conexion.State != ConnectionState.Open)
                    Conexion.Open();
                //Establecer Comando
                MySqlCommand SqlCmd = new MySqlCommand();
                SqlCmd.Connection = Conexion;
                SqlCmd.CommandText = "sp_Borrar_cargacuota";
                SqlCmd.CommandType = CommandType.StoredProcedure;
                //Aqui Parametros
                SqlCmd.Parameters.AddWithValue("@p_id", dCargacuota.Id);
                SqlCmd.Parameters.AddWithValue("@p_cargacuota_cta", dCargacuota.Cargacuota_cta);
                SqlCmd.Parameters.AddWithValue("@p_numero_contrato", dCargacuota.Numero_contrato);
                //Ejecutar comando
                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se eliminó el Registro";

            }
            catch (System.Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                if (Conexion.State == ConnectionState.Open)
                    Conexion.Close();
            }
            return rpta;
        }

        //Metodo Mostrar
        //public DataTable Mostrar()
        //{

        //}

        //Metodo Buscar
        public DataTable BuscarCuota(Cargacuota dCargacuota)
        {
            DataTable DtResultado = new DataTable("CargaCuota");
            MySqlConnection Conexion = Clases.Database.obtenerConexion(true);
            try
            {
                //Codigo
                if (Conexion.State != ConnectionState.Open)
                    Conexion.Open();
                //Establecer Comando
                MySqlCommand SqlCmd = new MySqlCommand();
                SqlCmd.Connection = Conexion;
                SqlCmd.CommandText = "sp_cargacuota_Por_Codigo";
                SqlCmd.CommandType = CommandType.StoredProcedure;
                //Aqui Parametros
                SqlCmd.Parameters.AddWithValue("@p_id", dCargacuota.Id);
                SqlCmd.Parameters.AddWithValue("@p_cargacuota_cta", dCargacuota.Cargacuota_cta);
                SqlCmd.Parameters.AddWithValue("@p_numero_contrato", dCargacuota.Numero_contrato);
                //Ejecutar comando
                MySqlDataAdapter SqlDat = new MySqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);
            }
            catch (System.Exception ex)
            {
                DtResultado = null;
            }
            finally
            {
                if (Conexion.State == ConnectionState.Open)
                    Conexion.Close();
            }
            return DtResultado;
        }

    }
}
