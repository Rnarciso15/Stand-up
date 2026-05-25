namespace StandUp.Application.Clients;

public interface IClientService
{
    Task<IReadOnlyList<ClientDto>> GetAllAsync(CancellationToken cancellationToken);
    Task<IReadOnlyList<ClientDto>> SearchByNameAsync(string name, CancellationToken cancellationToken);
    Task<ClientDto> CreateAsync(CreateClientRequest request, CancellationToken cancellationToken);
    Task<bool> SetActiveAsync(int id, bool isActive, CancellationToken cancellationToken);
}
