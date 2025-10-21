using Library_Management_API.Models;
using Microsoft.AspNetCore.JsonPatch;

namespace Library_Management_API.Interface;

public interface IBookRepository
{
    Task<IEnumerable<Book>> GetAllAsync();
    Task<Book?> GetByIdAsync(int id);
    Task<int> AddAsync(Book book);
    Task UpdateAsync(Book book);
    Task UpdatePatchAsync(int bookId, JsonPatchDocument bookModel);
    Task DeleteAsync(int id);
}