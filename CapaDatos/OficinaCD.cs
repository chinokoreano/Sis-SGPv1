using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class OficinaCD
    {
        public List<oficina> FnConsultarOficinas()
        {
            List<oficina> oResultado = new List<oficina>();
            try
            {
                using (OPERADB DB = new OPERADB())
                {
                    oResultado = DB.oficina.ToList();
                    return oResultado;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
