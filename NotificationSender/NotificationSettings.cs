namespace NotificationSender;

public class NotificationSettings
{
    public required string EmailId { get; set; }
    public string? Name { get; set; }
    public string? UserName { get; set; }
    public required string Password { get; set; }
    public required string Host { get; set; }
    public int Port { get; set; }
    public bool UseSSL { get; set; }
}
