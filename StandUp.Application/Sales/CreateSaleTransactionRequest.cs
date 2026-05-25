namespace StandUp.Application.Sales;

public sealed record CreateSaleTransactionRequest(
    string ClientNif,
    string VehicleLicensePlate,
    DateTime TransactionDate,
    int Value,
    string ClientName);
