using MongoDB.Bson.Serialization.Attributes;

namespace StellarForge.Server.Models;

public class SaveState
{
    [BsonId]
    public string UserId { get; set; }
    public string GameJson { get; set; }
    public DateTime LastSavedAt { get; set; } = DateTime.UtcNow;
}
