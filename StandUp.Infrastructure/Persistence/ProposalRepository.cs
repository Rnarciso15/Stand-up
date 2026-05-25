using Microsoft.EntityFrameworkCore;
using StandUp.Application.Abstractions;
using StandUp.Domain.Entities;

namespace StandUp.Infrastructure.Persistence;

public sealed class ProposalRepository : IProposalRepository
{
    private readonly StandUpDbContext _dbContext;

    public ProposalRepository(StandUpDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<ProposalDocument> AddAsync(ProposalDocument proposal, CancellationToken cancellationToken)
    {
        _dbContext.ProposalDocuments.Add(proposal);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return proposal;
    }

    public async Task<IReadOnlyList<ProposalDocument>> GetBySaleTransactionAsync(int saleTransactionId, CancellationToken cancellationToken)
    {
        return await _dbContext.ProposalDocuments
            .Where(x => x.SaleTransactionId == saleTransactionId)
            .OrderByDescending(x => x.CreatedAtUtc)
            .ToListAsync(cancellationToken);
    }

    public Task<ProposalDocument?> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        return _dbContext.ProposalDocuments.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }
}
