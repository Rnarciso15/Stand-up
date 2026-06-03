using Microsoft.JSInterop;

namespace StandUp.Presentation.Web.Services;

public sealed class FavoritesService(IJSRuntime js)
{
    public async Task<List<string>> GetPlatesAsync()
    {
        try { return (await js.InvokeAsync<string[]>("su.favorites.get"))?.ToList() ?? []; }
        catch { return []; }
    }

    public async Task<bool> HasAsync(string plate)
    {
        try { return await js.InvokeAsync<bool>("su.favorites.has", plate); }
        catch { return false; }
    }

    public async Task ToggleAsync(string plate)
    {
        try
        {
            if (await HasAsync(plate))
                await js.InvokeVoidAsync("su.favorites.remove", plate);
            else
                await js.InvokeVoidAsync("su.favorites.add", plate);
        }
        catch { }
    }

    public async Task<int> CountAsync()
    {
        try { return await js.InvokeAsync<int>("su.favorites.count"); }
        catch { return 0; }
    }
}
