using LxApi.Models;

namespace LxApi.Services;

public interface IEntriesService {
    public Task<List<Entry>> GetAllAsync();

    public Task<Entry?> GetByIdAsync(string id);

    public Task CreateAsync(Entry entry);

    public Task UpdateAsync(string id, Entry updatedEntry);

    public Task DeleteAsync(string id);
}
