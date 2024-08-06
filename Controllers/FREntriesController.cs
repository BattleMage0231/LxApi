using LxApi.Models.Languages;
using LxApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace LxApi.Controllers;

[Route("api/fr/entry")]
public class FREntriesController(IEntriesService<FREntry> entriesService) : BaseEntriesController<FREntry>(entriesService) {}
