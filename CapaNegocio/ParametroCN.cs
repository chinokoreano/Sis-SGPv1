using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class ParametroCN
    {
        public List<parametro> FnConsultarParametros()
        {
            List<parametro> oResultado = new List<parametro>();
            try
            {
                ParametroCD oParametroCD = new ParametroCD();
                oResultado = oParametroCD.FnConsultarParametros();
                return oResultado;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
