using LxApi.Models;
using LxApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace LxApi.Controllers;

using Entry = EntryFR;

[ApiController]
[Route("api/entry")]
public class EntriesFRController : ControllerBase {
    private readonly IEntriesFRService _entriesService;

    public EntriesFRController(IEntriesFRService entriesService) {
        _entriesService = entriesService;
    }

    [HttpGet]
    public async Task<List<Entry>> Get() => await _entriesService.GetAllAsync();
}
