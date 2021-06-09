using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Resultado
    {
        private string codigo1;
        private string codigo2;
        private string mensaje1;
        private string mensaje2;

        public string Codigo1 { get => codigo1; set => codigo1 = value; }
        public string Codigo2 { get => codigo2; set => codigo2 = value; }
        public string Mensaje1 { get => mensaje1; set => mensaje1 = value; }
        public string Mensaje2 { get => mensaje2; set => mensaje2 = value; }
    }
}
