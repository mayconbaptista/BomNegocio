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
    public interface IAnuncioRepository : IRepository<Anuncio>
    {
        Task<IPagedList<Anuncio>> GetAnunciosAsync (AnuncioFilterParameters parameters);

    }
}
