using System.Net.Http.Json;
using StellarForge.Client.Services.Interfaces;
using StellarForge.Shared.DTOs;
using StellarForge.Shared.Services.Interfaces;
using StellarForge.Shared.Extensions;
using StellarForge.Shared;

namespace StellarForge.Client.Services;

public class SaveService : ISaveService
{
    private const string FakeUserId = "fake-user-id";

    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IGameStateService _gameStateService;

    public SaveService(IHttpClientFactory httpClientFactory, IGameStateService gameStateService)
    {
        _httpClientFactory = httpClientFactory;
        _gameStateService = gameStateService;
    }

    public async Task SaveGameAsync()
    {
        var savedData = _gameStateService.ToSavedData();
        var request = new SaveRequest
        {
            UserId = FakeUserId,
            GameJson = savedData.ToJson(),
            SavedAt = savedData.LastSavedAt
        };

        var client = _httpClientFactory.CreateClient("server");
        Console.WriteLine(client.BaseAddress + Routes.Save);

        var response = await client.PostAsJsonAsync(Routes.Save, request);
        response.EnsureSuccessStatusCode();
    }
}
