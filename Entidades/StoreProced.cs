namespace SanEmeterio.Entidades
{
    using System;
    using System.Data;
    using MySql.Data.MySqlClient;

    public class StoreProced
    {
        public static void InvocarSP(int pValor1, Int16 pValor2, Byte[] pValor3)
        {
            using (MySqlCommand cmd = new MySqlCommand())
            {
                try
                {
                    // setear parametros del command
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = MySQLC.Conexion();
                    cmd.CommandText = "NOMBRE_DEL_STORED_PROCEDURE";

                    //asignar paramentros
                    cmd.Parameters.AddWithValue("param1", pValor1);
                    cmd.Parameters.AddWithValue("param2", pValor2);
                    cmd.Parameters.AddWithValue("param3", pValor3);

                    //abrir la conexion
                    MySQLC.Conexion().Open();

                    //ejecutar el query
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    MySQLC.Conexion().Close();
                } // end try
            } // end using
        } // end GuardarHuella
    }
}
