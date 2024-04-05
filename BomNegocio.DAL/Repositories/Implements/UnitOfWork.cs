using BomNegocio.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BomNegocio.DAL.Repositories.Implements
{
    public class UnitOfWork : IUnitOfWork
    {
        private IAnuncianteRepository? _anuncianteRepository;

        private IAnuncioRepository? _anuncioRepository;

        private ICategoriaRepository? _categoriaRepository;

        private IInteresseRepository? _InteresseRepository;

        public BNContext _bNContext;
        public UnitOfWork(BNContext bNContext)
        {
            _bNContext = bNContext;
        }

        public IAnuncianteRepository AnuncianteRepository
        {
            get
            {
                return _anuncianteRepository = _anuncianteRepository ?? new AnuncianteRepository(_bNContext);
            }
        }

        public IAnuncioRepository AnuncioRepository
        {
            get
            {
                return _anuncioRepository = _anuncioRepository ?? new AnuncioRepository(_bNContext);
            }
        }

        public ICategoriaRepository CategoriaRepository
        {
            get
            {
                return _categoriaRepository = _categoriaRepository ?? new CategoriaRepository(_bNContext);
            }
        }

        public IInteresseRepository InteresseRepository
        {
            get
            {
                return _InteresseRepository ?? new InteresseRepository(_bNContext);
            }
        }

        public async Task CommitAsync ()
        {
            await  _bNContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _bNContext.Dispose();
        }
    }
}
