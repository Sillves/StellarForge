using StellarForge.Shared.DTOs;
using StellarForge.Shared.Models;
using StellarForge.Shared.Services.Interfaces;

using System.Text.Json;

namespace StellarForge.Client.Services;

public class GameStateService : IGameStateService
{
    public event Action? OnStateChanged;
    private readonly Dictionary<ResourceType, ResourceAmount> _resources = new();

    public GameStateService()
    {
        _resources[ResourceType.Titanium] = new ResourceAmount
        {
            Type = ResourceType.Titanium,
            Amount = 0
        };
    }

    public IReadOnlyDictionary<ResourceType, ResourceAmount> AllResources => _resources;


    public double GetAmount(ResourceType resourceType)
    {
        return _resources.TryGetValue(resourceType, out var resource) ? resource.Amount : 0;
    }

    public void Add(ResourceType resourceType, double amount)
    {
        if (!_resources.ContainsKey(resourceType))
            _resources[resourceType] = new ResourceAmount { Type = resourceType, Amount = 0 };

        _resources[resourceType].Amount += amount;
        OnStateChanged?.Invoke(); // trigger
    }

    public SaveData ToSavedData()
    {
        return new SaveData
        {
            Resources = _resources.ToDictionary(
                r => r.Key,
                r => r.Value.Amount
                ),
            LastSavedAt = DateTime.UtcNow
        };
    }
}
