namespace StandUp.Domain.Entities;

public sealed class NotificationOutboxItem
{
    public int Id { get; set; }
    public int AppointmentId { get; set; }
    public string Type { get; set; } = string.Empty;
    public string Prefix { get; set; } = string.Empty;
    public DateTime NextAttemptUtc { get; set; }
    public int AttemptCount { get; set; }
    public int MaxAttempts { get; set; } = 5;
    public string Status { get; set; } = "pending";
    public string? LastError { get; set; }
    public DateTime CreatedAtUtc { get; set; }
    public DateTime UpdatedAtUtc { get; set; }
}
