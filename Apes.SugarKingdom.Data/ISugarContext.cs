using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Apes.SugarKingdom.Data;

public interface ISugarContext : IDisposable
{
    public DbSet<TEntity> Set<TEntity>() where TEntity : class;
    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    EntityEntry<TEntity> Remove<TEntity>(TEntity entity) where TEntity : class;

    public DbSet<VersusPoints> VersusPoints { get; set;}
}
