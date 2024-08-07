using LxApi.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace LxApi.Services;

public class EntriesService<T>(IMongoService mongo) : IEntriesService<T> where T : BaseEntry {
    private readonly IMongoCollection<BaseEntry> _entryCollection = mongo.Entries;

    public virtual async Task<List<T>> GetAllAsync() {
        var list = await _entryCollection.Find(entry => entry is T).ToListAsync();
        return list.Cast<T>().ToList();
    }

    public virtual async Task<T?> GetByIdAsync(string id) {
        if(ObjectId.TryParse(id, out _)) {
            return (T) await _entryCollection.Find(entry => entry is T && entry.Id == id).FirstOrDefaultAsync();
        }
        return null;
    }

    public virtual async Task CreateAsync(T entry) {
        await _entryCollection.InsertOneAsync(entry);
    }

    public virtual async Task UpdateAsync(string id, T updatedEntry) {
        if(ObjectId.TryParse(id, out _)) {
            await _entryCollection.ReplaceOneAsync(entry => entry is T && entry.Id == id, updatedEntry);
        }
    }

    public virtual async Task DeleteAsync(string id) {
        if(ObjectId.TryParse(id, out _)) {
            await _entryCollection.DeleteOneAsync(entry => entry is T && entry.Id == id);
        }
    }
}
