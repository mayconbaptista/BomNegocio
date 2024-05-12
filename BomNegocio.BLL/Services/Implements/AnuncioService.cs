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

        public AnuncioService (IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Anuncio> CreateAsync (Anuncio newAnuncio)
        {
           var anuncio  = this._unitOfWork.AnuncioRepository.Create (newAnuncio);
           await this._unitOfWork.CommitAsync ();
            
            return anuncio;
        }

        public async Task<Anuncio> DeleteAsync(int id)
        {
            var anuncio = await this._unitOfWork.AnuncioRepository.GetAsync(a => a.Id == id) ?? throw new NotFoundException("Anuncio não encontrado");

            this._unitOfWork.AnuncioRepository.Delete (anuncio);
            await this._unitOfWork.CommitAsync();
            
            return anuncio;
        }

        public async Task<IPagedList<Anuncio>> GetAllAsync (AnuncioFilterParameters anuncioFilterParameters)
        {
            var anuncios = await _unitOfWork.AnuncioRepository.GetAnunciosAsync(anuncioFilterParameters);

            return anuncios;
        }

        public async Task<Anuncio> GetAsync(int id)
        {
            var anuncio = await _unitOfWork.AnuncioRepository.GetAsyncANT(a => a.Id == id) ?? throw new NotFoundException("Anuncio não encontrado");

            return anuncio;
        }

        public async Task<Anuncio> UpdateAsync(Anuncio newAnuncio)
        {
            var anuncio = await this._unitOfWork.AnuncioRepository.GetAsync(a => a.Id == newAnuncio.Id) ?? throw new NotFoundException("Anuncio não existe");

            return newAnuncio;
        }
    }
}
