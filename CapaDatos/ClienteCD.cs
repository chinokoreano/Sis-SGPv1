using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class ClienteCD
    {
        public List<cliente> FnConsultarClientes(cliente oCliente)
        {
            List<cliente> oResultado = new List<cliente>();
            try
            {
                using (OPERADB DB = new OPERADB())
                {
                    oResultado = DB.cliente.Where(p => p.nm_cliente.Contains(oCliente.nm_cliente) || p.numero_identificacion == oCliente.numero_identificacion && p.estado == true).ToList();
                    return oResultado;
                }

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
                using (OPERADB DB = new OPERADB())
                {
                    
                    oResultado = DB.SPR_CONSULTA_USUARIO_CONTRATO(intOpcion, oUsuario.id, oCliente.numero_identificacion, oCliente.nm_cliente).ToList();
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
