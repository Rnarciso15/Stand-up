using StandUp.Application.Abstractions;
using StandUp.Domain.Entities;

namespace StandUp.Application.Proposals;

public sealed class ProposalDocumentService : IProposalDocumentService
{
    private readonly ISaleTransactionRepository _sales;
    private readonly IProposalRepository _proposals;
    private readonly IPdfProposalRenderer _renderer;

    public ProposalDocumentService(ISaleTransactionRepository sales, IProposalRepository proposals, IPdfProposalRenderer renderer)
    {
        _sales = sales;
        _proposals = proposals;
        _renderer = renderer;
    }

    public async Task<ProposalDocumentDto> GenerateAsync(int saleTransactionId, DateTime validUntilUtc, CancellationToken cancellationToken)
    {
        var sale = await _sales.GetByIdAsync(saleTransactionId, cancellationToken)
            ?? throw new InvalidOperationException("Venda nao encontrada.");

        var pdf = _renderer.Render(sale, validUntilUtc);
        var proposal = new ProposalDocument
        {
            SaleTransactionId = saleTransactionId,
            FileName = $"proposta_{saleTransactionId}_{DateTime.UtcNow:yyyyMMddHHmmss}.pdf",
            TemplateVersion = ProposalDocument.CurrentTemplateVersion,
            ValidUntilUtc = validUntilUtc,
            PdfBytes = pdf,
            CreatedAtUtc = DateTime.UtcNow
        };

        var created = await _proposals.AddAsync(proposal, cancellationToken);
        return Map(created);
    }

    public async Task<IReadOnlyList<ProposalDocumentDto>> GetBySaleTransactionAsync(int saleTransactionId, CancellationToken cancellationToken)
    {
        var list = await _proposals.GetBySaleTransactionAsync(saleTransactionId, cancellationToken);
        return list.Select(Map).ToList();
    }

    public async Task<byte[]?> GetPdfBytesAsync(int proposalId, CancellationToken cancellationToken)
    {
        return (await _proposals.GetByIdAsync(proposalId, cancellationToken))?.PdfBytes;
    }

    private static ProposalDocumentDto Map(ProposalDocument x) =>
        new(x.Id, x.SaleTransactionId, x.FileName, x.TemplateVersion, x.ValidUntilUtc, x.CreatedAtUtc);
}
