using StandUp.Domain.Entities;

namespace StandUp.Application.Abstractions;

public interface IUserRepository
{
    Task<User?> GetByEmployeeNumberAsync(int employeeNumber, CancellationToken cancellationToken);
    Task<bool> ExistsByEmployeeNumberAsync(int employeeNumber, CancellationToken cancellationToken);
    Task<User> AddAsync(User user, CancellationToken cancellationToken);
}
