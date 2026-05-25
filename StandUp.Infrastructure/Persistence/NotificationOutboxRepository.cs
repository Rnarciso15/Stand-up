using Microsoft.EntityFrameworkCore;
using StandUp.Application.Abstractions;
using StandUp.Domain.Entities;

namespace StandUp.Infrastructure.Persistence;

public sealed class NotificationOutboxRepository : INotificationOutboxRepository
{
    private readonly StandUpDbContext _dbContext;

    public NotificationOutboxRepository(StandUpDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddAsync(NotificationOutboxItem item, CancellationToken cancellationToken)
    {
        _dbContext.NotificationOutboxItems.Add(item);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<IReadOnlyList<NotificationOutboxItem>> GetDuePendingAsync(DateTime nowUtc, int limit, CancellationToken cancellationToken)
    {
        return await _dbContext.NotificationOutboxItems
            .Where(x => x.Status == "pending" && x.NextAttemptUtc <= nowUtc)
            .OrderBy(x => x.NextAttemptUtc)
            .Take(limit)
            .ToListAsync(cancellationToken);
    }

    public async Task UpdateAsync(NotificationOutboxItem item, CancellationToken cancellationToken)
    {
        _dbContext.NotificationOutboxItems.Update(item);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}
