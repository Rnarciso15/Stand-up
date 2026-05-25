using StandUp.Application.Dashboard;

namespace StandUp.Application.Abstractions;

public interface IDashboardRepository
{
    Task<DashboardKpiDto> GetKpisAsync(DateTime fromUtc, DateTime toUtc, CancellationToken cancellationToken);
}
