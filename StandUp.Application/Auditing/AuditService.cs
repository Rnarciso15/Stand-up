using StandUp.Application.Abstractions;
using StandUp.Domain.Entities;

namespace StandUp.Application.Auditing;

public sealed class AuditService : IAuditService
{
    private readonly IAuditRepository _repository;

    public AuditService(IAuditRepository repository)
    {
        _repository = repository;
    }

    public Task LogAsync(AuditEntryRequest entry, CancellationToken cancellationToken)
    {
        var log = new AuditLog
        {
            UserRole = entry.UserRole,
            Action = entry.Action,
            EntityName = entry.EntityName,
            BeforeJson = entry.BeforeJson,
            AfterJson = entry.AfterJson,
            TimestampUtc = DateTime.UtcNow
        };
        return _repository.AddAsync(log, cancellationToken);
    }
}
