using StandUp.Application.Abstractions;
using StandUp.Application.Notifications;
using StandUp.Domain.Entities;

namespace StandUp.Tests;

public sealed class NotificationServiceTests
{
    [Fact]
    public async Task SendAppointmentReminderAsync_DoesNotSend_WhenConsentMissing()
    {
        var appointments = new FakeAppointmentRepository(new Appointment
        {
            Id = 1,
            DateTimeSlot = DateTime.UtcNow.AddHours(2),
            ClientPhone = "+351910000000",
            SmsConsentGranted = false,
            VehicleBrand = "BMW",
            VehicleModel = "320",
            VehicleLicensePlate = "AA-00-AA"
        });
        var logs = new FakeNotificationLogRepository();
        var outbox = new FakeOutboxRepository();
        var sms = new FakeSmsSender((false, "failed", null, "x"));
        var sut = new NotificationService(appointments, sms, logs, outbox);

        var result = await sut.SendAppointmentReminderAsync(1, 24, CancellationToken.None);

        Assert.False(result.Success);
        Assert.Equal("consent_missing", result.Status);
        Assert.Equal(0, sms.Calls);
    }

    [Fact]
    public async Task SendAppointmentReminderAsync_IsIdempotent_WhenAlreadySent()
    {
        var appointments = new FakeAppointmentRepository(BuildValidAppointment());
        var logs = new FakeNotificationLogRepository { Exists = true };
        var outbox = new FakeOutboxRepository();
        var sms = new FakeSmsSender((true, "sent", "sid", null));
        var sut = new NotificationService(appointments, sms, logs, outbox);

        var result = await sut.SendAppointmentReminderAsync(1, 24, CancellationToken.None);

        Assert.True(result.Success);
        Assert.Equal("already_sent", result.Status);
        Assert.Equal(0, sms.Calls);
    }

    [Fact]
    public async Task SendAppointmentReminderAsync_QueuesOutbox_WhenRetryFails()
    {
        var appointments = new FakeAppointmentRepository(BuildValidAppointment());
        var logs = new FakeNotificationLogRepository();
        var outbox = new FakeOutboxRepository();
        var sms = new FakeSmsSender((false, "failed", null, "provider_error"));
        var sut = new NotificationService(appointments, sms, logs, outbox);

        var result = await sut.SendAppointmentReminderAsync(1, 24, CancellationToken.None);

        Assert.False(result.Success);
        Assert.Single(outbox.Items);
        Assert.Equal("pending", outbox.Items[0].Status);
    }

    private static Appointment BuildValidAppointment() => new()
    {
        Id = 1,
        DateTimeSlot = DateTime.UtcNow.AddHours(2),
        ClientPhone = "+351910000000",
        SmsConsentGranted = true,
        SmsConsentTimestampUtc = DateTime.UtcNow,
        VehicleBrand = "BMW",
        VehicleModel = "320",
        VehicleLicensePlate = "AA-00-AA"
    };

    private sealed class FakeAppointmentRepository : IAppointmentRepository
    {
        private readonly Appointment? _item;
        public FakeAppointmentRepository(Appointment? item) => _item = item;
        public Task<Appointment?> GetByIdAsync(int id, CancellationToken cancellationToken) => Task.FromResult(_item);
        public Task<IReadOnlyList<Appointment>> GetByDateAsync(DateTime dateOnly, CancellationToken cancellationToken) => Task.FromResult((IReadOnlyList<Appointment>)[]);
        public Task<IReadOnlyList<Appointment>> GetBetweenAsync(DateTime fromUtc, DateTime toUtc, CancellationToken cancellationToken) => Task.FromResult((IReadOnlyList<Appointment>)[]);
        public Task<bool> ExistsEmployeeConflictAsync(DateTime dateTimeSlot, int employeeNumber, CancellationToken cancellationToken) => Task.FromResult(false);
        public Task<bool> ExistsClientConflictAsync(DateTime dateTimeSlot, int clientId, CancellationToken cancellationToken) => Task.FromResult(false);
        public Task<bool> ExistsVehicleConflictAsync(DateTime dateTimeSlot, string vehicleLicensePlate, CancellationToken cancellationToken) => Task.FromResult(false);
        public Task<Appointment> AddAsync(Appointment appointment, CancellationToken cancellationToken) => Task.FromResult(appointment);
        public Task<bool> DeleteAsync(int id, CancellationToken cancellationToken) => Task.FromResult(false);
    }

    private sealed class FakeNotificationLogRepository : INotificationLogRepository
    {
        public bool Exists { get; set; }
        public Task AddAsync(NotificationLog log, CancellationToken cancellationToken) => Task.CompletedTask;
        public Task<bool> ExistsForAppointmentAndTypeAsync(int appointmentId, string type, CancellationToken cancellationToken) => Task.FromResult(Exists);
    }

    private sealed class FakeOutboxRepository : INotificationOutboxRepository
    {
        public List<NotificationOutboxItem> Items { get; } = [];
        public Task AddAsync(NotificationOutboxItem item, CancellationToken cancellationToken)
        {
            Items.Add(item);
            return Task.CompletedTask;
        }
        public Task<IReadOnlyList<NotificationOutboxItem>> GetDuePendingAsync(DateTime nowUtc, int limit, CancellationToken cancellationToken) => Task.FromResult((IReadOnlyList<NotificationOutboxItem>)Items);
        public Task UpdateAsync(NotificationOutboxItem item, CancellationToken cancellationToken) => Task.CompletedTask;
    }

    private sealed class FakeSmsSender : ISmsSender
    {
        private readonly (bool Success, string Status, string? ProviderMessageId, string? Error) _result;
        public int Calls { get; private set; }
        public FakeSmsSender((bool Success, string Status, string? ProviderMessageId, string? Error) result) => _result = result;
        public Task<(bool Success, string Status, string? ProviderMessageId, string? Error)> SendAsync(string to, string body, CancellationToken cancellationToken)
        {
            Calls++;
            return Task.FromResult(_result);
        }
    }
}
