using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class ParametroCD
    {
        public List<parametro> FnConsultarParametros()
        {
            List<parametro> oResultado = new List<parametro>();
            try
            {
                using (OPERADB DB = new OPERADB())
                {
                    oResultado = DB.parametro.Where(p => p.estado == true).ToList();
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
