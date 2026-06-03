using Microsoft.JSInterop;

namespace StandUp.Presentation.Web.Services;

public sealed class RecentViewsService(IJSRuntime js)
{
    public async Task<List<string>> GetPlatesAsync()
    {
        try { return (await js.InvokeAsync<string[]>("su.recent.get"))?.ToList() ?? []; }
        catch { return []; }
    }

    public async Task AddAsync(string plate)
    {
        try { await js.InvokeVoidAsync("su.recent.add", plate); }
        catch { }
    }
}
