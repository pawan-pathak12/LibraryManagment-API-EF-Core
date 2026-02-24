using Library_Management_API.Domain.Models;

namespace Library_Management_API.Application.Interface
{
    public interface IAuthorRepository
    {
        Task<Author> AddAuthorAsync(Author author);
        Task<IEnumerable<Author>> GetAllAuthorsAsync();
        Task<Author> GetAuthorByIdAsync(int id);

        Task<Author> UpdateAuthorAsync(Author author);
        Task<bool> DeleteAuthorAsync(int id);

    }
}
