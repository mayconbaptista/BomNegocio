using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BomNegocio.DAL.Repositories
{
    public interface IRepository<T>
    {
        Task<T?> GetAsync(Expression<Func<T, bool>> predicate);
        Task<IEnumerable<T>> GetAllAsync ();
        T Create (T entity);
        T Update (T entity);
        T Delete (T entity);
    }
}
