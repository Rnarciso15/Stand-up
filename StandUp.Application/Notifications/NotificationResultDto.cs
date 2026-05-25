namespace StandUp.Application.Notifications;

public sealed record NotificationResultDto(bool Success, string Status, string? ProviderMessageId, string? ErrorMessage);
