namespace StandUp.Domain.Entities;

public sealed class AuditLog
{
    public int Id { get; set; }
    public string UserRole { get; set; } = string.Empty;
    public string Action { get; set; } = string.Empty;
    public string EntityName { get; set; } = string.Empty;
    public string? BeforeJson { get; set; }
    public string? AfterJson { get; set; }
    public DateTime TimestampUtc { get; set; }
}
