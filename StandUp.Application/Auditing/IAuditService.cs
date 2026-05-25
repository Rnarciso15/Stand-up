namespace StandUp.Application.Auditing;

public interface IAuditService
{
    Task LogAsync(AuditEntryRequest entry, CancellationToken cancellationToken);
}
