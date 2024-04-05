using BomNegocio.DAL.Models;
using BomNegocio.DAL.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BomNegocio.DAL.Pagination;
using X.PagedList;

namespace BomNegocio.DAL.Repositories.Implements
{
    public class AnuncianteRepository : Repository<Anunciante>, IAnuncianteRepository
    {
        public AnuncianteRepository(BNContext bnContext) : base(bnContext) { }

        public async Task<IPagedList<Anunciante>> GetAnunciantesAsync(AnuncianteFilterParameters parameters)
        {
            var anunciantes = await GetAllAsync();

            var anunciantesOrdenados = anunciantes.OrderBy(a => a.Id).AsQueryable();

            var anunciantesPageList = await anunciantesOrdenados.ToPagedListAsync(parameters.PageNumber, parameters.PageSize);

            return anunciantesPageList;
        }
    }
}
