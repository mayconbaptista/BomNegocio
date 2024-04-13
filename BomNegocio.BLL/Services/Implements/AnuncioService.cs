using BomNegocio.DAL.Models;
using BomNegocio.DAL.Models.Exceptions;
using BomNegocio.DAL.Pagination;
using BomNegocio.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X.PagedList;

namespace BomNegocio.BLL.Services.Implements
{
    public class AnuncioService : IAnuncioService
    {
        public readonly IUnitOfWork _unitOfWork;

        public AnuncioService (IUnitOfWork unitOfWork, ITokenService tokenService)
        {
            _unitOfWork = unitOfWork;
        }

        public async  Task<Anuncio> CreateAsync (Anuncio newAnuncio, string email)
        {
            var anunciante = await _unitOfWork.AnuncianteRepository.GetAsync(a => a.Email == email)
                                                                            ?? throw new InternServerErrorException($"Desculpe ouve um erro ao cadastrar o anuncio");
            

            var categoria = await _unitOfWork.CategoriaRepository.GetAsync(a => a.Id == newAnuncio.CategoriaId)
                                                                            ?? throw new NotFoundException($"A categoria do anuncio não e valida");

            newAnuncio.AnuncianteId = anunciante.Id;

            var anuncio = _unitOfWork.AnuncioRepository.Create(newAnuncio) ?? throw new ConflictException("O anuncio já existe");
            await _unitOfWork.CommitAsync();
            
            return anuncio;
        }

        public async Task<Anuncio> DeleteAsync(int id, string email)
        {
            var anunciante = await _unitOfWork.AnuncianteRepository.GetAsync(a => a.Email == email) ?? throw new NotFoundException("Erro ao obter dados do anunciante");

            var anuncio = anunciante.Anuncios!.AsQueryable().FirstOrDefault(a => a.Id == id) ?? throw new NotFoundException($"Anuncio id:{id} não encontrado");

            _unitOfWork.AnuncioRepository.Delete(anuncio);
            await _unitOfWork.CommitAsync( );

            return anuncio;
        }

        public async Task<IPagedList<Anuncio>> GetAllAsync (AnuncioFilterParameters anuncioFilterParameters)
        {
            var anuncios = await _unitOfWork.AnuncioRepository.GetAnunciosAsync(anuncioFilterParameters);

            return anuncios;
        }

        public async Task<Anuncio> GetAsync(int id)
        {
            var anuncio = await _unitOfWork.AnuncioRepository.GetAsync(a => a.Id == id) ?? throw new NotFoundException("Anuncio não encontrado");

            return anuncio;
        }

        public async Task<Anuncio> UpdateAsync(Anuncio newAnuncio, string email)
        {
            var anunciante = await _unitOfWork.AnuncianteRepository.GetAsync(a => a.Email == email)
                                                                             ?? throw new InternServerErrorException("Erro ao obter dados do anunciante");

            var anuncio = await anunciante.Anuncios!.AsQueryable().FirstOrDefaultAsync(a => a.AnuncianteId == anunciante.Id)
                                                                                    ?? throw new NotFoundException($"Não foi encontrada correspondencia para o anuncio com id:{newAnuncio.Id}");

            newAnuncio.AnuncianteId = anunciante.Id;
            
            _unitOfWork.AnuncioRepository.Update(newAnuncio);
            await _unitOfWork.CommitAsync();

            return newAnuncio;
        }
    }
}
