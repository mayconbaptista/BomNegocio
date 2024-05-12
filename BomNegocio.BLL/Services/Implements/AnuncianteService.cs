using BomNegocio.DAL.Models;
using BomNegocio.DAL.Pagination;
using BomNegocio.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X.PagedList;

namespace BomNegocio.BLL.Services.Implements
{
    public class AnuncianteService : IAnuncianteService
    {
        private readonly IUnitOfWork _unitOfWork;
        public AnuncianteService(IUnitOfWork unitOfWork) 
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Anunciante> CreateAsync (Anunciante anunciante)
        {
            _unitOfWork.AnuncianteRepository.Create(anunciante);
            await _unitOfWork.CommitAsync();

            return anunciante;
        }

        public async  Task<Anunciante> DeleteAsync (int id)
        {
            var anunciante = await _unitOfWork.AnuncianteRepository.GetAsync(a => a.Id == id);

            return anunciante!;
        }

        public async Task<IPagedList<Anunciante>> GetAllAsync (AnuncianteFilterParameters anuncianteFilterParameters)
        {
            var anunciantes = await _unitOfWork.AnuncianteRepository.GetAnunciantesAsync(anuncianteFilterParameters);

            return anunciantes;
        }

        public async Task<Anunciante?> GetByIdAsync(int id)
        {
            var anunciante = await _unitOfWork.AnuncianteRepository.GetAsync(a => a.Id == id);

            return anunciante;
        }

        public async Task<Anunciante> UpdateAsync (Anunciante newAnuncinte)
        {
            var anunciante = _unitOfWork.AnuncianteRepository.Update(newAnuncinte);
            await _unitOfWork.CommitAsync();

            return anunciante!;
        }
    }
}
