using StandUp.Domain.Entities;

namespace StandUp.Application.Abstractions;

public interface IProposalRepository
{
    Task<ProposalDocument> AddAsync(ProposalDocument proposal, CancellationToken cancellationToken);
    Task<IReadOnlyList<ProposalDocument>> GetBySaleTransactionAsync(int saleTransactionId, CancellationToken cancellationToken);
    Task<ProposalDocument?> GetByIdAsync(int id, CancellationToken cancellationToken);
}
