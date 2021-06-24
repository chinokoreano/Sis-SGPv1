using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SIS_CARLITOS.Recursos
{
    public class clsSeguridad
    {
        public static string Encriptar(string _cadenaAencriptar)
        {
            string result = string.Empty;
            byte[] encryted = System.Text.Encoding.Unicode.GetBytes(_cadenaAencriptar);
            result = Convert.ToBase64String(encryted);
            return result;
        }

        
    }
}