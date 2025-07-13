using StellarForge.Shared.DTOs;
using StellarForge.Shared.Models;

namespace StellarForge.Shared.Services.Interfaces;

public interface IGameStateService
{
    event Action? OnStateChanged;

    double GetAmount(ResourceType resourceType);
    void Add(ResourceType resourceType, double amount);
    IReadOnlyDictionary<ResourceType, ResourceAmount> AllResources { get; }
    SaveData ToSavedData();
}
