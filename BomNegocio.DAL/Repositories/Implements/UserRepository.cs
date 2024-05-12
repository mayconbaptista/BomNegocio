using BomNegocio.DAL.Context;
using BomNegocio.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BomNegocio.DAL.Repositories.Implements
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(BNContext dbContext) : base(dbContext){ }
    }
}
