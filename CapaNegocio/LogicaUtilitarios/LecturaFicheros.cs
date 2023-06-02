using Entidades.DTO;
using Newtonsoft.Json;
using System.IO;
using System.Text;
using System.Web;

namespace Logica.LogicaUtilitarios
{
    public static class LecturaFicheros
    {
        static readonly object lockPlantillas = new object();
        static readonly object lockEscritura = new object();
        private static string Leer_string_lock(string ruta)
        {
            string json_str;

            //El siguiente bloque de código se usa para sicronizar todos los hilos y que se encolen hasta que el hilo que lee el archivo lo termine
            lock (lockPlantillas)
            {
                using (StreamReader r = new StreamReader(ruta, Encoding.Default, true))
                {
                    json_str = r.ReadToEnd();
                }
            }
            return json_str;
        }

        public static dynamic LeerArchivo_dynamic(string componente_nombre, string archivo = "/Content/json/configuracion.json")
        {
            string pathArchivo = string.Format("{0}{1}", HttpRuntime.AppDomainAppPath, archivo);
            string json_str = Leer_string_lock(pathArchivo);
            dynamic dincamico = JsonConvert.DeserializeObject(json_str);

            if (componente_nombre == null)
                return dincamico;
            else
                return dincamico[componente_nombre];
        }

        public static DiccioryObect LeerArchivo_diccionario(string componente_nombre = null, string archivo = "/Content/json/configuracion.json")
        {
            string pathArchivo = string.Format("{0}{1}", HttpRuntime.AppDomainAppPath, archivo);
            string json_str = Leer_string_lock(pathArchivo);
            dynamic dincamico = JsonConvert.DeserializeObject(json_str);

            if (componente_nombre == null)
            {
                return JsonConvert.DeserializeObject<DiccioryObect>(JsonConvert.SerializeObject(dincamico));
            }

            else
            {
                return JsonConvert.DeserializeObject<DiccioryObect>(JsonConvert.SerializeObject(dincamico[componente_nombre]));
            }

        }

        public static string LeerArchivo_str(string pathArchivo)
        {
            pathArchivo = string.Format("{0}{1}", HttpRuntime.AppDomainAppPath, pathArchivo);
            string archivo = Leer_string_lock(pathArchivo);
            //string plantilla= File.ReadAllText(ruta);
            return archivo;
        }

        public static void EscribirArchivo(string path, string cuerpoArchivo)
        {
            path = string.Format("{0}{1}", HttpRuntime.AppDomainAppPath, path);

            lock (lockEscritura)
            {
                using (var fs = new FileStream(path, FileMode.Create))
                {
                    byte[] buffer = Encoding.ASCII.GetBytes(cuerpoArchivo);
                    fs.Write(buffer, 0, buffer.Length);
                }
            }
        }
    }
}
