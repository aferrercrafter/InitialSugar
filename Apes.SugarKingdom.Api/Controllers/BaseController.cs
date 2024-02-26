using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Apes.SugarKingdom.Api.Controllers;

[EnableCors("corsOrigins")]
public class BaseController<T>(ILogger<T> logger) : ControllerBase
{
    protected ILogger<T> Logger { get; set; } = logger;
}
