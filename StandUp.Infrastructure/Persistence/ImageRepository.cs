using Microsoft.EntityFrameworkCore;
using StandUp.Application.Abstractions;
using StandUp.Domain.Entities;

namespace StandUp.Infrastructure.Persistence;

public sealed class ImageRepository : IImageRepository
{
    private readonly StandUpDbContext _dbContext;

    public ImageRepository(StandUpDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<ClientImage> AddClientImageAsync(int clientId, byte[] data, CancellationToken cancellationToken)
    {
        var img = new ClientImage { ClientId = clientId, Data = data, CreatedAt = DateTime.UtcNow };
        _dbContext.ClientImages.Add(img);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return img;
    }

    public async Task<IReadOnlyList<ClientImage>> GetClientImagesAsync(int clientId, CancellationToken cancellationToken)
    {
        return await _dbContext.ClientImages.Where(x => x.ClientId == clientId).OrderByDescending(x => x.CreatedAt).ToListAsync(cancellationToken);
    }

    public async Task<VehicleImage> AddVehicleImageAsync(string licensePlate, byte[] data, CancellationToken cancellationToken)
    {
        var img = new VehicleImage
        {
            VehicleLicensePlate = licensePlate.Trim().ToUpperInvariant(),
            Data = data,
            CreatedAt = DateTime.UtcNow
        };
        _dbContext.VehicleImages.Add(img);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return img;
    }

    public async Task<IReadOnlyList<VehicleImage>> GetVehicleImagesAsync(string licensePlate, CancellationToken cancellationToken)
    {
        var plate = licensePlate.Trim().ToUpperInvariant();
        return await _dbContext.VehicleImages.Where(x => x.VehicleLicensePlate == plate).OrderByDescending(x => x.CreatedAt).ToListAsync(cancellationToken);
    }

    public async Task<byte[]?> GetFirstVehicleImageDataAsync(string licensePlate, CancellationToken cancellationToken)
    {
        var plate = licensePlate.Trim().ToUpperInvariant();
        var img = await _dbContext.VehicleImages
            .Where(x => x.VehicleLicensePlate == plate)
            .OrderByDescending(x => x.CreatedAt)
            .FirstOrDefaultAsync(cancellationToken);
        return img?.Data;
    }
}
