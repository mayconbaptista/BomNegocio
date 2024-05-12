using BomNegocio.DAL.Context;
using BomNegocio.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BomNegocio.DAL.Repositories.Implements
{
    public class DesejoRepository : Repository<Desejo>, IDesejoRepository
    {
        public DesejoRepository(BNContext dbContext) : base(dbContext)
        {
        }
    }
} 
