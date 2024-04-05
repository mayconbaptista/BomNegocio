using BomNegocio.DAL.Models;
using BomNegocio.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BomNegocio.BLL.Services.Implements
{
    public class CategoriaService : ICategoriaService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoriaService(IUnitOfWork unitOfWork) 
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<Categoria>> GetCategorias()
        {
            var categorias = await _unitOfWork.CategoriaRepository.GetAllAsync();

            return categorias;
        }
    }
}
