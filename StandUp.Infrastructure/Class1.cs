using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StandUp.Application.Abstractions;
using StandUp.Infrastructure.Documents;
using StandUp.Infrastructure.Messaging;
using StandUp.Infrastructure.Persistence;
using StandUp.Infrastructure.Security;

namespace StandUp.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Sqlite")
            ?? "Data Source=standup.db";

        services.AddDbContext<StandUpDbContext>(options =>
            options.UseSqlite(connectionString));

        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IAuditRepository, AuditRepository>();
        services.AddScoped<IAppointmentRepository, AppointmentRepository>();
        services.AddScoped<IClientRepository, ClientRepository>();
        services.AddScoped<IDashboardRepository, DashboardRepository>();
        services.AddScoped<IImageRepository, ImageRepository>();
        services.AddScoped<INotificationLogRepository, NotificationLogRepository>();
        services.AddScoped<INotificationOutboxRepository, NotificationOutboxRepository>();
        services.AddScoped<IProposalRepository, ProposalRepository>();
        services.AddScoped<ISaleTransactionRepository, SaleTransactionRepository>();
        services.AddScoped<IVehicleRepository, VehicleRepository>();
        services.AddSingleton<IPdfProposalRenderer, SimplePdfProposalRenderer>();
        services.AddHttpClient("TwilioClient")
            .AddTypedClient<ISmsSender>((httpClient, sp) => new TwilioSmsSender(
                httpClient,
                Environment.GetEnvironmentVariable("TWILIO_ACCOUNT_SID") ?? configuration["Twilio:AccountSid"] ?? string.Empty,
                Environment.GetEnvironmentVariable("TWILIO_AUTH_TOKEN") ?? configuration["Twilio:AuthToken"] ?? string.Empty,
                Environment.GetEnvironmentVariable("TWILIO_FROM_NUMBER") ?? configuration["Twilio:FromNumber"] ?? string.Empty));
        services.AddSingleton<IPasswordHasher, Sha1PasswordHasher>();

        return services;
    }
}
