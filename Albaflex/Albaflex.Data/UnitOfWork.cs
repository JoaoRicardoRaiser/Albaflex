using Albaflex.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Albaflex.Data
{
    public class UnitOfWork : IUnitOfWork
    {

        private static DbContext _dbContext;
        public UnitOfWork(DbContext context)
        {
            _dbContext = context;
        }

        public async Task CommitAsync()
        {
            var entities = _dbContext.ChangeTracker.Entries().Where(x => x.State == EntityState.Modified).Select(x => x.Entity);
            foreach (BaseEntity entity in entities.Cast<BaseEntity>())
                entity.UpdateAudit();

            await _dbContext.SaveChangesAsync();
        }
    }
}
