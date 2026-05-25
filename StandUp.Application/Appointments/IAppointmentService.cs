namespace StandUp.Application.Appointments;

public interface IAppointmentService
{
    Task<IReadOnlyList<AppointmentDto>> GetByDateAsync(DateTime dateOnly, CancellationToken cancellationToken);
    Task<AppointmentDto> CreateAsync(CreateAppointmentRequest request, CancellationToken cancellationToken);
    Task<bool> DeleteAsync(int id, CancellationToken cancellationToken);
}
