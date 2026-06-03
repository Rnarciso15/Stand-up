using System.Security.Cryptography;
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

    /// <summary>Devolve a primeira imagem do veículo como JPEG. Usado pelo catálogo público.</summary>
    [HttpGet("vehicles/{licensePlate}/first")]
    public async Task<IActionResult> GetFirstVehicleImage(string licensePlate, CancellationToken cancellationToken)
    {
        var data = await _service.GetFirstVehicleImageDataAsync(licensePlate, cancellationToken);
        if (data is null || data.Length == 0) return NotFound();
        return ImageResponse(data);
    }

    /// <summary>Devolve a imagem do veículo pelo índice (0-based) como JPEG. Usado pela galeria.</summary>
    [HttpGet("vehicles/{licensePlate}/{index:int}")]
    public async Task<IActionResult> GetVehicleImageByIndex(string licensePlate, int index, CancellationToken cancellationToken)
    {
        if (index < 0) return BadRequest();
        var data = await _service.GetVehicleImageByIndexAsync(licensePlate, index, cancellationToken);
        if (data is null || data.Length == 0) return NotFound();
        return ImageResponse(data);
    }

    /// <summary>Devolve a imagem do cliente pelo índice (0-based) como JPEG.</summary>
    [HttpGet("clients/{clientId:int}/{index:int}")]
    public async Task<IActionResult> GetClientImageByIndex(int clientId, int index, CancellationToken cancellationToken)
    {
        if (index < 0) return BadRequest();
        var data = await _service.GetClientImageByIndexAsync(clientId, index, cancellationToken);
        if (data is null || data.Length == 0) return NotFound();
        return ImageResponse(data);
    }

    private IActionResult ImageResponse(byte[] data)
    {
        var etag = $"\"{Convert.ToBase64String(MD5.HashData(data))[..16]}\"";
        if (Request.Headers.IfNoneMatch == etag) return StatusCode(304);
        Response.Headers.CacheControl = "public, max-age=86400, immutable";
        Response.Headers.ETag = etag;
        return File(data, "image/jpeg");
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
