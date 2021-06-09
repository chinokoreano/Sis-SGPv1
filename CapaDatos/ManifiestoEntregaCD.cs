using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class ManifiestoEntregaCD
    {
        public Resultado FnInsertarManifiestoEntrega(manifiesto_entrega oManifiestoEntrega)
        {
            Resultado oResultado = new Resultado();
            int intId;
            intId = 0;
            try
            {
                using (OPERADB DB = new OPERADB())
                {
                    List<SPR_GENERAR_COD_MANIFIESTO_ENTREGA_Result> oResultadoCodManifiestoEntrega = new List<SPR_GENERAR_COD_MANIFIESTO_ENTREGA_Result>();
                    oResultadoCodManifiestoEntrega = DB.SPR_GENERAR_COD_MANIFIESTO_ENTREGA(oManifiestoEntrega.id_oficina).ToList();

                    string strCodigoManifiesto = oResultadoCodManifiestoEntrega[0].codigo_manifiesto;
                    int intSecuencia = int.Parse(oResultadoCodManifiestoEntrega[0].secuencia.ToString());


                    var idMax = DB.manifiesto_entrega.Select(u => u.id)
                                   .DefaultIfEmpty(-1)
                                   .Max();
                    if (idMax == -1)
                    {
                        oManifiestoEntrega.id = 1;
                    }
                    else
                    {
                        intId = idMax + 1;
                        oManifiestoEntrega.id = intId;
                    }
                    oManifiestoEntrega.codigo_manifiesto = strCodigoManifiesto;
                    oManifiestoEntrega.secuencia = intSecuencia;
                    oManifiestoEntrega.estado = 1;
                    oManifiestoEntrega.fecha_registro = DateTime.Now;
                    DB.manifiesto_entrega.Add(oManifiestoEntrega);
                    DB.SaveChanges();

                    oResultado.Codigo1 = "1";
                    oResultado.Mensaje1 = strCodigoManifiesto;
                    oResultado.Codigo2 = oManifiestoEntrega.id.ToString();

                    return oResultado;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
