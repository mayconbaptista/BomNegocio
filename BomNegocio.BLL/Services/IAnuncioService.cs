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
        Task<Anuncio> CreateAsync (Anuncio anuncio, string email);
        Task<Anuncio> UpdateAsync (Anuncio anuncio, string email);
        Task<Anuncio> DeleteAsync (int id, string email);
        Task<Anuncio> GetAsync (int id);
        Task<IPagedList<Anuncio>> GetAllAsync (AnuncioFilterParameters anuncioFilterParameters);
    }
}
