namespace StandUp.Application.Appointments;

public sealed record CreateAppointmentRequest(
    DateTime DateTimeSlot,
    int EmployeeNumber,
    string EmployeeName,
    int ClientId,
    string ClientName,
    string? ClientPhone,
    bool SmsConsentGranted,
    string VehicleBrand,
    string VehicleModel,
    string VehicleLicensePlate);
