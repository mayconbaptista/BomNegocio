using BomNegocio.Domain.Models;
using BomNegocio.Domain.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BomNegocio.DAL.Pagination;
using X.PagedList;
using BomNegocio.Domain.Repositories.Interfaces;

namespace BomNegocio.Infrastructure.Repositories.Implements
{
    public class AdvertiserRepository : ReadRepository<AdvertiserEntity>, WriteRepository<AdvertiserEntity>, IAnuncianteRepository
    {
        public AdvertiserRepository(BNContext bnContext) : base(bnContext) { }

        public AdvertiserEntity Create(AdvertiserEntity entity)
        {
            throw new NotImplementedException();
        }

        public AdvertiserEntity Delete(AdvertiserEntity entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IPagedList<AdvertiserEntity>> GetAnunciantesAsync(AnuncianteFilterParameters parameters)
        {
            var anunciantes = await GetAllAsync();

            var anunciantesOrdenados = anunciantes.OrderBy(a => a.Id).AsQueryable();

            var anunciantesPageList = await anunciantesOrdenados.ToPagedListAsync(parameters.PageNumber, parameters.PageSize);

            return anunciantesPageList;
        }

        public AdvertiserEntity Update(AdvertiserEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
