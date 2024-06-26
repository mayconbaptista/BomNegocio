using X.PagedList;

namespace BomNegocio.Application.Services.Interface
{
    public interface IReadService<TEntity, TDto>
        where TEntity : class
        where TDto : class
    {
        Task<IPagedList<TDto>> GetAll();
        Task<TDto> GetById(int id);
    }
}
