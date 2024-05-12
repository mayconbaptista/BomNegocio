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
    public interface IAnuncioService
    {
        Task<Anuncio> CreateAsync (Anuncio anuncio);
        Task<Anuncio> UpdateAsync (Anuncio anuncio);
        Task<Anuncio> DeleteAsync (int id);
        Task<Anuncio> GetAsync (int id);
        Task<IPagedList<Anuncio>> GetAllAsync (AnuncioFilterParameters anuncioFilterParameters);
    }
}
