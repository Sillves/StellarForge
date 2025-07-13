namespace StellarForge.ApiService.Models;

public class SaveState
{
    public string UserId { get; set; } = default!;
    public string GameJson { get; set; } = default!;
    public DateTime SavedAt { get; set; }
}
