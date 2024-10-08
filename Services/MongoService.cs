using LxApi.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace LxApi.Services;

public class MongoService : IMongoService {
    private readonly IMongoDatabase _db;

    public MongoService(IOptions<MongoSettings> settings) {
        var client = new MongoClient(settings.Value.ConnectionURI);
        _db = client.GetDatabase(settings.Value.DatabaseName);
    }

    public IMongoCollection<BaseEntry> Entries => _db.GetCollection<BaseEntry>("Entries");
}
