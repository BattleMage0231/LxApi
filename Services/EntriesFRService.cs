using LxApi.Models;
using MongoDB.Driver;

namespace LxApi.Services;

using Entry = EntryFR;

public class EntriesFRService : IEntriesFRService {
    private readonly IMongoCollection<Entry> _entryCollection;

    public EntriesFRService(IMongoService mongo) {
        _entryCollection = mongo.EntriesFR;
    }

    public async Task<List<Entry>> GetAllAsync() {
        return await _entryCollection.Find(_ => true).ToListAsync();
    }

    public async Task CreateAsync(Entry entry) {
        await _entryCollection.InsertOneAsync(entry);
    }

    public async Task DeleteAsync(string id) {
        await _entryCollection.DeleteOneAsync(x => x.Id == id);
    }
}
