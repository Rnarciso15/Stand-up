using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Sentry;

namespace StandUp.Presentation.WinForms;

internal static class Program
{
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();

        using var host = Host.CreateDefaultBuilder()
            .ConfigureAppConfiguration(config =>
            {
                config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            })
            .ConfigureServices((context, services) =>
            {
                var apiBaseUrl = context.Configuration["ApiBaseUrl"] ?? "https://localhost:7262/";
                services.AddHttpClient<IAuthApiClient, AuthApiClient>(client =>
                {
                    client.BaseAddress = new Uri(apiBaseUrl);
                });
                services.AddHttpClient<IClientApiClient, ClientApiClient>(client =>
                {
                    client.BaseAddress = new Uri(apiBaseUrl);
                });
                services.AddHttpClient<IVehicleApiClient, VehicleApiClient>(client =>
                {
                    client.BaseAddress = new Uri(apiBaseUrl);
                });
                services.AddHttpClient<IAppointmentApiClient, AppointmentApiClient>(client =>
                {
                    client.BaseAddress = new Uri(apiBaseUrl);
                });
                services.AddHttpClient<ISalesApiClient, SalesApiClient>(client =>
                {
                    client.BaseAddress = new Uri(apiBaseUrl);
                });
                services.AddHttpClient<IImagesApiClient, ImagesApiClient>(client =>
                {
                    client.BaseAddress = new Uri(apiBaseUrl);
                });
                services.AddHttpClient<IDashboardApiClient, DashboardApiClient>(client =>
                {
                    client.BaseAddress = new Uri(apiBaseUrl);
                });
                services.AddTransient<Form1>();
                services.AddTransient<ClientsForm>();
                services.AddTransient<VehiclesForm>();
                services.AddTransient<AppointmentsForm>();
                services.AddTransient<SalesForm>();
                services.AddTransient<ImagesForm>();
                services.AddTransient<DashboardForm>();
            })
            .Build();

        var dsn = host.Services.GetRequiredService<IConfiguration>()["Sentry:Dsn"];
        if (!string.IsNullOrWhiteSpace(dsn))
        {
            SentrySdk.Init(options => options.Dsn = dsn);
        }

        using var scope = host.Services.CreateScope();
        var form = scope.ServiceProvider.GetRequiredService<Form1>();
        System.Windows.Forms.Application.Run(form);
    }
}
