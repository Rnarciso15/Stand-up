namespace StandUp.Application.Notifications;

public interface INotificationService
{
    Task<NotificationResultDto> SendAppointmentConfirmationAsync(int appointmentId, CancellationToken cancellationToken);
    Task<NotificationResultDto> SendAppointmentReminderAsync(int appointmentId, int hoursBefore, CancellationToken cancellationToken);
    Task<NotificationResultDto> SendAppointmentCancellationAsync(int appointmentId, CancellationToken cancellationToken);
    Task<int> ProcessOutboxAsync(CancellationToken cancellationToken);
}
