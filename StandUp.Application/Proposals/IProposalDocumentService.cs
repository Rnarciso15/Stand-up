namespace StandUp.Application.Proposals;

public interface IProposalDocumentService
{
    Task<ProposalDocumentDto> GenerateAsync(int saleTransactionId, DateTime validUntilUtc, CancellationToken cancellationToken);
    Task<IReadOnlyList<ProposalDocumentDto>> GetBySaleTransactionAsync(int saleTransactionId, CancellationToken cancellationToken);
    Task<byte[]?> GetPdfBytesAsync(int proposalId, CancellationToken cancellationToken);
}
