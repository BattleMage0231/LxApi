using LxApi.Models;

namespace LxApi.Services;

using Entry = EntryFR;

public interface IEntriesFRService {
    public Task<List<Entry>> GetAllAsync();

    public Task CreateAsync(Entry entry);

    public Task DeleteAsync(string id);
}
