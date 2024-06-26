using BomNegocio.DAL.Models;
using BomNegocio.DAL.Pagination;
using X.PagedList;

namespace BomNegocio.Application.Services.Interface
{
    public interface IAnuncioService
    {
        Task<Anun> CreateAsync(AnnouncementEntity anuncio);
        Task<Anuncio> UpdateAsync(Anuncio anuncio);
        Task<Anuncio> DeleteAsync(int id);
        Task<Anuncio> GetAsync(int id);
        Task<IPagedList<Anuncio>> GetAllAsync(AnuncioFilterParameters anuncioFilterParameters);
    }
}
