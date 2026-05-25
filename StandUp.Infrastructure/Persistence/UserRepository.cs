using Microsoft.EntityFrameworkCore;
using StandUp.Application.Abstractions;
using StandUp.Domain.Entities;

namespace StandUp.Infrastructure.Persistence;

public sealed class UserRepository : IUserRepository
{
    private readonly StandUpDbContext _dbContext;

    public UserRepository(StandUpDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<User?> GetByEmployeeNumberAsync(int employeeNumber, CancellationToken cancellationToken)
    {
        return _dbContext.Users.FirstOrDefaultAsync(x => x.EmployeeNumber == employeeNumber, cancellationToken);
    }
}
