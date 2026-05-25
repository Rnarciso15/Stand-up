using StandUp.Application.Abstractions;

namespace StandUp.Application.Dashboard;

public sealed class DashboardService : IDashboardService
{
    private readonly IDashboardRepository _repository;

    public DashboardService(IDashboardRepository repository)
    {
        _repository = repository;
    }

    public Task<DashboardKpiDto> GetKpisAsync(DateTime fromUtc, DateTime toUtc, CancellationToken cancellationToken)
        => _repository.GetKpisAsync(fromUtc, toUtc, cancellationToken);
}
