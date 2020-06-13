namespace SanEmeterio.Entidades
{
    using MySql.Data.MySqlClient;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Comentarios
    {
        private int _Comentarios_id;

        public int Comentarios_id
        {
            get { return _Comentarios_id; }
            set { _Comentarios_id = value; }
        }
        private DateTime _Comentarios_Fecha;

        public DateTime Comentarios_Fecha
        {
            get { return _Comentarios_Fecha; }
            set { _Comentarios_Fecha = value; }
        }
        private string _Comentarios_Comentario;

        public string Comentarios_Comentario
        {
            get { return _Comentarios_Comentario; }
            set { _Comentarios_Comentario = value; }
        }
        private string _Comentarios_Operador;

        public string Comentarios_Operador
        {
            get { return _Comentarios_Operador; }
            set { _Comentarios_Operador = value; }
        }
        private string _Contrato;

        public string Contrato
        {
            get { return _Contrato; }
            set { _Contrato = value; }
        }
        private string _Estado;

        public string Estado
        {
            get { return _Estado; }
            set { _Estado = value; }
        }
        private string _Carpeta;

        public string Carpeta
        {
            get { return _Carpeta; }
            set { _Carpeta = value; }
        }

        //public int Comentarios_id { get => _Comentarios_id; set => _Comentarios_id = value; }
        //public DateTime Comentarios_Fecha { get => _Comentarios_Fecha; set => _Comentarios_Fecha = value; }
        //public string Comentarios_Comentario { get => _Comentarios_Comentario; set => _Comentarios_Comentario = value; }
        //public string Comentarios_Operador { get => _Comentarios_Operador; set => _Comentarios_Operador = value; }
        //public string Contrato { get => _Contrato; set => _Contrato = value; }
        //public string Estado { get => _Estado; set => _Estado = value; }
        //public string Carpeta { get => _Carpeta; set => _Carpeta = value; }

        public Comentarios()
        {

        }

        public Comentarios(int comentarios_id, DateTime comentarios_fecha, string comentarios_comentario, string comentarios_operador, string contrato, string estado, string carpeta)
        {
            this.Comentarios_id = comentarios_id;
            this.Comentarios_Fecha = comentarios_fecha;
            this.Comentarios_Comentario = comentarios_comentario;
            this.Comentarios_Operador = comentarios_operador;
            this.Contrato = contrato;
            this.Estado = estado;
            this.Carpeta = carpeta;
        }

        public string Insertar(Comentarios dComentarios)
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
                SqlCmd.CommandText = "sp_Comentarios_Insertarcomentarios";
                SqlCmd.CommandType = CommandType.StoredProcedure;
                //Aqui Parametros
                SqlCmd.Parameters.AddWithValue("@p_comentarios_Id", 0);
                SqlCmd.Parameters.AddWithValue("@p_comentarios_Fecha", dComentarios.Comentarios_Fecha);
                SqlCmd.Parameters.AddWithValue("@p_comentarios_Comentario", dComentarios.Comentarios_Comentario);
                SqlCmd.Parameters.AddWithValue("@p_comentarios_Operador", dComentarios.Comentarios_Operador);
                SqlCmd.Parameters.AddWithValue("@p_contrato", dComentarios.Contrato);
                SqlCmd.Parameters.AddWithValue("@p_estado", dComentarios.Estado);
                SqlCmd.Parameters.AddWithValue("@p_carpeta", dComentarios.Carpeta);
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
        public string Editar(Comentarios dComentarios)
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
                SqlCmd.CommandText = "sp_Comentarios_Actualizar_comentarios";
                SqlCmd.CommandType = CommandType.StoredProcedure;
                //Aqui Parametros
                SqlCmd.Parameters.AddWithValue("@p_comentarios_Id", dComentarios.Comentarios_id);
                SqlCmd.Parameters.AddWithValue("@p_comentarios_Fecha", dComentarios.Comentarios_Fecha);
                SqlCmd.Parameters.AddWithValue("@p_comentarios_Comentario", dComentarios.Comentarios_Comentario);
                SqlCmd.Parameters.AddWithValue("@p_comentarios_Operador", dComentarios.Comentarios_Operador);
                SqlCmd.Parameters.AddWithValue("@p_contrato", dComentarios.Contrato);
                SqlCmd.Parameters.AddWithValue("@p_estado", dComentarios.Estado);
                SqlCmd.Parameters.AddWithValue("@p_carpeta", dComentarios.Carpeta);
                //Ejecutar comando
                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se modifico el Registro";

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

        public string Eliminar(Comentarios dComentarios)
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
                SqlCmd.CommandText = "sp_Comentarios_Borrar_comentarios";
                SqlCmd.CommandType = CommandType.StoredProcedure;
                //Aqui Parametros
                SqlCmd.Parameters.AddWithValue("@p_comentarios_Id", dComentarios.Comentarios_id);
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
        public DataTable BuscarComentario(Comentarios dComentarios)
        {
            DataTable DtResultado = new DataTable("Comentarios");
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
                SqlCmd.Parameters.AddWithValue("@p_nombre_documento", dComentarios.Contrato);
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
