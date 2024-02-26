using Apes.SugarKingdom.Data;
using AutoMapper;
using Microsoft.Extensions.Configuration;

namespace Apes.SugarKingdom.Application;

public class BaseService
{
    protected ISugarContext Context { get; }
    protected IMapper Mapper { get; }

    protected IConfiguration Configuration { get; }

    protected bool IsProduction => Configuration["ASPNETCORE_ENVIRONMENT"] == "Production";

    public BaseService(ISugarContext context, IMapper mapper, IConfiguration configuration)
    {
        Context = context;
        Mapper = mapper;
        Configuration = configuration;
    }
}


