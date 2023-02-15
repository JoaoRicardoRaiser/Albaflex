using Albaflex.Data.Entities;
using Albaflex.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Albaflex.Data.Repositories
{
    public class TissueRepository : GenericRepository<Tissue>, ITissueRepository
    {
        public TissueRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
