using BomNegocio.DAL.Models;
using BomNegocio.DAL.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X.PagedList;

namespace BomNegocio.Domain.Repositories.Interfaces
{
    public interface IAnuncioRepository : IWriteRepository<AnnouncementEntity>, IReadRepository<AnnouncementEntity>
    {
        Task<IPagedList<AnnouncementEntity>> GetAnunciosAsync(AnuncioFilterParameters parameters);

    }
}
