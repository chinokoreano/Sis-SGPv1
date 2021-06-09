using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class PaqueteCN
    {
        public void FnCargarDatosTablaTemporal(DataTable dt, Guid gLote, int intIdServicio, int intIdUsuario, int intIdCliente, string strDetalleOrdenServicio, int intIdOficina, string strIdProvinciaCarga, string strIdCantonCarga, int intIdContrato)
        {
            try
            {
                PaqueteCD oPaqueteCD = new PaqueteCD();
                oPaqueteCD.FnCargarDatosTablaTemporal(dt, gLote, intIdServicio, intIdUsuario, intIdCliente, strDetalleOrdenServicio, intIdOficina, strIdProvinciaCarga, strIdCantonCarga, intIdContrato);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Resultado FnProcesarCargaDatos(Guid gIdentificador)
        {
            Resultado oResultado = new Resultado();
            try
            {
                PaqueteCD oPaqueteCD = new PaqueteCD();
                oResultado = oPaqueteCD.FnProcesarCargaDatos(gIdentificador);
                return oResultado;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public paquete FnConsultarPaquete(paquete oPaquete)
        {
            paquete oResultado = new paquete();
            try
            {
                PaqueteCD oPaqueteCD = new PaqueteCD();
                oResultado = oPaqueteCD.FnConsultarPaquete(oPaquete);
                return oResultado;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<SPR_CONSULTA_ENVIO_GUIAS_Result> FnConsultarGuias(int intOpcion, orden_servicio oOrdenServicio)
        {
            List<SPR_CONSULTA_ENVIO_GUIAS_Result> oResultado = new List<SPR_CONSULTA_ENVIO_GUIAS_Result>();
            try
            {
                PaqueteCD oPaqueteCD = new PaqueteCD();
                oResultado = oPaqueteCD.FnConsultarGuias(intOpcion, oOrdenServicio);
                return oResultado;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Boolean FnActualizarEventoPaquete(paquete oPaquete, evento oEvento)
        {
            Boolean bolResultado = false;
            try
            {
                PaqueteCD oPaqueteCD = new PaqueteCD();
                bolResultado = oPaqueteCD.FnActualizarEventoPaquete(oPaquete, oEvento);
                return bolResultado;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<SPR_CONSULTA_ENVIO_Result> FnTrackingPaquetes(int intOpcion, string strCodigoEnvio, string strCodigoOrdenServicio, string strDestinatario, int intUsuario, string strFecha1, string strFecha2, string strGestion, int intIdCliente)
        {
            List<SPR_CONSULTA_ENVIO_Result> oResultado = new List<SPR_CONSULTA_ENVIO_Result>();
            try
            {
                PaqueteCD oPaqeueteCD = new PaqueteCD();
                oResultado = oPaqeueteCD.FnTrackingPaquetes(intOpcion, strCodigoEnvio, strCodigoOrdenServicio, strDestinatario, intUsuario, strFecha1, strFecha2, strGestion, intIdCliente);
                return oResultado;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
