using app.api.Dtos;
using app.api.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace app.api.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Cliente, ClienteDatosDto>().ReverseMap();
            CreateMap<ClienteDto, Cliente>();
        }
    }
}
