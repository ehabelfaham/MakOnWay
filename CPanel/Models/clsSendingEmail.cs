using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;

namespace CPanel.Models
{
    public class clsSendingEmail
    {
        public static bool SendingListEmails(String to, string subject, String Message)
        {
            try
            {
                MailMessage mail = new MailMessage();
                mail.To.Add(to);
                mail.From = new MailAddress("webmaster@marcomtrade.com");
                mail.Subject = string.Format("From {0} ", "marcom Trade");
                mail.Subject = subject;
                string Body = Message;
                mail.Body = Body;
                mail.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "mail.marcomtrade.com";
                smtp.Port = 25;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new System.Net.NetworkCredential("webmaster@marcomtrade.com", "w@bm@r15");
                smtp.Send(mail);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}