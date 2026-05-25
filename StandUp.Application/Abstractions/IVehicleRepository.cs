using StandUp.Domain.Entities;
using StandUp.Application.Vehicles;

namespace StandUp.Application.Abstractions;

public interface IVehicleRepository
{
    Task<IReadOnlyList<Vehicle>> GetAllAsync(bool isSold, CancellationToken cancellationToken);
    Task<IReadOnlyList<Vehicle>> SearchByLicensePlateAsync(string licensePlate, bool isSold, CancellationToken cancellationToken);
    Task<Vehicle> AddAsync(Vehicle vehicle, CancellationToken cancellationToken);
    Task<bool> SetSoldAsync(string licensePlate, bool isSold, CancellationToken cancellationToken);
    Task<IReadOnlyList<Vehicle>> SearchAdvancedAsync(VehicleSearchFilter filter, CancellationToken cancellationToken);
}
