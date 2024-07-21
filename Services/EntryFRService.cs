using LxApi.Models;
using MongoDB.Driver;

namespace LxApi.Services;

public class EntryFRService : IEntryFRService {
    private readonly IMongoCollection<EntryFR> _entryCollection;

    public EntryFRService(IMongoService mongo) {
        _entryCollection = mongo.EntriesFR;
    }
}
