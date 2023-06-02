using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.DTO
{
    public class DiccioryObect : Dictionary<string, object>
    {
        public string getSrt(string clave)
        {
            return base[clave].ToString();

        }
        public bool getBool(string clave)
        {
            return Convert.ToBoolean(base[clave].ToString());

        }
    }
}
