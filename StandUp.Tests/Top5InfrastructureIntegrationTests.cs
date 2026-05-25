using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using StandUp.Domain.Entities;
using StandUp.Infrastructure.Persistence;

namespace StandUp.Tests;

public sealed class Top5InfrastructureIntegrationTests
{
    [Fact]
    public async Task NotificationOutboxRepository_GetDuePendingAsync_ReturnsOnlyDuePending()
    {
        await using var db = await CreateDbAsync();
        db.NotificationOutboxItems.AddRange(
            new NotificationOutboxItem { AppointmentId = 1, Type = "reminder_24h", Prefix = "Lembrete", Status = "pending", NextAttemptUtc = DateTime.UtcNow.AddMinutes(-1), CreatedAtUtc = DateTime.UtcNow, UpdatedAtUtc = DateTime.UtcNow },
            new NotificationOutboxItem { AppointmentId = 2, Type = "reminder_24h", Prefix = "Lembrete", Status = "sent", NextAttemptUtc = DateTime.UtcNow.AddMinutes(-1), CreatedAtUtc = DateTime.UtcNow, UpdatedAtUtc = DateTime.UtcNow });
        await db.SaveChangesAsync();

        var repo = new NotificationOutboxRepository(db);
        var result = await repo.GetDuePendingAsync(DateTime.UtcNow, 10, CancellationToken.None);

        Assert.Single(result);
        Assert.Equal(1, result[0].AppointmentId);
    }

    [Fact]
    public async Task AuditRepository_GetAsync_FiltersByEntity()
    {
        await using var db = await CreateDbAsync();
        db.AuditLogs.AddRange(
            new AuditLog { UserRole = "Admin", Action = "create", EntityName = "client", TimestampUtc = DateTime.UtcNow },
            new AuditLog { UserRole = "Admin", Action = "create", EntityName = "vehicle", TimestampUtc = DateTime.UtcNow });
        await db.SaveChangesAsync();

        var repo = new AuditRepository(db);
        var result = await repo.GetAsync(null, null, null, "vehicle", 100, CancellationToken.None);

        Assert.Single(result);
        Assert.Equal("vehicle", result[0].EntityName);
    }

    [Fact]
    public async Task ProposalRepository_PersistsTemplateVersion()
    {
        await using var db = await CreateDbAsync();
        var repo = new ProposalRepository(db);
        var proposal = new ProposalDocument
        {
            SaleTransactionId = 1,
            FileName = "p1.pdf",
            TemplateVersion = "v1",
            ValidUntilUtc = DateTime.UtcNow.AddDays(7),
            PdfBytes = [1, 2, 3],
            CreatedAtUtc = DateTime.UtcNow
        };

        var created = await repo.AddAsync(proposal, CancellationToken.None);

        Assert.True(created.Id > 0);
        Assert.Equal("v1", created.TemplateVersion);
    }

    [Fact]
    public async Task VehicleRepository_SearchAdvancedAsync_AppliesPagingAndSort()
    {
        await using var db = await CreateDbAsync();
        db.Vehicles.AddRange(
            new Vehicle { LicensePlate = "AA-00-AA", Brand = "BMW", Model = "A", Price = 5000, Kilometers = 10000, IsSold = false, RegistrationDate = DateTime.UtcNow.AddYears(-3) },
            new Vehicle { LicensePlate = "BB-00-BB", Brand = "BMW", Model = "B", Price = 7000, Kilometers = 9000, IsSold = false, RegistrationDate = DateTime.UtcNow.AddYears(-2) },
            new Vehicle { LicensePlate = "CC-00-CC", Brand = "BMW", Model = "C", Price = 9000, Kilometers = 8000, IsSold = false, RegistrationDate = DateTime.UtcNow.AddYears(-1) });
        await db.SaveChangesAsync();

        var repo = new VehicleRepository(db);
        var filter = new StandUp.Application.Vehicles.VehicleSearchFilter("BMW", null, null, null, null, null, null, null, null, false, 2, 1, "price", true);
        var result = await repo.SearchAdvancedAsync(filter, CancellationToken.None);

        Assert.Single(result);
        Assert.Equal("BB-00-BB", result[0].LicensePlate);
    }

    [Fact]
    public async Task DashboardRepository_GetKpisAsync_ReturnsZeroOnEmptyRange()
    {
        await using var db = await CreateDbAsync();
        var repo = new DashboardRepository(db);

        var kpi = await repo.GetKpisAsync(DateTime.UtcNow.AddDays(-1), DateTime.UtcNow, CancellationToken.None);

        Assert.Equal(0, kpi.TotalAppointments);
        Assert.Equal(0, kpi.TotalSales);
        Assert.Equal(0, kpi.ConversionRate);
    }

    private static async Task<StandUpDbContext> CreateDbAsync()
    {
        var connection = new SqliteConnection("Data Source=:memory:");
        await connection.OpenAsync();
        var options = new DbContextOptionsBuilder<StandUpDbContext>()
            .UseSqlite(connection)
            .Options;

        var db = new StandUpDbContext(options);
        await db.Database.EnsureCreatedAsync();
        return db;
    }
}
