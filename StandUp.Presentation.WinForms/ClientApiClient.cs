using System.Net.Http.Json;
using StandUp.Application.Clients;

namespace StandUp.Presentation.WinForms;

public interface IClientApiClient
{
    Task<IReadOnlyList<ClientDto>> GetAllAsync(CancellationToken cancellationToken);
    Task<IReadOnlyList<ClientDto>> SearchAsync(string name, CancellationToken cancellationToken);
    Task<ClientDto> CreateAsync(CreateClientRequest request, CancellationToken cancellationToken);
    Task SetActiveAsync(int id, bool isActive, CancellationToken cancellationToken);
}

public sealed class ClientApiClient : IClientApiClient
{
    private readonly HttpClient _httpClient;

    public ClientApiClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IReadOnlyList<ClientDto>> GetAllAsync(CancellationToken cancellationToken)
    {
        UserSession.ApplyRoleHeader(_httpClient);
        var result = await _httpClient.GetFromJsonAsync<List<ClientDto>>("api/clients", cancellationToken);
        return result ?? [];
    }

    public async Task<IReadOnlyList<ClientDto>> SearchAsync(string name, CancellationToken cancellationToken)
    {
        UserSession.ApplyRoleHeader(_httpClient);
        var result = await _httpClient.GetFromJsonAsync<List<ClientDto>>($"api/clients/search?name={Uri.EscapeDataString(name)}", cancellationToken);
        return result ?? [];
    }

    public async Task<ClientDto> CreateAsync(CreateClientRequest request, CancellationToken cancellationToken)
    {
        UserSession.ApplyRoleHeader(_httpClient);
        var response = await _httpClient.PostAsJsonAsync("api/clients", request, cancellationToken);
        response.EnsureSuccessStatusCode();
        var created = await response.Content.ReadFromJsonAsync<ClientDto>(cancellationToken: cancellationToken);
        return created ?? throw new InvalidOperationException("Resposta inválida da API.");
    }

    public async Task SetActiveAsync(int id, bool isActive, CancellationToken cancellationToken)
    {
        UserSession.ApplyRoleHeader(_httpClient);
        var response = await _httpClient.PatchAsync($"api/clients/{id}/active?isActive={isActive}", null, cancellationToken);
        response.EnsureSuccessStatusCode();
    }
}
