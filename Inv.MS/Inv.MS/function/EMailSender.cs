using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inv.MS.function
{
    public static class EMailSender
    {
        public static void Send(string email, int key)
        {
            MailMessage emailMessage = new MailMessage();
            try
            {
                var smtpClient = new SmtpClient("smtp.gmail.com", 587);
                smtpClient.EnableSsl = true;
                smtpClient.Timeout = 60 * 60;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential("invms561@gmail.com", "@0a497!AgZo20");

                emailMessage.From = new MailAddress("invms561@gmail.com", "Inv.MS");
                emailMessage.Body = "Seu codigo de recuperação de Senha" + key;
                emailMessage.Subject = "Recuperação de Senha";
                emailMessage.IsBodyHtml = true;
                emailMessage.Priority = MailPriority.Normal;
                emailMessage.To.Add(email);

                smtpClient.Send(emailMessage);
            }
            catch(Exception)
            {
                return;
            }
        }

    }
}
