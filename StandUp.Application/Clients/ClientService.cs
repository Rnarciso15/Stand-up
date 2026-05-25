using StandUp.Application.Abstractions;
using StandUp.Domain.Entities;

namespace StandUp.Application.Clients;

public sealed class ClientService : IClientService
{
    private readonly IClientRepository _clientRepository;

    public ClientService(IClientRepository clientRepository)
    {
        _clientRepository = clientRepository;
    }

    public async Task<IReadOnlyList<ClientDto>> GetAllAsync(CancellationToken cancellationToken)
    {
        var clients = await _clientRepository.GetAllAsync(cancellationToken);
        return clients.Select(Map).ToList();
    }

    public async Task<IReadOnlyList<ClientDto>> SearchByNameAsync(string name, CancellationToken cancellationToken)
    {
        var clients = await _clientRepository.SearchByNameAsync(name, cancellationToken);
        return clients.Select(Map).ToList();
    }

    public async Task<ClientDto> CreateAsync(CreateClientRequest request, CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(request.Name))
        {
            throw new ArgumentException("Nome é obrigatório.");
        }

        var client = new Client
        {
            Name = request.Name.Trim(),
            BirthDate = request.BirthDate,
            Gender = request.Gender,
            Email = request.Email,
            Phone = request.Phone,
            Nib = request.Nib,
            Nif = request.Nif,
            Address = request.Address,
            IsActive = true
        };

        var created = await _clientRepository.AddAsync(client, cancellationToken);
        return Map(created);
    }

    public Task<bool> SetActiveAsync(int id, bool isActive, CancellationToken cancellationToken)
    {
        return _clientRepository.SetActiveAsync(id, isActive, cancellationToken);
    }

    private static ClientDto Map(Client x) =>
        new(x.Id, x.Name, x.BirthDate, x.Gender, x.Email, x.Phone, x.Nib, x.Nif, x.Address, x.IsActive);
}
