using BomNegocio.DAL.Context;
using BomNegocio.Domain.Repositories.Interfaces;
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
        private IAnnouncementRepository? _anuncioRepository;
        private IEvaluetionRepository? _avaliacaoRepository;
        private ICategoryRepository? _categoriaRepository;
        private IClientRepository? _clienteRepository;
        private IWisheRepository? _desejoRepository;
        private IAddressRepository? _enderecoRepository;
        private IImageRepository? _imagemRepository;
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

        public IAnnouncementRepository AnuncioRepository
        {
            get
            {
                return _anuncioRepository = _anuncioRepository ?? new AnnouncementRepository(_bNContext);
            }
        }

        public IEvaluetionRepository AvaliacaoRepository
        {
            get
            {
                return _avaliacaoRepository = _avaliacaoRepository ?? new EvaluetionRepository(_bNContext);
            }
        }

        public ICategoryRepository CategoriaRepository
        {
            get
            {
                return _categoriaRepository = _categoriaRepository ?? new CategoriaRepository(_bNContext);
            }
        }

        public IClientRepository ClienteRepository
        {
            get
            {
                return (_clienteRepository ?? new ClientRepository(_bNContext));
            }
        }

        public IWisheRepository DesejoRepository
        {
            get
            {
                return (_desejoRepository ?? new WisheRepository(_bNContext));
            }
        }

        public IAddressRepository EnderecoRepository
        {
            get
            {
                return (_enderecoRepository ?? new AddressRepository(_bNContext));
            }
        }

        public IImageRepository ImagemRepository
        {
            get
            {
                return (_imageRepository ?? new ImageRepository(_bNContext));
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
