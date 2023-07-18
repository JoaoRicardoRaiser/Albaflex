using Albaflex.Data.Entities;
using System.Linq.Expressions;

namespace Albaflex.Data.Interfaces
{
    public interface IProductRepository: IGenericRepository<Product>
    {
        Task<bool> Exists(Expression<Func<Product, bool>> predicate);
    }
}
