using BomNegocio.Domain.Entitys;
using BomNegocio.Domain.;
using X.PagedList;

namespace BomNegocio.Infrastructure.Repositories.Interfaces
{
    public interface IAdvertiserRepository : IWriteRepository<AdvertiserEntity>, IReadRepository<AdvertiserEntity>
    {
        Task<IPagedList<AdvertiserEntity>> GetAnunciantesAsync(AnuncianteFilterParameters parameters);
    }
}
