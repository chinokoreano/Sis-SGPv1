using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class OficinaCN
    {
        public List<oficina> FnConsultarClientes()
        {
            List<oficina> oResultado = new List<oficina>();
            try
            {
                OficinaCD oOficinaCD = new OficinaCD();
                oResultado = oOficinaCD.FnConsultarOficinas();
                return oResultado;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
