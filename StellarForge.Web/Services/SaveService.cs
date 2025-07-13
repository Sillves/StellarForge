using System.Net.Http.Json;

using StellarForge.Shared.DTOs;
using StellarForge.Shared.Services.Interfaces;

namespace StellarForge.Web.Services;

public class SaveService : ISaveService
{
    private readonly HttpClient _httpClient;

    public SaveService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task SaveAsync(SaveState state)
    {
        var response = await _httpClient.PostAsJsonAsync("api/save", state);
        response.EnsureSuccessStatusCode();
    }

    public async Task<SaveState?> LoadAsync(string userId)
    {
        return await _httpClient.GetFromJsonAsync<SaveState>($"api/save/{userId}");
    }
}
