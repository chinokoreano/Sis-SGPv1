using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class ProcesoCN
    {
        public Resultado FnInsertarRegistro(proceso_tmp oProcesoTmp)
        {
            Resultado oResultado = new Resultado();
            try
            {
                ProcesoCD oProcesoCD = new ProcesoCD();
                oResultado = oProcesoCD.FnInsertarRegistro(oProcesoTmp);
                return oResultado;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
