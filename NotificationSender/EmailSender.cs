using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Options;

namespace NotificationSender;

public class EmailSender(IOptions<NotificationSettings> options) : INotificationSender
{
    private readonly NotificationSettings _settings = options.Value;

    public void SendNotification(string receiver, string subject, string message)
    {
        var sender = _settings.EmailId;
        var pw = _settings.Password;


        var client = new SmtpClient(_settings.Host)
        {
            Port = _settings.Port,
            EnableSsl = _settings.UseSSL,
            Credentials = new NetworkCredential(sender, pw)
        };

        message = DecorateMessage(message, _settings.UserName ?? "", _settings.Name ?? "");

        var mail = new MailMessage(sender, receiver, subject, message);
        client.Send(mail);
    }

    public string DecorateMessage(string message, string senderName, string organizationName) 
    {
        if(senderName != "") 
        {
            message += $"\nBest Regards \n{senderName}";
            if(organizationName != "")
                message += $"\n{organizationName}";
        }
        return message;
    }
}
