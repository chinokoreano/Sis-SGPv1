using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class SucesoCD
    {
        public List<suceso> FnConsultarSucesos(suceso oSuceso)
        {
            List<suceso> oResultado = new List<suceso>();
            try
            {
                using (OPERADB DB = new OPERADB())
                {
                    oResultado = DB.suceso.Where(p=>p.id_lote == oSuceso.id_lote).ToList();
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
