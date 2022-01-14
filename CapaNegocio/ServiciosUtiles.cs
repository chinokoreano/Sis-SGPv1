using CapaEntidad;
using CapaServicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class ServiciosUtiles
    {
        public Resultado enviarCorreo(string strDe, string strPara, string strAsunto, string strMensaje, string strCC)
        {
            Resultado oResultado = new Resultado();
            oResultado.Codigo1 = "-1";
            oResultado.Mensaje1 = "";
            try
            {
                CorreoElectronico oCorreo = new CorreoElectronico();
                oResultado = oCorreo.enviarCorreo(strDe, strPara, strAsunto, strMensaje, strCC);
                return oResultado;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Resultado generarContrasenia(int intLongMinima, int intLongMaxima)
        {
            Resultado oResultado = new Resultado();
            oResultado.Codigo1 = "-1";
            oResultado.Mensaje1 = "";
            
            try
            {
                
                oResultado.Codigo1 = "1";
                oResultado.Mensaje1 = RandomPassword.Generate(intLongMaxima);
                return oResultado;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
