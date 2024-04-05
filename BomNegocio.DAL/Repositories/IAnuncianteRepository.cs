using BomNegocio.DAL.Models;
using BomNegocio.DAL.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X.PagedList;

namespace BomNegocio.DAL.Repositories
{
    public interface IAnuncianteRepository : IRepository<Anunciante>
    {
        Task<IPagedList<Anunciante>> GetAnunciantesAsync (AnuncianteFilterParameters parameters);
    }
}
