using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Logica.LogicaUtilitarios
{
    public static class ExpresionRegular
    {
        //https://regex101.com/
        public static bool Verificar4Digitos(string cadena)
        {
            string pattern = @"^\d{4}$";
            Regex r = new System.Text.RegularExpressions.Regex(pattern);
            bool isMatch = r.IsMatch(cadena);
            return isMatch;
        }

        public static bool VerificarPatronUsurioLDAP(string cadena)
        {
            string pattern = @"^([a-zA-Z]+).([a-zA-Z]+)$";
            Regex r = new System.Text.RegularExpressions.Regex(pattern);
            bool isMatch = r.IsMatch(cadena);
            return isMatch;
        }

    }
}
