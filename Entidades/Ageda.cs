using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanEmeterio.Entidades
{
    public class Agenda
    {
        private int _Id;

        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }
        private string _Contrato;

        public string Contrato
        {
            get { return _Contrato; }
            set { _Contrato = value; }
        }
        private DateTime _Fecha;

        public DateTime Fecha
        {
            get { return _Fecha; }
            set { _Fecha = value; }
        }
        private string _Hora;

        public string Hora
        {
            get { return _Hora; }
            set { _Hora = value; }
        }
        private string _Tarea;

        public string Tarea
        {
            get { return _Tarea; }
            set { _Tarea = value; }
        }
        private string _Estado;

        public string Estado
        {
            get { return _Estado; }
            set { _Estado = value; }
        }
        private string _Operador;

        public string Operador
        {
            get { return _Operador; }
            set { _Operador = value; }
        }
        private string _Carpeta;

        public string Carpeta
        {
            get { return _Carpeta; }
            set { _Carpeta = value; }
        }
        private DateTime _Creado;

        public DateTime Creado
        {
            get { return _Creado; }
            set { _Creado = value; }
        }
        private string _TextoBuscar;

        public string TextoBuscar
        {
            get { return _TextoBuscar; }
            set { _TextoBuscar = value; }
        }

        //public int Id { get => _Id; set => _Id = value; }
        //public string Contrato { get => _Contrato; set => _Contrato = value; }
        //public DateTime Fecha { get => _Fecha; set => _Fecha = value; }
        //public string Hora { get => _Hora; set => _Hora = value; }
        //public string Tarea { get => _Tarea; set => _Tarea = value; }
        //public string Estado { get => _Estado; set => _Estado = value; }
        //public string Operador { get => _Operador; set => _Operador = value; }
        //public string Carpeta { get => _Carpeta; set => _Carpeta = value; }
        //public DateTime Creado { get => _Creado; set => _Creado = value; }
        //public string TextoBuscar { get => _TextoBuscar; set => _TextoBuscar = value; }

        public Agenda()
        {

        }

        public Agenda(int id, string contrato, DateTime fecha, string hora, string tarea, string estado, string operador, string carpeta, DateTime creado, string textobuscar)
        {
            this.Id = id;
            this.Contrato = contrato;
            this.Fecha = fecha;
            this.Hora = hora;
            this.Tarea = tarea;
            this.Estado = estado;
            this.Operador = operador;
            this.Carpeta = carpeta;
            this.Creado = creado;
            this.TextoBuscar = textobuscar;
        }

        //Metodo Insertar
        public string Insertar(Agenda dAgenda)
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
                SqlCmd.CommandText = "sp_agenda";
                SqlCmd.CommandType = CommandType.StoredProcedure;
                //Aqui Parametros
                SqlCmd.Parameters.AddWithValue("@_id", 0);
                SqlCmd.Parameters.AddWithValue("@_contrato", dAgenda.Contrato);
                SqlCmd.Parameters.AddWithValue("@_fecha", dAgenda.Fecha);
                SqlCmd.Parameters.AddWithValue("@_hora", dAgenda.Hora);
                SqlCmd.Parameters.AddWithValue("@_tarea", dAgenda.Tarea);
                SqlCmd.Parameters.AddWithValue("@_estado", dAgenda.Estado);
                SqlCmd.Parameters.AddWithValue("@_operador", dAgenda.Operador);
                SqlCmd.Parameters.AddWithValue("@_carpeta", dAgenda.Carpeta);
                SqlCmd.Parameters.AddWithValue("@_creado", dAgenda.Creado);
                SqlCmd.Parameters.AddWithValue("@accion", "nuevo");
                SqlCmd.Parameters.AddWithValue("@valorUp", "");
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
        public string Editar(Agenda dAgenda)
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
                SqlCmd.CommandText = "sp_agenda";
                SqlCmd.CommandType = CommandType.StoredProcedure;
                //Aqui Parametros
                SqlCmd.Parameters.AddWithValue("@_contrato", dAgenda.Contrato);
                SqlCmd.Parameters.AddWithValue("@_fecha", dAgenda.Fecha);
                SqlCmd.Parameters.AddWithValue("@_hora", dAgenda.Hora);
                SqlCmd.Parameters.AddWithValue("@_tarea", dAgenda.Tarea);
                SqlCmd.Parameters.AddWithValue("@_estado", dAgenda.Estado);
                SqlCmd.Parameters.AddWithValue("@_operador", dAgenda.Operador);
                SqlCmd.Parameters.AddWithValue("@_carpeta", dAgenda.Carpeta);
                SqlCmd.Parameters.AddWithValue("@_creado", dAgenda.Creado);
                SqlCmd.Parameters.AddWithValue("@accion", "editar");
                SqlCmd.Parameters.AddWithValue("@valorUp", dAgenda.TextoBuscar);
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
        public string Eliminar(Agenda dAgenda)
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
                SqlCmd.CommandText = "sp_agenda";
                SqlCmd.CommandType = CommandType.StoredProcedure;
                //Aqui Parametros
                SqlCmd.Parameters.AddWithValue("@accion", "eliminar");

                SqlCmd.Parameters.AddWithValue("@_id", dAgenda.Id);
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
        public DataTable BuscarContrato(Agenda dAgenda)
        {
            DataTable DtResultado = new DataTable("Agenda");
            MySqlConnection Conexion = Clases.Database.obtenerConexion(true);
            try
            {
                //Codigo
                if (Conexion.State != ConnectionState.Open)
                    Conexion.Open();
                //Establecer Comando
                MySqlCommand SqlCmd = new MySqlCommand();
                SqlCmd.Connection = Conexion;
                SqlCmd.CommandText = "sp_agenda";
                SqlCmd.CommandType = CommandType.StoredProcedure;
                //Aqui Parametros
                SqlCmd.Parameters.AddWithValue("@accion", "consultar");
                SqlCmd.Parameters.AddWithValue("@valorUp", dAgenda.TextoBuscar);
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
