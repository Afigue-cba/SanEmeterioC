namespace SanEmeterio.Entidades
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using MySql.Data.MySqlClient;

    public class Provincias
    {
        private int _idprovincia;

        public int Idprovincia
        {
            get { return _idprovincia; }
            set { _idprovincia = value; }
        }
        private string _letra_provincia;

        public string Letra_provincia
        {
            get { return _letra_provincia; }
            set { _letra_provincia = value; }
        }
        private string _nombre_provincia;

        public string Nombre_provincia
        {
            get { return _nombre_provincia; }
            set { _nombre_provincia = value; }
        }

        //public int Idprovincia { get => _idprovincia; set => _idprovincia = value; }
        //public string Letra_provincia { get => _letra_provincia; set => _letra_provincia = value; }
        //public string Nombre_provincia { get => _nombre_provincia; set => _nombre_provincia = value; }

        public Provincias()
        {

        }

        public Provincias(int Idprovincia, string Letra_provincia, string Nombre_provincia)
        {
            this.Idprovincia = _idprovincia;
            this.Letra_provincia = _letra_provincia;
            this.Nombre_provincia = _nombre_provincia;
        }

        //Metodo Insertar
        public string Insertar(Provincias mProvincias)
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
                SqlCmd.CommandText = "sp_Provincias_Insertarprovincias";
                SqlCmd.CommandType = CommandType.StoredProcedure;
                //Aqui Parametros
                SqlCmd.Parameters.AddWithValue("@Idprovincia", mProvincias._idprovincia);
                SqlCmd.Parameters.AddWithValue("@Letra_provincia", mProvincias.Letra_provincia);
                SqlCmd.Parameters.AddWithValue("@Nombre_provincia", mProvincias.Nombre_provincia);
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
        public DataTable BuscarProvinciaN(Provincias dProvincias)
        {
            DataTable DtResultado = new DataTable("Provincias");
            MySqlConnection Conexion = Clases.Database.obtenerConexion(true);
            try
            {
                //Codigo
                if (Conexion.State != ConnectionState.Open)
                    Conexion.Open();
                //Establecer Comando
                MySqlCommand SqlCmd = new MySqlCommand();
                SqlCmd.Connection = Conexion;
                SqlCmd.CommandText = @"sp_provincias_Por_Nombre";
                SqlCmd.CommandType = CommandType.StoredProcedure;
                //Aqui Parametros
                SqlCmd.Parameters.AddWithValue("@p_nombre_provincia", dProvincias.Nombre_provincia);
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
