using BomNegocio.Application.Services.Interface;
using BomNegocio.DAL.Models;
using BomNegocio.Domain.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BomNegocio.BLL.Services.Implements
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryService(IUnitOfWork unitOfWork) 
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<CategoryEntity>> GetCategorias()
        {
            var categorias = await _unitOfWork.CategoriaRepository.GetAllAsync();

            return categorias;
        }
    }
}
