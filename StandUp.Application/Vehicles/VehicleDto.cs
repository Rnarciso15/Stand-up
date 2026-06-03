namespace StandUp.Application.Vehicles;

public sealed record VehicleDto(
    string LicensePlate,
    int Kilometers,
    DateTime? RegistrationDate,
    string Brand,
    string Model,
    string? Fuel,
    int Price,
    bool IsSold,
    bool IsMotorcycle,
    DateTime? AddedAt = null);
