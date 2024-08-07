using LxApi.Models;
using LxApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace LxApi.Controllers;

[ApiController]
public abstract class BaseEntriesController<T>(IEntriesService<T> entriesService) : ControllerBase where T : BaseEntry {
    private readonly IEntriesService<T> _entriesService = entriesService;

    [HttpGet]
    public async Task<List<T>> Get() => await _entriesService.GetAllAsync();

    [HttpGet("{id}")]
    public async Task<ActionResult<T>> Get(string id) {
        var entry = await _entriesService.GetByIdAsync(id);
        if(entry is null) {
            return NotFound();
        }
        return entry;
    }

    [HttpPost]
    public async Task<IActionResult> Post(T newEntry) {
        if(newEntry.Id is not null) {
            return BadRequest(error: new { error = "Request body should not contain entry id" });
        }
        await _entriesService.CreateAsync(newEntry);
        return CreatedAtAction(nameof(Get), new { id = newEntry.Id }, newEntry);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(string id, T updatedEntry) {
        if(updatedEntry.Id is not null) {
            return BadRequest(error: new { error = "Request body should not contain entry id" });
        }
        var entry = await _entriesService.GetByIdAsync(id);
        if(entry is null) {
            return NotFound();
        }
        updatedEntry.Id = entry.Id;
        await _entriesService.UpdateAsync(id, updatedEntry);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id) {
        var entry = await _entriesService.GetByIdAsync(id);
        if(entry is null) {
            return NotFound();
        }
        await _entriesService.DeleteAsync(id);
        return NoContent();
    }
}
