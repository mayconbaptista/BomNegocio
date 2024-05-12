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
        Task<Anunciante?> GetByIdAsync (int id);
        Task<IPagedList<Anunciante>> GetAllAsync(AnuncianteFilterParameters anuncianteFilterParameters);
        Task<Anunciante> UpdateAsync (Anunciante newAnuncinte);
        Task<Anunciante> DeleteAsync (int id);
        Task<Anunciante> CreateAsync (Anunciante anuncio);
    }
}
