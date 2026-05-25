using StandUp.Application.Abstractions;
using StandUp.Domain.Entities;

namespace StandUp.Application.Appointments;

public sealed class AppointmentService : IAppointmentService
{
    private readonly IAppointmentRepository _repository;

    public AppointmentService(IAppointmentRepository repository)
    {
        _repository = repository;
    }

    public async Task<IReadOnlyList<AppointmentDto>> GetByDateAsync(DateTime dateOnly, CancellationToken cancellationToken)
    {
        var items = await _repository.GetByDateAsync(dateOnly.Date, cancellationToken);
        return items.Select(Map).ToList();
    }

    public async Task<AppointmentDto> CreateAsync(CreateAppointmentRequest request, CancellationToken cancellationToken)
    {
        if (await _repository.ExistsEmployeeConflictAsync(request.DateTimeSlot, request.EmployeeNumber, cancellationToken))
            throw new InvalidOperationException("Funcionário já ocupado neste horário.");
        if (await _repository.ExistsClientConflictAsync(request.DateTimeSlot, request.ClientId, cancellationToken))
            throw new InvalidOperationException("Cliente já ocupado neste horário.");
        if (await _repository.ExistsVehicleConflictAsync(request.DateTimeSlot, request.VehicleLicensePlate, cancellationToken))
            throw new InvalidOperationException("Veículo já ocupado neste horário.");

        var appointment = new Appointment
        {
            DateOnly = request.DateTimeSlot.Date,
            DateTimeSlot = request.DateTimeSlot,
            EmployeeNumber = request.EmployeeNumber,
            EmployeeName = request.EmployeeName,
            ClientId = request.ClientId,
            ClientName = request.ClientName,
            ClientPhone = request.ClientPhone,
            SmsConsentGranted = request.SmsConsentGranted,
            SmsConsentTimestampUtc = request.SmsConsentGranted ? DateTime.UtcNow : null,
            VehicleBrand = request.VehicleBrand,
            VehicleModel = request.VehicleModel,
            VehicleLicensePlate = request.VehicleLicensePlate.Trim().ToUpperInvariant()
        };

        var created = await _repository.AddAsync(appointment, cancellationToken);
        return Map(created);
    }

    public Task<bool> DeleteAsync(int id, CancellationToken cancellationToken) => _repository.DeleteAsync(id, cancellationToken);

    private static AppointmentDto Map(Appointment x) =>
        new(x.Id, x.DateTimeSlot, x.EmployeeNumber, x.EmployeeName, x.ClientId, x.ClientName, x.ClientPhone, x.SmsConsentGranted, x.VehicleBrand, x.VehicleModel, x.VehicleLicensePlate);
}
