using StandUp.Application.Abstractions;
using StandUp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace StandUp.Infrastructure.Persistence;

public sealed class NotificationLogRepository : INotificationLogRepository
{
    private readonly StandUpDbContext _dbContext;

    public NotificationLogRepository(StandUpDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddAsync(NotificationLog log, CancellationToken cancellationToken)
    {
        _dbContext.NotificationLogs.Add(log);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public Task<bool> ExistsForAppointmentAndTypeAsync(int appointmentId, string type, CancellationToken cancellationToken)
    {
        return _dbContext.NotificationLogs.AnyAsync(
            x => x.AppointmentId == appointmentId && x.Type == type && x.Status == "sent",
            cancellationToken);
    }
}
