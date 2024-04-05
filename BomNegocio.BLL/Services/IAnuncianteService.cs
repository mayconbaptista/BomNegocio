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
    interface IAnuncianteService
    {
        Task<Anunciante?> GetAnuncianteAsync (int id);
        Task<IPagedList<Anunciante>> GetAll(AnuncianteFilterParameters anuncianteFilterParameters);
        Task<Anunciante> Update(Anunciante newAnuncinte);
        Task<Anunciante> Delete(int id);
        Task<Anunciante> Create(Anunciante anuncio);
    }
}
