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
        private IAvaliacaoRepository? _avaliacaoRepository;
        private ICategoriaRepository? _categoriaRepository;
        private IClienteRepository? _clienteRepository;
        private IDesejoRepository? _desejoRepository;
        private IEnderecoRepository? _enderecoRepository;
        private IImagemRepository? _imagemRepository;
        private IUserRepository? _userRepository;

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

        public IAvaliacaoRepository AvaliacaoRepository
        {
            get
            {
                return _avaliacaoRepository = _avaliacaoRepository ?? new AvaliacaoRepository(_bNContext);
            }
        }

        public ICategoriaRepository CategoriaRepository
        {
            get
            {
                return _categoriaRepository = _categoriaRepository ?? new CategoriaRepository(_bNContext);
            }
        }

        public IClienteRepository ClienteRepository
        {
            get
            {
                return (_clienteRepository ?? new ClienteRepository(_bNContext));
            }
        }

        public IDesejoRepository DesejoRepository
        {
            get
            {
                return (_desejoRepository ?? new DesejoRepository(_bNContext));
            }
        }

        public IEnderecoRepository EnderecoRepository
        {
            get
            {
                return (_enderecoRepository ?? new EnderecoRepository(_bNContext));
            }
        }

        public IImagemRepository ImagemRepository
        {
            get
            {
                return (_imagemRepository ?? new ImagemRepository(_bNContext));
            }
        }

        public IUserRepository UserRepository
        {
            get
            {
                return (UserRepository ?? new UserRepository(_bNContext));
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
