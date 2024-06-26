using BomNegocio.DAL.Context;
using BomNegocio.DAL.Models;
using BomNegocio.Domain.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BomNegocio.DAL.Repositories.Implements
{
    public class WisheRepository : WriteRepository<WisheEntity>, IWisheRepository
    {
        public WisheRepository(BNContext dbContext) : base(dbContext)
        {
        }
    }
} 
