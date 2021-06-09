using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class EntregaCN
    {
        public Resultado FnInsertarEntrega(entrega oEntrega)
        {
           
            Resultado oResultado = new Resultado();

            try
            {
                EntregaCD objEntrega = new EntregaCD();
                oResultado = objEntrega.FnInsertarEntrega(oEntrega);
                return oResultado;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
