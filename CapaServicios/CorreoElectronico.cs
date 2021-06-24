using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace CapaServicios
{
    public class CorreoElectronico
    {
        public Resultado enviarCorreo(string strUsuarioDominio, int intOpcion, string strPara, string strInfo)
        {
            Resultado resultado;
            string strAsunto;
            string strMensaje;

            strAsunto = string.Empty;
            strMensaje = string.Empty;

            try
            {
                String strServidor = Properties.Settings.Default.servidor_correo;
                int strPuertoServidor = int.Parse(Properties.Settings.Default.puerto_servidor_correo);
                String strUsuario = Properties.Settings.Default.usuario_correo;
                String strContrasenia = Properties.Settings.Default.contrasenia_correo;
                string[] strDe = Properties.Settings.Default.correo_remitente.ToString().Split('|');


                if (intOpcion == 1)
                {
                    strAsunto = "Correos del Ecuador CDE EP. - Restablecer contraseña";
                    strMensaje = "<body style=\"margin:0px;font-family:Arial, Helvetica, sans-serif;font-size:12px;\">" + "Estimado usuario.<br /><br />"
                            + "    En base a su solicitud el sistema ha procedido a asignarle una contraseña temporal." + "<br>" + "<br>" + "<b>Usuario: </b>" + strUsuarioDominio + "<br>" + "<b>Contraseña: </b>" + strInfo + "<br>" + "<br>" + "<p  style=\"color:red;font-weight:bold;\">Por favor recuerde cambiar su contraseña, para lo cual debe ingresar la contraseña temporal asignada<br /></p>" + "<br>" + "Recuerda que para mayor seguridad tu contraseña debe incluir al menos una letra en mayúscula, minúscula y un dígito." + "<br>" + "<br>" + "<b>Saludos,</b>" + "<br>" + "<b>Correos del Ecuador CDE EP</b>" + "<br>" + "<br>" + "Este correo electrónico fue generado automáticamente, por favor no responda al mismo. Si Necesita Mayor Información Por Favor Comunicarse : Al 1700 CORREO (267736)";
                }
                else if (intOpcion == 2)
                {
                    strAsunto = "Correos del Ecuador CDE EP. - Cambio de Contraseña";
                    strMensaje = "<body style=\"margin:0px;font-family:Arial, Helvetica, sans-serif;font-size:12px;\">" + "Estimado usuario.<br /><br />"
                            + "    Usted ha procedido a realizar el cambio de su contraseña." + "<br>" + "<br>" + "<b>Usuario: </b>" + strUsuarioDominio + "<br>" + "<p  style=\"color:red;font-weight:bold;\">Por favor recuerde cambiar su contraseña periodicamente<br /></p>" + "<br>" + "<b>Saludos,</b>" + "<br>" + "<b>Correos del Ecuador CDE EP</b>" + "<br>" + "<br>" + "Este correo electrónico fue generado automáticamente, por favor no responda al mismo. Si Necesita Mayor Información Por Favor Comunicarse : Al 1700 CORREO (267736)";
                }




                MailMessage mail = new MailMessage();
                mail.IsBodyHtml = true;
                mail.From = new MailAddress(strDe[0].ToString(), strDe[1].ToString());
                mail.To.Add(new MailAddress(strPara, ""));
                mail.Subject = strAsunto;
                mail.Body = strMensaje;
                mail.CC.Add(new MailAddress(strDe[0].ToString(), strDe[1].ToString()));
                using (SmtpClient smtp = new SmtpClient())
                {
                    smtp.Host = strServidor; // "172.17.1.208";
                    smtp.Port = strPuertoServidor; // 25;
                    //smtp.EnableSsl = true;
                    System.Net.NetworkCredential NetworkCred = new System.Net.NetworkCredential();
                    NetworkCred.UserName = strUsuario;
                    NetworkCred.Password = strContrasenia;
                    smtp.UseDefaultCredentials = true;
                    smtp.Credentials = NetworkCred;
                    smtp.Send(mail);
                    Resultado r = new Resultado();
                    r.Codigo1 = "1";
                    r.Mensaje1 = "Mensaje enviado correctamente";
                    return r;
                }
            }



            catch (Exception e)
            {
                resultado = new Resultado();
                resultado.Codigo1 = "-1";
                resultado.Mensaje1 = e.Message;
            }

            return resultado;

        }

    }
}
