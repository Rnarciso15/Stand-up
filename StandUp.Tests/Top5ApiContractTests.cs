using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StandUp.Application.Abstractions;
using StandUp.Application.Auditing;
using StandUp.Application.Dashboard;
using StandUp.Application.Notifications;
using StandUp.Application.Proposals;
using StandUp.Application.Vehicles;
using StandUp.Domain.Entities;
using StandUp.Presentation.Api.Controllers;

namespace StandUp.Tests;

public sealed class Top5ApiContractTests
{
    [Fact]
    public async Task NotificationsController_ProcessOutbox_ReturnsOkObject()
    {
        var sut = new NotificationsController(new FakeNotificationService());
        var result = await sut.ProcessOutbox(CancellationToken.None);

        Assert.IsType<OkObjectResult>(result.Result);
    }

    [Fact]
    public async Task DashboardController_Get_ReturnsKpiPayload()
    {
        var sut = new DashboardController(new FakeDashboardService());
        var result = await sut.Get(DateTime.UtcNow.AddDays(-1), DateTime.UtcNow, CancellationToken.None);

        Assert.Equal(1, result.TotalAppointments);
        Assert.Equal(1, result.TotalSales);
    }

    [Fact]
    public async Task VehiclesController_AdvancedSearch_ReturnsOk()
    {
        var sut = new VehiclesController(new FakeVehicleService(), new AuditService(new FakeAuditRepository()))
        {
            ControllerContext = new ControllerContext { HttpContext = new DefaultHttpContext() }
        };
        var result = await sut.AdvancedSearch("BMW", null, null, null, null, null, null, null, null, false, 1, 20, "price", false, CancellationToken.None);

        Assert.IsType<OkObjectResult>(result.Result);
    }

    [Fact]
    public async Task ProposalsController_Download_ReturnsFile_WhenExists()
    {
        var sut = new ProposalsController(new FakeProposalService());
        var result = await sut.Download(10, CancellationToken.None);

        Assert.IsType<FileContentResult>(result);
    }

    private sealed class FakeNotificationService : INotificationService
    {
        public Task<NotificationResultDto> SendAppointmentConfirmationAsync(int appointmentId, CancellationToken cancellationToken) => Task.FromResult(new NotificationResultDto(true, "sent", "id", null));
        public Task<NotificationResultDto> SendAppointmentReminderAsync(int appointmentId, int hoursBefore, CancellationToken cancellationToken) => Task.FromResult(new NotificationResultDto(true, "sent", "id", null));
        public Task<NotificationResultDto> SendAppointmentCancellationAsync(int appointmentId, CancellationToken cancellationToken) => Task.FromResult(new NotificationResultDto(true, "sent", "id", null));
        public Task<int> ProcessOutboxAsync(CancellationToken cancellationToken) => Task.FromResult(3);
    }

    private sealed class FakeDashboardService : IDashboardService
    {
        public Task<DashboardKpiDto> GetKpisAsync(DateTime fromUtc, DateTime toUtc, CancellationToken cancellationToken)
            => Task.FromResult(new DashboardKpiDto(1, 1, 100, 2, [new TopVehicleDto("AA-00-AA", 1)]));
    }

    private sealed class FakeVehicleService : IVehicleService
    {
        public Task<IReadOnlyList<VehicleDto>> GetAllAsync(bool isSold, CancellationToken cancellationToken) => Task.FromResult((IReadOnlyList<VehicleDto>)[]);
        public Task<IReadOnlyList<VehicleDto>> SearchByLicensePlateAsync(string licensePlate, bool isSold, CancellationToken cancellationToken) => Task.FromResult((IReadOnlyList<VehicleDto>)[]);
        public Task<VehicleDto> CreateAsync(CreateVehicleRequest request, CancellationToken cancellationToken) => Task.FromResult(new VehicleDto("AA-00-AA", 0, DateTime.UtcNow, "BMW", "A", null, 0, false, false));
        public Task<bool> SetSoldAsync(string licensePlate, bool isSold, CancellationToken cancellationToken) => Task.FromResult(true);
        public Task<IReadOnlyList<VehicleDto>> SearchAdvancedAsync(VehicleSearchFilter filter, CancellationToken cancellationToken)
            => Task.FromResult((IReadOnlyList<VehicleDto>)[new VehicleDto("AA-00-AA", 0, DateTime.UtcNow, "BMW", "A", null, 0, false, false)]);
    }

    private sealed class FakeProposalService : IProposalDocumentService
    {
        public Task<ProposalDocumentDto> GenerateAsync(int saleTransactionId, DateTime validUntilUtc, CancellationToken cancellationToken)
            => Task.FromResult(new ProposalDocumentDto(1, saleTransactionId, "p.pdf", "v1", validUntilUtc, DateTime.UtcNow));
        public Task<IReadOnlyList<ProposalDocumentDto>> GetBySaleTransactionAsync(int saleTransactionId, CancellationToken cancellationToken)
            => Task.FromResult((IReadOnlyList<ProposalDocumentDto>)[new ProposalDocumentDto(1, saleTransactionId, "p.pdf", "v1", DateTime.UtcNow.AddDays(7), DateTime.UtcNow)]);
        public Task<byte[]?> GetPdfBytesAsync(int proposalId, CancellationToken cancellationToken) => Task.FromResult<byte[]?>([1, 2, 3]);
    }

    private sealed class FakeAuditRepository : IAuditRepository
    {
        public Task AddAsync(AuditLog log, CancellationToken cancellationToken) => Task.CompletedTask;
        public Task<IReadOnlyList<AuditLog>> GetAsync(DateTime? fromUtc, DateTime? toUtc, string? userRole, string? entityName, int take, CancellationToken cancellationToken)
            => Task.FromResult((IReadOnlyList<AuditLog>)[]);
    }
}
