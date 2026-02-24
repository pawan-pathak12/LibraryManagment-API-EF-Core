using AutoMapper;
using Library_Management_API.Domain.Models;
using Library_Management_API.Shared.DTOs.Category;

namespace Library_Management_API.Shared.AutoMapper
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CreateCategoryDto>().ReverseMap();
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Category, UpdateCategoryDTO>().ReverseMap();
        }
    }
}
