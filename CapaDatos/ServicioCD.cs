using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class ServicioCD
    {
        public List<servicio> FnConsultarServicios()
        {
            List<servicio> oResultado = new List<servicio>();
            try
            {
                using (OPERADB DB = new OPERADB())
                {
                    oResultado = DB.servicio.Where(p => p.estado == true).ToList();

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
