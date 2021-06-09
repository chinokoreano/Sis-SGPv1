using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class GestionCN
    {
        public List<gestion> FnConsultarGestiones()
        {
            List<gestion> oResultado = new List<gestion>();
            try
            {
                GestionCD oGestionCD = new GestionCD();
                oResultado = oGestionCD.FnConsultarGestiones();
                return oResultado;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Boolean FnValidarGestion(evento oEvento)
        {
            Boolean bolResultado = new Boolean();
            bolResultado = false;
            try
            {
                GestionCD oGestionCD = new GestionCD();
                bolResultado= oGestionCD.FnValidarGestion(oEvento);
                return bolResultado;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
