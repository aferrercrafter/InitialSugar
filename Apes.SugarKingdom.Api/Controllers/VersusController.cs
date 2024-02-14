using Microsoft.AspNetCore.Mvc;

namespace Apes.SugarKingdom.Api.Controllers;

public class VersusController(ILogger<VersusController> logger) : BaseController<VersusController>(logger)
{
    public ActionResult GetPointsByWalletAsync()
    {
        return BadRequest();
    }
}
