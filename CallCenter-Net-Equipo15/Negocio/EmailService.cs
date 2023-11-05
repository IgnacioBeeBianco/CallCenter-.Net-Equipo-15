using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class EmailService
    {
        private MailMessage mail;
        private SmtpClient server;

        public EmailService()
        {
            server = new SmtpClient();
            server.Credentials = new NetworkCredential("f887163ae3399c", "fbe92c8145dda9");//Cambiar la credencial para que ande
            server.EnableSsl = true;
            server.Port = 2525;
            server.Host = "sandbox.smtp.mailtrap.io";
        }

        public void armarCorreo(string correoDestino, string asunto, string cuerpo)
        {
            mail = new MailMessage();
            mail.From=new MailAddress("noresponder@callcentergrupo15.com");
            mail.To.Add(correoDestino);
            mail.Subject = asunto;
            mail.IsBodyHtml = true;
            mail.Body = cuerpo;
        }

        public void enviarEmail()
        {
            try
            {
                server.Send(mail);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}
