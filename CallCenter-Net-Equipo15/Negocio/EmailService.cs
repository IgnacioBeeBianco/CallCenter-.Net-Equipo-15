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
            server.Credentials = new NetworkCredential();
            server.EnableSsl = true;
            server.Port = 0;
            server.Host = "localhost";
        }

        public void armarCorreo(string correoDestino, string asunto, string cuerpo)
        {
            mail = new MailMessage();
            mail.From=new MailAddress("noresponder@callcentergrupo15.com");
            mail.To.Add(correoDestino);
            mail.Subject = asunto;
            mail.IsBodyHtml = true;
            mail.Body = "Se a registrado al Call Center para visualizar sus incidencias con exito";
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
