using Management.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Management.Application.Services
{
    public class EmailSender : IEmailSenderRepository
    {
        public EmailSender()
        {

        }

        public Task SendEmail(string email, string subject, string htmlMessage)
        {
            string fromMail = "gihun2da@naver.com";
            string fromPassword = "Acrophobia8!";

            MailMessage message = new MailMessage();
            message.From = new MailAddress(fromMail);
            message.Subject = subject;
            message.To.Add(new MailAddress(email));
            message.Body = "<html><body>" + htmlMessage + "</body></html>";
            message.IsBodyHtml = true;

            var smtpClient = new SmtpClient("smtp.naver.com")
            {
                Port = 587,
                Credentials = new NetworkCredential(fromMail, fromPassword),
                EnableSsl = true,
            };
            smtpClient.Send(message);

            return Task.CompletedTask;
        }



    }
}
