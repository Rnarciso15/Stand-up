using StandUp.Domain.Entities;

namespace StandUp.Application.Abstractions;

public interface ISaleTransactionRepository
{
    Task<SaleTransaction> AddAsync(SaleTransaction transaction, CancellationToken cancellationToken);
    Task<SaleTransaction?> GetByIdAsync(int id, CancellationToken cancellationToken);
    Task<IReadOnlyList<SaleTransaction>> GetAllAsync(CancellationToken cancellationToken);
    Task<IReadOnlyList<SaleTransaction>> SearchByLicensePlateAsync(string licensePlate, CancellationToken cancellationToken);
}
