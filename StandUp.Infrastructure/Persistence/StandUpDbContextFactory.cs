using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace StandUp.Infrastructure.Persistence;

public sealed class StandUpDbContextFactory : IDesignTimeDbContextFactory<StandUpDbContext>
{
    public StandUpDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<StandUpDbContext>();
        optionsBuilder.UseSqlite("Data Source=standup.db");
        return new StandUpDbContext(optionsBuilder.Options);
    }
}
