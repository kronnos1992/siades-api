
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using siades.Services.DTOs;

namespace siades.Services.Mapping
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            // auth mapping
            CreateMap<IdentityUser, UserDTO>().ReverseMap();
            CreateMap<IdentityUser, UserLoginDTO>().ReverseMap();
        }
    }
}