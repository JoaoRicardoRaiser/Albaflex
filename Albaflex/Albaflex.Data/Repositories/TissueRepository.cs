using Albaflex.Data.Entities;
using Albaflex.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Albaflex.Data.Repositories
{
    public class TissueRepository : GenericRepository<Product>, IProductRepository
    {
        public TissueRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public Task<bool> Exists(Expression<Func<Product, bool>> predicate)
            => _dbSet.AnyAsync(predicate);
    }
}
