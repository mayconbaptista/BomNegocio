using BomNegocio.Domain.Entitys;
using BomNegocio.DAL.Pagination;
using X.PagedList;

namespace BomNegocio.Infrastructure.Repositories.Interfaces
{
    public interface IAnuncianteRepository : IWriteRepository<AdvertiserEntity>, IReadRepository<AdvertiserEntity>
    {
        Task<IPagedList<AdvertiserEntity>> GetAnunciantesAsync(AnuncianteFilterParameters parameters);
    }
}
