using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class UsuarioCN
    {
        public List<usuario> FnConsultaUsuario(usuario oUsuario)
        {
            List<usuario> oResultado = new List<usuario>();
            UsuarioCD oUsuarioCD = new UsuarioCD();
            oResultado = oUsuarioCD.FnConsultaUsuario(oUsuario);
            return oResultado;

        }

        public Resultado FnActualizaUsuario(usuario oUsuario, string strContrasenia, int intOpcion)
        {
            Resultado oResultado = new Resultado();
            try
            {
                UsuarioCD oUsuarioCD = new UsuarioCD();
                oResultado = oUsuarioCD.FnActualizaUsuario(oUsuario, strContrasenia, intOpcion);
                return oResultado;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
