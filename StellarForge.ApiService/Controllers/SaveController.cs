using Microsoft.AspNetCore.Mvc;

using StellarForge.ApiService.Models;
using StellarForge.ApiService.Services;

namespace StellarForge.ApiService.Controllers;

[ApiController]
[Route("api/save")]
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

    [HttpGet("{userId}")]
    public async Task<ActionResult<SaveState>> Get(string userId)
    {
        var save = await _saveService.GetSaveAsync(userId);
        if (save is null)
            return NotFound();
        return Ok(save);
    }
}
