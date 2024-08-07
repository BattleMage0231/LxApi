using LxApi.Models.Languages;
using LxApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace LxApi.Controllers.Languages;

[Route("api/entry/fr")]
public class FREntriesController(IEntriesService<FREntry> entriesService) : BaseEntriesController<FREntry>(entriesService) {}
