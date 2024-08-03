using LxApi.Models;
using LxApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace LxApi.Controllers;

[ApiController]
[Route("api/entry")]
public class EntriesFRController : ControllerBase {
    private readonly IEntriesService _entriesService;

    public EntriesFRController(IEntriesService entriesService) {
        _entriesService = entriesService;
    }

    [HttpGet]
    public async Task<List<Entry>> Get() => await _entriesService.GetAllAsync();
}
