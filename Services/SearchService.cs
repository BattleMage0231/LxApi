using LxApi.Models;
using System.Text;
using MongoDB.Driver;

namespace LxApi.Services;

public class SearchService<T>(IMongoService mongo) : ISearchService<T> where T : BaseEntry {
    private readonly IMongoCollection<BaseEntry> _entryCollection = mongo.Entries;

    private static string NormalizeKey(string key) {
        var bytes = Encoding.GetEncoding("ISO-8859-8").GetBytes(key);
        return Encoding.UTF8.GetString(bytes);
    }

    public virtual async Task<List<string>> SuggestAsync(string searchString, int limit) {
        var normalizedString = NormalizeKey(searchString);
        var list = (await _entryCollection.DistinctAsync(
            entry => entry.Key,
            entry => entry is T && entry.NormalizedKey!.StartsWith(normalizedString)
        )).ToList();
        return list[0..Math.Min(limit, list.Count)];
    }

    public virtual async Task<List<T>> SearchAsync(string searchString) {
        var normalizedString = NormalizeKey(searchString);
        var list = await _entryCollection.Find(entry => entry is T && entry.NormalizedKey == normalizedString)
            .SortBy(entry => entry.Key).ToListAsync();
        return list.Cast<T>().ToList();
    }
}
