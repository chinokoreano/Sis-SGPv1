using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class SucesoCN
    {
        public List<suceso> FnConsultarSucesos(suceso oSuceso)
        {
            List<suceso> oResultado = new List<suceso>();
            try
            {
                SucesoCD sucesoCD = new SucesoCD();
                oResultado = sucesoCD.FnConsultarSucesos(oSuceso);
                return oResultado;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
