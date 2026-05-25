using StandUp.Domain.Entities;

namespace StandUp.Application.Abstractions;

public interface IUserRepository
{
    Task<User?> GetByEmployeeNumberAsync(int employeeNumber, CancellationToken cancellationToken);
}
