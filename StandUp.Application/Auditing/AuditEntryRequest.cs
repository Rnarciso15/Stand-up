namespace StandUp.Application.Auditing;

public sealed record AuditEntryRequest(
    string UserRole,
    string Action,
    string EntityName,
    string? BeforeJson,
    string? AfterJson);
