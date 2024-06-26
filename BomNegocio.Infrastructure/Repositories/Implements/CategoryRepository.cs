using BomNegocio.DAL.Models;
using BomNegocio.DAL.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BomNegocio.Domain.Repositories.Interfaces;

namespace BomNegocio.DAL.Repositories.Implements
{
    public class CategoryRepository : WriteRepository<CategoryEntity>,  ICategoryRepository
    {
        public CategoriaRepository(BNContext bnContext) : base(bnContext) { }

    }
}
