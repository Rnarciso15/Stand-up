namespace StandUp.Domain.Entities;

public sealed class NotificationLog
{
    public int Id { get; set; }
    public int AppointmentId { get; set; }
    public string PhoneNumber { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public int Attempts { get; set; }
    public string? ProviderMessageId { get; set; }
    public string? ErrorMessage { get; set; }
    public bool ConsentGranted { get; set; }
    public DateTime ConsentTimestampUtc { get; set; }
    public DateTime CreatedAtUtc { get; set; }
}
