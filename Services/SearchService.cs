using LxApi.Models;
using MongoDB.Driver;

namespace LxApi.Services;

public class SearchService<T>(IMongoService mongo) : ISearchService<T> where T : BaseEntry {
    private readonly IMongoCollection<BaseEntry> _entryCollection = mongo.Entries;

    public virtual async Task<List<T>> CompleteAsync(string searchString) {
        var list = await _entryCollection.Find(entry => entry is T && entry.Key.Contains(searchString))
            .SortByDescending(entry => entry.Key).ToListAsync();
        return list.Cast<T>().ToList();
    }

    public virtual async Task<List<T>> SearchAsync(string searchString) {
        var list = await _entryCollection.Find(entry => entry is T && entry.Key == searchString)
            .SortByDescending(entry => entry.Key).ToListAsync();
        return list.Cast<T>().ToList();
    }
}
