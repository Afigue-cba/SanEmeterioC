namespace SanEmeterio.Entidades
{
    using SanEmeterio.Clases;
    using MySql.Data.MySqlClient;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Reporte_Diskette
    {
        private string _Letra_carpeta;

        public string Letra_carpeta
        {
            get { return _Letra_carpeta; }
            set { _Letra_carpeta = value; }
        }
        private int _Numero_carpeta;

        public int Numero_carpeta
        {
            get { return _Numero_carpeta; }
            set { _Numero_carpeta = value; }
        }
        private string _Apellidoynombre;

        public string Apellidoynombre
        {
            get { return _Apellidoynombre; }
            set { _Apellidoynombre = value; }
        }
        private string _Numero_contrato;

        public string Numero_contrato
        {
            get { return _Numero_contrato; }
            set { _Numero_contrato = value; }
        }
        private int _Existe;

        public int Existe
        {
            get { return _Existe; }
            set { _Existe = value; }
        }
        private string _Domicilio;

        public string Domicilio
        {
            get { return _Domicilio; }
            set { _Domicilio = value; }
        }
        private string _Ver_campo;

        public string Ver_campo
        {
            get { return _Ver_campo; }
            set { _Ver_campo = value; }
        }
        private int _Carpeta_anterior;

        public int Carpeta_anterior
        {
            get { return _Carpeta_anterior; }
            set { _Carpeta_anterior = value; }
        }
        private string _Modifico;

        public string Modifico
        {
            get { return _Modifico; }
            set { _Modifico = value; }
        }

        //public string Letra_carpeta { get => _Letra_carpeta; set => _Letra_carpeta = value; }
        //public int Numero_carpeta { get => _Numero_carpeta; set => _Numero_carpeta = value; }
        //public string Apellidoynombre { get => _Apellidoynombre; set => _Apellidoynombre = value; }
        //public string Numero_contrato { get => _Numero_contrato; set => _Numero_contrato = value; }
        //public int Existe { get => _Existe; set => _Existe = value; }
        //public string Domicilio { get => _Domicilio; set => _Domicilio = value; }
        //public string Ver_campo { get => _Ver_campo; set => _Ver_campo = value; }
        //public int Carpeta_anterior { get => _Carpeta_anterior; set => _Carpeta_anterior = value; }
        //public string Modifico { get => _Modifico; set => _Modifico = value; }

        public Reporte_Diskette()
        {

        }
        public Reporte_Diskette(string letra_carpeta, int numero_carpeta, string apellidoynombre, string numero_contrato, int existe, string domicilio, string ver_campo, int carpeta_anterior, string modifico)
        {
            this.Letra_carpeta = letra_carpeta;
            this.Numero_carpeta = numero_carpeta;
            this.Apellidoynombre = apellidoynombre;
            this.Numero_contrato = numero_contrato;
            this.Existe = existe;
            this.Domicilio = domicilio;
            this.Ver_campo = ver_campo;
            this.Carpeta_anterior = carpeta_anterior;
            this.Modifico = modifico;
        }
        public static Boolean InsertarReporteDiskette(string letra_carpeta, int numero_carpeta, string apellidoynombre, string numero_contrato, int existe, string domicilio, string ver_campo, int carpeta_anterior, string modifico)
        {
            string SqlText = "INSERT INTO reporte_diskette (letra_carpeta, numero_carpeta, apellidoynombre, numero_contrato, existe, domicilio, ver_campo, carpeta_anterior, modifico) VALUES " +
                "(@letra_carpeta, @numero_carpeta, @apellidoynombre, @numero_contrato, @existe, @domicilio, @ver_campo, @carpeta_anterior, @modifico) ";

            MySqlConnection cnxMax = Database.obtenerConexion(true);
            if (cnxMax.State != ConnectionState.Open)
                cnxMax.Open();
            MySqlCommand _Comando = new MySqlCommand(SqlText, cnxMax);
            _Comando.Parameters.AddWithValue("@letra_carpeta", letra_carpeta);
            _Comando.Parameters.AddWithValue("@numero_carpeta", numero_carpeta);
            _Comando.Parameters.AddWithValue("@apellidoynombre", apellidoynombre);
            _Comando.Parameters.AddWithValue("@numero_contrato", numero_contrato);
            _Comando.Parameters.AddWithValue("@existe", existe);
            _Comando.Parameters.AddWithValue("@domicilio", domicilio);
            _Comando.Parameters.AddWithValue("@ver_campo", ver_campo);
            _Comando.Parameters.AddWithValue("@carpeta_anterior", carpeta_anterior);
            _Comando.Parameters.AddWithValue("@modifico", modifico);
            _Comando.ExecuteNonQuery();
            cnxMax.Close();
            return true;
        }

    }
}
