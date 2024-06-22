using BomNegocio.Application.Services.Interface;
using BomNegocio.Domain.Entitys;
using X.PagedList;

namespace BomNegocio.BLL.Services.Implements
{
    public class AdvertiserService : IAdvertiserService
    {
        private readonly IUnitOfWork _unitOfWork;
        public AdvertiserService(IUnitOfWork unitOfWork) 
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<AdvertiserEntity> CreateAsync (AdvertiserEntity anunciante)
        {
            _unitOfWork.AnuncianteRepository.Create(anunciante);
            await _unitOfWork.CommitAsync();

            return anunciante;
        }

        public async  Task<AdvertiserEntity> DeleteAsync (int id)
        {
            var anunciante = await _unitOfWork.AnuncianteRepository.GetAsync(a => a.UserId == id);

            return anunciante!;
        }

        public async Task<IPagedList<AdvertiserEntity>> GetAllAsync (AnuncianteFilterParameters anuncianteFilterParameters)
        {
            var anunciantes = await _unitOfWork.AnuncianteRepository.GetAnunciantesAsync(anuncianteFilterParameters);

            return anunciantes;
        }

        public async Task<AdvertiserEntity?> GetByIdAsync(int id)
        {
            var anunciante = await _unitOfWork.AnuncianteRepository.GetAsync(a => a.Id == id);

            return anunciante;
        }

        public async Task<AdvertiserEntity> UpdateAsync (AdvertiserEntity newAnuncinte)
        {
            var anunciante = _unitOfWork.AnuncianteRepository.Update(newAnuncinte);
            await _unitOfWork.CommitAsync();

            return anunciante!;
        }
    }
}
