using Microsoft.EntityFrameworkCore;
using StandUp.Application.Abstractions;
using StandUp.Application.Vehicles;
using StandUp.Domain.Entities;

namespace StandUp.Infrastructure.Persistence;

public sealed class VehicleRepository : IVehicleRepository
{
    private readonly StandUpDbContext _dbContext;

    public VehicleRepository(StandUpDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IReadOnlyList<Vehicle>> GetAllAsync(bool isSold, CancellationToken cancellationToken)
    {
        return await _dbContext.Vehicles
            .Where(x => x.IsSold == isSold)
            .OrderBy(x => x.LicensePlate)
            .ToListAsync(cancellationToken);
    }

    public async Task<IReadOnlyList<Vehicle>> SearchByLicensePlateAsync(string licensePlate, bool isSold, CancellationToken cancellationToken)
    {
        var term = licensePlate.Trim().ToUpperInvariant();
        return await _dbContext.Vehicles
            .Where(x => x.IsSold == isSold && x.LicensePlate.Contains(term))
            .OrderBy(x => x.LicensePlate)
            .ToListAsync(cancellationToken);
    }

    public async Task<Vehicle> AddAsync(Vehicle vehicle, CancellationToken cancellationToken)
    {
        _dbContext.Vehicles.Add(vehicle);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return vehicle;
    }

    public async Task<bool> SetSoldAsync(string licensePlate, bool isSold, CancellationToken cancellationToken)
    {
        var normalized = licensePlate.Trim().ToUpperInvariant();
        var vehicle = await _dbContext.Vehicles.FirstOrDefaultAsync(x => x.LicensePlate == normalized, cancellationToken);
        if (vehicle is null)
        {
            return false;
        }

        vehicle.IsSold = isSold;
        await _dbContext.SaveChangesAsync(cancellationToken);
        return true;
    }

    public async Task<IReadOnlyList<Vehicle>> SearchAdvancedAsync(VehicleSearchFilter filter, CancellationToken cancellationToken)
    {
        var query = _dbContext.Vehicles.AsQueryable();
        query = query.Where(x => x.IsSold == filter.IsSold);

        if (!string.IsNullOrWhiteSpace(filter.Brand)) query = query.Where(x => x.Brand.Contains(filter.Brand));
        if (!string.IsNullOrWhiteSpace(filter.Model)) query = query.Where(x => x.Model.Contains(filter.Model));
        if (!string.IsNullOrWhiteSpace(filter.Fuel)) query = query.Where(x => x.Fuel != null && x.Fuel.Contains(filter.Fuel));
        if (!string.IsNullOrWhiteSpace(filter.Color)) query = query.Where(x => x.Color != null && x.Color.Contains(filter.Color));
        if (filter.IsMotorcycle.HasValue) query = query.Where(x => x.IsMotorcycle == filter.IsMotorcycle.Value);
        if (filter.KmMin.HasValue) query = query.Where(x => x.Kilometers >= filter.KmMin.Value);
        if (filter.KmMax.HasValue) query = query.Where(x => x.Kilometers <= filter.KmMax.Value);
        if (filter.PriceMin.HasValue) query = query.Where(x => x.Price >= filter.PriceMin.Value);
        if (filter.PriceMax.HasValue) query = query.Where(x => x.Price <= filter.PriceMax.Value);

        query = (filter.SortBy ?? "price").ToLowerInvariant() switch
        {
            "km" => filter.Desc ? query.OrderByDescending(x => x.Kilometers) : query.OrderBy(x => x.Kilometers),
            "date" => filter.Desc ? query.OrderByDescending(x => x.RegistrationDate) : query.OrderBy(x => x.RegistrationDate),
            _ => filter.Desc ? query.OrderByDescending(x => x.Price) : query.OrderBy(x => x.Price)
        };

        var skip = Math.Max(0, (filter.Page - 1) * filter.PageSize);
        var take = Math.Clamp(filter.PageSize, 1, 200);
        return await query.Skip(skip).Take(take).ToListAsync(cancellationToken);
    }
}
