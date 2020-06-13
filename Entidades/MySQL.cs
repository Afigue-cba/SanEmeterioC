namespace SanEmeterio.Entidades
{
    using System;
    using System.Configuration;
    using System.Text;
    using MySql.Data.MySqlClient;

    public class MySQLC
    {
        private static MySqlConnection connMY = new MySqlConnection();

        private static string CrearCadena()
        {
            //String para cadena de conexion
            //StringBuilder sCadena = new StringBuilder("");
            string sCadena = ConfigurationManager.ConnectionStrings["cnx"].ConnectionString;
            //sCadena.Append("Server=<SERVIDOR>;");
            //sCadena.Append("Port=<PUERTO>;");
            //sCadena.Append("DataBase=<BASE>;");
            //sCadena.Append("Uid=<USER>;");
            //sCadena.Append("Pwd=<PASSWORD>;");
            //sCadena.Replace("<SERVIDOR>", "127.0.0.1");
            //sCadena.Replace("<PUERTO>", "3306");
            //sCadena.Replace("<BASE>", "devtroce");
            //sCadena.Replace("<USER>", "geekzero");
            //sCadena.Replace("<PASSWORD>", "********");

            return sCadena;
        } // end CrearConexion()

        private static string CrearCadena(string Servidor, string Puerto, string Base, string Usuario, string Password)
        {
            //String para cadena de conexion
            StringBuilder sCadena = new StringBuilder("");

            sCadena.Append("Server=<SERVIDOR>;");
            sCadena.Append("Port=<PUERTO>;");
            sCadena.Append("DataBase=<BASE>;");
            sCadena.Append("Uid=<USER>;");
            sCadena.Append("Pwd=<PASSWORD>;");
            sCadena.Replace("<SERVIDOR>", Servidor);
            sCadena.Replace("<PUERTO>", Puerto);
            sCadena.Replace("<BASE>", Base);
            sCadena.Replace("<USER>", Usuario);
            sCadena.Replace("<PASSWORD>", Password);

            return Convert.ToString(sCadena);
        } // end CrearCadena(5)

        public static MySqlConnection Conexion()
        {
            // objeto de conexion
            if (connMY.State != System.Data.ConnectionState.Open)
                connMY.ConnectionString = CrearCadena();
            return connMY;
        } // end Conexion()

        public static MySqlConnection Conexion(string Servidor, string Puerto, string Base, string Usuario, string Password)
        {
            // objeto de conexion
            if (connMY.State != System.Data.ConnectionState.Open)
                connMY.ConnectionString = CrearCadena(Servidor, Puerto, Base, Usuario, Password);
            return connMY;
        } // end Conexion()
    }
}
