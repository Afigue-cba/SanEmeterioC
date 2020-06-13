namespace SanEmeterio.Entidades
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using MySql.Data.MySqlClient;

    public class EstadoCarpetas
    {
        private int _id;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        private int _codigo;

        public int Codigo
        {
            get { return _codigo; }
            set { _codigo = value; }
        }
        private string _denominacion;

        public string Denominacion
        {
            get { return _denominacion; }
            set { _denominacion = value; }
        }
        private string _ai;

        public string Ai
        {
            get { return _ai; }
            set { _ai = value; }
        }

        //public int Id { get => _id; set => _id = value; }
        //public int Codigo { get => _codigo; set => _codigo = value; }
        //public string Denominacion { get => _denominacion; set => _denominacion = value; }
        //public string Ai { get => _ai; set => _ai = value; }
        public EstadoCarpetas()
        {

        }
        public EstadoCarpetas(int ID, int Codigo, string Denominacion, string AI)
        {
            this.Id = ID;
            this.Codigo = Codigo;
            this.Denominacion = Denominacion;
            this.Ai = AI;
        }
        //Metodo Insertar
        public string Insertar(EstadoCarpetas mEstadoCarpeta)
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
                SqlCmd.CommandText = "sp_estadocarpetas_Insertar";
                SqlCmd.CommandType = CommandType.StoredProcedure;
                //Aqui Parametros
                SqlCmd.Parameters.AddWithValue("@p_ID", mEstadoCarpeta.Id);
                SqlCmd.Parameters.AddWithValue("@p_Codigo", mEstadoCarpeta.Codigo);
                SqlCmd.Parameters.AddWithValue("@p_Denominacion", mEstadoCarpeta.Denominacion);
                SqlCmd.Parameters.AddWithValue("@p_Ai", mEstadoCarpeta.Ai);
                //Ejecutar comando
                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se ejecuto el comando";

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
        //public string Editar(Documento mDocumento)
        //{

        //}
        //Metodo Eliminar
        //public string Eliminar(Documento mDocumento)
        //{

        //}
        //Metodo Mostrar
        //public DataTable Mostrar()
        //{

        //}
        //Metodo Buscar por Nombre
        //public DataTable BuscarNombre(Documento mDocumento)
        //{

        //}
        public DataTable BuscarEstadoCarpetaN(EstadoCarpetas dEastadoCarpeta)
        {
            DataTable DtResultado = new DataTable("EstadoCarpeta");
            MySqlConnection Conexion = Clases.Database.obtenerConexion(true);
            try
            {
                //Codigo
                if (Conexion.State != ConnectionState.Open)
                    Conexion.Open();
                //Establecer Comando
                MySqlCommand SqlCmd = new MySqlCommand();
                SqlCmd.Connection = Conexion;
                SqlCmd.CommandText = @"sp_estadocarpetas_Por_Nombre";
                SqlCmd.CommandType = CommandType.StoredProcedure;
                //Aqui Parametros
                SqlCmd.Parameters.AddWithValue("@p_Denominacion", dEastadoCarpeta.Denominacion);
                //Ejecutar comando
                MySqlDataAdapter SqlDat = new MySqlDataAdapter(SqlCmd);
                DataTable dt = new DataTable();
                SqlDat.Fill(DtResultado);
            }
            catch (System.Exception ex)
            {
                string error = ex.Message;
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
