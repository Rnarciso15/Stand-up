using Microsoft.AspNetCore.Mvc;
using StandUp.Application.Auditing;
using StandUp.Application.Appointments;
using StandUp.Presentation.Api.Security;

namespace StandUp.Presentation.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[RequireRole("Admin", "Vendedor", "Rececao")]
public sealed class AppointmentsController : ControllerBase
{
    private readonly IAppointmentService _service;
    private readonly IAuditService _auditService;

    public AppointmentsController(IAppointmentService service, IAuditService auditService)
    {
        _service = service;
        _auditService = auditService;
    }

    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<AppointmentDto>>> GetByDate([FromQuery] DateTime date, CancellationToken cancellationToken)
    {
        return Ok(await _service.GetByDateAsync(date, cancellationToken));
    }

    [HttpPost]
    public async Task<ActionResult<AppointmentDto>> Create([FromBody] CreateAppointmentRequest request, CancellationToken cancellationToken)
    {
        var created = await _service.CreateAsync(request, cancellationToken);
        await _auditService.LogAsync(new AuditEntryRequest(GetRole(), "create", "appointment", null, System.Text.Json.JsonSerializer.Serialize(created)), cancellationToken);
        return CreatedAtAction(nameof(GetByDate), new { date = created.DateTimeSlot.Date }, created);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
    {
        var deleted = await _service.DeleteAsync(id, cancellationToken);
        if (deleted) await _auditService.LogAsync(new AuditEntryRequest(GetRole(), "delete", "appointment", $"{{\"id\":{id}}}", null), cancellationToken);
        return deleted ? NoContent() : NotFound();
    }

    private string GetRole() => HttpContext.Request.Headers["X-User-Role"].FirstOrDefault() ?? "Unknown";
}
