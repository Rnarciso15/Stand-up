using StandUp.Domain.Entities;

namespace StandUp.Application.Abstractions;

public interface IClientRepository
{
    Task<IReadOnlyList<Client>> GetAllAsync(CancellationToken cancellationToken);
    Task<IReadOnlyList<Client>> SearchByNameAsync(string name, CancellationToken cancellationToken);
    Task<Client> AddAsync(Client client, CancellationToken cancellationToken);
    Task<bool> SetActiveAsync(int id, bool isActive, CancellationToken cancellationToken);
}
