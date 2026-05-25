namespace StandUp.Application.Vehicles;

public interface IVehicleService
{
    Task<IReadOnlyList<VehicleDto>> GetAllAsync(bool isSold, CancellationToken cancellationToken);
    Task<IReadOnlyList<VehicleDto>> SearchByLicensePlateAsync(string licensePlate, bool isSold, CancellationToken cancellationToken);
    Task<VehicleDto> CreateAsync(CreateVehicleRequest request, CancellationToken cancellationToken);
    Task<bool> SetSoldAsync(string licensePlate, bool isSold, CancellationToken cancellationToken);
    Task<IReadOnlyList<VehicleDto>> SearchAdvancedAsync(VehicleSearchFilter filter, CancellationToken cancellationToken);
}
