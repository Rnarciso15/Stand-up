using StandUp.Domain.Entities;

namespace StandUp.Application.Abstractions;

public interface IImageRepository
{
    Task<ClientImage> AddClientImageAsync(int clientId, byte[] data, CancellationToken cancellationToken);
    Task<IReadOnlyList<ClientImage>> GetClientImagesAsync(int clientId, CancellationToken cancellationToken);
    Task<VehicleImage> AddVehicleImageAsync(string licensePlate, byte[] data, CancellationToken cancellationToken);
    Task<IReadOnlyList<VehicleImage>> GetVehicleImagesAsync(string licensePlate, CancellationToken cancellationToken);
    Task<byte[]?> GetFirstVehicleImageDataAsync(string licensePlate, CancellationToken cancellationToken);
}
