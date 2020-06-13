using MySql.Data.MySqlClient;
using SanEmeterio.Clases;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SanEmeterio.Entidades;


namespace SanEmeterio.CapaNegocio
{
    public class TratamientoDeuda
    {
        public static int Contar_Carpeta(string sContrato)
        {
            int iExiste = 0;
            string sWhere = " numero_contrato LIKE @numero_contrato";
            string Sqltext = "SELECT id, idcocesionario, iddocumentoG, iddocumentoS, idprovinciaG, idprovinciaS, IDestadocarpetas, numero_letra, numero_contrato, existe, numero_estudio, periodo, apellidoynombre_propietario, " +
                "actual_propietario, domicilio_propietario, localidad_propietario, cp_propietario, telefono_propietario, numerodni_propietario, apellidoynombre_garante, domicilio_garante, localidad_garante, " +
                "cp_garante, telefono_garante, numerodni_garante, p_n_cor, fecha_ingreso, ult_estado, intcap, estado_carpeta, nivel_deuda, cuotas, deuda, estado_comentario, domicilio_ap, " +
                "localidad_ap, cp_ap, idprovincia_ap, email, nivel, CuitDni, CondIva, N_garante, Piso_garante, Dpto_garante, Email_garante " +
                "FROM tratamientocarpetas where " + sWhere;

            MySqlConnection Conexion = Database.obtenerConexion(true);

            if (Conexion.State != ConnectionState.Open)
                Conexion.Open();

            MySqlCommand _Comando = new MySqlCommand(Sqltext, Conexion);
            _Comando.Parameters.AddWithValue("@numero_contrato", sContrato + "%");
            MySqlDataReader _readerIT = _Comando.ExecuteReader();

            while (_readerIT.Read())
            {
                iExiste = iExiste + 1;
            }
            Conexion.Close();
            return iExiste;
        }

        public static string Insertar(int idcocesionario, int iddocumentoG, int iddocumentoS, int idprovinciaG, int idprovinciaS, int Idestadocarpetas, int idletracarpetas, int numero_letra, string numero_contrato, int existe, string numero_estudio, DateTime periodo, string apellidoynombre_propietario, string actual_propietario,
            string domicilio_propietario, string localidad_propietario, int cp_propietario, string telefono_propietario, string numerodni_propietario, string apellidoynombre_garante, string domicilio_garante, string localidad_garante, int cp_garante, string telefono_garante, string numerodni_garante, int p_n_cor,
            DateTime fecha_ingreso, DateTime ult_estado, string intcap, string estado_carpeta, string nivel_deuda, string cuotas, string deuda, string estado_comentario, string domicilio_ap, string localidad_ap, int cp_ap, int idprovincia_ap, string email, int nivel, string Cuitdni, string Condiva, string N_Garante,
            string Piso_Garante, string Dpto_Garante, string Email_Garante)
        {
            Carpetas Obj = new Carpetas
            {
                Idcocesionario = idcocesionario,
                IddocumentoG = iddocumentoG,
                IddocumentoS = iddocumentoS,
                IdprovinciaG = idprovinciaG,
                IdprovinciaS = idprovinciaS,
                IDestadocarpetas = Idestadocarpetas,
                Idletracarpetas = idletracarpetas,
                Numero_letra = numero_letra,
                Numero_contrato = numero_contrato,
                Existe = existe,
                Numero_estudio = numero_estudio,
                Periodo = periodo,
                Apellidoynombre_propietario = apellidoynombre_propietario,
                Actual_propietario = actual_propietario,
                Domicilio_propietario = domicilio_propietario,
                Localidad_propietario = localidad_propietario,
                Cp_propietario = cp_propietario,
                Telefono_propietario = telefono_propietario,
                Numerodni_propietario = numerodni_propietario,
                Apellidoynombre_garante = apellidoynombre_garante,
                Domicilio_garante = domicilio_garante,
                Localidad_garante = localidad_garante,
                Cp_garante = cp_garante,
                Telefono_garante = telefono_garante,
                Numerodni_garante = numerodni_garante,
                P_n_cor = p_n_cor,
                Fecha_ingreso = fecha_ingreso,
                Ult_estado = ult_estado,
                Intcap = intcap,
                Estado_carpeta = estado_carpeta,
                Nivel_deuda = nivel_deuda,
                Cuotas = cuotas,
                Deuda = deuda,
                Estado_comentario = estado_comentario,
                Domicilio_ap = domicilio_ap,
                Localidad_ap = localidad_ap,
                Cp_ap = cp_ap,
                Idprovincia_ap = idprovincia_ap,
                Email = email,
                Nivel = nivel,
                CuitDni = Cuitdni,
                CondIva = Condiva,
                N_garante = N_Garante,
                Piso_garante = Piso_Garante,
                Dpto_garante = Dpto_Garante,
                Email_garante = Email_Garante
            };
            return Obj.Insertar(Obj);
        }

        public static string Editar(int idcocesionario, int iddocumentoG, int iddocumentoS, int idprovinciaG, int idprovinciaS, int Idestadocarpetas, int idletracarpetas, int numero_letra, string numero_contrato, int existe, string numero_estudio, DateTime periodo, string apellidoynombre_propietario, string actual_propietario,
        string domicilio_propietario, string localidad_propietario, int cp_propietario, string telefono_propietario, string numerodni_propietario, string apellidoynombre_garante, string domicilio_garante, string localidad_garante, int cp_garante, string telefono_garante, string numerodni_garante, int p_n_cor,
        DateTime fecha_ingreso, DateTime ult_estado, string intcap, string estado_carpeta, string nivel_deuda, string cuotas, string deuda, string estado_comentario, string domicilio_ap, string localidad_ap, int cp_ap, int idprovincia_ap, string email, int nivel, string Cuitdni, string Condiva, string N_Garante,
        string Piso_Garante, string Dpto_Garante, string Email_Garante)
        {
            Carpetas Obj = new Carpetas
            {
                Idcocesionario = idcocesionario,
                IddocumentoG = iddocumentoG,
                IddocumentoS = iddocumentoS,
                IdprovinciaG = idprovinciaG,
                IdprovinciaS = idprovinciaS,
                IDestadocarpetas = Idestadocarpetas,
                Idletracarpetas = idletracarpetas,
                Numero_letra = numero_letra,
                Numero_contrato = numero_contrato,
                Existe = existe,
                Numero_estudio = numero_estudio,
                Periodo = periodo,
                Apellidoynombre_propietario = apellidoynombre_propietario,
                Actual_propietario = actual_propietario,
                Domicilio_propietario = domicilio_propietario,
                Localidad_propietario = localidad_propietario,
                Cp_propietario = cp_propietario,
                Telefono_propietario = telefono_propietario,
                Numerodni_propietario = numerodni_propietario,
                Apellidoynombre_garante = apellidoynombre_garante,
                Domicilio_garante = domicilio_garante,
                Localidad_garante = localidad_garante,
                Cp_garante = cp_garante,
                Telefono_garante = telefono_garante,
                Numerodni_garante = numerodni_garante,
                P_n_cor = p_n_cor,
                Fecha_ingreso = fecha_ingreso,
                Ult_estado = ult_estado,
                Intcap = intcap,
                Estado_carpeta = estado_carpeta,
                Nivel_deuda = nivel_deuda,
                Cuotas = cuotas,
                Deuda = deuda,
                Estado_comentario = estado_comentario,
                Domicilio_ap = domicilio_ap,
                Localidad_ap = localidad_ap,
                Cp_ap = cp_ap,
                Idprovincia_ap = idprovincia_ap,
                Email = email,
                Nivel = nivel,
                CuitDni = Cuitdni,
                CondIva = Condiva,
                N_garante = N_Garante,
                Piso_garante = Piso_Garante,
                Dpto_garante = Dpto_Garante,
                Email_garante = Email_Garante
            };
            return Obj.Editar(Obj);
        }

        public static string Eliminar(int id)
        {
            Carpetas Obj = new Carpetas
            {
                Id = id
            };
            return Obj.Eliminar(Obj);
        }

        public static DataTable BuscarCarpeta(int iCarpeta)
        {
            Carpetas Obj = new Carpetas
            {
                ICarpeta = iCarpeta
            };
            return Obj.BuscarContrato(Obj);
        }

        public static int MaxNroLetraContrato(string contrato, string OtroParametro)
        {
            int UltimaCarpeta = 0;
            string sWhere = "";
            if (OtroParametro != "")
            {
                sWhere = OtroParametro;
            }

            string SqlText = "SELECT Max(Tr.numero_letra) AS Maximo FROM tratamientocarpetas AS Tr where numero_contrato=@contrato " + sWhere;

            MySqlConnection cnxMax = Database.obtenerConexion(true);
            if (cnxMax.State != ConnectionState.Open)
                cnxMax.Open();
            MySqlCommand _Comando = new MySqlCommand(SqlText, cnxMax);
            _Comando.Parameters.AddWithValue("@contrato", contrato);

            MySqlDataReader _ReadPar = _Comando.ExecuteReader();
            while (_ReadPar.Read())
            {
                if (_ReadPar.GetValue(0) != DBNull.Value)
                    UltimaCarpeta = _ReadPar.GetInt32("Maximo");
            }
            cnxMax.Close();
            return UltimaCarpeta;
        }

        public static int CarpetaMaxima()
        {
            int UltimaCarpeta = 0;

            string SqlText = "SELECT Max(Tr.numero_letra) AS Maximo FROM tratamientocarpetas AS Tr ";

            MySqlConnection cnxMax = Database.obtenerConexion(true);
            if (cnxMax.State != ConnectionState.Open)
                cnxMax.Open();
            MySqlCommand _Comando = new MySqlCommand(SqlText, cnxMax);

            MySqlDataReader _ReadPar = _Comando.ExecuteReader();
            while (_ReadPar.Read())
            {
                UltimaCarpeta = _ReadPar.GetInt32("Maximo") + 1;
            }
            cnxMax.Close();
            return UltimaCarpeta;
        }

        public static Boolean ActualizaTratamiento(int Idestadocarpetas, int numero_letra, string numero_contrato, int existe, DateTime periodo, string apellidoynombre_propietario,
            string domicilio_propietario, string localidad_propietario, int cp_propietario, string telefono_propietario, string numerodni_propietario, string apellidoynombre_garante,
            string domicilio_garante, string localidad_garante, int cp_garante, string telefono_garante, string numerodni_garante,
            DateTime ult_estado, string estado_carpeta, string nivel_deuda)
        {
            string SqlText = "update tratamientocarpetas set idestadocarpetas=@idestadocarpetas, existe=@existe, periodo=@periodo, apellidoynombre_propietario=@apellidoynombre_propietario, domicilio_propietario=@domicilio_propietario, " +
                "localidad_propietario=@localidad_propietario, cp_propietario=@cp_propietario, telefono_propietario=@telefono_propietario, numerodni_propietario=@numerodni_propietario, apellidoynombre_garante=@apellidoynombre_garante, " +
                "domicilio_garante=@domicilio_garante, localidad_garante=@localidad_garante, cp_garante=@cp_garante, telefono_garante=@telefono_garante, numerodni_garante=@numerodni_garante, ult_estado=@ult_estado, estado_carpeta=@estado_carpeta, " +
                "nivel_deuda=@nivel_deuda where numero_contrato = @numero_contrato and numero_letra = @numero_letra";

            MySqlConnection cnxMax = Database.obtenerConexion(true);
            if (cnxMax.State != ConnectionState.Open)
                cnxMax.Open();
            MySqlCommand _Comando = new MySqlCommand(SqlText, cnxMax);
            _Comando.Parameters.AddWithValue("@idestadocarpetas", Idestadocarpetas);
            _Comando.Parameters.AddWithValue("@numero_letra", numero_letra);
            _Comando.Parameters.AddWithValue("@numero_contrato", numero_contrato);
            _Comando.Parameters.AddWithValue("@existe", existe);
            _Comando.Parameters.AddWithValue("@periodo", periodo);
            _Comando.Parameters.AddWithValue("@apellidoynombre_propietario", apellidoynombre_propietario);
            _Comando.Parameters.AddWithValue("@domicilio_propietario", domicilio_propietario);
            _Comando.Parameters.AddWithValue("@localidad_propietario", localidad_propietario);
            _Comando.Parameters.AddWithValue("@cp_propietario", cp_propietario);
            _Comando.Parameters.AddWithValue("@telefono_propietario", telefono_propietario);
            _Comando.Parameters.AddWithValue("@numerodni_propietario", numerodni_propietario);
            _Comando.Parameters.AddWithValue("@apellidoynombre_garante", apellidoynombre_garante);
            _Comando.Parameters.AddWithValue("@domicilio_garante", domicilio_garante);
            _Comando.Parameters.AddWithValue("@localidad_garante", localidad_garante);
            _Comando.Parameters.AddWithValue("@cp_garante", cp_garante);
            _Comando.Parameters.AddWithValue("@telefono_garante", telefono_garante);
            _Comando.Parameters.AddWithValue("@numerodni_garante", numerodni_garante);
            _Comando.Parameters.AddWithValue("@ult_estado", ult_estado);
            _Comando.Parameters.AddWithValue("@estado_carpeta", estado_carpeta);
            _Comando.Parameters.AddWithValue("@nivel_deuda", nivel_deuda);
            _Comando.ExecuteNonQuery();
            cnxMax.Close();
            return true;
        }

        public static Boolean InsertarTratamiento(int idcocesionario, int iddocumentoG, int iddocumentoS, int idprovinciaG, int idprovinciaS, int Idestadocarpetas, int idletracarpetas, int numero_letra, string numero_contrato, int existe, string numero_estudio, DateTime periodo, string apellidoynombre_propietario,
            string domicilio_propietario, string localidad_propietario, int cp_propietario, string telefono_propietario, string numerodni_propietario, string apellidoynombre_garante, string domicilio_garante, string localidad_garante, int cp_garante, string telefono_garante, string numerodni_garante,
            DateTime fecha_ingreso, DateTime ult_estado, string estado_carpeta, string nivel_deuda)
        {
            string SqlText = "INSERT INTO tratamientocarpetas (idcocesionario, iddocumentoG, iddocumentoS, idprovinciaG, idprovinciaS, Idestadocarpetas, idletracarpetas, numero_letra, numero_contrato, existe, numero_estudio, periodo, apellidoynombre_propietario, " +
                " domicilio_propietario, localidad_propietario, cp_propietario, telefono_propietario, numerodni_propietario, apellidoynombre_garante, domicilio_garante, localidad_garante, cp_garante, telefono_garante, numerodni_garante, " +
                " fecha_ingreso, ult_estado, estado_carpeta, nivel_deuda) VALUES (@idcocesionario, @iddocumentoG, @iddocumentoS, @idprovinciaG, @idprovinciaS, @Idestadocarpetas, @idletracarpetas, @numero_letra, @numero_contrato, @existe, @numero_estudio, @periodo, @apellidoynombre_propietario, " +
                " @domicilio_propietario, @localidad_propietario, @cp_propietario, @telefono_propietario, @numerodni_propietario, @apellidoynombre_garante, @domicilio_garante, @localidad_garante, @cp_garante, @telefono_garante, @numerodni_garante, " +
                " @fecha_ingreso, @ult_estado, @estado_carpeta, @nivel_deuda) ";

            MySqlConnection cnxMax = Database.obtenerConexion(true);
            if (cnxMax.State != ConnectionState.Open)
                cnxMax.Open();
            MySqlCommand _Comando = new MySqlCommand(SqlText, cnxMax);
            _Comando.Parameters.AddWithValue("@idcocesionario", idcocesionario);
            _Comando.Parameters.AddWithValue("@iddocumentoG", iddocumentoG);
            _Comando.Parameters.AddWithValue("@iddocumentoS", iddocumentoS);
            _Comando.Parameters.AddWithValue("@idprovinciaG", idprovinciaG);
            _Comando.Parameters.AddWithValue("@idprovinciaS", idprovinciaS);
            _Comando.Parameters.AddWithValue("@Idestadocarpetas", Idestadocarpetas);
            _Comando.Parameters.AddWithValue("@idletracarpetas", idletracarpetas);
            _Comando.Parameters.AddWithValue("@numero_letra", numero_letra);
            _Comando.Parameters.AddWithValue("@numero_contrato", numero_contrato);
            _Comando.Parameters.AddWithValue("@existe", existe);
            _Comando.Parameters.AddWithValue("@numero_estudio", numero_estudio);
            _Comando.Parameters.AddWithValue("@periodo", periodo);
            _Comando.Parameters.AddWithValue("@apellidoynombre_propietario", apellidoynombre_propietario);
            _Comando.Parameters.AddWithValue("@domicilio_propietario", domicilio_propietario);
            _Comando.Parameters.AddWithValue("@localidad_propietario", localidad_propietario);
            _Comando.Parameters.AddWithValue("@cp_propietario", cp_propietario);
            _Comando.Parameters.AddWithValue("@telefono_propietario", telefono_propietario);
            _Comando.Parameters.AddWithValue("@numerodni_propietario", numerodni_propietario);
            _Comando.Parameters.AddWithValue("@apellidoynombre_garante", apellidoynombre_garante);
            if (apellidoynombre_garante.Length > 0)
            {
                if (domicilio_garante.Length > 50)
                {
                    domicilio_garante = domicilio_garante.Substring(1, 50);
                }
                _Comando.Parameters.AddWithValue("@domicilio_garante", domicilio_garante);
                _Comando.Parameters.AddWithValue("@localidad_garante", localidad_garante);
                _Comando.Parameters.AddWithValue("@cp_garante", cp_garante);
                _Comando.Parameters.AddWithValue("@telefono_garante", telefono_garante);
                _Comando.Parameters.AddWithValue("@numerodni_garante", numerodni_garante);
            }
            else
            {
                _Comando.Parameters.AddWithValue("@domicilio_garante", null);
                _Comando.Parameters.AddWithValue("@localidad_garante", null);
                _Comando.Parameters.AddWithValue("@cp_garante", 0);
                _Comando.Parameters.AddWithValue("@telefono_garante", null);
                _Comando.Parameters.AddWithValue("@numerodni_garante", null);
            }
            _Comando.Parameters.AddWithValue("@fecha_ingreso", fecha_ingreso);
            _Comando.Parameters.AddWithValue("@ult_estado", ult_estado);
            _Comando.Parameters.AddWithValue("@estado_carpeta", estado_carpeta);
            _Comando.Parameters.AddWithValue("@nivel_deuda", nivel_deuda);
            _Comando.ExecuteNonQuery();
            cnxMax.Close();
            return true;
        }

        public static int BuscarIdCarpeta(int NroCarpeta)
        {
            int IdCarpeta = 0;

            string SqlText = "SELECT Id AS Maximo FROM tratamientocarpetas AS Tr where numero_letra=@numero_letra ";

            MySqlConnection cnxMax = Database.obtenerConexion(true);
            if (cnxMax.State != ConnectionState.Open)
                cnxMax.Open();
            MySqlCommand _Comando = new MySqlCommand(SqlText, cnxMax);
            _Comando.Parameters.AddWithValue("@numero_letra", NroCarpeta);

            MySqlDataReader _ReadPar = _Comando.ExecuteReader();
            while (_ReadPar.Read())
            {
                IdCarpeta = _ReadPar.GetInt32("Maximo");
            }
            cnxMax.Close();
            return IdCarpeta;
        }


    }
}
