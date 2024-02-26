using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Apes.SugarKingdom.Data
{
    public static class DatabaseMigrationExtensions
    {
        public static IApplicationBuilder MigrateDatabase(this IApplicationBuilder app)
        {
            var x = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>();
            using (var scope = x.CreateScope())
            {
                var context = scope.ServiceProvider.GetService<SugarContext>();
                context?.Database.Migrate();
            }

            return app;
        }
    }
}
