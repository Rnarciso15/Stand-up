using StandUp.Application.Abstractions;
using StandUp.Application.Auth;
using StandUp.Domain.Entities;

namespace StandUp.Tests;

public sealed class AuthenticationServiceTests
{
    [Fact]
    public async Task LoginAsync_ReturnsSuccess_WhenCredentialsAreValid()
    {
        var repo = new FakeRepository(new User
        {
            EmployeeNumber = 1000,
            Name = "Admin",
            PasswordHash = "HASH",
            IsActive = true,
            IsAdmin = true
        });
        var hasher = new FakeHasher("HASH");
        var sut = new AuthenticationService(repo, hasher);

        var result = await sut.LoginAsync(new LoginRequest(1000, "teste"), CancellationToken.None);

        Assert.True(result.IsAuthenticated);
        Assert.True(result.IsAdmin);
    }

    private sealed class FakeRepository : IUserRepository
    {
        private readonly User? _user;
        public FakeRepository(User? user) => _user = user;
        public Task<User?> GetByEmployeeNumberAsync(int employeeNumber, CancellationToken cancellationToken)
            => Task.FromResult(_user);
        public Task<bool> ExistsByEmployeeNumberAsync(int employeeNumber, CancellationToken cancellationToken)
            => Task.FromResult(false);
        public Task<User> AddAsync(User user, CancellationToken cancellationToken)
            => Task.FromResult(user);
    }

    private sealed class FakeHasher : IPasswordHasher
    {
        private readonly string _hash;
        public FakeHasher(string hash) => _hash = hash;
        public string Hash(string plainText) => _hash;
    }
}
