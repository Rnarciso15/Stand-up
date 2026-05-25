namespace StandUp.Application.Vehicles;

public sealed record CreateVehicleRequest(
    string LicensePlate,
    int Kilometers,
    DateTime? RegistrationDate,
    string Brand,
    string Model,
    string? Fuel,
    int Price,
    bool IsMotorcycle);
