namespace StandUp.Application.Images;

public interface IImageService
{
    Task<ImageDto> AddClientImageAsync(int clientId, byte[] data, CancellationToken cancellationToken);
    Task<IReadOnlyList<ImageDto>> GetClientImagesAsync(int clientId, CancellationToken cancellationToken);
    Task<ImageDto> AddVehicleImageAsync(string licensePlate, byte[] data, CancellationToken cancellationToken);
    Task<IReadOnlyList<ImageDto>> GetVehicleImagesAsync(string licensePlate, CancellationToken cancellationToken);
    Task<byte[]?> GetFirstVehicleImageDataAsync(string licensePlate, CancellationToken cancellationToken);
}
