using Microsoft.AspNetCore.Mvc;
using StandUp.Application.Auditing;
using StandUp.Application.Clients;
using StandUp.Presentation.Api.Security;

namespace StandUp.Presentation.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[RequireRole("Admin", "Vendedor", "Rececao")]
public sealed class ClientsController : ControllerBase
{
    private readonly IClientService _clientService;
    private readonly IAuditService _auditService;

    public ClientsController(IClientService clientService, IAuditService auditService)
    {
        _clientService = clientService;
        _auditService = auditService;
    }

    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<ClientDto>>> GetAll(CancellationToken cancellationToken)
    {
        return Ok(await _clientService.GetAllAsync(cancellationToken));
    }

    [HttpGet("search")]
    public async Task<ActionResult<IReadOnlyList<ClientDto>>> Search([FromQuery] string name, CancellationToken cancellationToken)
    {
        return Ok(await _clientService.SearchByNameAsync(name, cancellationToken));
    }

    [HttpPost]
    public async Task<ActionResult<ClientDto>> Create([FromBody] CreateClientRequest request, CancellationToken cancellationToken)
    {
        var created = await _clientService.CreateAsync(request, cancellationToken);
        await _auditService.LogAsync(new AuditEntryRequest(GetRole(), "create", "client", null, System.Text.Json.JsonSerializer.Serialize(created)), cancellationToken);
        return CreatedAtAction(nameof(GetAll), new { id = created.Id }, created);
    }

    [HttpPatch("{id:int}/active")]
    public async Task<IActionResult> SetActive(int id, [FromQuery] bool isActive, CancellationToken cancellationToken)
    {
        var updated = await _clientService.SetActiveAsync(id, isActive, cancellationToken);
        if (updated) await _auditService.LogAsync(new AuditEntryRequest(GetRole(), "update_active", "client", null, $"{{\"id\":{id},\"isActive\":{isActive.ToString().ToLowerInvariant()}}}"), cancellationToken);
        return updated ? NoContent() : NotFound();
    }

    private string GetRole() => HttpContext.Request.Headers["X-User-Role"].FirstOrDefault() ?? "Unknown";
}
