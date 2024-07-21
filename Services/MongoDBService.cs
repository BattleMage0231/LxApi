using LxApi.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace LxApi.Services;

public class MongoDBService : IMongoDBService {
    private readonly IMongoDatabase _db;

    public MongoDBService(IOptions<MongoDBSettings> settings) {
        var client = new MongoClient(settings.Value.ConnectionURI);
        _db = client.GetDatabase(settings.Value.DatabaseName);
    }
}
