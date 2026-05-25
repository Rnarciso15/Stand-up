using System.Net.Http.Json;
using StandUp.Application.Vehicles;

namespace StandUp.Presentation.WinForms;

public interface IVehicleApiClient
{
    Task<IReadOnlyList<VehicleDto>> GetAllAsync(bool isSold, CancellationToken cancellationToken);
    Task<IReadOnlyList<VehicleDto>> SearchAsync(string licensePlate, bool isSold, CancellationToken cancellationToken);
    Task<VehicleDto> CreateAsync(CreateVehicleRequest request, CancellationToken cancellationToken);
    Task SetSoldAsync(string licensePlate, bool isSold, CancellationToken cancellationToken);
    Task<IReadOnlyList<VehicleDto>> SearchAdvancedAsync(string query, bool isSold, CancellationToken cancellationToken);
}

public sealed class VehicleApiClient : IVehicleApiClient
{
    private readonly HttpClient _httpClient;

    public VehicleApiClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IReadOnlyList<VehicleDto>> GetAllAsync(bool isSold, CancellationToken cancellationToken)
    {
        UserSession.ApplyRoleHeader(_httpClient);
        var result = await _httpClient.GetFromJsonAsync<List<VehicleDto>>($"api/vehicles?isSold={isSold}", cancellationToken);
        return result ?? [];
    }

    public async Task<IReadOnlyList<VehicleDto>> SearchAsync(string licensePlate, bool isSold, CancellationToken cancellationToken)
    {
        UserSession.ApplyRoleHeader(_httpClient);
        var result = await _httpClient.GetFromJsonAsync<List<VehicleDto>>($"api/vehicles/search?licensePlate={Uri.EscapeDataString(licensePlate)}&isSold={isSold}", cancellationToken);
        return result ?? [];
    }

    public async Task<VehicleDto> CreateAsync(CreateVehicleRequest request, CancellationToken cancellationToken)
    {
        UserSession.ApplyRoleHeader(_httpClient);
        var response = await _httpClient.PostAsJsonAsync("api/vehicles", request, cancellationToken);
        response.EnsureSuccessStatusCode();
        var created = await response.Content.ReadFromJsonAsync<VehicleDto>(cancellationToken: cancellationToken);
        return created ?? throw new InvalidOperationException("Resposta inválida da API.");
    }

    public async Task SetSoldAsync(string licensePlate, bool isSold, CancellationToken cancellationToken)
    {
        UserSession.ApplyRoleHeader(_httpClient);
        var response = await _httpClient.PatchAsync($"api/vehicles/{Uri.EscapeDataString(licensePlate)}/sold?isSold={isSold}", null, cancellationToken);
        response.EnsureSuccessStatusCode();
    }

    public async Task<IReadOnlyList<VehicleDto>> SearchAdvancedAsync(string query, bool isSold, CancellationToken cancellationToken)
    {
        UserSession.ApplyRoleHeader(_httpClient);
        var result = await _httpClient.GetFromJsonAsync<List<VehicleDto>>($"api/vehicles/advanced?brand={Uri.EscapeDataString(query)}&isSold={isSold}", cancellationToken);
        return result ?? [];
    }
}
