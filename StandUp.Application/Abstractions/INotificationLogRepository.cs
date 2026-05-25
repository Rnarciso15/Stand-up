using StandUp.Domain.Entities;

namespace StandUp.Application.Abstractions;

public interface INotificationLogRepository
{
    Task AddAsync(NotificationLog log, CancellationToken cancellationToken);
    Task<bool> ExistsForAppointmentAndTypeAsync(int appointmentId, string type, CancellationToken cancellationToken);
}
