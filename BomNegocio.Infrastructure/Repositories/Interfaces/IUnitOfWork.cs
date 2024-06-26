using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BomNegocio.Domain.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        public IAnuncianteRepository AnuncianteRepository { get; }
        public IAnnouncementRepository AnuncioRepository { get; }
        public ICategoryRepository CategoriaRepository { get; }
        public IClientRepository ClienteRepository { get; }
        public IWisheRepository DesejoRepository { get; }
        public IAddressRepository EnderecoRepository { get; }
        public IImageRepository ImagemRepository { get; }
        public IUserRepository UserRepository { get; }

        public

        Task CommitAsync();

    }
}
