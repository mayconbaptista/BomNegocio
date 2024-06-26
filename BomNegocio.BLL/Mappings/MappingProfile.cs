using AutoMapper;
using BomNegocio.API.DTOs;
using BomNegocio.DAL.Models;

namespace BomNegocio.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AdvertiserEntity, UserDTO>().ReverseMap();
            CreateMap<CategoryEntity, CategoryDTO>().ReverseMap();
            CreateMap<AnnouncementEntity, AnnouncementDTO>().ReverseMap();
        }
    }
}
