using StellarForge.ApiService.Models;

namespace StellarForge.ApiService.Services;

public class SaveService
{
    private readonly Dictionary<string, SaveState> _saves = new();

    public Task<SaveState?> GetSaveAsync(string userId)
    {
        _saves.TryGetValue(userId, out var save);
        return Task.FromResult(save);
    }

    public Task UpsertSaveAsync(SaveState save)
    {
        _saves[save.UserId] = save;
        return Task.CompletedTask;
    }
}
