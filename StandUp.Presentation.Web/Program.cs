using StandUp.Presentation.Web.Components;
using StandUp.Presentation.Web.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var apiBase = builder.Configuration["ApiBaseUrl"] ?? "https://localhost:7262/";
builder.Services.AddHttpClient<VehicleApiClient>(c => c.BaseAddress = new Uri(apiBase));
builder.Services.AddScoped<FavoritesService>();
builder.Services.AddScoped<RecentViewsService>();
builder.Services.AddSingleton<CompareService>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseAntiforgery();
app.MapStaticAssets();

// Proxy endpoint para o JS da pesquisa global
app.MapGet("/_search/vehicles", async (VehicleApiClient api) =>
    Results.Json(await api.GetAvailableAsync()));

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
