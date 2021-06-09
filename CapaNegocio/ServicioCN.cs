using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class ServicioCN
    {
        public List<servicio> FnConsultarServicios()
        {
            List<servicio> oResultado = new List<servicio>();
            try
            {
                ServicioCD oServicioCD = new ServicioCD();
                oResultado = oServicioCD.FnConsultarServicios();
                return oResultado;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        
    }
}
