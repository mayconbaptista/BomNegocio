using System.Threading.Tasks;

namespace BomNegocio.Application.Services.Interface
{
    public interface IWriteService<TEntity, TDto>
        where TEntity : class
        where TDto : class
    {
        Task<TDto> Create(TDto dto);
        Task<TDto> Update(TDto dto);
        Task<TDto> Delete(int id);
    }
}
