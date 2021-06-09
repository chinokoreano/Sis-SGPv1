using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class ClienteCN
    {
        public List<cliente> FnConsultarClientes(cliente oCliente)
        {
            List<cliente> oResultado = new List<cliente>();
            try
            {
                ClienteCD oClienteCD = new ClienteCD();
                oResultado = oClienteCD.FnConsultarClientes(oCliente);
                return oResultado;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<SPR_CONSULTA_USUARIO_CONTRATO_Result> FnConsultarClientesContratos(int intOpcion, usuario oUsuario, cliente oCliente)
        {
            List<SPR_CONSULTA_USUARIO_CONTRATO_Result> oResultado = new List<SPR_CONSULTA_USUARIO_CONTRATO_Result>();
            try
            {
                ClienteCD oCLienteCD = new ClienteCD();
                oResultado = oCLienteCD.FnConsultarClientesContratos(intOpcion, oUsuario, oCliente);
                return oResultado;
                
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
