namespace StandUp.Domain.Entities;

public sealed class Appointment
{
    public int Id { get; set; }
    public DateTime DateOnly { get; set; }
    public DateTime DateTimeSlot { get; set; }
    public int EmployeeNumber { get; set; }
    public string EmployeeName { get; set; } = string.Empty;
    public int ClientId { get; set; }
    public string ClientName { get; set; } = string.Empty;
    public string VehicleBrand { get; set; } = string.Empty;
    public string VehicleModel { get; set; } = string.Empty;
    public string VehicleLicensePlate { get; set; } = string.Empty;
    public string? ClientPhone { get; set; }
    public bool SmsConsentGranted { get; set; }
    public DateTime? SmsConsentTimestampUtc { get; set; }
}
