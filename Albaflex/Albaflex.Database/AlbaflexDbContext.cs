using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Albaflex.Database
{
    public class AlbaflexDbContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql(DbInfoProvider.GetPostgresConnectionString());

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
