using StandUp.Application.Abstractions;
using StandUp.Domain.Entities;

namespace StandUp.Application.Notifications;

public sealed class NotificationService : INotificationService
{
    private const int OutboxBatchSize = 100;
    private const int ImmediateRetryAttempts = 2;
    private const int MaxOutboxAttempts = 5;
    private readonly IAppointmentRepository _appointments;
    private readonly ISmsSender _smsSender;
    private readonly INotificationLogRepository _logs;
    private readonly INotificationOutboxRepository _outbox;

    public NotificationService(
        IAppointmentRepository appointments,
        ISmsSender smsSender,
        INotificationLogRepository logs,
        INotificationOutboxRepository outbox)
    {
        _appointments = appointments;
        _smsSender = smsSender;
        _logs = logs;
        _outbox = outbox;
    }

    public Task<NotificationResultDto> SendAppointmentConfirmationAsync(int appointmentId, CancellationToken cancellationToken)
        => SendAsync(appointmentId, "confirmation", "Confirmacao de marcacao", cancellationToken, allowQueueOnFailure: true);

    public Task<NotificationResultDto> SendAppointmentReminderAsync(int appointmentId, int hoursBefore, CancellationToken cancellationToken)
        => SendAsync(appointmentId, $"reminder_{hoursBefore}h", $"Lembrete: marcacao em {hoursBefore}h", cancellationToken, allowQueueOnFailure: true);

    public Task<NotificationResultDto> SendAppointmentCancellationAsync(int appointmentId, CancellationToken cancellationToken)
        => SendAsync(appointmentId, "cancellation", "Cancelamento de marcacao", cancellationToken, allowQueueOnFailure: true);

    public async Task<int> ProcessOutboxAsync(CancellationToken cancellationToken)
    {
        var due = await _outbox.GetDuePendingAsync(DateTime.UtcNow, OutboxBatchSize, cancellationToken);
        var processed = 0;

        foreach (var item in due)
        {
            var result = await SendAsync(item.AppointmentId, item.Type, item.Prefix, cancellationToken, allowQueueOnFailure: false);
            item.AttemptCount++;
            item.UpdatedAtUtc = DateTime.UtcNow;

            if (result.Success)
            {
                item.Status = "sent";
                item.LastError = null;
            }
            else if (item.AttemptCount >= item.MaxAttempts)
            {
                item.Status = "dead";
                item.LastError = result.ErrorMessage;
            }
            else
            {
                item.Status = "pending";
                item.LastError = result.ErrorMessage;
                var backoffMinutes = Math.Min(60, (int)Math.Pow(2, item.AttemptCount));
                item.NextAttemptUtc = DateTime.UtcNow.AddMinutes(backoffMinutes);
            }

            await _outbox.UpdateAsync(item, cancellationToken);
            processed++;
        }

        return processed;
    }

    private async Task<NotificationResultDto> SendAsync(int appointmentId, string type, string prefix, CancellationToken cancellationToken, bool allowQueueOnFailure)
    {
        var appointment = await _appointments.GetByIdAsync(appointmentId, cancellationToken);
        if (appointment is null)
        {
            return new NotificationResultDto(false, "not_found", null, "Marcacao nao encontrada.");
        }

        if (string.IsNullOrWhiteSpace(appointment.ClientPhone) || !appointment.SmsConsentGranted)
        {
            return new NotificationResultDto(false, "consent_missing", null, "Consentimento ou telefone em falta.");
        }

        if (!IsE164Phone(appointment.ClientPhone))
        {
            return new NotificationResultDto(false, "invalid_phone", null, "Numero de telefone invalido (E.164).");
        }

        if (await _logs.ExistsForAppointmentAndTypeAsync(appointmentId, type, cancellationToken))
        {
            return new NotificationResultDto(true, "already_sent", null, null);
        }

        var body = $"{prefix}: {appointment.DateTimeSlot:yyyy-MM-dd HH:mm} para {appointment.VehicleBrand} {appointment.VehicleModel} ({appointment.VehicleLicensePlate}).";
        var attempts = 0;
        (bool Success, string Status, string? ProviderMessageId, string? Error) response = (false, "failed", null, "not_sent");

        for (var i = 0; i < ImmediateRetryAttempts; i++)
        {
            attempts++;
            response = await _smsSender.SendAsync(appointment.ClientPhone, body, cancellationToken);
            if (response.Success)
            {
                break;
            }

            if (i == 0)
            {
                await Task.Delay(TimeSpan.FromSeconds(2), cancellationToken);
            }
        }

        var finalStatus = response.Success ? response.Status : "failed_after_retry";

        await _logs.AddAsync(new NotificationLog
        {
            AppointmentId = appointmentId,
            PhoneNumber = appointment.ClientPhone,
            Type = type,
            Status = finalStatus,
            Attempts = attempts,
            ProviderMessageId = response.ProviderMessageId,
            ErrorMessage = response.Error,
            ConsentGranted = appointment.SmsConsentGranted,
            ConsentTimestampUtc = appointment.SmsConsentTimestampUtc ?? DateTime.UtcNow,
            CreatedAtUtc = DateTime.UtcNow
        }, cancellationToken);

        if (!response.Success && allowQueueOnFailure)
        {
            await _outbox.AddAsync(new NotificationOutboxItem
            {
                AppointmentId = appointmentId,
                Type = type,
                Prefix = prefix,
                NextAttemptUtc = DateTime.UtcNow.AddMinutes(5),
                AttemptCount = 0,
                MaxAttempts = MaxOutboxAttempts,
                Status = "pending",
                LastError = response.Error,
                CreatedAtUtc = DateTime.UtcNow,
                UpdatedAtUtc = DateTime.UtcNow
            }, cancellationToken);
        }

        return new NotificationResultDto(response.Success, finalStatus, response.ProviderMessageId, response.Error);
    }

    private static bool IsE164Phone(string phone)
    {
        if (string.IsNullOrWhiteSpace(phone) || phone[0] != '+')
        {
            return false;
        }

        if (phone.Length < 8 || phone.Length > 16)
        {
            return false;
        }

        for (var i = 1; i < phone.Length; i++)
        {
            if (!char.IsDigit(phone[i]))
            {
                return false;
            }
        }

        return true;
    }
}
