namespace SanEmeterio.Entidades
{
    using MySql.Data.MySqlClient;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Carpetas
    {
        private int _Id;

        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }
        private int _Idcocesionario;

        public int Idcocesionario
        {
            get { return _Idcocesionario; }
            set { _Idcocesionario = value; }
        }
        private int _IddocumentoG;

        public int IddocumentoG
        {
            get { return _IddocumentoG; }
            set { _IddocumentoG = value; }
        }
        private int _IddocumentoS;

        public int IddocumentoS
        {
            get { return _IddocumentoS; }
            set { _IddocumentoS = value; }
        }
        private int _IdprovinciaG;

        public int IdprovinciaG
        {
            get { return _IdprovinciaG; }
            set { _IdprovinciaG = value; }
        }
        private int _IdprovinciaS;

        public int IdprovinciaS
        {
            get { return _IdprovinciaS; }
            set { _IdprovinciaS = value; }
        }
        private int _Idestadocarpetas;

        public int IDestadocarpetas
        {
            get { return _Idestadocarpetas; }
            set { _Idestadocarpetas = value; }
        }
        private int _Idletracarpetas;

        public int Idletracarpetas
        {
            get { return _Idletracarpetas; }
            set { _Idletracarpetas = value; }
        }
        private int _Numero_letra;

        public int Numero_letra
        {
            get { return _Numero_letra; }
            set { _Numero_letra = value; }
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
        private string _Numero_estudio;

        public string Numero_estudio
        {
            get { return _Numero_estudio; }
            set { _Numero_estudio = value; }
        }
        private DateTime _Periodo;

        public DateTime Periodo
        {
            get { return _Periodo; }
            set { _Periodo = value; }
        }
        private string _Apellidoynombre_propietario;

        public string Apellidoynombre_propietario
        {
            get { return _Apellidoynombre_propietario; }
            set { _Apellidoynombre_propietario = value; }
        }
        private string _Actual_propietario;

        public string Actual_propietario
        {
            get { return _Actual_propietario; }
            set { _Actual_propietario = value; }
        }
        private string _Domicilio_propietario;

        public string Domicilio_propietario
        {
            get { return _Domicilio_propietario; }
            set { _Domicilio_propietario = value; }
        }
        private string _Localidad_propietario;

        public string Localidad_propietario
        {
            get { return _Localidad_propietario; }
            set { _Localidad_propietario = value; }
        }
        private int _Cp_propietario;

        public int Cp_propietario
        {
            get { return _Cp_propietario; }
            set { _Cp_propietario = value; }
        }
        private string _Telefono_propietario;

        public string Telefono_propietario
        {
            get { return _Telefono_propietario; }
            set { _Telefono_propietario = value; }
        }
        private string _Numerodni_propietario;

        public string Numerodni_propietario
        {
            get { return _Numerodni_propietario; }
            set { _Numerodni_propietario = value; }
        }
        private string _Apellidoynombre_garante;

        public string Apellidoynombre_garante
        {
            get { return _Apellidoynombre_garante; }
            set { _Apellidoynombre_garante = value; }
        }
        private string _Domicilio_garante;

        public string Domicilio_garante
        {
            get { return _Domicilio_garante; }
            set { _Domicilio_garante = value; }
        }
        private string _Localidad_garante;

        public string Localidad_garante
        {
            get { return _Localidad_garante; }
            set { _Localidad_garante = value; }
        }
        private int _Cp_garante;

        public int Cp_garante
        {
            get { return _Cp_garante; }
            set { _Cp_garante = value; }
        }
        private string _Telefono_garante;

        public string Telefono_garante
        {
            get { return _Telefono_garante; }
            set { _Telefono_garante = value; }
        }
        private string _Numerodni_garante;

        public string Numerodni_garante
        {
            get { return _Numerodni_garante; }
            set { _Numerodni_garante = value; }
        }
        private int _P_n_cor;

        public int P_n_cor
        {
            get { return _P_n_cor; }
            set { _P_n_cor = value; }
        }
        private DateTime _Fecha_ingreso;

        public DateTime Fecha_ingreso
        {
            get { return _Fecha_ingreso; }
            set { _Fecha_ingreso = value; }
        }
        private DateTime _Ult_estado;

        public DateTime Ult_estado
        {
            get { return _Ult_estado; }
            set { _Ult_estado = value; }
        }
        private string _Intcap;

        public string Intcap
        {
            get { return _Intcap; }
            set { _Intcap = value; }
        }
        private string _Estado_carpeta;

        public string Estado_carpeta
        {
            get { return _Estado_carpeta; }
            set { _Estado_carpeta = value; }
        }
        private string _Nivel_deuda;

        public string Nivel_deuda
        {
            get { return _Nivel_deuda; }
            set { _Nivel_deuda = value; }
        }
        private string _Cuotas;

        public string Cuotas
        {
            get { return _Cuotas; }
            set { _Cuotas = value; }
        }
        private string _Deuda;

        public string Deuda
        {
            get { return _Deuda; }
            set { _Deuda = value; }
        }
        private string _Estado_comentario;

        public string Estado_comentario
        {
            get { return _Estado_comentario; }
            set { _Estado_comentario = value; }
        }
        private string _Domicilio_ap;

        public string Domicilio_ap
        {
            get { return _Domicilio_ap; }
            set { _Domicilio_ap = value; }
        }
        private string _Localidad_ap;

        public string Localidad_ap
        {
            get { return _Localidad_ap; }
            set { _Localidad_ap = value; }
        }
        private int _Cp_ap;

        public int Cp_ap
        {
            get { return _Cp_ap; }
            set { _Cp_ap = value; }
        }
        private int _Idprovincia_ap;

        public int Idprovincia_ap
        {
            get { return _Idprovincia_ap; }
            set { _Idprovincia_ap = value; }
        }
        private string _Email;

        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }
        private int _Nivel;

        public int Nivel
        {
            get { return _Nivel; }
            set { _Nivel = value; }
        }
        private string _Cuitdni;

        public string CuitDni
        {
            get { return _Cuitdni; }
            set { _Cuitdni = value; }
        }
        private string _Condiva;

        public string CondIva
        {
            get { return _Condiva; }
            set { _Condiva = value; }
        }
        private string _N_Garante;

        public string N_garante
        {
            get { return _N_Garante; }
            set { _N_Garante = value; }
        }
        private string _Piso_Garante;

        public string Piso_garante
        {
            get { return _Piso_Garante; }
            set { _Piso_Garante = value; }
        }
        private string _Dpto_Garante;

        public string Dpto_garante
        {
            get { return _Dpto_Garante; }
            set { _Dpto_Garante = value; }
        }
        private string _Email_Garante;

        public string Email_garante
        {
            get { return _Email_Garante; }
            set { _Email_Garante = value; }
        }
        private string _TextoBuscar;

        public string TextoBuscar
        {
            get { return _TextoBuscar; }
            set { _TextoBuscar = value; }
        }
        private int _ICarpeta;

        public int ICarpeta
        {
            get { return _ICarpeta; }
            set { _ICarpeta = value; }
        }


        //public int Id { get => _Id; set => _Id = value; }
        //public int Idcocesionario { get => _Idcocesionario; set => _Idcocesionario = value; }
        //public int IddocumentoG { get => _IddocumentoG; set => _IddocumentoG = value; }
        //public int IddocumentoS { get => _IddocumentoS; set => _IddocumentoS = value; }
        //public int IdprovinciaG { get => _IdprovinciaG; set => _IdprovinciaG = value; }
        //public int IdprovinciaS { get => _IdprovinciaS; set => _IdprovinciaS = value; }
        //public int IDestadocarpetas { get => _Idestadocarpetas; set => _Idestadocarpetas = value; }
        //public int Idletracarpetas { get => _Idletracarpetas; set => _Idletracarpetas = value; }
        //public int Numero_letra { get => _Numero_letra; set => _Numero_letra = value; }
        //public string Numero_contrato { get => _Numero_contrato; set => _Numero_contrato = value; }
        //public int Existe { get => _Existe; set => _Existe = value; }
        //public string Numero_estudio { get => _Numero_estudio; set => _Numero_estudio = value; }
        //public DateTime Periodo { get => _Periodo; set => _Periodo = value; }
        //public string Apellidoynombre_propietario { get => _Apellidoynombre_propietario; set => _Apellidoynombre_propietario = value; }
        //public string Actual_propietario { get => _Actual_propietario; set => _Actual_propietario = value; }
        //public string Domicilio_propietario { get => _Domicilio_propietario; set => _Domicilio_propietario = value; }
        //public string Localidad_propietario { get => _Localidad_propietario; set => _Localidad_propietario = value; }
        //public int Cp_propietario { get => _Cp_propietario; set => _Cp_propietario = value; }
        //public string Telefono_propietario { get => _Telefono_propietario; set => _Telefono_propietario = value; }
        //public string Numerodni_propietario { get => _Numerodni_propietario; set => _Numerodni_propietario = value; }
        //public string Apellidoynombre_garante { get => _Apellidoynombre_garante; set => _Apellidoynombre_garante = value; }
        //public string Domicilio_garante { get => _Domicilio_garante; set => _Domicilio_garante = value; }
        //public string Localidad_garante { get => _Localidad_garante; set => _Localidad_garante = value; }
        //public int Cp_garante { get => _Cp_garante; set => _Cp_garante = value; }
        //public string Telefono_garante { get => _Telefono_garante; set => _Telefono_garante = value; }
        //public string Numerodni_garante { get => _Numerodni_garante; set => _Numerodni_garante = value; }
        //public int P_n_cor { get => _P_n_cor; set => _P_n_cor = value; }
        //public DateTime Fecha_ingreso { get => _Fecha_ingreso; set => _Fecha_ingreso = value; }
        //public DateTime Ult_estado { get => _Ult_estado; set => _Ult_estado = value; }
        //public string Intcap { get => _Intcap; set => _Intcap = value; }
        //public string Estado_carpeta { get => _Estado_carpeta; set => _Estado_carpeta = value; }
        //public string Nivel_deuda { get => _Nivel_deuda; set => _Nivel_deuda = value; }
        //public string Cuotas { get => _Cuotas; set => _Cuotas = value; }
        //public string Deuda { get => _Deuda; set => _Deuda = value; }
        //public string Estado_comentario { get => _Estado_comentario; set => _Estado_comentario = value; }
        //public string Domicilio_ap { get => _Domicilio_ap; set => _Domicilio_ap = value; }
        //public string Localidad_ap { get => _Localidad_ap; set => _Localidad_ap = value; }
        //public int Cp_ap { get => _Cp_ap; set => _Cp_ap = value; }
        //public int Idprovincia_ap { get => _Idprovincia_ap; set => _Idprovincia_ap = value; }
        //public string Email { get => _Email; set => _Email = value; }
        //public int Nivel { get => _Nivel; set => _Nivel = value; }
        //public string CuitDni { get => _Cuitdni; set => _Cuitdni = value; }
        //public string CondIva { get => _Condiva; set => _Condiva = value; }
        //public string N_garante { get => _N_Garante; set => _N_Garante = value; }
        //public string Piso_garante { get => _Piso_Garante; set => _Piso_Garante = value; }
        //public string Dpto_garante { get => _Dpto_Garante; set => _Dpto_Garante = value; }
        //public string Email_garante { get => _Email_Garante; set => _Email_Garante = value; }
        //public string TextoBuscar { get => _TextoBuscar; set => _TextoBuscar = value; }
        //public int ICarpeta { get => _ICarpeta; set => _ICarpeta = value; }

        public Carpetas()
        {

        }

        public Carpetas(int idcocesionario, int iddocumentoG, int iddocumentoS, int idprovinciaG, int idprovinciaS, int Idestadocarpetas, int idletracarpetas, int numero_letra, string numero_contrato, int existe, string numero_estudio, DateTime periodo, string apellidoynombre_propietario, string actual_propietario,
            string domicilio_propietario, string localidad_propietario, int cp_propietario, string telefono_propietario, string numerodni_propietario, string apellidoynombre_garante, string domicilio_garante, string localidad_garante, int cp_garante, string telefono_garante, string numerodni_garante, int p_n_cor,
            DateTime fecha_ingreso, DateTime ult_estado, string intcap, string estado_carpeta, string nivel_deuda, string cuotas, string deuda, string estado_comentario, string domicilio_ap, string localidad_ap, int cp_ap, int idprovincia_ap, string email, int nivel, string Cuitdni, string Condiva, string N_Garante,
            string Piso_Garante, string Dpto_Garante, string Email_Garante, string textobuscar, int iCarpeta)
        {
            this.Idcocesionario = idcocesionario;
            this.IddocumentoG = iddocumentoG;
            this.IddocumentoS = iddocumentoS;
            this.IdprovinciaG = idprovinciaG;
            this.IdprovinciaS = idprovinciaS;
            this.IDestadocarpetas = Idestadocarpetas;
            this.Idletracarpetas = idletracarpetas;
            this.Numero_letra = numero_letra;
            this.Numero_contrato = numero_contrato;
            this.Existe = existe;
            this.Numero_estudio = numero_estudio;
            this.Periodo = periodo;
            this.Apellidoynombre_propietario = apellidoynombre_propietario;
            this.Actual_propietario = actual_propietario;
            this.Domicilio_propietario = domicilio_propietario;
            this.Localidad_propietario = localidad_propietario;
            this.Cp_propietario = cp_propietario;
            this.Telefono_propietario = telefono_propietario;
            this.Numerodni_propietario = numerodni_propietario;
            this.Apellidoynombre_garante = apellidoynombre_garante;
            this.Domicilio_garante = domicilio_garante;
            this.Localidad_garante = localidad_garante;
            this.Cp_garante = cp_garante;
            this.Telefono_garante = telefono_garante;
            this.Numerodni_garante = numerodni_garante;
            this.P_n_cor = p_n_cor;
            this.Fecha_ingreso = fecha_ingreso;
            this.Ult_estado = ult_estado;
            this.Intcap = intcap;
            this.Estado_carpeta = estado_carpeta;
            this.Nivel_deuda = nivel_deuda;
            this.Cuotas = cuotas;
            this.Deuda = deuda;
            this.Estado_comentario = estado_comentario;
            this.Domicilio_ap = domicilio_ap;
            this.Localidad_ap = localidad_ap;
            this.Cp_ap = cp_ap;
            this.Idprovincia_ap = idprovincia_ap;
            this.Email = email;
            this.Nivel = nivel;
            this.CuitDni = Cuitdni;
            this.CondIva = Condiva;
            this.N_garante = N_Garante;
            this.Piso_garante = Piso_Garante;
            this.Dpto_garante = Dpto_Garante;
            this.Email_garante = Email_Garante;
            this.TextoBuscar = textobuscar;
            this.ICarpeta = iCarpeta;
        }

        //Metodo Insertar
        public string Insertar(Carpetas dCarpetas)
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
                SqlCmd.CommandText = "sp_carpetas";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Aqui Parametros
                //SqlCmd.Parameters.AddWithValue("@_Id", 0);
                SqlCmd.Parameters.AddWithValue("@_Idcocesionario", dCarpetas.Idcocesionario);
                SqlCmd.Parameters.AddWithValue("@_iddocumentoG", dCarpetas.IddocumentoG);
                SqlCmd.Parameters.AddWithValue("@_iddocumentoS", dCarpetas.IddocumentoS);
                SqlCmd.Parameters.AddWithValue("@_idprovinciaG", dCarpetas.IdprovinciaG);
                SqlCmd.Parameters.AddWithValue("@_idprovinciaS", dCarpetas.IdprovinciaS);
                SqlCmd.Parameters.AddWithValue("@_IDestadocarpetas", dCarpetas.IDestadocarpetas);
                SqlCmd.Parameters.AddWithValue("@_idletracarpetas", dCarpetas.Idletracarpetas);
                SqlCmd.Parameters.AddWithValue("@_numero_letra", dCarpetas.Numero_letra);
                SqlCmd.Parameters.AddWithValue("@_numero_contrato", dCarpetas.Numero_contrato);
                SqlCmd.Parameters.AddWithValue("@_existe", dCarpetas.Existe);
                SqlCmd.Parameters.AddWithValue("@_numero_estudio", dCarpetas.Numero_estudio);
                SqlCmd.Parameters.AddWithValue("@_periodo", dCarpetas.Periodo);
                SqlCmd.Parameters.AddWithValue("@_apellidoynombre_propietario", dCarpetas.Apellidoynombre_propietario);
                SqlCmd.Parameters.AddWithValue("@_actual_propietario", dCarpetas.Actual_propietario);
                SqlCmd.Parameters.AddWithValue("@_domicilio_propietario", dCarpetas.Domicilio_propietario);
                SqlCmd.Parameters.AddWithValue("@_localidad_propietario", dCarpetas.Localidad_propietario);
                SqlCmd.Parameters.AddWithValue("@_cp_propietario", dCarpetas.Cp_propietario);
                SqlCmd.Parameters.AddWithValue("@_telefono_propietario", dCarpetas.Telefono_propietario);
                SqlCmd.Parameters.AddWithValue("@_numerodni_propietario", dCarpetas.Numerodni_propietario);
                SqlCmd.Parameters.AddWithValue("@_apellidoynombre_garante", dCarpetas.Apellidoynombre_garante);
                SqlCmd.Parameters.AddWithValue("@_domicilio_garante", dCarpetas.Domicilio_garante);
                SqlCmd.Parameters.AddWithValue("@_localidad_garante", dCarpetas.Localidad_garante);
                SqlCmd.Parameters.AddWithValue("@_cp_garante", dCarpetas.Cp_garante);
                SqlCmd.Parameters.AddWithValue("@_telefono_garante", dCarpetas.Telefono_garante);
                SqlCmd.Parameters.AddWithValue("@_numerodni_garante", dCarpetas.Numerodni_garante);
                SqlCmd.Parameters.AddWithValue("@_p_n_cor", dCarpetas.P_n_cor);
                SqlCmd.Parameters.AddWithValue("@_fecha_ingreso", dCarpetas.Fecha_ingreso);
                SqlCmd.Parameters.AddWithValue("@_ult_estado", dCarpetas.Ult_estado);
                SqlCmd.Parameters.AddWithValue("@_intcap", dCarpetas.Intcap);
                SqlCmd.Parameters.AddWithValue("@_estado_carpeta", dCarpetas.Estado_carpeta);
                SqlCmd.Parameters.AddWithValue("@_nivel_deuda", dCarpetas.Nivel_deuda);
                SqlCmd.Parameters.AddWithValue("@_cuotas", dCarpetas.Cuotas);
                SqlCmd.Parameters.AddWithValue("@_deuda", dCarpetas.Deuda);
                SqlCmd.Parameters.AddWithValue("@_estado_comentario", dCarpetas.Estado_comentario);
                SqlCmd.Parameters.AddWithValue("@_domicilio_ap", dCarpetas.Domicilio_ap);
                SqlCmd.Parameters.AddWithValue("@_localidad_ap", dCarpetas.Localidad_ap);
                SqlCmd.Parameters.AddWithValue("@_cp_ap", dCarpetas.Cp_ap);
                SqlCmd.Parameters.AddWithValue("@_idprovincia_ap", dCarpetas.Idprovincia_ap);
                SqlCmd.Parameters.AddWithValue("@_email", dCarpetas.Email);
                SqlCmd.Parameters.AddWithValue("@_nivel", dCarpetas.Nivel);
                SqlCmd.Parameters.AddWithValue("@_Cuitdni", dCarpetas.CuitDni);
                SqlCmd.Parameters.AddWithValue("@_Condiva", dCarpetas.CondIva);
                SqlCmd.Parameters.AddWithValue("@_N_Garante", dCarpetas.N_garante);
                SqlCmd.Parameters.AddWithValue("@_Piso_Garante", dCarpetas.Piso_garante);
                SqlCmd.Parameters.AddWithValue("@_Dpto_Garante", dCarpetas.Dpto_garante);
                SqlCmd.Parameters.AddWithValue("@_Email_Garante", dCarpetas.Email_garante);
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
        public string Editar(Carpetas dCarpetas)
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
                SqlCmd.CommandText = "sp_Actualizar_Carpetas";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Aqui Parametros
                SqlCmd.Parameters.AddWithValue("@p_idcocesionario", dCarpetas.Idcocesionario);
                SqlCmd.Parameters.AddWithValue("@p_iddocumentoG", dCarpetas.IddocumentoG);
                SqlCmd.Parameters.AddWithValue("@p_iddocumentoS", dCarpetas.IddocumentoS);
                SqlCmd.Parameters.AddWithValue("@p_idprovinciaG", dCarpetas.IdprovinciaG);
                SqlCmd.Parameters.AddWithValue("@p_idprovinciaS", dCarpetas.IdprovinciaS);
                SqlCmd.Parameters.AddWithValue("@p_IDestadocarpetas", dCarpetas.IDestadocarpetas);
                SqlCmd.Parameters.AddWithValue("@p_idletracarpetas", dCarpetas.Idletracarpetas);
                SqlCmd.Parameters.AddWithValue("@p_numero_letra", dCarpetas.Numero_letra);
                SqlCmd.Parameters.AddWithValue("@p_numero_contrato", dCarpetas.Numero_contrato);
                SqlCmd.Parameters.AddWithValue("@p_existe", dCarpetas.Existe);
                SqlCmd.Parameters.AddWithValue("@p_numero_estudio", dCarpetas.Numero_estudio);
                SqlCmd.Parameters.AddWithValue("@p_periodo", dCarpetas.Periodo);
                SqlCmd.Parameters.AddWithValue("@p_apellidoynombre_propietario", dCarpetas.Apellidoynombre_propietario);
                SqlCmd.Parameters.AddWithValue("@p_actual_propietario", dCarpetas.Actual_propietario);
                SqlCmd.Parameters.AddWithValue("@p_domicilio_propietario", dCarpetas.Domicilio_propietario);
                SqlCmd.Parameters.AddWithValue("@p_localidad_propietario", dCarpetas.Localidad_propietario);
                SqlCmd.Parameters.AddWithValue("@p_cp_propietario", dCarpetas.Cp_propietario);
                SqlCmd.Parameters.AddWithValue("@p_telefono_propietario", dCarpetas.Telefono_propietario);
                SqlCmd.Parameters.AddWithValue("@p_numerodni_propietario", dCarpetas.Numerodni_propietario);
                SqlCmd.Parameters.AddWithValue("@p_apellidoynombre_garante", dCarpetas.Apellidoynombre_garante);
                SqlCmd.Parameters.AddWithValue("@p_domicilio_garante", dCarpetas.Domicilio_garante);
                SqlCmd.Parameters.AddWithValue("@p_localidad_garante", dCarpetas.Localidad_garante);
                SqlCmd.Parameters.AddWithValue("@p_cp_garante", dCarpetas.Cp_garante);
                SqlCmd.Parameters.AddWithValue("@p_telefono_garante", dCarpetas.Telefono_garante);
                SqlCmd.Parameters.AddWithValue("@p_numerodni_garante", dCarpetas.Numerodni_garante);
                SqlCmd.Parameters.AddWithValue("@p_p_n_cor", dCarpetas.P_n_cor);
                SqlCmd.Parameters.AddWithValue("@p_fecha_ingreso", dCarpetas.Fecha_ingreso);
                SqlCmd.Parameters.AddWithValue("@p_ult_estado", dCarpetas.Ult_estado);
                SqlCmd.Parameters.AddWithValue("@p_intcap", dCarpetas.Intcap);
                SqlCmd.Parameters.AddWithValue("@p_estado_carpeta", dCarpetas.Estado_carpeta);
                SqlCmd.Parameters.AddWithValue("@p_nivel_deuda", dCarpetas.Nivel_deuda);
                SqlCmd.Parameters.AddWithValue("@p_cuotas", dCarpetas.Cuotas);
                SqlCmd.Parameters.AddWithValue("@p_deuda", dCarpetas.Deuda);
                SqlCmd.Parameters.AddWithValue("@p_estado_comentario", dCarpetas.Estado_comentario);
                SqlCmd.Parameters.AddWithValue("@p_domicilio_ap", dCarpetas.Domicilio_ap);
                SqlCmd.Parameters.AddWithValue("@p_localidad_ap", dCarpetas.Localidad_ap);
                SqlCmd.Parameters.AddWithValue("@p_cp_ap", dCarpetas.Cp_ap);
                SqlCmd.Parameters.AddWithValue("@p_idprovincia_ap", dCarpetas.Idprovincia_ap);
                SqlCmd.Parameters.AddWithValue("@p_email", dCarpetas.Email);
                SqlCmd.Parameters.AddWithValue("@p_nivel", dCarpetas.Nivel);
                SqlCmd.Parameters.AddWithValue("@p_Cuitdni", dCarpetas.CuitDni);
                SqlCmd.Parameters.AddWithValue("@p_Condiva", dCarpetas.CondIva);
                SqlCmd.Parameters.AddWithValue("@p_N_Garante", dCarpetas.N_garante);
                SqlCmd.Parameters.AddWithValue("@p_Piso_Garante", dCarpetas.Piso_garante);
                SqlCmd.Parameters.AddWithValue("@p_Dpto_Garante", dCarpetas.Dpto_garante);
                SqlCmd.Parameters.AddWithValue("@p_Email_Garante", dCarpetas.Email_garante);
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
        public string Eliminar(Carpetas dCarpetas)
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
                SqlCmd.CommandText = "sp_carpetas";
                SqlCmd.CommandType = CommandType.StoredProcedure;
                //Aqui Parametros
                SqlCmd.Parameters.AddWithValue("@accion", "eliminar");
                SqlCmd.Parameters.AddWithValue("@_id", dCarpetas.Id);
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
        public DataTable BuscarContrato(Carpetas dCarpetas)
        {
            DataTable DtResultado = new DataTable("Carpetas");
            MySqlConnection Conexion = Clases.Database.obtenerConexion(true);
            try
            {
                //Codigo
                if (Conexion.State != ConnectionState.Open)
                    Conexion.Open();
                //Establecer Comando
                MySqlCommand SqlCmd = new MySqlCommand();
                SqlCmd.Connection = Conexion;
                SqlCmd.CommandText = "sp_Buscar_Carpeta";
                SqlCmd.CommandType = CommandType.StoredProcedure;
                //Aqui Parametros
                SqlCmd.Parameters.AddWithValue("@p_numero_letra", dCarpetas.ICarpeta);
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
