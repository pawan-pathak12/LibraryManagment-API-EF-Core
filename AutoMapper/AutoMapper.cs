using AutoMapper;
using Library_Management_API.Models;
using Library_Management_API.DTOs;
using Library_Management_API.DTOs.Update;

namespace Library_Management_API.Mapper
{
    public class AutoMapper :Profile
    {
        public AutoMapper()
        {
            // For POST (DTO → Model)
            CreateMap<CreateCategoryDto, Category>();
            CreateMap<CreateBookDto, Book>();

            // For GET (Model → DTO)
            CreateMap<Category, CategoryDto>();
            CreateMap<Book, BookDto>();

            //for Update
            CreateMap<UpdateCategoryDTO, Category>();
        }

    }
}
