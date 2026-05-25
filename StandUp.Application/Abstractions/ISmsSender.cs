namespace StandUp.Application.Abstractions;

public interface ISmsSender
{
    Task<(bool Success, string Status, string? ProviderMessageId, string? Error)> SendAsync(string to, string body, CancellationToken cancellationToken);
}
