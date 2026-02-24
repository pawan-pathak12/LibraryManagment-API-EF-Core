using AutoMapper;
using Library_Management_API.Domain.Models;
using Library_Management_API.Shared.DTOs.Books;

namespace Library_Management_API.Shared.AutoMapper;

public class BookProfile : Profile
{
    public BookProfile()
    {
        CreateMap<CreateBookDto, Book>().ReverseMap();
        CreateMap<BookDto, Book>().ReverseMap();
        CreateMap<Book, UpdateBookDto>().ReverseMap();
    }
}