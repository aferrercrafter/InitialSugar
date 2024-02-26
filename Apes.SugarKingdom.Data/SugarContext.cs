using Microsoft.EntityFrameworkCore;

namespace Apes.SugarKingdom.Data;

public class SugarContext(DbContextOptions options) : DbContext(options), ISugarContext
{
    public DbSet<VersusPoints> VersusPoints { get; set; } = default!;


}
