using Microsoft.AspNetCore.Mvc;
using StandUp.Application.Auditing;
using StandUp.Application.Images;
using StandUp.Presentation.Api.Security;

namespace StandUp.Presentation.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[RequireRole("Admin", "Vendedor", "Rececao")]
public sealed class ImagesController : ControllerBase
{
    private readonly IImageService _service;
    private readonly IAuditService _auditService;

    public ImagesController(IImageService service, IAuditService auditService)
    {
        _service = service;
        _auditService = auditService;
    }

    [HttpGet("clients/{clientId:int}")]
    public async Task<ActionResult<IReadOnlyList<ImageDto>>> GetClientImages(int clientId, CancellationToken cancellationToken)
    {
        return Ok(await _service.GetClientImagesAsync(clientId, cancellationToken));
    }

    [HttpPost("clients/{clientId:int}")]
    public async Task<ActionResult<ImageDto>> AddClientImage(int clientId, [FromBody] byte[] data, CancellationToken cancellationToken)
    {
        var created = await _service.AddClientImageAsync(clientId, data, cancellationToken);
        await _auditService.LogAsync(new AuditEntryRequest(GetRole(), "upload", "client_image", null, $"{{\"clientId\":{clientId},\"imageId\":{created.Id}}}"), cancellationToken);
        return CreatedAtAction(nameof(GetClientImages), new { clientId }, created);
    }

    [HttpGet("vehicles/{licensePlate}")]
    public async Task<ActionResult<IReadOnlyList<ImageDto>>> GetVehicleImages(string licensePlate, CancellationToken cancellationToken)
    {
        return Ok(await _service.GetVehicleImagesAsync(licensePlate, cancellationToken));
    }

    [HttpPost("vehicles/{licensePlate}")]
    public async Task<ActionResult<ImageDto>> AddVehicleImage(string licensePlate, [FromBody] byte[] data, CancellationToken cancellationToken)
    {
        var created = await _service.AddVehicleImageAsync(licensePlate, data, cancellationToken);
        await _auditService.LogAsync(new AuditEntryRequest(GetRole(), "upload", "vehicle_image", null, $"{{\"licensePlate\":\"{licensePlate}\",\"imageId\":{created.Id}}}"), cancellationToken);
        return CreatedAtAction(nameof(GetVehicleImages), new { licensePlate }, created);
    }

    private string GetRole() => HttpContext.Request.Headers["X-User-Role"].FirstOrDefault() ?? "Unknown";
}
