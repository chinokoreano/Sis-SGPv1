using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class ListaManifiestoCD
    {
        public Resultado FnInsertaListaManifiesto (manifiesto_entrega oManifiesto, proceso_tmp oProceso,int intOpcion)
        {
            Resultado oResultado = new Resultado();
            var Resultado=0;
            try
            {
               
                using (OPERADB DB = new OPERADB())
                {
                    Resultado = DB.SPR_INSERTAR_LISTA_MANIFIESTO(oManifiesto.id, oProceso.proceso_id, intOpcion);

                }
                oResultado.Codigo1 = Resultado.ToString(); 
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
                
                using (OPERADB DB = new OPERADB())
                {
                    oResultado = DB.SPR_CONSULTA_MANIFIESTO(intOpcion,oManifiesto.id).ToList();

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
