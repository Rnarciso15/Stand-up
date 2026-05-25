using Microsoft.EntityFrameworkCore;
using StandUp.Application.Abstractions;
using StandUp.Domain.Entities;

namespace StandUp.Infrastructure.Persistence;

public sealed class SaleTransactionRepository : ISaleTransactionRepository
{
    private readonly StandUpDbContext _dbContext;

    public SaleTransactionRepository(StandUpDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<SaleTransaction> AddAsync(SaleTransaction transaction, CancellationToken cancellationToken)
    {
        _dbContext.SaleTransactions.Add(transaction);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return transaction;
    }

    public async Task<IReadOnlyList<SaleTransaction>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _dbContext.SaleTransactions
            .OrderByDescending(x => x.TransactionDate)
            .ToListAsync(cancellationToken);
    }

    public Task<SaleTransaction?> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        return _dbContext.SaleTransactions.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task<IReadOnlyList<SaleTransaction>> SearchByLicensePlateAsync(string licensePlate, CancellationToken cancellationToken)
    {
        var plate = licensePlate.Trim().ToUpperInvariant();
        return await _dbContext.SaleTransactions
            .Where(x => x.VehicleLicensePlate.Contains(plate))
            .OrderByDescending(x => x.TransactionDate)
            .ToListAsync(cancellationToken);
    }
}
