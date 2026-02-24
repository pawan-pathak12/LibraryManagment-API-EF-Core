using Library_Management_API.Domain.Models;

namespace Library_Management_API.Infrastructure.Repository.Books
{
    public interface IBookQueryRepository
    {
        Task<Book> GetByIdAsync(int id);
        Task<IEnumerable<Book>> GetAllAsync();

    }
}
