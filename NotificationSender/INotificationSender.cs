namespace NotificationSender;

public interface INotificationSender
{
    void SendNotification(string receiver, string subject, string message);
    string DecorateMessage(string message, string senderName, string organizationName);
}
