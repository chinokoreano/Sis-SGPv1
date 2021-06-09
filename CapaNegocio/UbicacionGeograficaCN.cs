using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class UbicacionGeograficaCN
    {
        public List<ubicacion_geografica> FnConsultarUbicacionesGeograficas()
        {
            List<ubicacion_geografica> oResultado = new List<ubicacion_geografica>();
            try
            {
                UbicacionGeograficaCD oUbicacionGeograficaCD = new UbicacionGeograficaCD();
                oResultado = oUbicacionGeograficaCD.FnConsultarUbicacionesGeograficas();
                return oResultado;

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
                UbicacionGeograficaCD oUbicacionGeograficaCD = new UbicacionGeograficaCD();
                oResultado = oUbicacionGeograficaCD.FnConsultarUbicacionesGeograficas(intOpcion);
                return oResultado;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
