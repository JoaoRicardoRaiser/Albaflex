using Albaflex.Data.Entities;
using Albaflex.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Albaflex.Data.Interfaces
{
    public class MaterialRepository : GenericRepository<Material>, IMaterialRepository
    {
        public MaterialRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
