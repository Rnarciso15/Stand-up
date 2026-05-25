using StandUp.Application.Abstractions;
using StandUp.Domain.Entities;

namespace StandUp.Application.Sales;

public sealed class SaleTransactionService : ISaleTransactionService
{
    private readonly ISaleTransactionRepository _transactionRepository;
    private readonly IVehicleRepository _vehicleRepository;

    public SaleTransactionService(ISaleTransactionRepository transactionRepository, IVehicleRepository vehicleRepository)
    {
        _transactionRepository = transactionRepository;
        _vehicleRepository = vehicleRepository;
    }

    public async Task<SaleTransactionDto> CreateAsync(CreateSaleTransactionRequest request, CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(request.ClientNif) || string.IsNullOrWhiteSpace(request.VehicleLicensePlate))
        {
            throw new ArgumentException("NIF e matrícula são obrigatórios.");
        }

        var transaction = new SaleTransaction
        {
            ClientNif = request.ClientNif.Trim(),
            VehicleLicensePlate = request.VehicleLicensePlate.Trim().ToUpperInvariant(),
            TransactionDate = request.TransactionDate,
            Value = request.Value,
            ClientName = request.ClientName.Trim()
        };

        var created = await _transactionRepository.AddAsync(transaction, cancellationToken);
        await _vehicleRepository.SetSoldAsync(created.VehicleLicensePlate, true, cancellationToken);

        return Map(created);
    }

    public async Task<IReadOnlyList<SaleTransactionDto>> GetAllAsync(CancellationToken cancellationToken)
    {
        var list = await _transactionRepository.GetAllAsync(cancellationToken);
        return list.Select(Map).ToList();
    }

    public async Task<IReadOnlyList<SaleTransactionDto>> SearchByLicensePlateAsync(string licensePlate, CancellationToken cancellationToken)
    {
        var list = await _transactionRepository.SearchByLicensePlateAsync(licensePlate, cancellationToken);
        return list.Select(Map).ToList();
    }

    private static SaleTransactionDto Map(SaleTransaction x) =>
        new(x.Id, x.ClientNif, x.VehicleLicensePlate, x.TransactionDate, x.Value, x.ClientName);
}
