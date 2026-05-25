using System.Net.Http.Json;
using StandUp.Application.Auth;

namespace StandUp.Presentation.WinForms;

public interface IAuthApiClient
{
    Task<LoginResult> LoginAsync(int employeeNumber, string password, CancellationToken cancellationToken);
}

public sealed class AuthApiClient : IAuthApiClient
{
    private readonly HttpClient _httpClient;

    public AuthApiClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<LoginResult> LoginAsync(int employeeNumber, string password, CancellationToken cancellationToken)
    {
        var response = await _httpClient.PostAsJsonAsync(
            "api/auth/login",
            new LoginRequest(employeeNumber, password),
            cancellationToken);

        var result = await response.Content.ReadFromJsonAsync<LoginResult>(cancellationToken: cancellationToken);
        if (result is not null)
        {
            return result;
        }

        return LoginResult.Failed("Resposta inválida da API.");
    }
}
