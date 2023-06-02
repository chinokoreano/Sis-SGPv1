using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.LogicaUtilitarios
{
    public static class Merge
    {
        public static T cast<T>(Object obj)
        {
            T objeto;
            
            try
            {
                //JsonConvert.DeserializeObject<T>(param[reg].ToString());
                objeto = JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(obj));
            }
            catch (Exception ex)
            {
                throw new System.ArgumentException("No se puede castear el objeto solicitado. "+ ex.Message, "original");
            }
            return objeto;
        }
    }
}
