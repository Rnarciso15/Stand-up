namespace StandUp.Application.Sales;

public sealed record SaleTransactionDto(
    int Id,
    string ClientNif,
    string VehicleLicensePlate,
    DateTime TransactionDate,
    int Value,
    string ClientName);
