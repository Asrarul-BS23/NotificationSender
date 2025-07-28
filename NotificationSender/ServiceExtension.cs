using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace NotificationSender;
public static class NotificationServiceCollectionExtensions
{
    public static IServiceCollection AddNotifier(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<NotificationSettings>(configuration.GetSection("NotificationSettings"));
        services.AddScoped<INotificationSender, EmailSender>();
        return services;
    }
}

