using Microsoft.AspNetCore.Mvc;
using StandUp.Application.Auditing;
using StandUp.Application.Vehicles;
using StandUp.Presentation.Api.Security;

namespace StandUp.Presentation.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[RequireRole("Admin", "Vendedor", "Rececao")]
public sealed class VehiclesController : ControllerBase
{
    private readonly IVehicleService _vehicleService;
    private readonly IAuditService _auditService;

    public VehiclesController(IVehicleService vehicleService, IAuditService auditService)
    {
        _vehicleService = vehicleService;
        _auditService = auditService;
    }

    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<VehicleDto>>> GetAll([FromQuery] bool isSold = false, CancellationToken cancellationToken = default)
    {
        return Ok(await _vehicleService.GetAllAsync(isSold, cancellationToken));
    }

    [HttpGet("search")]
    public async Task<ActionResult<IReadOnlyList<VehicleDto>>> Search([FromQuery] string licensePlate, [FromQuery] bool isSold = false, CancellationToken cancellationToken = default)
    {
        return Ok(await _vehicleService.SearchByLicensePlateAsync(licensePlate, isSold, cancellationToken));
    }

    [HttpPost]
    public async Task<ActionResult<VehicleDto>> Create([FromBody] CreateVehicleRequest request, CancellationToken cancellationToken)
    {
        var created = await _vehicleService.CreateAsync(request, cancellationToken);
        await _auditService.LogAsync(new AuditEntryRequest(GetRole(), "create", "vehicle", null, System.Text.Json.JsonSerializer.Serialize(created)), cancellationToken);
        return CreatedAtAction(nameof(GetAll), new { licensePlate = created.LicensePlate }, created);
    }

    [HttpPatch("{licensePlate}/sold")]
    public async Task<IActionResult> SetSold(string licensePlate, [FromQuery] bool isSold, CancellationToken cancellationToken)
    {
        var updated = await _vehicleService.SetSoldAsync(licensePlate, isSold, cancellationToken);
        if (updated) await _auditService.LogAsync(new AuditEntryRequest(GetRole(), "update_sold", "vehicle", null, $"{{\"licensePlate\":\"{licensePlate}\",\"isSold\":{isSold.ToString().ToLowerInvariant()}}}"), cancellationToken);
        return updated ? NoContent() : NotFound();
    }

    [HttpGet("brands")]
    public async Task<ActionResult<IReadOnlyList<string>>> GetBrands(CancellationToken cancellationToken = default)
    {
        var vehicles = await _vehicleService.GetAllAsync(false, cancellationToken);
        var brands = vehicles
            .Select(v => v.Brand)
            .Distinct()
            .OrderBy(b => b)
            .ToList();
        return Ok(brands);
    }

    [HttpGet("advanced")]
    [HttpGet("search-advanced")]
    public async Task<ActionResult<IReadOnlyList<VehicleDto>>> AdvancedSearch(
        [FromQuery] string? brand,
        [FromQuery] string? model,
        [FromQuery] string? fuel,
        [FromQuery] int? kmMin,
        [FromQuery] int? kmMax,
        [FromQuery] int? priceMin,
        [FromQuery] int? priceMax,
        [FromQuery] string? color,
        [FromQuery] bool? isMotorcycle,
        [FromQuery] bool isSold = false,
        [FromQuery] int page = 1,
        [FromQuery] int pageSize = 25,
        [FromQuery] string? sortBy = "price",
        [FromQuery] bool desc = false,
        CancellationToken cancellationToken = default)
    {
        var safePage = Math.Max(1, page);
        var safePageSize = Math.Clamp(pageSize, 1, 100);
        var safeSortBy = (sortBy ?? "price").ToLowerInvariant() switch
        {
            "price" => "price",
            "km" => "km",
            "date" => "date",
            _ => "price"
        };

        var filter = new VehicleSearchFilter(brand, model, fuel, kmMin, kmMax, priceMin, priceMax, color, isMotorcycle, isSold, safePage, safePageSize, safeSortBy, desc);
        return Ok(await _vehicleService.SearchAdvancedAsync(filter, cancellationToken));
    }

    private string GetRole() => HttpContext.Request.Headers["X-User-Role"].FirstOrDefault() ?? "Unknown";
}
