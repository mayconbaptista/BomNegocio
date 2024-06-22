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
        public IAnuncioRepository AnuncioRepository { get; }
        public ICategoriaRepository CategoriaRepository { get; }
        public IClienteRepository ClienteRepository { get; }
        public IDesejoRepository DesejoRepository { get; }
        public IEnderecoRepository EnderecoRepository { get; }
        public IImagemRepository ImagemRepository { get; }
        public IUserRepository UserRepository { get; }

        public

        Task CommitAsync();

    }
}
