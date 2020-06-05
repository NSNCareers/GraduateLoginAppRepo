using System.Net.Mail;
using System.Net;
using Microsoft.AspNetCore.Identity.UI.Services;
using System.Threading.Tasks;
using System;

namespace LoginApp.EmailSenders
{
    public class EmailSender : IEmailSender
    {
        private readonly EmailConfiguration _emailConfig;

        public EmailSender(EmailConfiguration emailConfig)
        {
            _emailConfig = emailConfig;
        }

        public async Task SendEmailAsync(string email, string subjects, string htmlMessage)
        {
            var email1 = "snscareers@yahoo.com";
            var email3 = "NSNCareers@outlook.com";
            var fromAddress = new MailAddress(_emailConfig.From);
            var toAddress = new MailAddress(email);
            string fromPassword = _emailConfig.Password;
            string subject = subjects;
            string body = htmlMessage;
            SmtpClient smtp = null;

            try
            {
                smtp = new SmtpClient
                {
                    Host = _emailConfig.SmtpServer,
                    Port = _emailConfig.Port,
                    EnableSsl = _emailConfig.EnableSsl,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    Credentials = new NetworkCredential(fromAddress.Address, fromPassword),
                    Timeout = _emailConfig.Timeout
                };

                using (var message = new MailMessage(fromAddress, toAddress)
                {
                    Subject = subject,
                    Body = body
                })
                {
                    await smtp.SendMailAsync(message);
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                smtp.Dispose();
            }

        }
    }
}
