namespace SanEmeterio.Entidades
{
    using MySql.Data;
    using MySql.Data.MySqlClient;
    using System.Data;


    public class Documento
    {
        private int _iddocumento;
        private int _tipo_documento;
        private string _nombre_documento;
        private string _TextoBuscar;

        public string TextoBuscar
        {
            get { return _TextoBuscar; }
            set { _TextoBuscar = value; }
        }

        public string Nombre_documento
        {
            get { return _nombre_documento; }
            set { _nombre_documento = value; }
        }

        public int Tipo_documento
        {
            get { return _tipo_documento; }
            set { _tipo_documento = value; }
        }

        public int Iddocumento
        {
            get { return _iddocumento; }
            set { _iddocumento = value; }
        }

        //public int Iddocumento { get  _iddocumento; set  _iddocumento = value; }
        //public int Tipo_documento { get => _tipo_documento; set => _tipo_documento = value; }
        //public string Nombre_documento { get => _nombre_documento; set => _nombre_documento = value; }
        //public string TextoBuscar { get => _TextoBuscar; set => _TextoBuscar = value; }

        //Constructor Vacio
        public Documento()
        {

        }

        //Constructor con Parametros
        public Documento(int IdDocumento, int Tipo_Documento, string Nombre_Documento, string textobuacar)
        {
            this.Iddocumento = IdDocumento;
            this.Tipo_documento = Tipo_Documento;
            this.Nombre_documento = Nombre_Documento;
            this.TextoBuscar = textobuacar;
        }

        //Metodo Insertar
        public string Insertar(Documento mDocumento)
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
                SqlCmd.CommandText = "sp_Documento_Insertardocumento";
                SqlCmd.CommandType = CommandType.StoredProcedure;
                //Aqui Parametros
                SqlCmd.Parameters.AddWithValue("@p_iddocumento", mDocumento.Iddocumento);
                SqlCmd.Parameters.AddWithValue("@p_tipo_documento", mDocumento.Tipo_documento);
                SqlCmd.Parameters.AddWithValue("@p_nombre_documento", mDocumento.Nombre_documento);
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
        public DataTable BuscarDocumentoN(Documento dDocumento)
        {
            DataTable DtResultado = new DataTable("Documento");
            MySqlConnection Conexion = Clases.Database.obtenerConexion(true);
            try
            {
                //Codigo
                if (Conexion.State != ConnectionState.Open)
                    Conexion.Open();
                //Establecer Comando
                MySqlCommand SqlCmd = new MySqlCommand();
                SqlCmd.Connection = Conexion;
                SqlCmd.CommandText = @"sp_documento_Por_Nombre";
                SqlCmd.CommandType = CommandType.StoredProcedure;
                //Aqui Parametros
                SqlCmd.Parameters.AddWithValue("@p_nombre_documento", dDocumento.Nombre_documento);
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
