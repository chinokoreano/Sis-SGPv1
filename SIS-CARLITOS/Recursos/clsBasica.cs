using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SIS_CARLITOS.Recursos
{
    public class clsBasica
    {
        public static Boolean FnVerificarSesion(string strValor)
        {
            Boolean EsValido;
            EsValido = false;
            try
            {
                if (string.IsNullOrEmpty(strValor) || string.IsNullOrWhiteSpace(strValor))
                {
                    string str = "prueba";
                    str = str + "123";
                }
                return EsValido;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}