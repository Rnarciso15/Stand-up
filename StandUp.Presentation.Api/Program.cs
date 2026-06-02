using Sentry.AspNetCore;
using StandUp.Application;
using StandUp.Infrastructure;
using StandUp.Infrastructure.Persistence;
using StandUp.Presentation.Api.Background;

var builder = WebApplication.CreateBuilder(args);
builder.WebHost.UseSentry();

builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);
if (builder.Configuration.GetValue<bool>("FeatureFlags:Notifications"))
{
    builder.Services.AddHostedService<AppointmentReminderBackgroundService>();
}

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

if (!app.Environment.IsDevelopment())
{
    app.UseHttpsRedirection();
}
app.UseAuthorization();
app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<StandUpDbContext>();
    await DbInitializer.InitializeAsync(db);
}

app.Run();
