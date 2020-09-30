using API.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace API.Services
{
    public class SendEmailService
    {
        public void SendEmail(SendEmailVM sendEmailVM)
        {
            using (var message = new MailMessage())
            {
                message.To.Add(new MailAddress(sendEmailVM.Email));
                message.From = new MailAddress("royceda9522@gmail.com", "System Admin");
                message.Subject = sendEmailVM.Subject;
                message.Body = sendEmailVM.Body;
                message.IsBodyHtml = true;

                using (var client = new SmtpClient("smtp.gmail.com"))
                {
                    client.UseDefaultCredentials = false;
                    client.Port = 587;
                    client.Credentials = new NetworkCredential("royceda9522@gmail.com", "9522@EFal");
                    client.EnableSsl = true;
                    client.Send(message);
                }

            }

            
        }

        public void SendEmail2(string sendEmail)
        {
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
            mail.To.Add(new MailAddress(sendEmail));
            mail.From = new MailAddress("royceda9522@gmail.com", "NET CORE API");
            mail.Subject = "Canceled Booking" + DateTime.Now.ToString();
            mail.Body = "Dear" + sendEmail + ", <br><br>Please sign up using this code to your application :<br><br><b>";
            mail.IsBodyHtml = true;

            SmtpServer.UseDefaultCredentials = false;
            SmtpServer.Port = 587;
            SmtpServer.Credentials = new NetworkCredential("royceda9522@gmail.com", "9522@EFal");
            SmtpServer.EnableSsl = true;
            SmtpServer.Send(mail);

        }
    }
}
