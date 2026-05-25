using Microsoft.Extensions.DependencyInjection;
using StandUp.Application.Abstractions;
using StandUp.Application.Auth;
using StandUp.Application.Appointments;
using StandUp.Application.Authorization;
using StandUp.Application.Auditing;
using StandUp.Application.Clients;
using StandUp.Application.Dashboard;
using StandUp.Application.Images;
using StandUp.Application.Notifications;
using StandUp.Application.Proposals;
using StandUp.Application.Sales;
using StandUp.Application.Vehicles;

namespace StandUp.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IAuthenticationService, AuthenticationService>();
        services.AddScoped<IAppointmentService, AppointmentService>();
        services.AddScoped<IAuthorizationService, AuthorizationService>();
        services.AddScoped<IAuditService, AuditService>();
        services.AddScoped<IClientService, ClientService>();
        services.AddScoped<IDashboardService, DashboardService>();
        services.AddScoped<IImageService, ImageService>();
        services.AddScoped<INotificationService, NotificationService>();
        services.AddScoped<IProposalDocumentService, ProposalDocumentService>();
        services.AddScoped<ISaleTransactionService, SaleTransactionService>();
        services.AddScoped<IVehicleService, VehicleService>();
        return services;
    }
}
