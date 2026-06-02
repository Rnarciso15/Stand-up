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
                var apiBaseUrl = context.Configuration["ApiBaseUrl"] ?? "http://localhost:5196/";
                void Configure(HttpClient c) { c.BaseAddress = new Uri(apiBaseUrl); c.Timeout = TimeSpan.FromSeconds(10); }
                services.AddHttpClient<IAuthApiClient, AuthApiClient>(Configure);
                services.AddHttpClient<IClientApiClient, ClientApiClient>(Configure);
                services.AddHttpClient<IVehicleApiClient, VehicleApiClient>(Configure);
                services.AddHttpClient<IAppointmentApiClient, AppointmentApiClient>(Configure);
                services.AddHttpClient<ISalesApiClient, SalesApiClient>(Configure);
                services.AddHttpClient<IImagesApiClient, ImagesApiClient>(Configure);
                services.AddHttpClient<IDashboardApiClient, DashboardApiClient>(Configure);
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
