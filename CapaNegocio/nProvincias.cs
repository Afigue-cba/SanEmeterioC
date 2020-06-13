using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SanEmeterio.Entidades;


namespace SanEmeterio.CapaNegocio
{
    public class nProvincias
    {
        public static string Insertar(int IdProvincia, string Letra_Provincia, string Nombre_Provincia)
        {
            Provincias Obj = new Provincias
            {
                Idprovincia = IdProvincia,
                Letra_provincia = Letra_Provincia,
                Nombre_provincia = Nombre_Provincia
            };
            return Obj.Insertar(Obj);
        }
        //public static string Editar(int IdDocumento, int Tipo_Documento, string Nombre_Documento, string textobuscar)
        //{
        //    //Documento Obj = new Documento
        //    //{
        //    //    Iddocumento = IdDocumento,
        //    //    Tipo_documento = Tipo_Documento,
        //    //    Nombre_documento = Nombre_Documento,
        //    //    TextoBuscar = textobuscar
        //    //};
        //    //return Obj.Editar(Obj);
        //}
        //public static string Eliminar(int id)
        //{
        //    Documento Obj = new Documento
        //    {
        //        Iddocumento = id
        //    };
        //    return Obj.Eliminar(Obj);
        //}
        public static DataTable BuscarProvinciaN(string textobuscar)
        {
            Provincias Obj = new Provincias
            {
                Nombre_provincia = textobuscar
            };
            return Obj.BuscarProvinciaN(Obj);
        }

    }
}
