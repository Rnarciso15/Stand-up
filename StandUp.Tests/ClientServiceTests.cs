using StandUp.Application.Abstractions;
using StandUp.Application.Clients;
using StandUp.Domain.Entities;

namespace StandUp.Tests;

public sealed class ClientServiceTests
{
    [Fact]
    public async Task CreateAsync_CreatesActiveClient()
    {
        var repo = new InMemoryClientRepository();
        var sut = new ClientService(repo);

        var created = await sut.CreateAsync(
            new CreateClientRequest("Maria", null, null, "maria@x.pt", "910000000", null, "123456789", "Rua A"),
            CancellationToken.None);

        Assert.True(created.IsActive);
        Assert.Equal("Maria", created.Name);
    }

    private sealed class InMemoryClientRepository : IClientRepository
    {
        private readonly List<Client> _clients = [];
        private int _id = 0;

        public Task<IReadOnlyList<Client>> GetAllAsync(CancellationToken cancellationToken) =>
            Task.FromResult((IReadOnlyList<Client>)_clients);

        public Task<IReadOnlyList<Client>> SearchByNameAsync(string name, CancellationToken cancellationToken) =>
            Task.FromResult((IReadOnlyList<Client>)_clients.Where(x => x.Name.Contains(name)).ToList());

        public Task<Client> AddAsync(Client client, CancellationToken cancellationToken)
        {
            client.Id = ++_id;
            _clients.Add(client);
            return Task.FromResult(client);
        }

        public Task<bool> SetActiveAsync(int id, bool isActive, CancellationToken cancellationToken)
        {
            var client = _clients.FirstOrDefault(x => x.Id == id);
            if (client is null) return Task.FromResult(false);
            client.IsActive = isActive;
            return Task.FromResult(true);
        }
    }
}
