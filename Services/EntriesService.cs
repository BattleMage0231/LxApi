using LxApi.Models;
using MongoDB.Driver;

namespace LxApi.Services;

public class EntriesService : IEntriesService {
    private readonly IMongoCollection<Entry> _entryCollection;

    public EntriesService(IMongoService mongo) {
        _entryCollection = mongo.Entries;
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
