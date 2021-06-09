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
                    oResultado = DB.usuario.Where(p => p.usuario1 == oUsuario.usuario1 && p.contrasenia == oUsuario.contrasenia).ToList();

                }

                return oResultado;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
