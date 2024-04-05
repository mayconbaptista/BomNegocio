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
    public class AnuncioRepository : Repository<Anuncio>, IAnuncioRepository
    {
        public AnuncioRepository(BNContext bnContext) : base(bnContext) { }

        public async Task<IPagedList<Anuncio>> GetAnunciosAsync (AnuncioFilterParameters anuncioParams)
        {
            var query = _dbContext.Anuncios.AsQueryable();

            if(anuncioParams.PrecoMin.HasValue)
            {
                query = query.Where(a => a.Preco >= anuncioParams.PrecoMin).OrderBy(a => a.Preco);
            }
            if(anuncioParams.PrecoMax.HasValue)
            {
                query = query.Where(a => a.Preco <= anuncioParams.PrecoMax).OrderBy(a => a.Preco);
            }
            if(anuncioParams.AnuncianteId.HasValue)
            {
                query = query.Where(a => a.AnuncianteId == anuncioParams.AnuncianteId);
            }
            if(anuncioParams.CategoriaId.HasValue)
            {
                query = query.Where(a => a.CategoriaId == anuncioParams.CategoriaId);
            }

            IPagedList<Anuncio> anunciosPaginados = query.ToPagedList(anuncioParams.PageNumber, anuncioParams.PageSize);

            return anunciosPaginados;
        }
    }
}
