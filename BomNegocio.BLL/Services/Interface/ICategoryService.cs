using BomNegocio.DAL.Models;

namespace BomNegocio.Application.Services.Interface
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryEntity>> GetCategorias();
    }
}
