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

    /// <summary>
    /// Devolve todas as imagens do veículo em Base64.
    /// Retorna lista vazia se não houver imagens ou em caso de erro.
    /// </summary>
    public async Task<List<string>> GetVehicleImagesBase64Async(string plate, CancellationToken ct = default)
    {
        try
        {
            // Para cada veículo, temos múltiplas imagens armazenadas
            // Tentamos buscar até 10 imagens (limite prático)
            var images = new List<string>();

            for (int i = 1; i <= 10; i++)
            {
                try
                {
                    var response = await _http.GetAsync(
                        $"api/images/vehicles/{Uri.EscapeDataString(plate)}/{i}", ct);

                    if (!response.IsSuccessStatusCode) break; // Se falhar, paramos

                    var bytes = await response.Content.ReadAsByteArrayAsync(ct);
                    if (bytes is { Length: > 0 })
                    {
                        images.Add(Convert.ToBase64String(bytes));
                    }
                }
                catch
                {
                    break; // Se houver erro, paramos
                }
            }

            return images;
        }
        catch
        {
            return [];
        }
    }

    /// <summary>Pesquisa avançada server-side com todos os filtros disponíveis.</summary>
    public async Task<List<VehicleDto>> GetAdvancedAsync(
        string? brand = null,
        string? model = null,
        string? fuel = null,
        int? kmMin = null,
        int? kmMax = null,
        int? priceMin = null,
        int? priceMax = null,
        bool? isMotorcycle = null,
        CancellationToken ct = default)
    {
        try
        {
            var q = "api/vehicles/advanced?isSold=false";
            if (!string.IsNullOrWhiteSpace(brand))     q += $"&brand={Uri.EscapeDataString(brand)}";
            if (!string.IsNullOrWhiteSpace(model))     q += $"&model={Uri.EscapeDataString(model)}";
            if (!string.IsNullOrWhiteSpace(fuel))      q += $"&fuel={Uri.EscapeDataString(fuel)}";
            if (kmMin.HasValue)                        q += $"&kmMin={kmMin}";
            if (kmMax.HasValue)                        q += $"&kmMax={kmMax}";
            if (priceMin.HasValue)                     q += $"&priceMin={priceMin}";
            if (priceMax.HasValue)                     q += $"&priceMax={priceMax}";
            if (isMotorcycle.HasValue)                 q += $"&isMotorcycle={isMotorcycle}";
            q += "&pageSize=100";

            return await _http.GetFromJsonAsync<List<VehicleDto>>(q, ct) ?? [];
        }
        catch { return []; }
    }

    /// <summary>Envia pedido de contacto/visita para um veículo.</summary>
    public async Task<bool> SendContactAsync(string plate, string name, string phone, string message, CancellationToken ct = default)
    {
        try
        {
            var payload = new { plate, name, phone, message };
            var resp = await _http.PostAsJsonAsync("api/contact", payload, ct);
            return resp.IsSuccessStatusCode;
        }
        catch { return false; }
    }

    /// <summary>Devolve veículos similares baseado em marca, preço e tipo.</summary>
    public async Task<List<VehicleDto>> GetSimilarVehiclesAsync(
        string brand,
        int priceMin,
        int priceMax,
        bool isMotorcycle,
        CancellationToken ct = default)
    {
        try
        {
            var result = await _http.GetFromJsonAsync<List<VehicleDto>>(
                $"api/vehicles/advanced?brand={Uri.EscapeDataString(brand)}" +
                $"&priceMin={priceMin}&priceMax={priceMax}" +
                $"&isMotorcycle={isMotorcycle}&isSold=false", ct);

            return result ?? [];
        }
        catch
        {
            return [];
        }
    }
}
