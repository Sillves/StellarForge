using StellarForge.Shared.Models;

namespace StellarForge.Shared.DTOs;
public class SaveData
{
    public Dictionary<ResourceType, double> Resources { get; set; } = new();
    public DateTime LastSavedAt { get; set; } = DateTime.UtcNow;
}
