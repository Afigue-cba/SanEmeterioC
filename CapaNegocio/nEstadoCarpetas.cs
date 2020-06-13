using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SanEmeterio.Entidades;


namespace SanEmeterio.CapaNegocio
{
    public class nEstadoCarpetas
    {
        public static string Insertar(int ID, int Codigo, string Denominacion, string AI)
        {
            EstadoCarpetas Obj = new EstadoCarpetas
            {
                Id = ID,
                Codigo = Codigo,
                Denominacion = Denominacion,
                Ai = AI
            };
            return Obj.Insertar(Obj);
        }
        //public static string Editar(int ID, int Codigo, string Denominacion, string AI)
        //{
        //    EstadoCarpetas Obj = new EstadoCarpetas
        //    {
        //        Id = ID,
        //        Codigo = Codigo,
        //        Denominacion = Denominacion,
        //        Ai = AI
        //    };
        //    return Obj.Editar(Obj);
        //}
        //public static string Eliminar(int id)
        //{
        //    EstadoCarpetas Obj = new EstadoCarpetas
        //    {
        //        Id = id
        //    };
        //    return Obj.Eliminar(Obj);
        //}
        public static DataTable BuscarEstadoCarpeta(string textobuscar)
        {
            EstadoCarpetas Obj = new EstadoCarpetas
            {
                Denominacion = textobuscar
            };
            return Obj.BuscarEstadoCarpetaN(Obj);
        }
    }
}
