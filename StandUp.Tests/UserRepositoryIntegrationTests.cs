using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using StandUp.Domain.Entities;
using StandUp.Infrastructure.Persistence;

namespace StandUp.Tests;

public sealed class UserRepositoryIntegrationTests
{
    [Fact]
    public async Task GetByEmployeeNumberAsync_ReturnsUser_WhenExists()
    {
        await using var connection = new SqliteConnection("Data Source=:memory:");
        await connection.OpenAsync();

        var options = new DbContextOptionsBuilder<StandUpDbContext>()
            .UseSqlite(connection)
            .Options;

        await using var db = new StandUpDbContext(options);
        await db.Database.EnsureCreatedAsync();
        db.Users.Add(new User
        {
            EmployeeNumber = 2000,
            Name = "User",
            PasswordHash = "X",
            IsActive = true
        });
        await db.SaveChangesAsync();

        var repo = new UserRepository(db);
        var user = await repo.GetByEmployeeNumberAsync(2000, CancellationToken.None);

        Assert.NotNull(user);
        Assert.Equal("User", user!.Name);
    }
}
