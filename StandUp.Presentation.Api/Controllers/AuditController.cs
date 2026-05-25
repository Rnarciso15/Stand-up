using Microsoft.AspNetCore.Mvc;
using StandUp.Application.Abstractions;
using StandUp.Presentation.Api.Security;

namespace StandUp.Presentation.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[RequireRole("Admin")]
public sealed class AuditController : ControllerBase
{
    private readonly IAuditRepository _repository;

    public AuditController(IAuditRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<ActionResult<object>> Get(
        [FromQuery] DateTime? fromUtc,
        [FromQuery] DateTime? toUtc,
        [FromQuery] string? userRole,
        [FromQuery] string? entityName,
        [FromQuery] int take = 100,
        CancellationToken cancellationToken = default)
    {
        var logs = await _repository.GetAsync(fromUtc, toUtc, userRole, entityName, take, cancellationToken);
        var result = logs.Select(x => new
        {
            x.Id,
            x.UserRole,
            x.Action,
            x.EntityName,
            x.BeforeJson,
            x.AfterJson,
            x.TimestampUtc
        });

        return Ok(result);
    }
}
