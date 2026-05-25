using Microsoft.AspNetCore.Mvc;
using StandUp.Application.Notifications;
using StandUp.Presentation.Api.Security;

namespace StandUp.Presentation.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[RequireRole("Admin", "Vendedor", "Rececao")]
public sealed class NotificationsController : ControllerBase
{
    private readonly INotificationService _service;

    public NotificationsController(INotificationService service)
    {
        _service = service;
    }

    [HttpPost("appointments/{appointmentId:int}/confirmation")]
    public Task<NotificationResultDto> SendConfirmation(int appointmentId, CancellationToken cancellationToken)
        => _service.SendAppointmentConfirmationAsync(appointmentId, cancellationToken);

    [HttpPost("appointments/{appointmentId:int}/reminder")]
    public Task<NotificationResultDto> SendReminder(int appointmentId, [FromQuery] int hoursBefore = 24, CancellationToken cancellationToken = default)
        => _service.SendAppointmentReminderAsync(appointmentId, hoursBefore, cancellationToken);

    [HttpPost("appointments/{appointmentId:int}/cancellation")]
    public Task<NotificationResultDto> SendCancellation(int appointmentId, CancellationToken cancellationToken)
        => _service.SendAppointmentCancellationAsync(appointmentId, cancellationToken);

    [HttpPost("outbox/process")]
    [RequireRole("Admin")]
    public async Task<ActionResult<object>> ProcessOutbox(CancellationToken cancellationToken)
    {
        var processed = await _service.ProcessOutboxAsync(cancellationToken);
        return Ok(new { processed });
    }
}
