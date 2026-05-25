using System.Net.Http.Json;
using StandUp.Application.Appointments;

namespace StandUp.Presentation.WinForms;

public interface IAppointmentApiClient
{
    Task<IReadOnlyList<AppointmentDto>> GetByDateAsync(DateTime date, CancellationToken cancellationToken);
    Task<AppointmentDto> CreateAsync(CreateAppointmentRequest request, CancellationToken cancellationToken);
    Task DeleteAsync(int id, CancellationToken cancellationToken);
    Task SendConfirmationAsync(int id, CancellationToken cancellationToken);
    Task SendReminderAsync(int id, int hoursBefore, CancellationToken cancellationToken);
}

public sealed class AppointmentApiClient : IAppointmentApiClient
{
    private readonly HttpClient _httpClient;

    public AppointmentApiClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IReadOnlyList<AppointmentDto>> GetByDateAsync(DateTime date, CancellationToken cancellationToken)
    {
        UserSession.ApplyRoleHeader(_httpClient);
        var result = await _httpClient.GetFromJsonAsync<List<AppointmentDto>>($"api/appointments?date={date:yyyy-MM-dd}", cancellationToken);
        return result ?? [];
    }

    public async Task<AppointmentDto> CreateAsync(CreateAppointmentRequest request, CancellationToken cancellationToken)
    {
        UserSession.ApplyRoleHeader(_httpClient);
        var response = await _httpClient.PostAsJsonAsync("api/appointments", request, cancellationToken);
        response.EnsureSuccessStatusCode();
        var created = await response.Content.ReadFromJsonAsync<AppointmentDto>(cancellationToken: cancellationToken);
        return created ?? throw new InvalidOperationException("Resposta inválida da API.");
    }

    public async Task DeleteAsync(int id, CancellationToken cancellationToken)
    {
        UserSession.ApplyRoleHeader(_httpClient);
        var response = await _httpClient.DeleteAsync($"api/appointments/{id}", cancellationToken);
        response.EnsureSuccessStatusCode();
    }

    public async Task SendConfirmationAsync(int id, CancellationToken cancellationToken)
    {
        UserSession.ApplyRoleHeader(_httpClient);
        var response = await _httpClient.PostAsync($"api/notifications/appointments/{id}/confirmation", null, cancellationToken);
        response.EnsureSuccessStatusCode();
    }

    public async Task SendReminderAsync(int id, int hoursBefore, CancellationToken cancellationToken)
    {
        UserSession.ApplyRoleHeader(_httpClient);
        var response = await _httpClient.PostAsync($"api/notifications/appointments/{id}/reminder?hoursBefore={hoursBefore}", null, cancellationToken);
        response.EnsureSuccessStatusCode();
    }
}
