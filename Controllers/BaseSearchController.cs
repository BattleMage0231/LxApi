using LxApi.Models;
using LxApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace LxApi.Controllers;

[ApiController]
public abstract class BaseSearchController<T>(ISearchService<T> searchService) : ControllerBase where T : BaseEntry {
    private readonly ISearchService<T> _searchService = searchService;

    [HttpGet("complete")]
    public virtual async Task<List<T>> Complete(string searchString) => await  _searchService.CompleteAsync(searchString);

    [HttpGet("search")]
    public virtual async Task<List<T>> Search(string searchString) => await  _searchService.SearchAsync(searchString);
}
