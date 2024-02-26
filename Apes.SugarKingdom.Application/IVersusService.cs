using Apes.SugarKingdom.Application.Models;

namespace Apes.SugarKingdom.Application;

public interface IVersusService : IBaseDataService<VersusPoints>
{
    public Task<int> GetPointsByWallet(string wallet);
    public Task<IList<VersusPoints>> GetAllPoints();
}
