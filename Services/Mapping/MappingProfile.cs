
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using siades.Models;
using siades.Models.Auth;
using siades.Services.DTOs;

namespace siades.Services.Mapping
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            // auth mapping
            CreateMap<AppUser, UserDTO>().ReverseMap();
            CreateMap<AppUser, UserLoginDTO>().ReverseMap();

            // blood mapping
            CreateMap<Blood, BloodDTo>().ReverseMap();
        }
    }
}