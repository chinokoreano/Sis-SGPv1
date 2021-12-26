using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class EventoCD
    {
        public Resultado FnInsertarEvento(evento oEvento)
        {
            int intId;
            intId = 0;
            Resultado oResultado = new Resultado();
            try
            {
                using (OPERADB DB = new OPERADB())
                {
                    evento objEvento = new evento();
                    var idMax = DB.evento.Select(u => u.id)
                                   .DefaultIfEmpty(-1)
                                   .Max();
                    if (idMax == -1)
                    {
                        objEvento.id = 1;
                    }
                    else
                    {
                        intId = idMax + 1;
                        objEvento.id = intId;
                    }

                    objEvento.fecha_registro = DateTime.Now;
                    objEvento.estado = 1;
                    objEvento.identificador_paquete = oEvento.identificador_paquete;
                    objEvento.id_oficina = oEvento.id_oficina;
                    objEvento.id_tipo_evento = oEvento.id_tipo_evento;
                    objEvento.observacion1 = oEvento.observacion1;
                    objEvento.observacion2 = oEvento.observacion2;
                    objEvento.id_usuario = oEvento.id_usuario;

                    DB.evento.Add(objEvento);
                    DB.SaveChanges();

                    oResultado.Codigo1 = "1";

                }
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
                using (OPERADB DB = new OPERADB())
                {
                    oResultado = DB.evento.Where(p => p.identificador_paquete == oEvento.identificador_paquete).ToList();
                    return oResultado;
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<SPR_CONSULTA_EVENTOS_Result> FnTrackingEvento(int intOpcion,evento oEvento)
        {
            List<SPR_CONSULTA_EVENTOS_Result> oResultado = new List<SPR_CONSULTA_EVENTOS_Result>();
            try
            {
                using (OPERADB DB = new OPERADB())
                {
                    oResultado = DB.SPR_CONSULTA_EVENTOS(intOpcion,oEvento.identificador_paquete).ToList();
                    
                }
                return oResultado;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<SPR_ACT_ULTIMO_EVENTO_Result> FnActUltimoEvento(int intOpcion, paquete oPaquete, usuario oUsuario)
        {
            List<SPR_ACT_ULTIMO_EVENTO_Result> oResultado = new List<SPR_ACT_ULTIMO_EVENTO_Result>();
              
            try
            {
                using (OPERADB DB = new OPERADB())
                {
                    oResultado = DB.SPR_ACT_ULTIMO_EVENTO(oPaquete.codigo, intOpcion,oUsuario.nm).ToList();
                    
                }
                return oResultado;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}
