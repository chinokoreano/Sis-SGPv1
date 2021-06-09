using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class ProcesoCD
    {
        public Resultado FnInsertarRegistro(proceso_tmp oProcesoTmp)
        {
            Resultado oResultado = new Resultado();
            oResultado.Codigo1 = "0";
            int intId = 0;
            try
            {
                using (OPERADB DB = new OPERADB())
                {

                    var idMax = DB.proceso_tmp.Select(u => u.id)
                                   .DefaultIfEmpty(-1)
                                   .Max();
                    if (idMax == -1)
                    {
                        oProcesoTmp.id = 1;
                    }
                    else
                    {
                        intId = idMax + 1;
                        oProcesoTmp.id = intId;
                    }
                    DB.proceso_tmp.Add(oProcesoTmp);
                    DB.SaveChanges();

                    oResultado.Codigo1 = "1";
                }
                return oResultado;
            }
            catch (Exception)
            {

                throw;
            }
            
        }
       
    }
}
