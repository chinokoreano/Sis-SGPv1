using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaServicios
{
    public class Util
    {
        public Resultado generarContrasenia(int intLongMinima, int intLongMaxima)
        {
            Resultado oResultado = new Resultado();
            try
            {
                string password = RandomPassword.Generate(intLongMinima, intLongMaxima);
                oResultado.Codigo1 = "1";
                oResultado.Mensaje1 = password;
                return oResultado;
            }
            catch (Exception e)
            {
                oResultado = new Resultado();
                oResultado.Codigo1 = "-1";
                oResultado.Mensaje1 = e.Message;
            }
            return oResultado;
        }
        
    }
}
