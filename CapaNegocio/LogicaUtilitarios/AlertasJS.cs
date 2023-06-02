using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;

namespace Logica.LogicaUtilitarios
{
    public static class AlertasJS
    {
        /// <summary>
        /// Pemerite crear el string para cargar los mensajes por javaScript
        /// </summary>
        /// <param name="icono">Puede ser:success,error,warning,info y question  </param>
        /// <param name="titulo">Titulo que aparecerá en pop up flotantes</param>
        /// <param name="mensaje">Texto del mensaje</param>
        /// <param name="posicion">top, top-start, top-end, center, center-start, center-end, bottom, bottom-start, or bottom-end. Default top</param>
        /// <returns>https://sweetalert2.github.io/#icons</returns>
        private static string mensaje_str(string icono, string titulo, string mensaje, string posicion = null)
        {
            return string.Format("mensaje('{0}', '{1}', '{2}', {3});", icono, titulo, mensaje, txtNull(posicion));
        }

        /// <summary>
        /// Envía la notificacion de ERROR directo al UI, y registra en el console log del cliente el objeto EXCEPCIÓN sin el TRACE
        /// </summary>
        /// <param name="page">Parámetro 'this'del controlador UI</param>
        /// <param name="ex">Excepción del catch</param>
        /// <param name="funcionJs">Opcional, si se requiere ejecutar alguna función JS adicional</param>
        /// <param name="titulo">Opcional, Texto del título</param>
        /// <param name="posicion">Opcional, top, top-start, top-end, center, center-start, center-end, bottom, bottom-start, or bottom-end. Default top</param>
        /// <returns>https://sweetalert2.github.io/#icons</returns>
        public static void js_exepcion(Page page, Exception ex, string funcionJs = null, string titulo = "Ooop... Algo salió mal", string posicion = null)
        {
            string ico = "error";
            JObject jo = JObject.FromObject(ex);

            jo.Property("StackTraceString").Remove();

            string ex_str = jo.ToString();
            string ex_mensaje = jo["Message"].ToString().Replace("'", "\"").Replace("\n", "\\n").Replace("\r", "\\r");

            List<string> listString = Util.listStr(ex_mensaje, '|');

            if (listString.Count == 2)
                ico = listString[1];

            ex_mensaje = listString[0];

            var param = jo["ParamName"];
            if (param != null)
            {
                string ex_param = jo["ParamName"].ToString().Replace("'", "\"").Replace("\n", "\\n").Replace("\r", "\\r");
                if (ex_param.Trim().Length > 5)
                    titulo = ex_param.Trim();
            }

            string mensaje_js = AlertasJS.mensaje_str(ico, titulo, ex_mensaje, posicion);

            mensaje_js = string.Format("{0} console.log({1});", mensaje_js, ex_str);

            if (funcionJs != null)
                mensaje_js = string.Format("{0}{1};", mensaje_js, funcionJs);

            ScriptManager.RegisterStartupScript(page, page.GetType(), "ShowStatus", mensaje_js, true);
        }

        /// <summary>
        /// Cea modal NOTIFICACION ADVERTENCIA con título y subtitulo. Opcción de llamar una función JS
        /// </summary>
        /// <param name="page">Parámetro 'this'del controlador UI</param>
        /// <param name="response">'response' de los servicios</param>
        /// <param name="funcionJs">Opcional, si se requiere ejecutar alguna función JS adicional</param>
        /// <param name="titulo">Opcional, Texto del título</param>
        /// <param name="posicion">Opcional, top, top-start, top-end, center, center-start, center-end, bottom, bottom-start, or bottom-end. Default top</param>
        /// <returns>https://sweetalert2.github.io/#icons</returns>
        public static void Advertencia(Page page, string mensaje, string funcionJs = null, string titulo = "Advertencia", string posicion = null)
        {
            mensaje = mensaje.Replace("'", "\"").Replace("\n", "\\n").Replace("\r", "\\r");
            string mensaje_js = AlertasJS.mensaje_str("warning", titulo, mensaje, posicion);
            if (funcionJs != null)
                mensaje_js = string.Format("{0}{1};", mensaje_js, funcionJs);

            ScriptManager.RegisterStartupScript(page, page.GetType(), "ShowStatus", mensaje_js, true);
        }

        /// <summary>
        /// Cea modal de NOTIFICACIÓN con ícono y subtitulo. Opcción de llamar una función JS
        /// </summary>
        /// <param name="page">Parámetro 'this'del controlador UI</param>
        /// <param name="response">'response' de los servicios</param>
        /// <param name="icono">success, error ,warning ,info, question</param>
        /// <param name="funcionJs">Opcional, si se requiere ejecutar alguna función JS adicional</param>
        /// <param name="posicion">Opcional: top, top-start, top-end, center, center-start, center-end, bottom, bottom-start, or bottom-end. Default top</param>
        /// <returns></returns>
        public static void Notificacion(Page page, string mensaje, string icono, string funcionJs = null, string posicion = null)
        {
            mensaje = mensaje.Replace("'", "\"").Replace("\n", "\\n").Replace("\r", "\\r");

            if (mensaje == null && icono.Equals("success"))
                mensaje = "Transacción exitosa";


            string mensaje_js = string.Format("notificacion('{0}','{1}',{2});", icono, mensaje, txtNull(posicion));

            if (funcionJs != null)
                mensaje_js = string.Format("{0}{1};", mensaje_js, funcionJs);

            ScriptManager.RegisterStartupScript(page, page.GetType(), "ShowStatus", mensaje_js, true);
        }

        public static void MensajeFuncionJS(Page page, string titulo, string texto, string FuncionJS, string textoBoton = "Aceptar", string icono = "info")
        {
            texto = texto.Replace("'", "\"").Replace("\n", "\\n").Replace("\r", "\\r");
            string mensaje_js = string.Format("MensajeFuncionJS('{0}','{1}','{2}','{3}','{4}');", titulo, texto, FuncionJS, textoBoton, icono);

            ScriptManager.RegisterStartupScript(page, page.GetType(), "ShowStatus", mensaje_js, true);
        }

        /// <summary>
        /// Cea modal de NOTIFICACIÓN DE ÉXITO con título y subtitulo. Opcción de llamar una función JS
        /// </summary>
        /// <param name="page">Parámetro 'this'del controlador UI</param>
        /// <param name="response">'response' de los servicios</param>
        /// <param name="funcionJs">Opcional, si se requiere ejecutar alguna función JS adicional</param>
        /// <param name="titulo">Opcional, Texto del título</param>
        /// <param name="posicion">Opcional, top, top-start, top-end, center, center-start, center-end, bottom, bottom-start, or bottom-end. Default top</param>
        /// <returns>https://sweetalert2.github.io/#icons</returns>

        public static void Exito(Page page, string mensaje, string funcionJs = null, string titulo = "Procesado con éxito", string posicion = null)
        {
            string mensaje_js = AlertasJS.mensaje_str("success", titulo, mensaje, posicion);
            if (funcionJs != null)
                mensaje_js = string.Format("{0}{1};", mensaje_js, funcionJs);

            ScriptManager.RegisterStartupScript(page, page.GetType(), "ShowStatus", mensaje_js, true);
        }

        /// <summary>
        ///  Muesta un modal de CONFIRMACIÓN con titulo, subtitulo e imagen que en caso de acepar EJECUTA la funcion dada
        /// </summary>
        /// <param name="page">Parámetro 'this'del controlador UI</param>
        /// <param name="response">'response' de los servicios o string</param>
        /// <param name="titulo">Titulo de la notificación</param>
        /// <param name="funcionJs">string de la función que se ejecutará por JS</param>
        /// <param name="icono">success, error ,warning ,info, question</param>
        /// <param name="posicion">Opcional: top, top-start, top-end, center, center-start, center-end, bottom, bottom-start, or bottom-end. Default top</param>
        /// <param name="icono">OPCIONAL. En caso de requerrir mostrar una imagen setear la URL</param>
        public static void Confirmacion(Page page, string mensaje, string titulo, string funcionJs, string icono = null, string posicion = null, string srcImgen = null)
        {


            string mensaje_js = string.Format("confirmacionFuncionJS('{0}', '{1}', '{2}', {3}, 'Confirmar', {4}, {5});", titulo, mensaje, funcionJs, txtNull(srcImgen), txtNull(icono), txtNull(posicion));

            ScriptManager.RegisterStartupScript(page, page.GetType(), "ShowStatus", mensaje_js, true);
        }

        /// <summary>
        /// Muesta un modal con titulo y mensaje notificando al usuario previo a REDIRECCIONAR al url dado
        /// </summary>
        /// <param name="page">Parámetro 'this'del controlador UI</param>
        /// <param name="titulo">Titulo de la notificación</param>
        /// <param name="response">'response' de los servicios o string</param>
        /// <param name="icono">success, error ,warning ,info, question</param>
        /// <param name="urlRedirect">path relativo de la página a redireccionar</param>
        /// <param name="funcionJs">Opcional, si se requiere ejecutar alguna función JS adicional</param>
        /// <param name="posicion">Opcional: top, top-start, top-end, center, center-start, center-end, bottom, bottom-start, or bottom-end. Default top</param>
        public static void NotificacionRedirect(Page page, string titulo, string mensaje, string icono, string urlRedirect, string funcionJs = null, string posicion = null)
        {

            if (mensaje == null && icono.Equals("success"))
                mensaje = "Transacción exitosa";


            string mensaje_js = string.Format("notificacionRedirect({0},'{1}','{2}','{3}',{4});", txtNull(icono), titulo, mensaje, urlRedirect, txtNull(posicion));

            if (funcionJs != null)
                mensaje_js = string.Format("{0}{1};", mensaje_js, funcionJs);

            ScriptManager.RegisterStartupScript(page, page.GetType(), "ShowStatus", mensaje_js, true);
        }

        /// <summary>
        /// Envía un toast de éxito directo al UI, y opcionalmente llamar a una función JS 
        /// </summary>
        /// <param name="page">Parámetro 'this'del controlador UI</param>
        /// <param name="response">'response' de los servicios</param>
        /// <param name="posicion">Opcional, top, top-start, top-end, center, center-start, center-end, bottom, bottom-start, or bottom-end</param>
        /// <param name="funcionJs">Opcional, si se requiere ejecutar alguna función JS adicional</param>
        public static void ToastExito(Page page, string mensaje, string posicion = "top-end", string funcionJs = null)
        {

            string mensaje_js = "EjecutarToast('success','" + mensaje + "','" + posicion + "');";

            if (funcionJs != null)
                mensaje_js = string.Format("{0}{1};", mensaje_js, funcionJs);

            ScriptManager.RegisterStartupScript(page, page.GetType(), "ShowStatus", mensaje_js, true);
        }

        /// <summary>
        /// Envía un toast genpérico directo al UI, y opcionalmente llamar a una función JS
        /// </summary>
        /// <param name="page">Parámetro 'this'del controlador UI</param>
        /// <param name="response">'response' de los servicios</param>
        /// /// <param name="icono">success, error ,warning ,info, question</param>
        ///         /// <param name="posicion">Opcional, top, top-start, top-end, center, center-start, center-end, bottom, bottom-start, or bottom-end</param>
        /// <param name="funcionJs">Opcional, si se requiere ejecutar alguna función JS adicional</param>
        public static void Toast(Page page, string mensaje, string icono, string posicion = "top-end", string funcionJs = null)
        {

            string mensaje_js = "EjecutarToast('" + icono + "','" + mensaje + "','" + posicion + "');";
            //"ToastMensaje.fire({ icon: '" + icono + "', title: '" + mensaje + "'});";

            if (funcionJs != null)
                mensaje_js = string.Format("{0}{1};", mensaje_js, funcionJs);

            ScriptManager.RegisterStartupScript(page, page.GetType(), "ShowStatus", mensaje_js, true);
        }

        /// <summary>
        /// Invoca directamente una función JS al UI
        /// </summary>
        /// <param name="page">Parámetro 'this'del controlador UI</param>
        /// <param name="funcionJs">Opcional, si se requiere ejecutar alguna función JS adicional</param>
        public static void jsFuncion(Page page, string funcionJs)
        {
            ScriptManager.RegisterStartupScript(page, page.GetType(), "ShowStatus", funcionJs, true);
        }

        public static void AbrirModal(Page page, string nomnbreModal, string funcionJs = null)
        {
            string mensaje_js = "$('#" + nomnbreModal + "').modal('show');";

            if (funcionJs != null)
                mensaje_js = string.Format("{0}{1};", mensaje_js, funcionJs);

            ScriptManager.RegisterStartupScript(page, page.GetType(), "ShowStatus", mensaje_js, true);
        }

        public static void CerrarModal(Page page, string nomnbreModal, string funcionJs = null)
        {
            string mensaje_js = "$('#" + nomnbreModal + "').hide();";


            if (funcionJs != null)
                mensaje_js = string.Format("{0}{1};", mensaje_js, funcionJs);

            ScriptManager.RegisterStartupScript(page, page.GetType(), "ShowStatus", mensaje_js, true);
        }

        public static void CerrarModalBS(Page page, string nomnbreModal, string funcionJs = null)
        {
            string mensaje_js = "cerrar_modal_bs('" + nomnbreModal + "');";


            if (funcionJs != null)
                mensaje_js = string.Format("{0}{1};", mensaje_js, funcionJs);

            ScriptManager.RegisterStartupScript(page, page.GetType(), "ShowStatus", mensaje_js, true);
        }

        public static string txtNull(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return "null";

            else
                return string.Format("'{0}'", value);

        }



        /// <summary>
        /// Envía la notificacion de ADVERTENCIA directo al UI, registra en el console log del cliente el objeto requerido y opcionalmente llamar a una función JS
        /// </summary>
        /// <param name="page">Parámetro 'this'del controlador UI</param>
        /// <param name="response">'response' de los servicios</param>
        /// <param name="objectLogCliente">Objeto que se enviará al console.log del cliente</param>
        /// <param name="funcionJs">Opcional, si se requiere ejecutar alguna función JS adicional</param>
        /// <param name="titulo">Opcional, Texto del título</param>
        /// <param name="posicion">Opcional, top, top-start, top-end, center, center-start, center-end, bottom, bottom-start, or bottom-end. Default top</param>
        /// <returns>https://sweetalert2.github.io/#icons</returns>
        public static void jsAdvertenciaLog(Page page, string mensaje, Object objectLogCliente, string funcionJs = null, string titulo = "Advertencia", string posicion = "top")
        {


            string mensaje_js = AlertasJS.mensaje_str("warning", titulo, mensaje, posicion);

            if (objectLogCliente != null)
                mensaje_js = string.Format("{0};console.log({1});", mensaje_js, JsonConvert.SerializeObject(objectLogCliente));

            if (funcionJs != null)
                mensaje_js = string.Format("{0}{1};", mensaje_js, funcionJs);

            ScriptManager.RegisterStartupScript(page, page.GetType(), "ShowStatus", mensaje_js, true);
        }

        public static void js_exErrorPage(Page page, string ex_str)
        {

            string mensaje_js = string.Format("console.log({0});", ex_str);
            //ToDo enviar un mail de error con el objeto de expeción general
            ScriptManager.RegisterStartupScript(page, page.GetType(), "ShowStatus", mensaje_js, true);
        }


    }
}
