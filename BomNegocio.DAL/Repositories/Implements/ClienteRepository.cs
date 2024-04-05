using BomNegocio.DAL.Context;
using BomNegocio.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BomNegocio.DAL.Repositories.Implements
{
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
        public ClienteRepository(BNContext dbContext) : base(dbContext)
        {
        }
    }
}
