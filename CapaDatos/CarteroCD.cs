using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CarteroCD
    {
        public List<cartero> FnConsultarCarteros()
        {
            List<cartero> oResultado = new List<cartero>();
            try
            {
                using (OPERADB DB = new OPERADB())
                {
                    oResultado = DB.cartero.ToList();
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
