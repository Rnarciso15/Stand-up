using StandUp.Domain.Entities;

namespace StandUp.Application.Abstractions;

public interface INotificationOutboxRepository
{
    Task AddAsync(NotificationOutboxItem item, CancellationToken cancellationToken);
    Task<IReadOnlyList<NotificationOutboxItem>> GetDuePendingAsync(DateTime nowUtc, int limit, CancellationToken cancellationToken);
    Task UpdateAsync(NotificationOutboxItem item, CancellationToken cancellationToken);
}
