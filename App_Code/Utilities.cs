using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Mail;

/// <summary>
/// Summary description for Utilities
/// </summary>
public static class Utilities
{
    public static void SendMail(string from, string to, string subject, string body)
    {   //Mail gönderme kodu
        MailMessage mail = new MailMessage();
        // Mail a Şirket ismi vermek
        mail.From = new MailAddress(from);
        mail.To.Add(to);
        mail.Subject = subject;
        mail.Body = body;
        SmtpClient client = new SmtpClient(Configuration.MailServerHost, Configuration.MailServerPort);
        client.EnableSsl = true;
        client.Credentials = new NetworkCredential(Configuration.MailUserName, Configuration.MailUserPassword);
        client.Send(mail);

    }
    public static void LogError(Exception ex)
    {
        string dateTime = "Date : " + DateTime.Now.ToLongDateString() + ", Time: " + DateTime.Now.ToLongTimeString();
        string errorMessage = "Error Occur Date: " + dateTime;
        System.Web.HttpContext context = System.Web.HttpContext.Current;
        errorMessage += "\n\n Page Location: " + context.Request.RawUrl;
        errorMessage += "\n\n Error Message: " + ex.Message;
        errorMessage += "\n\n Source: " + ex.Source;
        string from = Configuration.MailUserName;
        string to = Configuration.ErrorMail;
        string subject = "Error";
        SendMail(from, to, subject, errorMessage);

    }
    public static int Integer(this string a)
    {
        return Convert.ToInt32(a);

    }
}