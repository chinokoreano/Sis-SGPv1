using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class UsuarioCD
    {
        public List<usuario> FnConsultaUsuario(usuario oUsuario)
        {
            List<usuario> oResultado = new List<usuario>();
     
            try
            {
               
                using (OPERADB DB = new OPERADB())
                {
                    
                    oResultado = DB.usuario.Where(p => p.usuario1 == oUsuario.usuario1 && p.activo == true).ToList();
                    if (oResultado.Count == 0)
                    {
                        oResultado = null;
                        return oResultado;
                    }

                    if (oResultado != null)
                    {
                        var itm = DB.SPR_CONSULTA_CREDENCIALES(oResultado[0].id).ToList();
                        string strValor = itm[0].ToString();
                        if (strValor == "-1")
                        {
                            oResultado = null;
                        }
                        else
                        {
                            oResultado[0].contrasenia = strValor;                        }
                    }
                    
                }

                return oResultado;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Resultado FnActualizaUsuario(usuario oUsuario, string strContrasenia, int intOpcion)
        {
            List<SPR_ACTUALIZA_CREDENCIALES_Result> oResultado = new List<SPR_ACTUALIZA_CREDENCIALES_Result>();
            Resultado oResultadoF = new Resultado();
            try
            {

                using (OPERADB DB = new OPERADB())
                {

                    oResultado = DB.SPR_ACTUALIZA_CREDENCIALES(oUsuario.id, strContrasenia, intOpcion).ToList();
                    if (oResultado[0].RESULTADO == 1)
                    {
                        oResultadoF.Codigo1 = oResultado[0].RESULTADO.ToString();
                        oResultadoF.Mensaje1 = oResultado[0].MENSAJE.ToString();
                    }

                }

                return oResultadoF;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
