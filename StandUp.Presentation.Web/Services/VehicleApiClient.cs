using System.Net.Http.Json;
using StandUp.Application.Vehicles;

namespace StandUp.Presentation.Web.Services;

/// <summary>
/// Cliente HTTP para a API de veículos.
/// Lança excepções em caso de falha — as páginas Blazor tratam-nas
/// e exibem a mensagem de erro adequada.
/// </summary>
public sealed class VehicleApiClient
{
    private readonly HttpClient _http;

    // Qualquer role válida serve para o catálogo público (só leitura)
    private const string PublicRole = "Rececao";

    public VehicleApiClient(HttpClient http)
    {
        _http = http;
        _http.DefaultRequestHeaders.Remove("X-User-Role");
        _http.DefaultRequestHeaders.Add("X-User-Role", PublicRole);
    }

    /// <summary>Devolve todos os veículos disponíveis (não vendidos).</summary>
    /// <exception cref="HttpRequestException">Se a API não estiver acessível.</exception>
    public async Task<List<VehicleDto>> GetAvailableAsync(CancellationToken ct = default)
    {
        // Parâmetro correcto: isSold (não soldOnly)
        var result = await _http.GetFromJsonAsync<List<VehicleDto>>(
            "api/vehicles?isSold=false", ct);
        return result ?? [];
    }

    /// <summary>Devolve um veículo por matrícula, ou null se não encontrado.</summary>
    public async Task<VehicleDto?> GetByPlateAsync(string plate, CancellationToken ct = default)
    {
        try
        {
            // Pesquisa primeiro nos disponíveis, depois nos vendidos
            var available = await _http.GetFromJsonAsync<List<VehicleDto>>(
                $"api/vehicles/search?licensePlate={Uri.EscapeDataString(plate)}&isSold=false", ct);

            if (available?.Count > 0) return available[0];

            var sold = await _http.GetFromJsonAsync<List<VehicleDto>>(
                $"api/vehicles/search?licensePlate={Uri.EscapeDataString(plate)}&isSold=true", ct);

            return sold?.FirstOrDefault();
        }
        catch (HttpRequestException)
        {
            return null;
        }
    }

    /// <summary>
    /// Devolve a primeira imagem do veículo em Base64, ou null se não houver.
    /// Falhas silenciosas — a UI mostra placeholder.
    /// </summary>
    /// <summary>
    /// Devolve a primeira imagem do veículo em Base64, ou null se não existir.
    /// Chama GET /api/images/vehicles/{plate}/first que devolve JPEG directo.
    /// </summary>
    public async Task<string?> GetVehicleImageBase64Async(string plate, CancellationToken ct = default)
    {
        try
        {
            var response = await _http.GetAsync(
                $"api/images/vehicles/{Uri.EscapeDataString(plate)}/first", ct);

            if (!response.IsSuccessStatusCode) return null;

            var bytes = await response.Content.ReadAsByteArrayAsync(ct);
            return bytes is { Length: > 0 } ? Convert.ToBase64String(bytes) : null;
        }
        catch
        {
            return null;
        }
    }
}
