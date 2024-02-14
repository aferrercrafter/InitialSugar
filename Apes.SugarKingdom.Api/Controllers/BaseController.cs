using Microsoft.AspNetCore.Mvc;

namespace Apes.SugarKingdom.Api.Controllers;

public class BaseController<T>(ILogger<T> logger) : ControllerBase
{
    protected ILogger<T> Logger { get; set; } = logger;
}
