using System.Net.Http.Json;
using StandUp.Application.Sales;

namespace StandUp.Presentation.WinForms;

public interface ISalesApiClient
{
    Task<IReadOnlyList<SaleTransactionDto>> GetAllAsync(CancellationToken cancellationToken);
    Task<IReadOnlyList<SaleTransactionDto>> SearchByPlateAsync(string licensePlate, CancellationToken cancellationToken);
    Task<SaleTransactionDto> CreateAsync(CreateSaleTransactionRequest request, CancellationToken cancellationToken);
    Task GenerateProposalAsync(int saleTransactionId, DateTime validUntilUtc, CancellationToken cancellationToken);
}

public sealed class SalesApiClient : ISalesApiClient
{
    private readonly HttpClient _httpClient;

    public SalesApiClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IReadOnlyList<SaleTransactionDto>> GetAllAsync(CancellationToken cancellationToken)
    {
        UserSession.ApplyRoleHeader(_httpClient);
        var result = await _httpClient.GetFromJsonAsync<List<SaleTransactionDto>>("api/sales", cancellationToken);
        return result ?? [];
    }

    public async Task<IReadOnlyList<SaleTransactionDto>> SearchByPlateAsync(string licensePlate, CancellationToken cancellationToken)
    {
        UserSession.ApplyRoleHeader(_httpClient);
        var result = await _httpClient.GetFromJsonAsync<List<SaleTransactionDto>>($"api/sales/search?licensePlate={Uri.EscapeDataString(licensePlate)}", cancellationToken);
        return result ?? [];
    }

    public async Task<SaleTransactionDto> CreateAsync(CreateSaleTransactionRequest request, CancellationToken cancellationToken)
    {
        UserSession.ApplyRoleHeader(_httpClient);
        var response = await _httpClient.PostAsJsonAsync("api/sales", request, cancellationToken);
        response.EnsureSuccessStatusCode();
        var created = await response.Content.ReadFromJsonAsync<SaleTransactionDto>(cancellationToken: cancellationToken);
        return created ?? throw new InvalidOperationException("Resposta invalida da API.");
    }

    public async Task GenerateProposalAsync(int saleTransactionId, DateTime validUntilUtc, CancellationToken cancellationToken)
    {
        UserSession.ApplyRoleHeader(_httpClient);
        var response = await _httpClient.PostAsync($"api/proposals/{saleTransactionId}?validUntilUtc={Uri.EscapeDataString(validUntilUtc.ToString("o"))}", null, cancellationToken);
        response.EnsureSuccessStatusCode();
    }
}
