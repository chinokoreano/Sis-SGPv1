using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class ManifiestoEntregaCN
    {
        public Resultado FnInsertarManifiestoEntrega(manifiesto_entrega oManifiestoEntrega)
        {
            Resultado oResultado = new Resultado();
            try
            {
                ManifiestoEntregaCD oManifiestoEntregaCD = new ManifiestoEntregaCD();
                oResultado = oManifiestoEntregaCD.FnInsertarManifiestoEntrega(oManifiestoEntrega);
                return oResultado;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
