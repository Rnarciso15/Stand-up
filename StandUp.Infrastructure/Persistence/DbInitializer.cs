using Microsoft.EntityFrameworkCore;
using StandUp.Domain.Entities;

namespace StandUp.Infrastructure.Persistence;

public static class DbInitializer
{
    public static async Task InitializeAsync(StandUpDbContext dbContext, CancellationToken cancellationToken = default)
    {
        await dbContext.Database.MigrateAsync(cancellationToken);
        await SeedDemoDataAsync(dbContext, cancellationToken);
    }

    private static async Task SeedDemoDataAsync(StandUpDbContext dbContext, CancellationToken cancellationToken)
    {
        if (!await dbContext.Clients.AnyAsync(cancellationToken))
        {
            dbContext.Clients.AddRange(
                new Client
                {
                    Name = "Joao Silva",
                    Email = "joao.silva@demo.pt",
                    Phone = "910000001",
                    Nif = "123456789",
                    Address = "Rua A, Lisboa",
                    IsActive = true
                },
                new Client
                {
                    Name = "Maria Santos",
                    Email = "maria.santos@demo.pt",
                    Phone = "910000002",
                    Nif = "987654321",
                    Address = "Rua B, Porto",
                    IsActive = true
                });
        }

        if (!await dbContext.Vehicles.AnyAsync(cancellationToken))
        {
            dbContext.Vehicles.AddRange(
                new Vehicle
                {
                    LicensePlate = "AA-00-AA",
                    Brand = "BMW",
                    Model = "320d",
                    Fuel = "Diesel",
                    Kilometers = 85000,
                    Price = 22500,
                    IsSold = false,
                    IsMotorcycle = false
                },
                new Vehicle
                {
                    LicensePlate = "BB-11-BB",
                    Brand = "Yamaha",
                    Model = "MT-07",
                    Fuel = "Gasolina",
                    Kilometers = 15000,
                    Price = 7200,
                    IsSold = false,
                    IsMotorcycle = true
                });
        }

        await dbContext.SaveChangesAsync(cancellationToken);

        if (!await dbContext.Appointments.AnyAsync(cancellationToken))
        {
            var firstClient = await dbContext.Clients.OrderBy(x => x.Id).FirstOrDefaultAsync(cancellationToken);
            var firstVehicle = await dbContext.Vehicles.OrderBy(x => x.Id).FirstOrDefaultAsync(cancellationToken);
            if (firstClient is not null && firstVehicle is not null)
            {
                dbContext.Appointments.Add(new Appointment
                {
                    DateOnly = DateTime.Today,
                    DateTimeSlot = DateTime.Today.AddHours(11),
                    EmployeeNumber = 1000,
                    EmployeeName = "Administrador",
                    ClientId = firstClient.Id,
                    ClientName = firstClient.Name,
                    VehicleBrand = firstVehicle.Brand,
                    VehicleModel = firstVehicle.Model,
                    VehicleLicensePlate = firstVehicle.LicensePlate
                });
            }
        }

        if (!await dbContext.SaleTransactions.AnyAsync(cancellationToken))
        {
            dbContext.SaleTransactions.Add(new SaleTransaction
            {
                ClientNif = "123456789",
                ClientName = "Joao Silva",
                VehicleLicensePlate = "CC-22-CC",
                TransactionDate = DateTime.Today.AddDays(-7),
                Value = 15400
            });
        }

        await dbContext.SaveChangesAsync(cancellationToken);
    }
}
