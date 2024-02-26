using Apes.SugarKingdom.Data;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Apes.SugarKingdom.Application;

public class VersusService : BaseDataService<VersusPoints, Models.VersusPoints>, IVersusService
{
    private readonly ISugarContext _context;
    private readonly IMapper _mapper;
    private readonly IConfiguration _config;

    public VersusService(ISugarContext context, IMapper mapper, IConfiguration configuration) : base(context, mapper, configuration)
    {
        _context = context;
        _mapper = mapper;
        _config = configuration;
    }

    public async Task<int> GetPointsByWallet(string wallet)
    {
        return await _context.VersusPoints.Where(x => x.Wallet == wallet).SumAsync(x => x.Points);
    }

    public async Task<IList<Models.VersusPoints>> GetAllPoints()
    {
        var points = await _context.VersusPoints.GroupBy(x => x.Wallet).Select(x => new VersusPoints { Wallet = x.Key, Points = x.Sum(x => x.Points) }).ToListAsync();
        return _mapper.Map<IList<Models.VersusPoints>>(points);
    }
}
