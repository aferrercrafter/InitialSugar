using Microsoft.EntityFrameworkCore;

namespace Apes.SugarKingdom.Data;

public class SugarContext(DbContextOptions options) : DbContext(options), ISugarContext
{
    public DbSet<VersusPoints> VersusPoints { get; set; } = default!;

    public override async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
    {
        var currentDateTime = DateTime.UtcNow;

        foreach (var entry in ChangeTracker.Entries().Where(e => e.Entity is BaseEntity))
        {
            if (entry.State == EntityState.Added)
            {
                ((BaseEntity)entry.Entity).CreatedDate = currentDateTime;
                ((BaseEntity)entry.Entity).ModifiedDate = currentDateTime;
            }
            else if (entry.State == EntityState.Modified)
            {
                ((BaseEntity)entry.Entity).ModifiedDate = currentDateTime;
            }
        }

        return await base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
    }
}
