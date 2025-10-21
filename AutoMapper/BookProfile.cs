using AutoMapper;
using Library_Management_API.DTOs.Book;
using Library_Management_API.Models;

namespace Library_Management_API.AutoMapper;

public class BookProfile : Profile
{
    public BookProfile()
    {
        CreateMap<CreateBookDto, Book>().ReverseMap();
        CreateMap<BookDto, Book>().ReverseMap();
        CreateMap<Book, UpdateBookDto>().ReverseMap();
    }
}