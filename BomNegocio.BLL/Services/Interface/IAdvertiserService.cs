using BomNegocio.DAL.Models;
using BomNegocio.DAL.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X.PagedList;

namespace BomNegocio.BLL.Services
{
    public interface IAnuncianteService
    {
        Task<AdvertiserEntity?> GetByIdAsync (int id);
        Task<IPagedList<AdvertiserEntity>> GetAllAsync(AnuncianteFilterParameters anuncianteFilterParameters);
        Task<AdvertiserEntity> UpdateAsync (AdvertiserEntity newAnuncinte);
        Task<AdvertiserEntity> DeleteAsync (int id);
        Task<AdvertiserEntity> CreateAsync (AdvertiserEntity anuncio);
    }
}
