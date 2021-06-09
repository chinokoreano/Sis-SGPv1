using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class OrdenServicioCN
    {
        public orden_servicio FnInsertarOrdenServicios(orden_servicio pOrden_Servicio)
        {
            orden_servicio oResultado = new orden_servicio();
            try
            {
                OrdenServicioCD OordenServicioCD = new OrdenServicioCD();
                oResultado = OordenServicioCD.FnInsertarOrdenServicios(pOrden_Servicio);
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
                OrdenServicioCD OordenServicioCD = new OrdenServicioCD();
                oResultado = OordenServicioCD.FnConsultarOrdenesDeServicio(intOpcion, oUsuario, oOrdenServicio);
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
                OrdenServicioCD oOrdenServicioCD = new OrdenServicioCD();
                bolResultado = oOrdenServicioCD.FnEliminarOrdenServicio(oOrden_Servicio);
                return bolResultado;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
