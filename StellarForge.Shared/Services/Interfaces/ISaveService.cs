using StellarForge.Shared.DTOs;

namespace StellarForge.Shared.Services.Interfaces;

public interface ISaveService
{
    Task SaveAsync(SaveState state);
    Task<SaveState?> LoadAsync(string userId);
}
