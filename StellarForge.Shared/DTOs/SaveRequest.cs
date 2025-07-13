namespace StellarForge.Shared.DTOs;

public class SaveRequest
{
    public string UserId { get; set; } = default!;
    public string GameJson { get; set; } = default!;
    public DateTime SavedAt { get; set; } = DateTime.UtcNow;
}
