using StandUp.Application.Abstractions;

namespace StandUp.Application.Images;

public sealed class ImageService : IImageService
{
    private readonly IImageRepository _repository;

    public ImageService(IImageRepository repository)
    {
        _repository = repository;
    }

    public async Task<ImageDto> AddClientImageAsync(int clientId, byte[] data, CancellationToken cancellationToken)
    {
        var image = await _repository.AddClientImageAsync(clientId, data, cancellationToken);
        return new ImageDto(image.Id, image.CreatedAt, image.Data.Length);
    }

    public async Task<IReadOnlyList<ImageDto>> GetClientImagesAsync(int clientId, CancellationToken cancellationToken)
    {
        var items = await _repository.GetClientImagesAsync(clientId, cancellationToken);
        return items.Select(x => new ImageDto(x.Id, x.CreatedAt, x.Data.Length)).ToList();
    }

    public async Task<ImageDto> AddVehicleImageAsync(string licensePlate, byte[] data, CancellationToken cancellationToken)
    {
        var image = await _repository.AddVehicleImageAsync(licensePlate, data, cancellationToken);
        return new ImageDto(image.Id, image.CreatedAt, image.Data.Length);
    }

    public async Task<IReadOnlyList<ImageDto>> GetVehicleImagesAsync(string licensePlate, CancellationToken cancellationToken)
    {
        var items = await _repository.GetVehicleImagesAsync(licensePlate, cancellationToken);
        return items.Select(x => new ImageDto(x.Id, x.CreatedAt, x.Data.Length)).ToList();
    }

    public Task<byte[]?> GetFirstVehicleImageDataAsync(string licensePlate, CancellationToken cancellationToken)
        => _repository.GetFirstVehicleImageDataAsync(licensePlate, cancellationToken);

    public Task<byte[]?> GetVehicleImageByIndexAsync(string licensePlate, int index, CancellationToken cancellationToken)
        => _repository.GetVehicleImageByIndexAsync(licensePlate, index, cancellationToken);

    public Task<byte[]?> GetClientImageByIndexAsync(int clientId, int index, CancellationToken cancellationToken)
        => _repository.GetClientImageByIndexAsync(clientId, index, cancellationToken);
}
