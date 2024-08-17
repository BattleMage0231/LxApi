using LxApi.Models;

namespace LxApi.Services;

public interface ISearchService<T> where T : BaseEntry {
    public Task<List<string>> SuggestAsync(string searchString, int limit);

    public Task<List<T>> SearchAsync(string searchString);
}
