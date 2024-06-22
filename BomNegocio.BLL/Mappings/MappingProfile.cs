using AutoMapper;
using BomNegocio.DAL.Models;

namespace BomNegocio.API.DTOs.Mappings
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
