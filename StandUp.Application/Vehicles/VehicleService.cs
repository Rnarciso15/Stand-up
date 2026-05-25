using StandUp.Application.Abstractions;
using StandUp.Domain.Entities;

namespace StandUp.Application.Vehicles;

public sealed class VehicleService : IVehicleService
{
    private readonly IVehicleRepository _vehicleRepository;

    public VehicleService(IVehicleRepository vehicleRepository)
    {
        _vehicleRepository = vehicleRepository;
    }

    public async Task<IReadOnlyList<VehicleDto>> GetAllAsync(bool isSold, CancellationToken cancellationToken)
    {
        var items = await _vehicleRepository.GetAllAsync(isSold, cancellationToken);
        return items.Select(Map).ToList();
    }

    public async Task<IReadOnlyList<VehicleDto>> SearchByLicensePlateAsync(string licensePlate, bool isSold, CancellationToken cancellationToken)
    {
        var items = await _vehicleRepository.SearchByLicensePlateAsync(licensePlate, isSold, cancellationToken);
        return items.Select(Map).ToList();
    }

    public async Task<VehicleDto> CreateAsync(CreateVehicleRequest request, CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(request.LicensePlate) || string.IsNullOrWhiteSpace(request.Brand) || string.IsNullOrWhiteSpace(request.Model))
        {
            throw new ArgumentException("Matrícula, marca e modelo são obrigatórios.");
        }

        var vehicle = new Vehicle
        {
            LicensePlate = request.LicensePlate.Trim().ToUpperInvariant(),
            Kilometers = request.Kilometers,
            RegistrationDate = request.RegistrationDate,
            Brand = request.Brand.Trim(),
            Model = request.Model.Trim(),
            Fuel = request.Fuel,
            Price = request.Price,
            IsMotorcycle = request.IsMotorcycle,
            IsSold = false
        };

        var created = await _vehicleRepository.AddAsync(vehicle, cancellationToken);
        return Map(created);
    }

    public Task<bool> SetSoldAsync(string licensePlate, bool isSold, CancellationToken cancellationToken)
    {
        return _vehicleRepository.SetSoldAsync(licensePlate, isSold, cancellationToken);
    }

    public async Task<IReadOnlyList<VehicleDto>> SearchAdvancedAsync(VehicleSearchFilter filter, CancellationToken cancellationToken)
    {
        var items = await _vehicleRepository.SearchAdvancedAsync(filter, cancellationToken);
        return items.Select(Map).ToList();
    }

    private static VehicleDto Map(Vehicle x) =>
        new(x.LicensePlate, x.Kilometers, x.RegistrationDate, x.Brand, x.Model, x.Fuel, x.Price, x.IsSold, x.IsMotorcycle);
}
