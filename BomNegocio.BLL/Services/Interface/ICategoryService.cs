using BomNegocio.DAL.Models;

namespace BomNegocio.BLL.Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryEntity>> GetCategorias();
    }
}
