using StandUp.Application.Abstractions;
using StandUp.Application.Notifications;

namespace StandUp.Presentation.Api.Background;

public sealed class AppointmentReminderBackgroundService : BackgroundService
{
    private readonly IServiceProvider _serviceProvider;
    private readonly ILogger<AppointmentReminderBackgroundService> _logger;

    public AppointmentReminderBackgroundService(IServiceProvider serviceProvider, ILogger<AppointmentReminderBackgroundService> logger)
    {
        _serviceProvider = serviceProvider;
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                await ProcessRemindersAsync(stoppingToken);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Reminder background service failed.");
            }

            await Task.Delay(TimeSpan.FromMinutes(5), stoppingToken);
        }
    }

    private async Task ProcessRemindersAsync(CancellationToken cancellationToken)
    {
        using var scope = _serviceProvider.CreateScope();
        var appointments = scope.ServiceProvider.GetRequiredService<IAppointmentRepository>();
        var notificationLogs = scope.ServiceProvider.GetRequiredService<INotificationLogRepository>();
        var notifications = scope.ServiceProvider.GetRequiredService<INotificationService>();

        var now = DateTime.UtcNow;
        await ProcessWindowAsync(appointments, notificationLogs, notifications, now.AddHours(23).AddMinutes(55), now.AddHours(24).AddMinutes(5), 24, cancellationToken);
        await ProcessWindowAsync(appointments, notificationLogs, notifications, now.AddHours(1).AddMinutes(55), now.AddHours(2).AddMinutes(5), 2, cancellationToken);
        await notifications.ProcessOutboxAsync(cancellationToken);
    }

    private static async Task ProcessWindowAsync(
        IAppointmentRepository appointments,
        INotificationLogRepository notificationLogs,
        INotificationService notifications,
        DateTime from,
        DateTime to,
        int hoursBefore,
        CancellationToken cancellationToken)
    {
        var list = await appointments.GetBetweenAsync(from, to, cancellationToken);
        var type = $"reminder_{hoursBefore}h";
        foreach (var appt in list)
        {
            var alreadySent = await notificationLogs.ExistsForAppointmentAndTypeAsync(appt.Id, type, cancellationToken);
            if (alreadySent) continue;
            await notifications.SendAppointmentReminderAsync(appt.Id, hoursBefore, cancellationToken);
        }
    }
}
