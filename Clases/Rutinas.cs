using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SanEmeterio.Entidades;
using SanEmeterio.Properties;
using System.Windows.Forms;
using System.Drawing;
using SanEmeterio.Formularios;


namespace SanEmeterio.Clases
{
    public class Rutinas
    {
        public static int IdUsuario = 0;

        List<Clases.BaseColor> _ColorBase = new List<Clases.BaseColor>();

        public static List<Agenda> ObtenerAgenda(string sContrato, string sCarpeta)
        {
            List<Agenda> _Agenda = new List<Agenda>();
            string sWhere = "";
            sWhere = " contrato=@contrato";
            MySqlConnection ConAgenda = Database.obtenerConexion(true);
            if (ConAgenda.State != ConnectionState.Open)
                ConAgenda.Open();
            MySqlCommand _comAgenda = new MySqlCommand("SELECT Ag.id, Ag.contrato, Ag.Fecha, Ag.Hora, Ag.Tarea, Ag.Estado, Ag.Operador, Ag.Carpeta, Ag.Creado FROM agenda AS Ag where " + sWhere, ConAgenda);
            _comAgenda.Parameters.AddWithValue("@contrato", sContrato);
            //_comAgenda.Parameters.AddWithValue("@Carpeta", sCarpeta);
            MySqlDataReader _ReadAge = _comAgenda.ExecuteReader();
            while (_ReadAge.Read())
            {
                Agenda pAgenda = new Agenda();
                pAgenda.Id = _ReadAge.GetInt32("id");
                pAgenda.Contrato = _ReadAge.GetString("contrato");
                pAgenda.Fecha = _ReadAge.GetDateTime("Fecha");
                pAgenda.Hora = _ReadAge.GetString("Hora");
                pAgenda.Tarea = _ReadAge.GetString("Tarea");
                pAgenda.Estado = _ReadAge.GetString("Estado");
                pAgenda.Operador = _ReadAge.GetString("Operador");
                pAgenda.Carpeta = _ReadAge.GetString("Carpeta");
                pAgenda.Creado = _ReadAge.GetDateTime("Creado");
                _Agenda.Add(pAgenda);
            }
            ConAgenda.Close();
            return _Agenda;
        }
        public static DataSet AgendaDataSet(DateTime fecha, string operador)
        {
            string sql = "";
            if (operador == "")
            {
                sql = @"SELECT A.Creado, A.Carpeta, T.apellidoynombre_propietario, A.Hora, A.Tarea, A.Operador, A.contrato
                        FROM tratamientocarpetas AS T INNER JOIN agenda AS A ON T.numero_letra = A.Carpeta
                        WHERE A.Creado = @fecha";
            }
            else
            {
                sql = @"SELECT A.Creado, A.Carpeta, T.apellidoynombre_propietario, A.Hora, A.Tarea, A.Operador, A.contrato
                        FROM tratamientocarpetas AS T INNER JOIN agenda AS A ON T.numero_letra = A.Carpeta
                        WHERE A.Creado = @fecha and A.Operador=@operador";
            }
            MySqlConnection conn = Clases.Database.obtenerConexion(true);
            if (conn.State != ConnectionState.Open)
                conn.Open();

            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@fecha", fecha);
            if (operador != "")
            {
                cmd.Parameters.AddWithValue("@operador", operador);
            }

            MySqlDataAdapter da = new MySqlDataAdapter();
            da.SelectCommand = cmd;

            //conn.Open();

            DataSet ds = new DataSet();
            da.Fill(ds, "Agenda");

            conn.Close();
            return ds;
        }
        public static List<parametrocuotas> ObtenetParametros()
        {
            List<parametrocuotas> _Parametros = new List<parametrocuotas>();
            MySqlConnection ConParam = Database.obtenerConexion(true);
            if (ConParam.State != ConnectionState.Open)
                ConParam.Open();
            MySqlCommand _comParam = new MySqlCommand("SELECT Pa.PC_Intmensual, Pa.PC_Gastosadmin, Pa.PC_Honarios, Pa.PC_Gtosbanco, Pa.PC_IVAInsc, Pa.PC_IVAninsc, Pa.version FROM parametrocuotas AS Pa", ConParam);
            MySqlDataReader _ReadPar = _comParam.ExecuteReader();
            while (_ReadPar.Read())
            {
                parametrocuotas pParam = new parametrocuotas();
                pParam.PC_Intmensual = _ReadPar.GetDouble("PC_Intmensual");
                pParam.PC_Gastosadmin = _ReadPar.GetDouble("PC_Gastosadmin");
                pParam.PC_Honarios = _ReadPar.GetDouble("PC_Honarios");
                pParam.PC_Gtosbanco = _ReadPar.GetDouble("PC_Gtosbanco");
                pParam.PC_IVAInsc = _ReadPar.GetDouble("PC_IVAInsc");
                pParam.PC_IVAninsc = _ReadPar.GetDouble("PC_IVAninsc");
                if (!_ReadPar.IsDBNull(_ReadPar.GetOrdinal("version")))
                {
                    pParam.version = _ReadPar.GetString("version");
                }
                else
                {
                    pParam.version = "";
                }
                _Parametros.Add(pParam);
            }
            ConParam.Close();
            return _Parametros;
        }
        public static List<numerorecibos> ObtenerNumeros()
        {
            List<numerorecibos> _ListaNumeros = new List<numerorecibos>();
            MySqlConnection Conexion = Clases.Database.obtenerConexion(true );
            if (Conexion.State != System.Data.ConnectionState.Open)
                Conexion.Open();
            MySqlCommand _Comando = new MySqlCommand("SELECT Nr.idrecibos, Nr.nombre_recibos, Nr.numero_recibos, Nr.Copias FROM numerorecibos AS Nr", Conexion);
            MySqlDataReader _reader = _Comando.ExecuteReader();
            while (_reader.Read())
            {
                numerorecibos pNrosComp = new numerorecibos();
                pNrosComp.Idrecibos = _reader.GetInt32("Idrecibos");
                pNrosComp.Nombre_recibos = _reader.GetString("Nombre_recibos");
                pNrosComp.Numero_recibos = _reader.GetInt32("Numero_recibos");
                pNrosComp.Copias = _reader.GetInt32("Copias");
                _ListaNumeros.Add(pNrosComp);
            }
            Conexion.Close();
            return _ListaNumeros;
        }

        public static List<operadoresdelsistema> ObtenerUsuario()
        {
            List<operadoresdelsistema> _listaProv = new List<operadoresdelsistema>();
            MySqlConnection Conexion = Clases.Database.obtenerConexion();
            if (Conexion.State != System.Data.ConnectionState.Open)
                Conexion.Open();
            MySqlCommand _Comando = new MySqlCommand("SELECT o.idoperadores, o.Password, o.nombre_operadores, o.Nivel FROM operadoresdelsistema AS o where o.nombre_operadores<>''", Conexion);
            MySqlDataReader _reader = _Comando.ExecuteReader();
            while (_reader.Read())
            {
                operadoresdelsistema pProveedor = new operadoresdelsistema();
                pProveedor.idoperadores = _reader.GetInt32("idoperadores");
                pProveedor.Password = _reader.GetString("Password");
                pProveedor.nombre_operadores = _reader.GetString("nombre_operadores");
                if (!_reader.IsDBNull(_reader.GetOrdinal("Nivel")))
                {
                    pProveedor.Nivel = _reader.GetInt32("Nivel");
                }
                else
                {
                    pProveedor.Nivel = 0;
                }
                _listaProv.Add(pProveedor);
            }
            Conexion.Close();
            return _listaProv;
        }

        public static string ConCeros(string sValor, int CantCeros)
        {
            string formato = "{0:000}";
            if (CantCeros == 3)
            {
                formato = "{0:000}";
            }
            else if (CantCeros == 4)
            {
                formato = "{0:0000}";
            }
            else if (CantCeros == 5)
            {
                formato = "{0:00000}";
            }
            else if (CantCeros == 6)
            {
                formato = "{0:000000}";
            }
            else if (CantCeros == 7)
            {
                formato = "{0:0000000}";
            }
            int value = Convert.ToInt32(sValor);
            string a = string.Format(formato, value); // Too complex
            //txtPV.Text = a.ToString();
            //sValor = Space(CantCeros - Len(sValor)) + sValor;
            //sValor = Replace(sValor, " ", "0");
            return string.Format(formato, value);
        }

        public static Boolean EncuentraUsuario(string User, string Pass)
        {
            bool Encontro = false;
            MySqlConnection Conexion = Clases.Database.obtenerConexion();
            if (Conexion.State != ConnectionState.Open)
            {
                Conexion.Open();
            }
            MySqlCommand cmd = new MySqlCommand("Select * from operadoresdelsistema where nombre_operadores=@User and Password=@Pass", Conexion);
            cmd.Parameters.AddWithValue("@User", User);
            cmd.Parameters.AddWithValue("@Pass", Pass);
            MySqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                operadoresdelsistema Os = new operadoresdelsistema();
                Os.idoperadores = rd.GetInt32("idoperadores");
                Os.Password = rd.GetString("Password");
                Os.nombre_operadores = rd.GetString("nombre_operadores");
                if (!rd.IsDBNull(rd.GetOrdinal("Nivel")))
                {
                    Os.Nivel = rd.GetInt32("Nivel");
                }
                else
                {
                    Os.Nivel = 0;
                }
                IdUsuario = Os.idoperadores;
                Encontro = true;
            }
            Conexion.Close();
            return Encontro;
        }
        public void BuscarColor()
        {
            if (VariablesGlobales.NombreBase == "rombo")
            {
                VariablesGlobales.ColorBoton = Settings.Default.ColorBotonRombo;
                VariablesGlobales.ColorFondo = Settings.Default.ColorFondoRombo;
                VariablesGlobales.ColorFondoTexto = Settings.Default.ColorFondoTextoRombo;
                VariablesGlobales.ColorForm = Settings.Default.ColorFondoRombo;
                VariablesGlobales.ColorLetras = Settings.Default.ColorEtiquetaRombo;
                VariablesGlobales.ColorTexto = Settings.Default.ColorTextoRombo;
            }
            else if (VariablesGlobales.NombreBase == "chevrolet")
            {
                VariablesGlobales.ColorBoton = Settings.Default.ColorBotonChev;
                VariablesGlobales.ColorFondo = Settings.Default.ColorFondoChev;
                VariablesGlobales.ColorFondoTexto = Settings.Default.colorFondoTextoChev;
                VariablesGlobales.ColorForm = Settings.Default.ColorFondoChev;
                VariablesGlobales.ColorLetras = Settings.Default.ColorEtiquetaChev;
                VariablesGlobales.ColorTexto = Settings.Default.ColorTextoChev;
            }
        }
        public static string RecorreControls(Form MyForm)
        {
            int TFuente = VariablesGlobales.TamFuente;
            foreach (Control cPadre in MyForm.Controls)
            {
                MyForm.BackColor = VariablesGlobales.ColorFondo;
                new Switch(cPadre)
                .Case<DataGridView>(action =>
                {
                    cPadre.BackColor = Color.DimGray;
                    cPadre.ForeColor = Color.WhiteSmoke;
                    // Instrucciones en caso se trate de un TextBox...;
                })
                .Case<Button>(action =>
                {
                    cPadre.BackColor = VariablesGlobales.ColorBoton;
                    // Instrucciones en caso se trate de un TextBox...;
                })
                .Case<Label>(action =>
                {
                    if ((string)cPadre.Tag != "Color")
                    {
                        cPadre.ForeColor = VariablesGlobales.ColorLetras;
                        cPadre.BackColor = System.Drawing.Color.Transparent;
                        cPadre.Font = new Font("Arial", TFuente, FontStyle.Regular);
                    }
                    // Instrucciones en caso se trate de un CheckBox...;
                })
                .Case<TextBox>(action =>
                {
                    if ((string)cPadre.Tag != "Color")
                    {
                        cPadre.BackColor = VariablesGlobales.ColorFondoTexto;
                        cPadre.ForeColor = VariablesGlobales.ColorTexto;
                        cPadre.Font = new Font("Arial", TFuente, FontStyle.Regular);
                    }
                    // Instrucciones en caso se trate de un CheckBox...;
                })
                .Case<RadioButton>(action =>
                {
                    if ((string)cPadre.Tag != "Color")
                    {
                        cPadre.BackColor = VariablesGlobales.ColorFondoTexto;
                        cPadre.ForeColor = VariablesGlobales.ColorTexto;
                        cPadre.Font = new Font("Arial", TFuente, FontStyle.Regular);
                    }
                    // Instrucciones en caso se trate de un CheckBox...;
                })
                .Case<ComboBox>(action =>
                {
                    cPadre.BackColor = VariablesGlobales.ColorFondoTexto;
                    cPadre.ForeColor = VariablesGlobales.ColorTexto;
                    // Instrucciones en caso se trate de un CheckBox...;
                });

                foreach (Control cHijo in cPadre.Controls)
                {
                    new Switch(cHijo)
                     .Case<Button>(action =>
                     {
                         cHijo.BackColor = VariablesGlobales.ColorBoton;
                         // Instrucciones en caso se trate de un TextBox...;
                     })
                     .Case<Label>(action =>
                     {
                         if ((string)cHijo.Tag != "Color")
                         {
                             cHijo.ForeColor = VariablesGlobales.ColorLetras;
                             cHijo.BackColor = System.Drawing.Color.Transparent;
                             cHijo.Font = new Font("Arial", TFuente, FontStyle.Regular);
                         }
                         // Instrucciones en caso se trate de un CheckBox...;
                     })
                    .Case<TextBox>(action =>
                    {
                        if ((string)cHijo.Tag != "Color")
                        {
                            cHijo.BackColor = VariablesGlobales.ColorFondoTexto;
                            cHijo.ForeColor = VariablesGlobales.ColorTexto;
                            cHijo.Font = new Font("Arial", TFuente, FontStyle.Regular);
                        }
                        // Instrucciones en caso se trate de un CheckBox...;
                    })
                    .Case<RadioButton>(action =>
                    {
                        if ((string)cHijo.Tag != "Color")
                        {
                            cHijo.BackColor = VariablesGlobales.ColorFondoTexto;
                            cHijo.ForeColor = VariablesGlobales.ColorTexto;
                            cHijo.Font = new Font("Arial", TFuente, FontStyle.Regular);
                        }
                        // Instrucciones en caso se trate de un CheckBox...;
                    })
                    .Case<ComboBox>(action =>
                    {
                        cHijo.BackColor = VariablesGlobales.ColorFondoTexto;
                        cHijo.ForeColor = VariablesGlobales.ColorTexto;
                        // Instrucciones en caso se trate de un CheckBox...;
                    })
                    .Case<Panel>(action =>
                    {
                        if ((string)cHijo.Tag == "estono")
                        {
                            cHijo.BackColor = System.Drawing.Color.WhiteSmoke;
                        }
                        else if ((string)cHijo.Tag == "Color")
                        {
                        }
                        else
                        {
                            cHijo.BackColor = VariablesGlobales.ColorForm;
                        }
                        // Instrucciones en caso se trate de un CheckBox...;
                    });
                    foreach (Control subHijo in cHijo.Controls)
                    {
                        new Switch(subHijo)
                         .Case<Button>(action =>
                         {
                             subHijo.BackColor = VariablesGlobales.ColorBoton;
                             // Instrucciones en caso se trate de un TextBox...;
                         })
                         .Case<Label>(action =>
                         {
                             if ((string)subHijo.Tag != "Color")
                             {
                                 subHijo.ForeColor = VariablesGlobales.ColorLetras;
                                 subHijo.BackColor = System.Drawing.Color.Transparent;
                                 subHijo.Font = new Font("Arial", TFuente, FontStyle.Regular);
                             }
                             // Instrucciones en caso se trate de un CheckBox...;
                         })
                        .Case<TextBox>(action =>
                        {
                            if ((string)subHijo.Tag != "Color")
                            {
                                subHijo.BackColor = VariablesGlobales.ColorFondoTexto;
                                subHijo.ForeColor = VariablesGlobales.ColorTexto;
                                subHijo.Font = new Font("Arial", TFuente, FontStyle.Regular);
                            }
                            // Instrucciones en caso se trate de un CheckBox...;
                        })
                         .Case<RadioButton>(action =>
                         {
                             if ((string)subHijo.Tag != "Color")
                             {
                                 subHijo.BackColor = VariablesGlobales.ColorFondoTexto;
                                 subHijo.ForeColor = VariablesGlobales.ColorTexto;
                                 subHijo.Font = new Font("Arial", TFuente, FontStyle.Regular);
                             }
                             // Instrucciones en caso se trate de un CheckBox...;
                         })
                       .Case<ComboBox>(action =>
                       {
                           subHijo.BackColor = VariablesGlobales.ColorFondoTexto;
                           subHijo.ForeColor = VariablesGlobales.ColorTexto;
                           // Instrucciones en caso se trate de un CheckBox...;
                       })
                        .Case<Panel>(action =>
                        {
                            if ((string)subHijo.Tag == "estono")
                            {
                                subHijo.BackColor = System.Drawing.Color.WhiteSmoke;
                            }
                            else if ((string)subHijo.Tag == "Color")
                            {
                            }
                            else
                            {
                                subHijo.BackColor = VariablesGlobales.ColorForm;
                            }
                            // Instrucciones en caso se trate de un CheckBox...;
                        });
                        foreach (Control subHijo2 in subHijo.Controls)
                        {
                            new Switch(subHijo2)
                             .Case<Button>(action =>
                             {
                                 subHijo2.BackColor = VariablesGlobales.ColorBoton;
                                 // Instrucciones en caso se trate de un TextBox...;
                             })
                             .Case<Label>(action =>
                             {
                                 if ((string)subHijo2.Tag != "Color")
                                 {
                                     subHijo2.ForeColor = VariablesGlobales.ColorLetras;
                                     subHijo2.BackColor = System.Drawing.Color.Transparent;
                                     subHijo2.Font = new Font("Arial", TFuente, FontStyle.Regular);
                                 }
                                 // Instrucciones en caso se trate de un CheckBox...;
                             })
                            .Case<TextBox>(action =>
                            {
                                if ((string)subHijo2.Tag != "Color")
                                {
                                    subHijo2.BackColor = VariablesGlobales.ColorFondoTexto;
                                    subHijo2.ForeColor = VariablesGlobales.ColorTexto;
                                    subHijo2.Font = new Font("Arial", TFuente, FontStyle.Regular);
                                }
                                // Instrucciones en caso se trate de un CheckBox...;
                            })
                            .Case<RadioButton>(action =>
                            {
                                if ((string)subHijo2.Tag != "Color")
                                {
                                    subHijo2.BackColor = VariablesGlobales.ColorFondoTexto;
                                    subHijo2.ForeColor = VariablesGlobales.ColorTexto;
                                    subHijo2.Font = new Font("Arial", TFuente, FontStyle.Regular);
                                }
                                // Instrucciones en caso se trate de un CheckBox...;
                            })
                            .Case<ComboBox>(action =>
                            {
                                subHijo2.BackColor = VariablesGlobales.ColorFondoTexto;
                                subHijo2.ForeColor = VariablesGlobales.ColorTexto;
                                // Instrucciones en caso se trate de un CheckBox...;
                            })
                            .Case<Panel>(action =>
                            {
                                if ((string)subHijo2.Tag == "estono")
                                {
                                    subHijo2.BackColor = System.Drawing.Color.WhiteSmoke;
                                }
                                else if ((string)subHijo2.Tag == "Color")
                                {
                                }
                                else
                                {
                                    subHijo2.BackColor = VariablesGlobales.ColorForm;
                                }
                                // Instrucciones en caso se trate de un CheckBox...;
                            });
                            foreach (Control subHijo3 in subHijo2.Controls)
                            {
                                new Switch(subHijo3)
                                 .Case<Button>(action =>
                                 {
                                     subHijo3.BackColor = VariablesGlobales.ColorBoton;
                                     // Instrucciones en caso se trate de un TextBox...;
                                 })
                                 .Case<Label>(action =>
                                 {
                                     if ((string)subHijo3.Tag != "Color")
                                     {
                                         subHijo3.ForeColor = VariablesGlobales.ColorLetras;
                                         subHijo3.BackColor = System.Drawing.Color.Transparent;
                                         subHijo3.Font = new Font("Arial", TFuente, FontStyle.Regular);
                                     }
                                     // Instrucciones en caso se trate de un CheckBox...;
                                 })
                                .Case<TextBox>(action =>
                                {
                                    if ((string)subHijo3.Tag != "Color")
                                    {
                                        subHijo3.BackColor = VariablesGlobales.ColorFondoTexto;
                                        subHijo3.ForeColor = VariablesGlobales.ColorTexto;
                                        subHijo3.Font = new Font("Arial", TFuente, FontStyle.Regular);
                                    }
                                    // Instrucciones en caso se trate de un CheckBox...;
                                })
                                .Case<RadioButton>(action =>
                                {
                                    if ((string)subHijo3.Tag != "Color")
                                    {
                                        subHijo3.BackColor = VariablesGlobales.ColorFondoTexto;
                                        subHijo3.ForeColor = VariablesGlobales.ColorTexto;
                                        subHijo3.Font = new Font("Arial", TFuente, FontStyle.Regular);
                                    }
                                    // Instrucciones en caso se trate de un CheckBox...;
                                })
                                .Case<ComboBox>(action =>
                                {
                                    subHijo3.BackColor = VariablesGlobales.ColorFondoTexto;
                                    subHijo3.ForeColor = VariablesGlobales.ColorTexto;
                                    // Instrucciones en caso se trate de un CheckBox...;
                                })
                                .Case<Panel>(action =>
                                {
                                    if ((string)subHijo3.Tag == "estono")
                                    {
                                        subHijo3.BackColor = System.Drawing.Color.WhiteSmoke;
                                    }
                                    else if ((string)subHijo3.Tag == "Color")
                                    {
                                    }
                                    else
                                    {
                                        subHijo3.BackColor = VariablesGlobales.ColorForm;
                                    }
                                    // Instrucciones en caso se trate de un CheckBox...;
                                });
                            }

                        }

                    }

                }
            }
            return "";
        }

        public static List<EstadoCarpetas> ObtenerEstadoCarpeta()
        {
            List<EstadoCarpetas> _EstadoC = new List<EstadoCarpetas>();
            MySqlConnection cnxCondIva = Clases.Database.obtenerConexion();
            if (cnxCondIva.State != System.Data.ConnectionState.Open)
                cnxCondIva.Open();
            MySqlCommand _LeerEstado = new MySqlCommand("SELECT ID, Codigo, Denominacion, AI FROM estadocarpetas", cnxCondIva);
            MySqlDataReader _ReadEstadoC = _LeerEstado.ExecuteReader();
            while (_ReadEstadoC.Read())
            {
                EstadoCarpetas pEstado = new EstadoCarpetas();
                pEstado.Codigo = _ReadEstadoC.GetInt32("Codigo");
                pEstado.Denominacion = _ReadEstadoC.GetString("Denominacion");
                _EstadoC.Add(pEstado);
            }
            cnxCondIva.Close();
            return _EstadoC;
        }

        public static string BuscarDocumento(int idDocumento)
        {
            string retorno = "";
            string sWhere = "";
            sWhere = "SELECT iddocumento, tipo_documento, nombre_documento FROM documento where iddocumento = @ID";
            MySqlConnection cnxDocumento = Database.obtenerConexion(true);
            if (cnxDocumento.State != ConnectionState.Open)
                cnxDocumento.Open();
            MySqlCommand _LeerDocu = new MySqlCommand(sWhere, cnxDocumento);
            _LeerDocu.Parameters.AddWithValue("@ID", idDocumento);
            MySqlDataReader _reader = _LeerDocu.ExecuteReader();
            while (_reader.Read())
            {
                Documento sDocu = new Documento();
                sDocu.Iddocumento = _reader.GetInt32("iddocumento");
                sDocu.Tipo_documento = _reader.GetInt32("tipo_documento");
                sDocu.Nombre_documento = _reader.GetString("nombre_documento");
                retorno = sDocu.Nombre_documento;
            }
            cnxDocumento.Close();
            return retorno;
        }

        public static string BuscaEstadoCarpeta(int idEstado, string denominacion)
        {
            string retorno = "";
            string sWhere = "";
            if (idEstado == 0)
            {
                sWhere = "SELECT ID, Codigo, Denominacion, AI FROM estadocarpetas where Denominacion = @denominacion";
            }
            else
            {
                sWhere = "SELECT ID, Codigo, Denominacion, AI FROM estadocarpetas where ID = @ID";
            }
            MySqlConnection cnxEstado = Database.obtenerConexion(true);
            if (cnxEstado.State != ConnectionState.Open)
                cnxEstado.Open();
            MySqlCommand _LeerEstado = new MySqlCommand(sWhere, cnxEstado);
            if (idEstado == 0)
            {
                _LeerEstado.Parameters.AddWithValue("@denominacion", denominacion);
            }
            else
            {
                _LeerEstado.Parameters.AddWithValue("@ID", idEstado);
            }
            MySqlDataReader _reader = _LeerEstado.ExecuteReader();
            while (_reader.Read())
            {
                EstadoCarpetas eCar = new EstadoCarpetas();
                eCar.Id = _reader.GetInt32("ID");
                eCar.Codigo = _reader.GetInt32("Codigo");
                eCar.Denominacion = _reader.GetString("Denominacion");
                eCar.Ai = _reader.GetString("AI");
                if (idEstado == 0)
                {
                    retorno = eCar.Id.ToString();
                }
                else
                {
                    retorno = eCar.Denominacion;
                }
            }
            cnxEstado.Close();
            return retorno;
        }
        public static string BuscaProvincia(int idProv, string LetraProv, string campo)
        {
            string retorno = "";
            string sWhere = "";
            if (idProv != 0)
            {
                sWhere = " idprovincia=@idprovincia";
            }
            else
            {
                sWhere = " letra_provincia=@letra_provincia";
            }
            MySqlConnection cnxProvincia = Database.obtenerConexion(true);
            if (cnxProvincia.State != ConnectionState.Open)
                cnxProvincia.Open();
            MySqlCommand _LeerProvincia = new MySqlCommand("SELECT * FROM Provincias where " + sWhere, cnxProvincia);
            if (idProv != 0)
            {
                _LeerProvincia.Parameters.AddWithValue("@idprovincia", idProv);
            }
            else
            {
                _LeerProvincia.Parameters.AddWithValue("@letra_provincia", LetraProv);
            }
            MySqlDataReader _ReadProvincia = _LeerProvincia.ExecuteReader();
            while (_ReadProvincia.Read())
            {
                Provincias pProvincias = new Provincias();
                pProvincias.Idprovincia = _ReadProvincia.GetInt32("idprovincia");
                pProvincias.Letra_provincia = _ReadProvincia.GetString("letra_provincia");
                pProvincias.Nombre_provincia = _ReadProvincia.GetString("nombre_provincia");
                if (campo == "ID")
                {
                    retorno = pProvincias.Idprovincia.ToString();
                }
                else if (campo == "NOMBRE")
                {
                    retorno = pProvincias.Nombre_provincia;
                }
            }
            cnxProvincia.Close();
            return retorno;
        }

        public static List<Provincias> ObtenerProvincia()
        {
            List<Provincias> _Provincia = new List<Provincias>();
            MySqlConnection cnxProvincia = Clases.Database.obtenerConexion();
            if (cnxProvincia.State != System.Data.ConnectionState.Open)
                cnxProvincia.Open();
            MySqlCommand _LeerProvincia = new MySqlCommand("SELECT * FROM Provincias order by nombre_provincia", cnxProvincia);
            MySqlDataReader _ReadProvincia = _LeerProvincia.ExecuteReader();
            while (_ReadProvincia.Read())
            {
                Provincias pProvincias = new Provincias();
                pProvincias.Idprovincia = _ReadProvincia.GetInt32("idprovincia");
                pProvincias.Letra_provincia = _ReadProvincia.GetString("letra_provincia");
                pProvincias.Nombre_provincia = _ReadProvincia.GetString("nombre_provincia");
                _Provincia.Add(pProvincias);
            }
            cnxProvincia.Close();
            return _Provincia;
        }
        public static string Reemplaza(string Texto)
        {
            string retorno = Texto.Replace("Á", "A").Replace("É", "E").Replace("Í", "I").Trim();
            return retorno;
        }
        public static List<Cargacuota> ObtenerCuotas(int IdCarpeta)
        {
            List<Cargacuota> _Cuotas = new List<Cargacuota>();
            string sWhere = "";
            MySqlConnection cnxCuotas = Clases.Database.obtenerConexion(true);
            if (cnxCuotas.State != ConnectionState.Open)
                cnxCuotas.Open();
            sWhere = " id=@id";
            MySqlCommand _LeerCuotas = new MySqlCommand("SELECT id, cargacuota_fecliquidacion, cargacuota_fecvto, cargacuota_cta, cargacuota_capital, cargacuota_interes, cargacuota_estado, cargacuota_total, numero_contrato, Manual FROM cargacuota where " + sWhere, cnxCuotas);
            _LeerCuotas.Parameters.AddWithValue("@id", IdCarpeta);
            MySqlDataReader _ReadCuotas = _LeerCuotas.ExecuteReader();
            while (_ReadCuotas.Read())
            {
                Cargacuota pCuotas = new Cargacuota();
                pCuotas.Id = _ReadCuotas.GetInt32("id");
                pCuotas.Cargacuota_fecliquidacion = _ReadCuotas.GetDateTime("cargacuota_fecliquidacion");
                pCuotas.Cargacuota_fecvto = _ReadCuotas.GetDateTime("cargacuota_fecvto");
                pCuotas.Cargacuota_cta = _ReadCuotas.GetInt32("cargacuota_cta");
                pCuotas.Cargacuota_capital = _ReadCuotas.GetDouble("cargacuota_capital");
                pCuotas.Cargacuota_interes = _ReadCuotas.GetDouble("cargacuota_interes");
                pCuotas.Cargacuota_estado = _ReadCuotas.GetString("cargacuota_estado");
                pCuotas.Cargacuota_total = _ReadCuotas.GetDouble("cargacuota_total");
                pCuotas.Numero_contrato = _ReadCuotas.GetString("numero_contrato");
                if (!_ReadCuotas.IsDBNull(_ReadCuotas.GetOrdinal("Manual")))
                {
                    pCuotas.Manual = _ReadCuotas.GetString("Manual");
                }
                else
                {
                    pCuotas.Manual = "";
                }
                _Cuotas.Add(pCuotas);
            }
            cnxCuotas.Close();
            return _Cuotas;
        }

        public static List<Comentarios> ObtenerComentarios(string Tipo, string Campo)
        {
            List<Comentarios> _Comentarios = new List<Comentarios>();
            string sWhere = "";
            MySqlConnection cnxComentarios = Clases.Database.obtenerConexion(true);
            if (cnxComentarios.State != System.Data.ConnectionState.Open)
                cnxComentarios.Open();
            if (Tipo == "Carpeta")
            {
                sWhere = " carpeta=@Campo";
            }
            else
            {
                sWhere = " contrato=@Campo";
            }
            MySqlCommand _LeerComentarios = new MySqlCommand("Select * from comentarios where" + sWhere, cnxComentarios);
            _LeerComentarios.Parameters.AddWithValue("@Campo", Campo);
            MySqlDataReader _ReadComentarios = _LeerComentarios.ExecuteReader();
            while (_ReadComentarios.Read())
            {
                Comentarios pComentarios = new Comentarios();
                pComentarios.Comentarios_id = _ReadComentarios.GetInt32("comentarios_Id");
                pComentarios.Comentarios_Fecha = _ReadComentarios.GetDateTime("comentarios_Fecha");
                pComentarios.Comentarios_Comentario = _ReadComentarios.GetString("comentarios_Comentario");
                pComentarios.Comentarios_Operador = _ReadComentarios.GetString("comentarios_Operador");
                pComentarios.Contrato = _ReadComentarios.GetString("contrato");
                pComentarios.Estado = _ReadComentarios.GetString("estado");
                pComentarios.Carpeta = _ReadComentarios.GetString("carpeta");
                _Comentarios.Add(pComentarios);
            }
            cnxComentarios.Close();
            return _Comentarios;
        }

        public static List<Documento> ObtenerDocumento()
        {
            List<Documento> _Documento = new List<Documento>();
            MySqlConnection cnx = Clases.Database.obtenerConexion();
            if (cnx.State != System.Data.ConnectionState.Open)
                cnx.Open();
            MySqlCommand _LeerDocumento = new MySqlCommand("SELECT * FROM Documento", cnx);
            MySqlDataReader _ReadEstadoC = _LeerDocumento.ExecuteReader();
            while (_ReadEstadoC.Read())
            {
                Documento pDocumento = new Documento();
                pDocumento.Iddocumento = _ReadEstadoC.GetInt32("iddocumento");
                pDocumento.Nombre_documento = _ReadEstadoC.GetString("nombre_documento");
                pDocumento.Tipo_documento = _ReadEstadoC.GetInt32("tipo_documento");
                _Documento.Add(pDocumento);
            }
            cnx.Close();
            return _Documento;
        }

        public static List<Carpetas> Buscar_Carpeta(string Campo, double dCarpeta, string sTitular, string sContrato)
        {
            List<Carpetas> _BuscarCarpeta = new List<Carpetas>();

            string sWhere = "";
            if (Campo == "Carpeta")
            {
                sWhere = " numero_letra=@numero_letra";
            }
            else if (Campo == "Titular")
            {
                sWhere = " apellidoynombre_propietario LIKE @apellidoynombre_propietario";
            }
            else
            {
                sWhere = " numero_contrato LIKE @numero_contrato";
            }
            string Sqltext = "SELECT id, idcocesionario, iddocumentoG, iddocumentoS, idprovinciaG, idprovinciaS, IDestadocarpetas, numero_letra, numero_contrato, existe, numero_estudio, periodo, apellidoynombre_propietario, " +
                "actual_propietario, domicilio_propietario, localidad_propietario, cp_propietario, telefono_propietario, numerodni_propietario, apellidoynombre_garante, domicilio_garante, localidad_garante, " +
                "cp_garante, telefono_garante, numerodni_garante, p_n_cor, fecha_ingreso, ult_estado, intcap, estado_carpeta, nivel_deuda, cuotas, deuda, estado_comentario, domicilio_ap, " +
                "localidad_ap, cp_ap, idprovincia_ap, email, nivel, CuitDni, CondIva, N_garante, Piso_garante, Dpto_garante, Email_garante " +
                "FROM tratamientocarpetas where " + sWhere;
            _BuscarCarpeta.Clear();
            MySqlConnection Conexion = Clases.Database.obtenerConexion(true);
            if (Conexion.State != ConnectionState.Open)
                Conexion.Open();
            MySqlCommand _Comando = new MySqlCommand(Sqltext, Conexion);

            if (Campo == "Carpeta")
            {
                _Comando.Parameters.AddWithValue("@numero_letra", dCarpeta);
            }
            else if (Campo == "Titular")
            {
                _Comando.Parameters.AddWithValue("@apellidoynombre_propietario", "%" + sTitular + "%");
            }
            else
            {
                _Comando.Parameters.AddWithValue("@numero_contrato", sContrato + "%");
            }

            MySqlDataReader _readerIT = _Comando.ExecuteReader();

            while (_readerIT.Read())
            {
                Carpetas p = new Carpetas();

                p.Id = _readerIT.GetInt32("id");
                if (!_readerIT.IsDBNull(_readerIT.GetOrdinal("idcocesionario")))
                {
                    p.Idcocesionario = _readerIT.GetInt32("idcocesionario");
                }
                if (!_readerIT.IsDBNull(_readerIT.GetOrdinal("iddocumentoG")))
                {
                    p.IddocumentoG = _readerIT.GetInt32("iddocumentoG");
                }
                if (!_readerIT.IsDBNull(_readerIT.GetOrdinal("iddocumentoS")))
                {
                    p.IddocumentoS = _readerIT.GetInt32("iddocumentoS");
                }
                if (!_readerIT.IsDBNull(_readerIT.GetOrdinal("idprovinciaG")))
                {
                    p.IdprovinciaG = _readerIT.GetInt32("idprovinciaG");
                }
                if (!_readerIT.IsDBNull(_readerIT.GetOrdinal("idprovinciaS")))
                {
                    p.IdprovinciaS = _readerIT.GetInt32("idprovinciaS");
                }
                if (!_readerIT.IsDBNull(_readerIT.GetOrdinal("IDestadocarpetas")))
                {
                    p.IDestadocarpetas = _readerIT.GetInt32("IDestadocarpetas");
                }
                if (!_readerIT.IsDBNull(_readerIT.GetOrdinal("numero_letra")))
                {
                    p.Numero_letra = _readerIT.GetInt32("numero_letra");
                }
                if (!_readerIT.IsDBNull(_readerIT.GetOrdinal("numero_contrato")))
                {
                    p.Numero_contrato = _readerIT.GetString("numero_contrato");
                }
                else
                {
                    p.Numero_contrato = "";
                }
                if (!_readerIT.IsDBNull(_readerIT.GetOrdinal("existe")))
                {
                    p.Existe = _readerIT.GetInt32("existe");
                }
                else
                {
                    p.Existe = 0;
                }
                if (!_readerIT.IsDBNull(_readerIT.GetOrdinal("numero_estudio")))
                {
                    p.Numero_estudio = _readerIT.GetString("numero_estudio");
                }
                else
                {
                    p.Numero_estudio = "";
                }
                if (!_readerIT.IsDBNull(_readerIT.GetOrdinal("periodo")))
                {
                    p.Periodo = _readerIT.GetDateTime("periodo");
                }
                if (!_readerIT.IsDBNull(_readerIT.GetOrdinal("apellidoynombre_propietario")))
                {
                    p.Apellidoynombre_propietario = _readerIT.GetString("apellidoynombre_propietario");
                }
                if (!_readerIT.IsDBNull(_readerIT.GetOrdinal("actual_propietario")))
                {
                    p.Actual_propietario = _readerIT.GetString("actual_propietario");
                }
                else
                {
                    p.Actual_propietario = "";
                }
                if (!_readerIT.IsDBNull(_readerIT.GetOrdinal("domicilio_propietario")))
                {
                    p.Domicilio_propietario = _readerIT.GetString("domicilio_propietario");
                }
                if (!_readerIT.IsDBNull(_readerIT.GetOrdinal("localidad_propietario")))
                {
                    p.Localidad_propietario = _readerIT.GetString("localidad_propietario");
                }
                if (!_readerIT.IsDBNull(_readerIT.GetOrdinal("cp_propietario")))
                {
                    p.Cp_propietario = _readerIT.GetInt32("cp_propietario");
                }
                if (!_readerIT.IsDBNull(_readerIT.GetOrdinal("telefono_propietario")))
                {
                    p.Telefono_propietario = _readerIT.GetString("telefono_propietario");
                }
                else
                {
                    p.Telefono_propietario = "";
                }
                if (!_readerIT.IsDBNull(_readerIT.GetOrdinal("numerodni_propietario")))
                {
                    p.Numerodni_propietario = _readerIT.GetString("numerodni_propietario");
                }
                else
                {
                    p.Numerodni_propietario = "";
                }
                if (!_readerIT.IsDBNull(_readerIT.GetOrdinal("apellidoynombre_garante")))
                {
                    p.Apellidoynombre_garante = _readerIT.GetString("apellidoynombre_garante");
                }
                else
                {
                    p.Apellidoynombre_garante = "";
                }
                if (!_readerIT.IsDBNull(_readerIT.GetOrdinal("domicilio_garante")))
                {
                    p.Domicilio_garante = _readerIT.GetString("domicilio_garante");
                }
                else
                {
                    p.Domicilio_garante = "";
                }
                if (!_readerIT.IsDBNull(_readerIT.GetOrdinal("localidad_garante")))
                {
                    p.Localidad_garante = _readerIT.GetString("localidad_garante");
                }
                else
                {
                    p.Localidad_garante = "";
                }
                if (!_readerIT.IsDBNull(_readerIT.GetOrdinal("cp_garante")))
                {
                    p.Cp_garante = _readerIT.GetInt32("cp_garante");
                }
                else
                {
                    p.Cp_garante = 0;
                }
                if (!_readerIT.IsDBNull(_readerIT.GetOrdinal("telefono_garante")))
                {
                    p.Telefono_garante = _readerIT.GetString("telefono_garante");
                }
                else
                {
                    p.Telefono_garante = "";
                }
                if (!_readerIT.IsDBNull(_readerIT.GetOrdinal("numerodni_garante")))
                {
                    p.Numerodni_garante = _readerIT.GetString("numerodni_garante");
                }
                else
                {
                    p.Numerodni_garante = "";
                }
                if (!_readerIT.IsDBNull(_readerIT.GetOrdinal("p_n_cor")))
                {
                    p.P_n_cor = _readerIT.GetInt32("p_n_cor");
                }
                if (!_readerIT.IsDBNull(_readerIT.GetOrdinal("fecha_ingreso")))
                {
                    p.Fecha_ingreso = _readerIT.GetDateTime("fecha_ingreso");
                }
                if (!_readerIT.IsDBNull(_readerIT.GetOrdinal("ult_estado")))
                {
                    p.Ult_estado = _readerIT.GetDateTime("ult_estado");
                }
                if (!_readerIT.IsDBNull(_readerIT.GetOrdinal("intcap")))
                {
                    p.Intcap = _readerIT.GetString("intcap");
                }
                if (!_readerIT.IsDBNull(_readerIT.GetOrdinal("estado_carpeta")))
                {
                    p.Estado_carpeta = _readerIT.GetString("estado_carpeta");
                }
                else
                {
                    p.Estado_carpeta = "";
                }
                if (!_readerIT.IsDBNull(_readerIT.GetOrdinal("nivel_deuda")))
                {
                    p.Nivel_deuda = _readerIT.GetString("nivel_deuda");
                }
                if (!_readerIT.IsDBNull(_readerIT.GetOrdinal("cuotas")))
                {
                    p.Cuotas = _readerIT.GetString("cuotas");
                }
                else
                {
                    p.Cuotas = "";
                }
                if (!_readerIT.IsDBNull(_readerIT.GetOrdinal("deuda")))
                {
                    p.Deuda = _readerIT.GetString("deuda");
                }
                else
                {
                    p.Deuda = "";
                }
                if (!_readerIT.IsDBNull(_readerIT.GetOrdinal("estado_comentario")))
                {
                    p.Estado_comentario = _readerIT.GetString("estado_comentario");
                }
                else
                {
                    p.Estado_comentario = "";
                }
                if (!_readerIT.IsDBNull(_readerIT.GetOrdinal("domicilio_ap")))
                {
                    p.Domicilio_ap = _readerIT.GetString("domicilio_ap");
                }
                else
                {
                    p.Domicilio_ap = "";
                }
                if (!_readerIT.IsDBNull(_readerIT.GetOrdinal("localidad_ap")))
                {
                    p.Localidad_ap = _readerIT.GetString("localidad_ap");
                }
                else
                {
                    p.Localidad_ap = "";
                }
                if (!_readerIT.IsDBNull(_readerIT.GetOrdinal("cp_ap")))
                {
                    p.Cp_ap = _readerIT.GetInt32("cp_ap");
                }
                else
                {
                    p.Cp_ap = 0;
                }
                if (!_readerIT.IsDBNull(_readerIT.GetOrdinal("idprovincia_ap")))
                {
                    p.Idprovincia_ap = _readerIT.GetInt32("idprovincia_ap");
                }
                if (!_readerIT.IsDBNull(_readerIT.GetOrdinal("email")))
                {
                    p.Email = _readerIT.GetString("email");
                }
                else
                {
                    p.Email = "";
                }
                if (!_readerIT.IsDBNull(_readerIT.GetOrdinal("nivel")))
                {
                    p.Nivel = _readerIT.GetInt32("nivel");
                }
                if (!_readerIT.IsDBNull(_readerIT.GetOrdinal("CuitDni")))
                {
                    p.CuitDni = _readerIT.GetString("CuitDni");
                }
                if (!_readerIT.IsDBNull(_readerIT.GetOrdinal("CondIva")))
                {
                    p.CondIva = _readerIT.GetString("CondIva");
                }
                _BuscarCarpeta.Add(p);
            }
            Conexion.Close();
            return _BuscarCarpeta;
        }
        public static Boolean BorraCuotas(int idTratamiento)
        {
            string SqlText = "delete from cargacuota where id = @id";

            MySqlConnection cnxMax = Database.obtenerConexion(true);
            if (cnxMax.State != ConnectionState.Open)
                cnxMax.Open();
            MySqlCommand _Comando = new MySqlCommand(SqlText, cnxMax);
            _Comando.Parameters.AddWithValue("@id", idTratamiento);
            _Comando.ExecuteNonQuery();
            cnxMax.Close();
            return true;
        }
        public static int MaxNroLetra(string Suma, string sWhere)
        {
            int UltimaCarpeta = 0;

            string SqlText = "SELECT Max(Tr.numero_letra) AS Maximo FROM tratamientocarpetas AS Tr " + sWhere;

            MySqlConnection cnxMax = Database.obtenerConexion(true);
            if (cnxMax.State != ConnectionState.Open)
                cnxMax.Open();
            MySqlCommand _Comando = new MySqlCommand(SqlText, cnxMax);

            MySqlDataReader _ReadPar = _Comando.ExecuteReader();
            while (_ReadPar.Read())
            {
                if (_ReadPar.GetValue(0) != DBNull.Value)
                {
                    if (Suma == "S")
                    {
                        UltimaCarpeta = _ReadPar.GetInt32("Maximo") + 1;
                    }
                    else
                    {
                        UltimaCarpeta = _ReadPar.GetInt32("Maximo");
                    }
                }
            }
            cnxMax.Close();
            return UltimaCarpeta;
        }

        public static Boolean UpdateCuotas()
        {
            string SqlText = "update cargacuota set cargacuota_estado = 'N'";

            MySqlConnection cnxMax = Database.obtenerConexion(true);
            if (cnxMax.State != ConnectionState.Open)
                cnxMax.Open();
            MySqlCommand _Comando = new MySqlCommand(SqlText, cnxMax);
            _Comando.ExecuteNonQuery();
            cnxMax.Close();
            return true;
        }

        public static Boolean UpdateTratamiento(string contrato)
        {
            string SqlText = "update tratamientocarpetas set estado_carpeta = 'N' where numero_contrato = @contrato";

            MySqlConnection cnxMax = Database.obtenerConexion(true);
            if (cnxMax.State != ConnectionState.Open)
                cnxMax.Open();
            MySqlCommand _Comando = new MySqlCommand(SqlText, cnxMax);
            _Comando.Parameters.AddWithValue("@contrato", contrato);
            _Comando.ExecuteNonQuery();
            cnxMax.Close();
            return true;
        }


        public static Boolean BorraReporte()
        {
            string SqlText = "delete from reporte_diskette";

            MySqlConnection cnxMax = Database.obtenerConexion(true);
            if (cnxMax.State != ConnectionState.Open)
                cnxMax.Open();
            MySqlCommand _Comando = new MySqlCommand(SqlText, cnxMax);
            _Comando.ExecuteNonQuery();
            cnxMax.Close();
            return true;
        }

        public static int LastId()
        {
            int UltimaCarpeta = 0;

            string SqlText = "SELECT last_insert_id();";

            MySqlConnection cnxMax = Database.obtenerConexion(true);
            if (cnxMax.State != ConnectionState.Open)
                cnxMax.Open();
            object ores = MySqlHelper.ExecuteScalar(cnxMax, SqlText);
            if (ores != null)
            {
                // Odd, I got ulong here.
                ulong qkwl = (ulong)ores;
                int Id = (int)qkwl;
                UltimaCarpeta = Id;
            }
            cnxMax.Close();
            return UltimaCarpeta;
        }
        public static double ConvertirStr(string valor, string Tipo)
        {
            if (Tipo=="D")
            {
                double retornod = Math.Round(Convert.ToDouble(valor), 2);
                return retornod;
            }
            else
            {
                int retornoi = Convert.ToInt32(valor);
                return retornoi;
            }
        }
        
        public static int BuscarEstado(string nombre)
        {
            int iDestado = 0;
            string SqlText = "SELECT Ec.ID FROM estadocarpetas AS Ec WHERE Ec.Denominacion = '" + nombre + "'";

            MySqlConnection cnxMax = Database.obtenerConexion(true);
            if (cnxMax.State != ConnectionState.Open)
                cnxMax.Open();
            MySqlCommand _Comando = new MySqlCommand(SqlText, cnxMax);

            MySqlDataReader _ReadPar = _Comando.ExecuteReader();
            while (_ReadPar.Read())
            {
                if (_ReadPar.GetValue(0) != DBNull.Value)
                {
                    iDestado = _ReadPar.GetInt32("ID");
                }
            }
            cnxMax.Close();
            return iDestado;
        }

        public static bool InsertaCuota(int iIdTentativa, string sCuota, DateTime sFecha, DateTime FechaPago, double dCapital, double dPunitorio, double dIntereses, double dGastos, double dBancario, double dHonorario)
        {
            DateTime fechaDia = sFecha;
            MySqlConnection cnxInsertTI = Clases.Database.obtenerConexion(true);
            // objeto transaccional
            MySqlTransaction tran = null;
            // string para transaccion
            string strSQL = "";
            // objeto command para ejecucion del query
            MySqlCommand command = new MySqlCommand();
            command.Connection = cnxInsertTI;
            command.CommandType = CommandType.Text;
            command.CommandTimeout = 0;

            try
            {
                // abrir la conexion
                if (cnxInsertTI.State != ConnectionState.Open)
                    cnxInsertTI.Open();
                // comenzamos la transaccion
                tran = cnxInsertTI.BeginTransaction();
                // asignamos transaccion al command
                command.Transaction = tran;

                // preparamos Insert Pedido
                strSQL = "Insert into tentativaitems (idTentativa, cuota, valores, fechaVto, fechapago, valorhistorico, interespunitorio, interesfinanciero, gastoadministrativo, gastobancario, honorarios) values (@idTentativa, @cuota, @valores, @fechaVto, @fechapago, @valorhistorico, @interespunitorio, @interesfinanciero, @gastoadministrativo, @gastobancario, @honorarios)";
                // reasignamos el string sql al command
                command.Parameters.Clear();
                command.CommandText = strSQL;
                command.Parameters.AddWithValue("@idTentativa", iIdTentativa);
                command.Parameters.AddWithValue("@cuota", sCuota);
                command.Parameters.AddWithValue("@valores", fechaDia);
                command.Parameters.AddWithValue("@fechaVto", FechaPago);
                command.Parameters.AddWithValue("@fechapago", fechaDia);
                command.Parameters.AddWithValue("@valorhistorico", dCapital);
                command.Parameters.AddWithValue("@interespunitorio", dPunitorio);
                command.Parameters.AddWithValue("@interesfinanciero", dIntereses);
                command.Parameters.AddWithValue("@gastoadministrativo", dGastos);
                command.Parameters.AddWithValue("@gastobancario", dBancario);
                command.Parameters.AddWithValue("@honorarios", dHonorario);
                // ejecutamos Insert
                command.ExecuteNonQuery();

                // si todo salio bien commiteamos los cambios
                tran.Commit();
                // emitimos el aviso exitoso
                //MessageBox.Show("Actualizado");
            }
            catch (Exception ex)
            {
                // si algo fallo deshacemos todo
                tran.Rollback();
                // mostramos el mensaje del error
                //MessageBox.Show(ex.Message);
            }
            finally
            {
                // cerramos la conexion
                if (cnxInsertTI.State != ConnectionState.Closed)
                    cnxInsertTI.Close();
                // destruimos la conexion
                cnxInsertTI.Dispose();
            }

            return true;
        }

    }
}
