using LxApi.Models;

namespace LxApi.Services;

public interface IEntriesService<T> where T : Entry {
    public Task<List<T>> GetAllAsync();

    public Task<T?> GetByIdAsync(string id);

    public Task CreateAsync(T entry);

    public Task UpdateAsync(string id, T updatedEntry);

    public Task DeleteAsync(string id);
}
