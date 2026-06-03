using System.Net.Http.Json;
using StandUp.Application.Images;

namespace StandUp.Presentation.WinForms;

public interface IImagesApiClient
{
    Task<IReadOnlyList<ImageDto>> GetClientImagesAsync(int clientId, CancellationToken cancellationToken);
    Task<ImageDto> AddClientImageAsync(int clientId, byte[] data, CancellationToken cancellationToken);
    Task<IReadOnlyList<ImageDto>> GetVehicleImagesAsync(string licensePlate, CancellationToken cancellationToken);
    Task<ImageDto> AddVehicleImageAsync(string licensePlate, byte[] data, CancellationToken cancellationToken);
    Task<byte[]?> GetVehicleImageByIndexAsync(string licensePlate, int index, CancellationToken cancellationToken);
    Task<byte[]?> GetClientImageByIndexAsync(int clientId, int index, CancellationToken cancellationToken);
}

public sealed class ImagesApiClient : IImagesApiClient
{
    private readonly HttpClient _httpClient;

    public ImagesApiClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IReadOnlyList<ImageDto>> GetClientImagesAsync(int clientId, CancellationToken cancellationToken)
    {
        UserSession.ApplyRoleHeader(_httpClient);
        var result = await _httpClient.GetFromJsonAsync<List<ImageDto>>($"api/images/clients/{clientId}", cancellationToken);
        return result ?? [];
    }

    public async Task<ImageDto> AddClientImageAsync(int clientId, byte[] data, CancellationToken cancellationToken)
    {
        UserSession.ApplyRoleHeader(_httpClient);
        var response = await _httpClient.PostAsJsonAsync($"api/images/clients/{clientId}", data, cancellationToken);
        response.EnsureSuccessStatusCode();
        return (await response.Content.ReadFromJsonAsync<ImageDto>(cancellationToken: cancellationToken))!;
    }

    public async Task<IReadOnlyList<ImageDto>> GetVehicleImagesAsync(string licensePlate, CancellationToken cancellationToken)
    {
        UserSession.ApplyRoleHeader(_httpClient);
        var result = await _httpClient.GetFromJsonAsync<List<ImageDto>>($"api/images/vehicles/{Uri.EscapeDataString(licensePlate)}", cancellationToken);
        return result ?? [];
    }

    public async Task<ImageDto> AddVehicleImageAsync(string licensePlate, byte[] data, CancellationToken cancellationToken)
    {
        UserSession.ApplyRoleHeader(_httpClient);
        var response = await _httpClient.PostAsJsonAsync($"api/images/vehicles/{Uri.EscapeDataString(licensePlate)}", data, cancellationToken);
        response.EnsureSuccessStatusCode();
        return (await response.Content.ReadFromJsonAsync<ImageDto>(cancellationToken: cancellationToken))!;
    }

    public async Task<byte[]?> GetVehicleImageByIndexAsync(string licensePlate, int index, CancellationToken cancellationToken)
    {
        UserSession.ApplyRoleHeader(_httpClient);
        var response = await _httpClient.GetAsync(
            $"api/images/vehicles/{Uri.EscapeDataString(licensePlate)}/{index}", cancellationToken);
        if (!response.IsSuccessStatusCode) return null;
        var bytes = await response.Content.ReadAsByteArrayAsync(cancellationToken);
        return bytes is { Length: > 0 } ? bytes : null;
    }

    public async Task<byte[]?> GetClientImageByIndexAsync(int clientId, int index, CancellationToken cancellationToken)
    {
        UserSession.ApplyRoleHeader(_httpClient);
        var response = await _httpClient.GetAsync(
            $"api/images/clients/{clientId}/{index}", cancellationToken);
        if (!response.IsSuccessStatusCode) return null;
        var bytes = await response.Content.ReadAsByteArrayAsync(cancellationToken);
        return bytes is { Length: > 0 } ? bytes : null;
    }
}
