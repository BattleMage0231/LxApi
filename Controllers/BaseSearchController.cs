using LxApi.Models;
using LxApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace LxApi.Controllers;

[ApiController]
public abstract class BaseSearchController<T>(ISearchService<T> searchService) : ControllerBase where T : BaseEntry {
    private readonly ISearchService<T> _searchService = searchService;

    private const int SuggestLimit = 10;

    [HttpGet("suggest")]
    public virtual async Task<List<string>> Suggest(string searchString) => await _searchService.SuggestAsync(searchString, SuggestLimit);

    [HttpGet("search")]
    public virtual async Task<List<T>> Search(string searchString) => await _searchService.SearchAsync(searchString);
}
