using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class DetalleOrdenServicioCD
    {
        //public Boolean FnInsertarDetalleOrdenServicio(detalle_orden_servicio oDetalle_orden_servicio)
        //{
        //    Boolean bolResultado = false;
        //    int intId;
        //    try
        //    {
        //        using (OPERADB DB = new OPERADB())
        //        {

        //            var idMax = DB.detalle_orden_servicio.Select(u => u.id)
        //                            .DefaultIfEmpty(-1)
        //                            .Max();
        //            if (idMax == -1)
        //            {
        //                oDetalle_orden_servicio.id = 1;
        //            }
        //            else
        //            {
        //                intId = idMax + 1;
        //                oDetalle_orden_servicio.id = intId;
        //            }
        //            DB.detalle_orden_servicio.Add(oDetalle_orden_servicio);
        //            DB.SaveChanges();

        //        }
        //        return bolResultado;
        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }
        //}
    }
}
