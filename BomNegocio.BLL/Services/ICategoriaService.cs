using BomNegocio.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BomNegocio.BLL.Services
{
    public interface ICategoriaService
    {
        Task<IEnumerable<Categoria>> GetCategorias();
    }
}
