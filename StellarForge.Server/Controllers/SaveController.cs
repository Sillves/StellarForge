using System.IO;

using Microsoft.AspNetCore.Mvc;
using StellarForge.Server.Models;
using StellarForge.Server.Services;

namespace StellarForge.Server.Controllers;

[ApiController]
[Route(template: "api/Save")]
public class SaveController : ControllerBase
{
    private readonly SaveService _saveService;

    public SaveController(SaveService saveService)
    {
        _saveService = saveService;
    }

    [HttpPost]
    public async Task<IActionResult> Save([FromBody] SaveState save)
    {
        await _saveService.UpsertSaveAsync(save);
        return Ok();
    }
}
