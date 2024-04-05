using BomNegocio.DAL.Models;
using BomNegocio.DAL.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BomNegocio.DAL.Repositories.Implements
{
    public class InteresseRepository : Repository<Avaliacao>, IInteresseRepository
    {
        public InteresseRepository(BNContext bnContext) : base(bnContext) { }
    }
}
