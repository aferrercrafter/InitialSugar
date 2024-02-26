using Apes.SugarKingdom.Application.Exceptions;
using Apes.SugarKingdom.Application.Models;
using Apes.SugarKingdom.Data;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.ComponentModel.DataAnnotations;

namespace Apes.SugarKingdom.Application;

public class BaseDataService<T, TU> : BaseService, IBaseDataService<TU>
    where T : BaseEntity
    where TU : BaseModel
{

    protected virtual IQueryable<T> Query => Context.Set<T>();

    public BaseDataService(ISugarContext context, IMapper mapper, IConfiguration configuration) : base(context, mapper, configuration) { }

    public virtual async Task<TU> GetByIdAsync(Guid id)
    {
        var result = await Query.FirstOrDefaultAsync(x => x.Id == id) ?? throw new InvalidEntityException(typeof(T), id);
        return Mapper.Map<TU>(result);
    }

    public virtual Task<IList<TU>> GetAllAsync() =>
        Task.FromResult(Mapper.Map<IList<TU>>(Context.Set<T>().OrderByDescending(x => x.CreatedDate)));

    public virtual Task<IList<TU>> GetManyAsync(Guid[] ids) =>
        Task.FromResult(Mapper.Map<IList<TU>>(Context.Set<T>().Where(x => ids.Contains(x.Id))));

    public virtual async Task<TU> CreateAsync(TU data)
    {
        ValidateModel(data);
        var entity = Mapper.Map<T>(data);
        var result = await Context.Set<T>().AddAsync(entity);
        _ = await Context.SaveChangesAsync();
        return Mapper.Map<TU>(result.Entity);
    }


    public virtual async Task DeleteAsync(Guid id)
    {
        var existing = await Context.Set<T>().FindAsync(id) ?? throw new InvalidEntityException(typeof(T), id);
        _ = Context.Remove(existing);
        _ = await Context.SaveChangesAsync();
    }

    public virtual async Task<TU> UpdateAsync(Guid id, TU data)
    {
        ValidateModel(data);
        var existing = await Context.Set<T>()
            .FirstOrDefaultAsync(x => x.Id == id) ?? throw new InvalidEntityException(typeof(T), id);

        _ = Mapper.Map(data, existing);
        _ = await Context.SaveChangesAsync();
        return Mapper.Map<TU>(existing);
    }

    public virtual void ValidateModel<TX>(TX data) where TX : BaseModel
    {
        var validationResults = data.Validate();
        if (validationResults.Any())
        {
            var message = string.Join(", ", validationResults.Select(x => x.ErrorMessage));
            throw new ValidationException(message);
        }
    }
}
