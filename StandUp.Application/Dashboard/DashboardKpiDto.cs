namespace StandUp.Application.Dashboard;

public sealed record DashboardKpiDto(
    int TotalAppointments,
    int TotalSales,
    decimal ConversionRate,
    double AvgDaysToSale,
    IReadOnlyList<TopVehicleDto> TopVehicles);

public sealed record TopVehicleDto(string LicensePlate, int SalesCount);
