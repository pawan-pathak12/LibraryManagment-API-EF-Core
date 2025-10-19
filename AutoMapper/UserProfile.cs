using AutoMapper;
using Library_Management_API.DTOs.User;
using Library_Management_API.Models;

namespace Library_Management_API.AutoMapper
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
