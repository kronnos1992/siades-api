
using AutoMapper;
using siades.Models.IdentityModels;
using siades.Services.DTOs;

namespace siades.Services.Mapping
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            // auth mapping
            CreateMap<Users, UserDTO>().ReverseMap();
            CreateMap<Users, UserLoginDTO>().ReverseMap();
        }
    }
}