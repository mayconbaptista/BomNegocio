
using System.Linq.Expressions;

namespace BomNegocio.Domain.Repositories.Interfaces
{
    public interface IReadRepository<TEntity> where TEntity : class
    {
        Task<TEntity?> GetAsyncANT(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> predicate);
        Task<IEnumerable<TEntity>> GetAllAsync();
    }
}
