
namespace BomNegocio.Domain.Repositories.Interfaces
{
    public interface IWriteRepository<TEntity> where TEntity : class
    {
        TEntity Create(TEntity entity);
        TEntity Update(TEntity entity);
        TEntity Delete(TEntity entity);
    }
}
