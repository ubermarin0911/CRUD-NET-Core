using app.api.Dtos;
using app.api.Entities;
using AutoMapper;

namespace app.api.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<ClienteDto, Cliente>().ReverseMap();
        }
    }
}