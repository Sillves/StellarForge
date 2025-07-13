using Microsoft.Extensions.Options;
using MongoDB.Driver;
using StellarForge.Server.Models;
using StellarForge.Server.Utils.Settings;

namespace StellarForge.Server.Services;

public class SaveService
{
    private readonly IMongoCollection<SaveState> _saveCollection;

    public SaveService(IOptions<MongoSettings> options)
    {
        var client = new MongoClient(options.Value.ConnectionString);
        var database = client.GetDatabase(options.Value.DatabaseName);
        _saveCollection = database.GetCollection<SaveState>("saves");
    }

    public async Task<SaveState?> GetSaveAsync(string userId)
    {
        return await _saveCollection.Find(s => s.UserId == userId).FirstOrDefaultAsync();
    }

    public async Task UpsertSaveAsync(SaveState save)
    {
        var filter = Builders<SaveState>.Filter.Eq(s => s.UserId, save.UserId);
        await _saveCollection.ReplaceOneAsync(filter, save, new ReplaceOptions { IsUpsert = true });
    }
}
