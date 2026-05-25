using System.Net.Http.Json;
using StandUp.Application.Dashboard;

namespace StandUp.Presentation.WinForms;

public interface IDashboardApiClient
{
    Task<DashboardKpiDto?> GetKpisAsync(DateTime fromUtc, DateTime toUtc, CancellationToken cancellationToken);
}

public sealed class DashboardApiClient : IDashboardApiClient
{
    private readonly HttpClient _httpClient;

    public DashboardApiClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public Task<DashboardKpiDto?> GetKpisAsync(DateTime fromUtc, DateTime toUtc, CancellationToken cancellationToken)
    {
        UserSession.ApplyRoleHeader(_httpClient);
        return _httpClient.GetFromJsonAsync<DashboardKpiDto>($"api/dashboard/kpis?fromUtc={Uri.EscapeDataString(fromUtc.ToString("o"))}&toUtc={Uri.EscapeDataString(toUtc.ToString("o"))}", cancellationToken);
    }
}
