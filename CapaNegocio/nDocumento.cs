using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SanEmeterio.Entidades;


namespace SanEmeterio.CapaNegocio
{
    public class nDocumento
    {
        public static string Insertar(int IdDocumento, int Tipo_Documento, string Nombre_Documento)
        {
            Documento Obj = new Documento
            {
                Iddocumento = IdDocumento,
                Tipo_documento = Tipo_Documento,
                Nombre_documento = Nombre_Documento
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
        public static DataTable BuscarDocumentoN(string textobuscar)
        {
            Documento Obj = new Documento
            {
                Nombre_documento = textobuscar
            };
            return Obj.BuscarDocumentoN(Obj);
        }

    }
}
