using BomNegocio.DAL.Context;
using BomNegocio.Domain.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BomNegocio.DAL.Repositories.Implements
{
    public abstract class WriteRepository<T> : IWriteRepository<T> where T : class
    {
        protected readonly BNContext _dbContext;

        public WriteRepository(BNContext dbContext)
        {
            _dbContext = dbContext;
        }

        public T Create(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            return entity;
        }

        public T Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            return entity;
        }

        public T Update(T entity)
        {
            _dbContext.Set<T>().Update(entity);
            return entity;
        }
    }
}
