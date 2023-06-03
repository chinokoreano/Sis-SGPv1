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
        public void enviarCorreo(string remitente, string para, string asunto, string mensaje, string cc, string plantilla, Dictionary<string, string> valores)
        {
            
            try
            {
                CorreoElectronico.enviar(remitente, para, asunto, mensaje, cc, plantilla, valores);
                
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
