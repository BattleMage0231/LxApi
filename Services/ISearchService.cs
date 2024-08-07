using LxApi.Models;

namespace LxApi.Services;

public interface ISearchService<T> where T : BaseEntry {
    public Task<List<T>> CompleteAsync(string searchString);

    public Task<List<T>> SearchAsync(string searchString);
}
