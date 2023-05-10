using CapaEntidad;
using EASendMail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using MailAddress = System.Net.Mail.MailAddress;
using SmtpClient = System.Net.Mail.SmtpClient;

namespace CapaServicios
{
    public class CorreoElectronico
    {
        //public Resultado enviarCorreo(string strDe, string strPara, string strAsunto, string strMensaje, string strCC)
        //{
        //    Resultado resultado;


        //    try
        //    {
        //        String strServidor = Properties.Settings.Default.servidor_correo;
        //        int strPuertoServidor = int.Parse(Properties.Settings.Default.puerto_servidor_correo);
        //        String strUsuario = Properties.Settings.Default.usuario_correo;
        //        String strContrasenia = Properties.Settings.Default.contrasenia_correo;
        //        string strSslActivo = Properties.Settings.Default.enable_ssl;



        //        MailMessage mail = new MailMessage();
        //        mail.IsBodyHtml = true;
        //        mail.From = new MailAddress("cacsoporte247@gmail.com");

        //        string[] Destinatarios = strPara.ToString().Split(',');


        //        foreach (var itm in Destinatarios)
        //        {
        //            mail.To.Add(new MailAddress(itm.ToString(), ""));
        //        }


        //        mail.Subject = strAsunto;
        //        mail.Body = strMensaje;

        //        if (!string.IsNullOrEmpty(strCC) && strCC.Trim().Contains("@"))
        //        {
        //            string[] strCopia = strCC.ToString().Split(',');
        //            foreach (var itm in strCopia)
        //            {
        //                mail.CC.Add(new MailAddress(itm.ToString(), ""));
        //            }
        //        }

        //        using (SmtpClient smtp = new SmtpClient())
        //        {
        //            smtp.Host = "smtp.mail.yahoo.com";//strServidor;
        //            smtp.Port = 465;//strPuertoServidor;

        //            //if (strSslActivo == "1")
        //            //    smtp.EnableSsl = true;
        //            //else
        //            //    smtp.EnableSsl = false;


        //            System.Net.NetworkCredential NetworkCred = new System.Net.NetworkCredential();
        //            NetworkCred.UserName = "sistema";
        //            NetworkCred.Password = "emricxcawswdbqqc";

        //            //smtp.UseDefaultCredentials = false;

        //            smtp.Credentials = NetworkCred;
        //            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
        //            smtp.EnableSsl = true;


        //            //await smtp.SendMailAsync(mail);

        //            smtp.Send(mail);


        //            Resultado r = new Resultado();
        //            r.Codigo1 = "1";
        //            r.Mensaje1 = "Mensaje enviado correctamente";
        //            return r;
        //        }
        //    }



        //    catch (Exception e)
        //    {
        //        resultado = new Resultado();
        //        resultado.Codigo1 = "-1";
        //        resultado.Mensaje1 = e.Message;
        //    }

        //    return resultado;

        //}

        public Resultado enviarCorreo(string strDe, string strPara, string strAsunto, string strMensaje, string strCC)
        {
            Resultado resultado;

            try { 
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient();
                mail.To.Add("******");

              
                mail.From = new MailAddress("*****", (string)"Sorporte 247");
                mail.Subject = "Asunto";
                mail.IsBodyHtml = true; //to make message body as html  
                mail.Body = "Prueba";
                using (SmtpClient smtp = new SmtpClient())
                {
                    smtp.UseDefaultCredentials = false;
                    smtp.Host = "smtp.gmail.com"; // "172.17.1.208";
                    smtp.Port = int.Parse("587");
                    smtp.EnableSsl = true;
                    System.Net.NetworkCredential NetworkCred = new System.Net.NetworkCredential();
                    NetworkCred.UserName = "******";
                    NetworkCred.Password = "******";
                    
                    smtp.Credentials = NetworkCred;
                    smtp.Send(mail);
                    smtp.Dispose();
       
                }


                Console.WriteLine("email was sent successfully!");
                Resultado r = new Resultado();
                r.Codigo1 = "1";
                r.Mensaje1 = "Mensaje enviado correctamente";
                return r;

            }
            catch (Exception e)
            {
                resultado = new Resultado();
                resultado.Codigo1 = "-1";
                resultado.Mensaje1 = e.Message;
            }

            return resultado;
        }
        //}
    }
}
