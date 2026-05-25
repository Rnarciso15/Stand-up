using StandUp.Application.Abstractions;
using StandUp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace StandUp.Infrastructure.Persistence;

public sealed class AuditRepository : IAuditRepository
{
    private readonly StandUpDbContext _dbContext;

    public AuditRepository(StandUpDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddAsync(AuditLog log, CancellationToken cancellationToken)
    {
        _dbContext.AuditLogs.Add(log);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<IReadOnlyList<AuditLog>> GetAsync(
        DateTime? fromUtc,
        DateTime? toUtc,
        string? userRole,
        string? entityName,
        int take,
        CancellationToken cancellationToken)
    {
        var query = _dbContext.AuditLogs.AsQueryable();

        if (fromUtc.HasValue) query = query.Where(x => x.TimestampUtc >= fromUtc.Value);
        if (toUtc.HasValue) query = query.Where(x => x.TimestampUtc <= toUtc.Value);
        if (!string.IsNullOrWhiteSpace(userRole)) query = query.Where(x => x.UserRole == userRole);
        if (!string.IsNullOrWhiteSpace(entityName)) query = query.Where(x => x.EntityName == entityName);

        var safeTake = Math.Clamp(take, 1, 500);
        return await query
            .OrderByDescending(x => x.TimestampUtc)
            .Take(safeTake)
            .ToListAsync(cancellationToken);
    }
}
