using AutoMapper;
using Library_Management_API.Domain.Models;
using Library_Management_API.Shared.DTOs.User;

namespace Library_Management_API.Shared.AutoMapper
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<LoginUserDto, AppUser>().ReverseMap();
            CreateMap<RegisterUserDto, AppUser>().ReverseMap();
        }
    }
}
