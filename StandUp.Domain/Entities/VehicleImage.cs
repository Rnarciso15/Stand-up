namespace StandUp.Domain.Entities;

public sealed class VehicleImage
{
    public int Id { get; set; }
    public string VehicleLicensePlate { get; set; } = string.Empty;
    public byte[] Data { get; set; } = [];
    public DateTime CreatedAt { get; set; }
}
