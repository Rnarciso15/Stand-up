namespace StandUp.Application.Dashboard;

public interface IDashboardService
{
    Task<DashboardKpiDto> GetKpisAsync(DateTime fromUtc, DateTime toUtc, CancellationToken cancellationToken);
}
