using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class OrdenServicioCD
    {
        public orden_servicio FnInsertarOrdenServicios(orden_servicio pOrden_Servicio)
        {
            
            int intId =0;
            try
            {
                using (OPERADB DB = new OPERADB())
                {

                    var idMax = DB.orden_servicio.Select(u => u.id)
                                    .DefaultIfEmpty(-1)
                                    .Max();
                    if (idMax == -1)
                    {
                        pOrden_Servicio.id = 1;
                    }
                    else
                    {
                        intId = idMax + 1;
                        pOrden_Servicio.id = intId;
                    }

                    pOrden_Servicio.codigo_orden_servicio = pOrden_Servicio.codigo_orden_servicio + "-" + pOrden_Servicio.id.ToString();
                    DB.orden_servicio.Add(pOrden_Servicio);
                    DB.SaveChanges();
                    
                }

                return pOrden_Servicio;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<orden_servicio> FnConsultaOrdenServicio(orden_servicio oOrden_Servicio)
        {
            List<orden_servicio> oResultado = new List<orden_servicio>();
            try
            {
                using (OPERADB DB = new OPERADB())
                {
                    oResultado = DB.orden_servicio.ToList();

                }

                return oResultado;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<SPR_CONSULTA_ORDENES_SERVICIO_Result> FnConsultarOrdenesDeServicio(int intOpcion, usuario oUsuario, orden_servicio oOrdenServicio)
        {
            List<SPR_CONSULTA_ORDENES_SERVICIO_Result> oResultado = new List<SPR_CONSULTA_ORDENES_SERVICIO_Result>();
            try
            {
                using (OPERADB DB = new OPERADB())
                {
                    oResultado = DB.SPR_CONSULTA_ORDENES_SERVICIO(intOpcion, oUsuario.id, oOrdenServicio.id).ToList();
                }
                return oResultado;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool FnEliminarOrdenServicio(orden_servicio oOrden_Servicio)
        {
            Boolean bolResultado;
            bolResultado = false;

            try
            {
                using (OPERADB DB = new OPERADB())
                {
                    
                    orden_servicio oResult = DB.orden_servicio.SingleOrDefault(p => p.id == oOrden_Servicio.id);
                    if (oResult != null)
                    {
                        oResult.estado = 0;
                        DB.SaveChanges();
                        bolResultado = true;
                    }

                }
                return bolResultado;
                
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
