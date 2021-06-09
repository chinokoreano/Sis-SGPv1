using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class UbicacionGeograficaCD
    {
        public List<ubicacion_geografica> FnConsultarUbicacionesGeograficas()
        {
            List<ubicacion_geografica> oResultado = new List<ubicacion_geografica>();
            try
            {
                using (OPERADB DB = new OPERADB())
                {
                    oResultado = DB.ubicacion_geografica.Where(p => p.estado ==true).ToList();
                    return oResultado;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<SPR_CONSULTA_UBICACIONES_GEOGRAFICAS_Result> FnConsultarUbicacionesGeograficas(int intOpcion)
        {
            
            List<SPR_CONSULTA_UBICACIONES_GEOGRAFICAS_Result> oResultado = new List<SPR_CONSULTA_UBICACIONES_GEOGRAFICAS_Result>();
            try
            {
                using (OPERADB DB = new OPERADB())
                {
                    oResultado = DB.SPR_CONSULTA_UBICACIONES_GEOGRAFICAS(intOpcion).ToList();
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
