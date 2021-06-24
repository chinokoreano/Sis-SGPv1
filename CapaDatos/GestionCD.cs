using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class GestionCD
    {
        public List<gestion> FnConsultarGestiones()
        {
            List<gestion> oResultado = new List<gestion>();
            try
            {
                using (OPERADB DB = new OPERADB())
                {
                    oResultado = DB.gestion.Where(p=>p.estado == 1 && p.estado_catalogo == 1).ToList();
                    return oResultado;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Boolean FnValidarGestion(evento oEvento)
        {
            List<parametro> oListaParametro = new List<parametro>();
            try
            {
                using (OPERADB DB = new OPERADB())
                {
                    oListaParametro = DB.parametro.Where(p => p.tipo == "PRECONDICION_MANIFIESTO" && p.estado == true).ToList();
                       
                }

                Boolean bolExiste = false;

                string[] aGestiones = oListaParametro[0].valor1.ToString().Split(',');
                bolExiste = aGestiones.Contains(oEvento.id_tipo_evento.ToString());
                return bolExiste;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}
