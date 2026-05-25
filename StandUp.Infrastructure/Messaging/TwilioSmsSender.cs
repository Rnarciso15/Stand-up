using System.Net.Http.Headers;
using System.Text;
using StandUp.Application.Abstractions;

namespace StandUp.Infrastructure.Messaging;

public sealed class TwilioSmsSender : ISmsSender
{
    private readonly HttpClient _httpClient;
    private readonly string _accountSid;
    private readonly string _authToken;
    private readonly string _fromNumber;

    public TwilioSmsSender(HttpClient httpClient, string accountSid, string authToken, string fromNumber)
    {
        _httpClient = httpClient;
        _accountSid = accountSid;
        _authToken = authToken;
        _fromNumber = fromNumber;
    }

    public async Task<(bool Success, string Status, string? ProviderMessageId, string? Error)> SendAsync(string to, string body, CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(_accountSid) || string.IsNullOrWhiteSpace(_authToken) || string.IsNullOrWhiteSpace(_fromNumber))
        {
            return (true, "skipped_no_config", null, null);
        }

        var request = new HttpRequestMessage(HttpMethod.Post, $"https://api.twilio.com/2010-04-01/Accounts/{_accountSid}/Messages.json");
        var token = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{_accountSid}:{_authToken}"));
        request.Headers.Authorization = new AuthenticationHeaderValue("Basic", token);
        request.Content = new FormUrlEncodedContent(new Dictionary<string, string>
        {
            ["To"] = to,
            ["From"] = _fromNumber,
            ["Body"] = body
        });

        var response = await _httpClient.SendAsync(request, cancellationToken);
        if (!response.IsSuccessStatusCode)
        {
            return (false, "failed", null, await response.Content.ReadAsStringAsync(cancellationToken));
        }

        var raw = await response.Content.ReadAsStringAsync(cancellationToken);
        return (true, "sent", raw, null);
    }
}
