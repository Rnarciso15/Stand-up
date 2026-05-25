using Microsoft.AspNetCore.Mvc;
using StandUp.Application.Auditing;
using StandUp.Application.Sales;
using StandUp.Presentation.Api.Security;

namespace StandUp.Presentation.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[RequireRole("Admin", "Vendedor")]
public sealed class SalesController : ControllerBase
{
    private readonly ISaleTransactionService _service;
    private readonly IAuditService _auditService;

    public SalesController(ISaleTransactionService service, IAuditService auditService)
    {
        _service = service;
        _auditService = auditService;
    }

    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<SaleTransactionDto>>> GetAll(CancellationToken cancellationToken)
    {
        return Ok(await _service.GetAllAsync(cancellationToken));
    }

    [HttpGet("search")]
    public async Task<ActionResult<IReadOnlyList<SaleTransactionDto>>> SearchByPlate([FromQuery] string licensePlate, CancellationToken cancellationToken)
    {
        return Ok(await _service.SearchByLicensePlateAsync(licensePlate, cancellationToken));
    }

    [HttpPost]
    public async Task<ActionResult<SaleTransactionDto>> Create([FromBody] CreateSaleTransactionRequest request, CancellationToken cancellationToken)
    {
        var created = await _service.CreateAsync(request, cancellationToken);
        await _auditService.LogAsync(new AuditEntryRequest(GetRole(), "create", "sale", null, System.Text.Json.JsonSerializer.Serialize(created)), cancellationToken);
        return CreatedAtAction(nameof(GetAll), new { id = created.Id }, created);
    }

    private string GetRole() => HttpContext.Request.Headers["X-User-Role"].FirstOrDefault() ?? "Unknown";
}
