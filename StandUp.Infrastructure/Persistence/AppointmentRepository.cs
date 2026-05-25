using Microsoft.EntityFrameworkCore;
using StandUp.Application.Abstractions;
using StandUp.Domain.Entities;

namespace StandUp.Infrastructure.Persistence;

public sealed class AppointmentRepository : IAppointmentRepository
{
    private readonly StandUpDbContext _dbContext;

    public AppointmentRepository(StandUpDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<IReadOnlyList<Appointment>> GetByDateAsync(DateTime dateOnly, CancellationToken cancellationToken) =>
        _dbContext.Appointments.Where(x => x.DateOnly == dateOnly.Date).OrderBy(x => x.DateTimeSlot).ToListAsync(cancellationToken).ContinueWith(t => (IReadOnlyList<Appointment>)t.Result, cancellationToken);

    public Task<Appointment?> GetByIdAsync(int id, CancellationToken cancellationToken) =>
        _dbContext.Appointments.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

    public async Task<IReadOnlyList<Appointment>> GetBetweenAsync(DateTime fromUtc, DateTime toUtc, CancellationToken cancellationToken)
    {
        return await _dbContext.Appointments
            .Where(x => x.DateTimeSlot >= fromUtc && x.DateTimeSlot <= toUtc)
            .OrderBy(x => x.DateTimeSlot)
            .ToListAsync(cancellationToken);
    }

    public Task<bool> ExistsEmployeeConflictAsync(DateTime dateTimeSlot, int employeeNumber, CancellationToken cancellationToken) =>
        _dbContext.Appointments.AnyAsync(x => x.DateTimeSlot == dateTimeSlot && x.EmployeeNumber == employeeNumber, cancellationToken);

    public Task<bool> ExistsClientConflictAsync(DateTime dateTimeSlot, int clientId, CancellationToken cancellationToken) =>
        _dbContext.Appointments.AnyAsync(x => x.DateTimeSlot == dateTimeSlot && x.ClientId == clientId, cancellationToken);

    public Task<bool> ExistsVehicleConflictAsync(DateTime dateTimeSlot, string vehicleLicensePlate, CancellationToken cancellationToken)
    {
        var plate = vehicleLicensePlate.Trim().ToUpperInvariant();
        return _dbContext.Appointments.AnyAsync(x => x.DateTimeSlot == dateTimeSlot && x.VehicleLicensePlate == plate, cancellationToken);
    }

    public async Task<Appointment> AddAsync(Appointment appointment, CancellationToken cancellationToken)
    {
        _dbContext.Appointments.Add(appointment);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return appointment;
    }

    public async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken)
    {
        var item = await _dbContext.Appointments.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        if (item is null) return false;
        _dbContext.Appointments.Remove(item);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return true;
    }
}
