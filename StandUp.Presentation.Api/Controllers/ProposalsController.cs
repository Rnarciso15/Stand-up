using Microsoft.AspNetCore.Mvc;
using StandUp.Application.Proposals;
using StandUp.Presentation.Api.Security;

namespace StandUp.Presentation.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[RequireRole("Admin", "Vendedor")]
public sealed class ProposalsController : ControllerBase
{
    private readonly IProposalDocumentService _service;

    public ProposalsController(IProposalDocumentService service)
    {
        _service = service;
    }

    [HttpPost("{saleTransactionId:int}")]
    public Task<ProposalDocumentDto> Generate(int saleTransactionId, [FromQuery] DateTime validUntilUtc, CancellationToken cancellationToken)
        => _service.GenerateAsync(saleTransactionId, validUntilUtc, cancellationToken);

    [HttpGet("{saleTransactionId:int}")]
    public Task<IReadOnlyList<ProposalDocumentDto>> GetBySale(int saleTransactionId, CancellationToken cancellationToken)
        => _service.GetBySaleTransactionAsync(saleTransactionId, cancellationToken);

    [HttpGet("download/{proposalId:int}")]
    [HttpGet("{proposalId:int}/download")]
    public async Task<IActionResult> Download(int proposalId, CancellationToken cancellationToken)
    {
        var bytes = await _service.GetPdfBytesAsync(proposalId, cancellationToken);
        return bytes is null ? NotFound() : File(bytes, "application/pdf", $"proposal_{proposalId}.pdf");
    }
}
