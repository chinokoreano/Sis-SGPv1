using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class ListaManifiestoCN
    {
        public Resultado FnInsertaListaManifiesto(manifiesto_entrega oManifiesto, proceso_tmp oProceso, int intOpcion)
        {
            Resultado oResultado = new Resultado();
            try
            {
                ListaManifiestoCD oListaManifiestoCD = new ListaManifiestoCD();
                oResultado = oListaManifiestoCD.FnInsertaListaManifiesto(oManifiesto, oProceso, intOpcion);
                return oResultado;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<SPR_CONSULTA_MANIFIESTO_Result> FnImprimirListaManifiest(manifiesto_entrega oManifiesto, int intOpcion)
        {
            List<SPR_CONSULTA_MANIFIESTO_Result> oResultado = new List<SPR_CONSULTA_MANIFIESTO_Result>();
            try
            {
                ListaManifiestoCD oListaManifiestoCD = new ListaManifiestoCD();
                oResultado = oListaManifiestoCD.FnImprimirListaManifiest(oManifiesto, intOpcion);
                return oResultado;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
