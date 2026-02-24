using Library_Management_API.Domain.Models;
using Microsoft.AspNetCore.JsonPatch;

namespace Library_Management_API.Infrastructure.Repository.Books
{
    public interface IBookCommandRepository
    {
        Task<int> AddAsync(Book book);
        Task UpdateAsync(Book book);
        Task DeleteAsync(int id);
        Task UpdatePatchAsync(int bookId, JsonPatchDocument bookModel);

    }
}
