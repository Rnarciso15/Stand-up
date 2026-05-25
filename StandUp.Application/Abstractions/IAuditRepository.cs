using StandUp.Domain.Entities;

namespace StandUp.Application.Abstractions;

public interface IAuditRepository
{
    Task AddAsync(AuditLog log, CancellationToken cancellationToken);
    Task<IReadOnlyList<AuditLog>> GetAsync(DateTime? fromUtc, DateTime? toUtc, string? userRole, string? entityName, int take, CancellationToken cancellationToken);
}
