using AutoMapper;
using BomNegocio.DAL.Models;

namespace BomNegocio.API.DTOs.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<Anunciante, AnuncianteDTO>().ReverseMap();
            CreateMap<Categoria, CategoriaDTO>().ReverseMap();
            CreateMap<Anuncio, AnuncioDTO>().ReverseMap();
        }
    }
}
