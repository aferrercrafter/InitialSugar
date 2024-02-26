namespace Apes.SugarKingdom.Application;

public interface IBaseDataService<TU>
{
    public Task<TU> GetByIdAsync(Guid id);

    public Task<IList<TU>> GetAllAsync();

    public Task<IList<TU>> GetManyAsync(Guid[] ids);

    public Task<TU> CreateAsync(TU data);

    public Task DeleteAsync(Guid id);

    public Task<TU> UpdateAsync(Guid id, TU data);

}
