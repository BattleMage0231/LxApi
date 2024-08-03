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
    public async Task<List<Entry>> GetAll() => await _entriesService.GetAllAsync();

    [HttpGet("{id}")]
    public async Task<ActionResult<Entry>> GetById(string id) {
        var entry = await _entriesService.GetByIdAsync(id);
        if(entry is null) {
            return NotFound();
        }
        return entry;
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Entry newEntry) {
        await _entriesService.CreateAsync(newEntry);
        return CreatedAtAction(nameof(GetById), new { id = newEntry.Id }, newEntry);
    }
}
