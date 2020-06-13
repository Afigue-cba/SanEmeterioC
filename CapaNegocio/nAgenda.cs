using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SanEmeterio.Entidades;


namespace SanEmeterio.CapaNegocio
{
    public class nAgenda
    {
        public static string Insertar(string contrato, DateTime fecha, string hora, string tarea, string estado, string operador, string carpeta, DateTime creado, string textobuscar)
        {
            Agenda Obj = new Agenda
            {
                Contrato = contrato,
                Fecha = fecha,
                Hora = hora,
                Tarea = tarea,
                Estado = estado,
                Operador = operador,
                Carpeta = carpeta,
                Creado = creado,
                TextoBuscar = textobuscar
            };
            return Obj.Insertar(Obj);
        }
        public static string Editar(string contrato, DateTime fecha, string hora, string tarea, string estado, string operador, string carpeta, DateTime creado, string textobuscar)
        {
            Agenda Obj = new Agenda
            {
                Contrato = contrato,
                Fecha = fecha,
                Hora = hora,
                Tarea = tarea,
                Estado = estado,
                Operador = operador,
                Carpeta = carpeta,
                Creado = creado,
                TextoBuscar = textobuscar
            };
            return Obj.Editar(Obj);
        }
        public static string Eliminar(int id)
        {
            Agenda Obj = new Agenda
            {
                Id = id
            };
            return Obj.Eliminar(Obj);
        }
        public static DataTable BuscarAgenda(string textobuscar)
        {
            Agenda Obj = new Agenda
            {
                TextoBuscar = textobuscar
            };
            return Obj.BuscarContrato(Obj);
        }


    }
}
