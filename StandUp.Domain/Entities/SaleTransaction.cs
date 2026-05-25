namespace StandUp.Domain.Entities;

public sealed class SaleTransaction
{
    public int Id { get; set; }
    public string ClientNif { get; set; } = string.Empty;
    public string VehicleLicensePlate { get; set; } = string.Empty;
    public DateTime TransactionDate { get; set; }
    public int Value { get; set; }
    public string ClientName { get; set; } = string.Empty;
}
