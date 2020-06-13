using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SanEmeterio.Entidades;

namespace SanEmeterio.CapaNegocio
{
    public class nCargaCuota
    {
        public static string Insertar(int id, DateTime cargacuota_fecliquidacion, DateTime cargacuota_fecvto, int cargacuota_cta, double cargacuota_capital, double cargacuota_interes, string cargacuota_estado, double cargacuota_total, string numero_contrato)
        {
            Cargacuota Obj = new Cargacuota
            {
                Id = id,
                Cargacuota_fecliquidacion = cargacuota_fecliquidacion,
                Cargacuota_fecvto = cargacuota_fecvto,
                Cargacuota_cta = cargacuota_cta,
                Cargacuota_capital = cargacuota_capital,
                Cargacuota_interes = cargacuota_interes,
                Cargacuota_estado = cargacuota_estado,
                Cargacuota_total = cargacuota_total,
                Numero_contrato = numero_contrato,
            };
            return Obj.Insertar(Obj);
        }
        public static string Editar(int id, DateTime cargacuota_fecliquidacion, DateTime cargacuota_fecvto, int cargacuota_cta, double cargacuota_capital, double cargacuota_interes, string cargacuota_estado, double cargacuota_total, string numero_contrato)
        {
            Cargacuota Obj = new Cargacuota
            {
                Id = id,
                Cargacuota_fecliquidacion = cargacuota_fecliquidacion,
                Cargacuota_fecvto = cargacuota_fecvto,
                Cargacuota_cta = cargacuota_cta,
                Cargacuota_capital = cargacuota_capital,
                Cargacuota_interes = cargacuota_interes,
                Cargacuota_estado = cargacuota_estado,
                Cargacuota_total = cargacuota_total,
                Numero_contrato = numero_contrato,
            };

            return Obj.Editar(Obj);
        }
        public static string Eliminar(int id, int cargacuota_cta, string numero_contrato)
        {
            Cargacuota Obj = new Cargacuota
            {
                Id = id,
                Cargacuota_cta = cargacuota_cta,
                Numero_contrato = numero_contrato
            };
            return Obj.Eliminar(Obj);
        }
        public static DataTable BuscarCuota(int id, int cargacuota_cta, string numero_contrato)
        {
            Cargacuota Obj = new Cargacuota
            {
                Id = id,
                Cargacuota_cta = cargacuota_cta,
                Numero_contrato = numero_contrato
            };
            return Obj.BuscarCuota(Obj);
        }

    }
}
