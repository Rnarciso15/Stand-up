namespace StandUp.Domain.Entities;

public sealed class Vehicle
{
    public int Id { get; set; }
    public string LicensePlate { get; set; } = string.Empty;
    public int Kilometers { get; set; }
    public DateTime? RegistrationDate { get; set; }
    public string Brand { get; set; } = string.Empty;
    public string Model { get; set; } = string.Empty;
    public string? Description { get; set; }
    public string? Fuel { get; set; }
    public int Price { get; set; }
    public string? Color { get; set; }
    public string? GearboxType { get; set; }
    public int? Doors { get; set; }
    public string? Traction { get; set; }
    public bool IsSold { get; set; }
    public bool IsMotorcycle { get; set; }
}
