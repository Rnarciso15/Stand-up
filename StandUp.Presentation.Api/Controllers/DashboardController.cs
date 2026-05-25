using Microsoft.AspNetCore.Mvc;
using StandUp.Application.Dashboard;
using StandUp.Presentation.Api.Security;

namespace StandUp.Presentation.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[RequireRole("Admin", "Vendedor")]
public sealed class DashboardController : ControllerBase
{
    private readonly IDashboardService _service;

    public DashboardController(IDashboardService service)
    {
        _service = service;
    }

    [HttpGet("kpis")]
    public Task<DashboardKpiDto> Get([FromQuery] DateTime fromUtc, [FromQuery] DateTime toUtc, CancellationToken cancellationToken)
        => _service.GetKpisAsync(fromUtc, toUtc, cancellationToken);
}
