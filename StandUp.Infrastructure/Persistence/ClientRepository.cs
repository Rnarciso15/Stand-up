using Microsoft.EntityFrameworkCore;
using StandUp.Application.Abstractions;
using StandUp.Domain.Entities;

namespace StandUp.Infrastructure.Persistence;

public sealed class ClientRepository : IClientRepository
{
    private readonly StandUpDbContext _dbContext;

    public ClientRepository(StandUpDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IReadOnlyList<Client>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _dbContext.Clients
            .OrderBy(x => x.Id)
            .ToListAsync(cancellationToken);
    }

    public async Task<IReadOnlyList<Client>> SearchByNameAsync(string name, CancellationToken cancellationToken)
    {
        var term = name.Trim();
        return await _dbContext.Clients
            .Where(x => x.Name.Contains(term))
            .OrderBy(x => x.Name)
            .ToListAsync(cancellationToken);
    }

    public async Task<Client> AddAsync(Client client, CancellationToken cancellationToken)
    {
        _dbContext.Clients.Add(client);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return client;
    }

    public async Task<bool> SetActiveAsync(int id, bool isActive, CancellationToken cancellationToken)
    {
        var client = await _dbContext.Clients.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        if (client is null)
        {
            return false;
        }

        client.IsActive = isActive;
        await _dbContext.SaveChangesAsync(cancellationToken);
        return true;
    }
}
