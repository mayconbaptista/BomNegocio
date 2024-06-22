using BomNegocio.DAL.Models;
using BomNegocio.DAL.Repositories.Implements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BomNegocio.Domain.Repositories.Interfaces
{
    public interface IImagemRepository : IWriteRepository<ImageEntity>, IReadRepository<ImageEntity>
    {

    }
}
