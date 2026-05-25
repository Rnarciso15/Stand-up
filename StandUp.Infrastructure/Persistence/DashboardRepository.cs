using Microsoft.EntityFrameworkCore;
using StandUp.Application.Abstractions;
using StandUp.Application.Dashboard;

namespace StandUp.Infrastructure.Persistence;

public sealed class DashboardRepository : IDashboardRepository
{
    private readonly StandUpDbContext _dbContext;

    public DashboardRepository(StandUpDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<DashboardKpiDto> GetKpisAsync(DateTime fromUtc, DateTime toUtc, CancellationToken cancellationToken)
    {
        var appointments = await _dbContext.Appointments
            .CountAsync(x => x.DateTimeSlot >= fromUtc && x.DateTimeSlot <= toUtc, cancellationToken);
        var sales = await _dbContext.SaleTransactions
            .Where(x => x.TransactionDate >= fromUtc && x.TransactionDate <= toUtc)
            .ToListAsync(cancellationToken);

        var totalSales = sales.Count;
        var conversionRate = appointments == 0 ? 0 : (decimal)totalSales / appointments * 100m;
        var avgDaysToSale = sales.Count == 0 ? 0 : sales.Average(x => (toUtc - x.TransactionDate).TotalDays);
        var topVehicles = sales
            .GroupBy(x => x.VehicleLicensePlate)
            .Select(g => new TopVehicleDto(g.Key, g.Count()))
            .OrderByDescending(x => x.SalesCount)
            .Take(5)
            .ToList();

        return new DashboardKpiDto(appointments, totalSales, Math.Round(conversionRate, 2), Math.Round(avgDaysToSale, 2), topVehicles);
    }
}
