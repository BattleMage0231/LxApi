using LxApi.Models;
using MongoDB.Bson;
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

    public async Task<Entry?> GetByIdAsync(string id) {
        if(ObjectId.TryParse(id, out _)) {
            return await _entryCollection.Find(entry => entry.Id == id).FirstOrDefaultAsync();
        }
        return null;
    }

    public async Task CreateAsync(Entry entry) {
        await _entryCollection.InsertOneAsync(entry);
    }

    public async Task DeleteAsync(string id) {
        if(ObjectId.TryParse(id, out _)) {
            await _entryCollection.DeleteOneAsync(x => x.Id == id);
        }
    }
}
