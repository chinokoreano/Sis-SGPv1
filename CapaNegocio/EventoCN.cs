using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class EventoCN
    {
        public Resultado FnInsertarEvento(evento oEvento)
        {
            Resultado oResultado = new Resultado();
            try
            {
                EventoCD eventoCD = new EventoCD();
                oResultado = eventoCD.FnInsertarEvento(oEvento);
                return oResultado;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<evento> FnConsultarEvento(evento oEvento)
        {
            List<evento> oResultado = new List<evento>();
            try
            {
                EventoCD oEventoCD = new EventoCD();
                oResultado = oEventoCD.FnConsultarEvento(oEvento);
                return oResultado;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<SPR_CONSULTA_EVENTOS_Result> FnTrackingEvento(int intOpcion, evento oEvento)
        {
            List<SPR_CONSULTA_EVENTOS_Result> oResultado = new List<SPR_CONSULTA_EVENTOS_Result>();
            try
            {
                EventoCD oEventoCD = new EventoCD();
                oResultado = oEventoCD.FnTrackingEvento(intOpcion, oEvento);
                return oResultado;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<SPR_ACT_ULTIMO_EVENTO1_Result> FnActUltimoEvento(int intOpcion, paquete oPaquete)
        {
            List<SPR_ACT_ULTIMO_EVENTO1_Result> oResultado = new List<SPR_ACT_ULTIMO_EVENTO1_Result>();

            try
            {
                EventoCD oEventoCD = new EventoCD();
                oResultado = oEventoCD.FnActUltimoEvento(intOpcion, oPaquete).ToList();
                return oResultado;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
