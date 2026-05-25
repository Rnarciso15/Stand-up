namespace StandUp.Application.Sales;

public interface ISaleTransactionService
{
    Task<SaleTransactionDto> CreateAsync(CreateSaleTransactionRequest request, CancellationToken cancellationToken);
    Task<IReadOnlyList<SaleTransactionDto>> GetAllAsync(CancellationToken cancellationToken);
    Task<IReadOnlyList<SaleTransactionDto>> SearchByLicensePlateAsync(string licensePlate, CancellationToken cancellationToken);
}
