
using CapaEntidad;
using MailKit.Net.Smtp;
using MimeKit;
using System.Collections.Generic;
using System.Linq;

namespace CapaServicios
{
    public static class CorreoElectronico
    {
        public static void enviar(string remitente, string para, string asunto, string mensaje, string cc, string plantilla, Dictionary <string, string> valores)
        {
            List<parametro_configuracion> parametros = new List<parametro_configuracion>();
            try
            {
                CrudGenerico<parametro_configuracion> crud = new CrudGenerico<parametro_configuracion>();
                
                parametros = crud.ObtenerTodos(p => p.grupo == "CORREO_ELECTRONICO");
                parametro_configuracion plantillaCorreo = parametros.Where(p => p.nombre == plantilla).FirstOrDefault();
                parametro_configuracion servidor = parametros.Where(p => p.nombre == "SERVIDOR").FirstOrDefault();

                Resultado resultado = new Resultado();
                var email = new MimeMessage();
                string plantillaHtml = plantillaCorreo.valor_html;
                foreach (var itm in valores)
                {
                    plantillaHtml = plantillaHtml.Replace(itm.Key, itm.Value);
                }

                email.From.Add(new MailboxAddress("Sender Name", remitente));
                email.To.Add(new MailboxAddress("Receiver Name", para));

                email.Subject = asunto;
                email.Body = new TextPart(MimeKit.Text.TextFormat.Html)
                {
                    Text = plantillaHtml
                };

                using (var smtp = new SmtpClient())
                {
                    smtp.Connect(servidor.valor, (int)servidor.valor_numerico, false);

                    // Note: only needed if the SMTP server requires authentication
                    //smtp.Authenticate(servidor.valor, servidor.valor_clave);
                    smtp.Authenticate("", "");
                    smtp.Send(email);
                    smtp.Disconnect(true);
                }
                
            }
            catch (System.Exception ex)
            {

                throw ex;
            }
            
        }
  

    }
}




