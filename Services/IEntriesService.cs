using LxApi.Models;

namespace LxApi.Services;

public interface IEntriesService {
    public Task<List<Entry>> GetAllAsync();

    public Task CreateAsync(Entry entry);

    public Task DeleteAsync(string id);
}
