using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CarteroCN
    {
        public List<cartero> FnConsultarCarteros()
        {
            List<cartero> oResultado = new List<cartero>();
            try
            {
                CarteroCD oCarteroCD = new CarteroCD();
                oResultado = oCarteroCD.FnConsultarCarteros();
                return oResultado;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
