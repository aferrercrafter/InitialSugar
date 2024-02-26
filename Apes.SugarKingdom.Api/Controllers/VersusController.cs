using Apes.SugarKingdom.Application;
using Apes.SugarKingdom.Application.Models;
using Microsoft.AspNetCore.Mvc;

namespace Apes.SugarKingdom.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VersusController(IVersusService service, ILogger<VersusController> logger) : BaseController<VersusController>(logger)
{
    private readonly IVersusService _service = service;

    [HttpGet("{wallet}")]
    public async Task<ActionResult<VersusScore>> GetPointsByWalletAsync([FromRoute] string wallet)
    {
        var score = await _service.GetPointsByWallet(wallet);
        return Ok(new VersusScore { Score = score });
    }

    [HttpGet]
    public async Task<ActionResult<IList<VersusPoints>>> GetPointsByWalletAsync()
    {
        return Ok(await _service.GetAllPoints());
    }

    [HttpPost]
    public async Task<ActionResult<VersusPoints>> AddPointsToWallet([FromBody] VersusPoints points)
    {
        return await _service.CreateAsync(points);
    }
}
