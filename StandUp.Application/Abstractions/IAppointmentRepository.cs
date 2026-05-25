using StandUp.Domain.Entities;

namespace StandUp.Application.Abstractions;

public interface IAppointmentRepository
{
    Task<IReadOnlyList<Appointment>> GetByDateAsync(DateTime dateOnly, CancellationToken cancellationToken);
    Task<Appointment?> GetByIdAsync(int id, CancellationToken cancellationToken);
    Task<IReadOnlyList<Appointment>> GetBetweenAsync(DateTime fromUtc, DateTime toUtc, CancellationToken cancellationToken);
    Task<bool> ExistsEmployeeConflictAsync(DateTime dateTimeSlot, int employeeNumber, CancellationToken cancellationToken);
    Task<bool> ExistsClientConflictAsync(DateTime dateTimeSlot, int clientId, CancellationToken cancellationToken);
    Task<bool> ExistsVehicleConflictAsync(DateTime dateTimeSlot, string vehicleLicensePlate, CancellationToken cancellationToken);
    Task<Appointment> AddAsync(Appointment appointment, CancellationToken cancellationToken);
    Task<bool> DeleteAsync(int id, CancellationToken cancellationToken);
}
