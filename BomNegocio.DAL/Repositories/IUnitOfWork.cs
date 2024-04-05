using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BomNegocio.DAL.Repositories
{
    public interface IUnitOfWork
    {
        public IAnuncianteRepository AnuncianteRepository { get; }
        public IAnuncioRepository AnuncioRepository { get; }
        public ICategoriaRepository CategoriaRepository { get; }
        public IInteresseRepository InteresseRepository { get; }
        public IClienteRepository ClienteRepository { get; }
        public IEnderecoRepository EnderecoRepository { get; }
        public 

        Task CommitAsync ();

    }
}
