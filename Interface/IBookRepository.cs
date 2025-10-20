using Library_Management_API.Models;

namespace Library_Management_API.Interface
{
    public interface IBookRepository
    {

        Task<IEnumerable<Book>> GetAllAsync();
        Task<Book?> GetByIdAsync(int id);
        Task<int> AddAsync(Book book);
        Task UpdateAsync(Book book);
        Task DeleteAsync(int id);
    }
}
