using Library_Management_API.Domain.Models;
using Library_Management_API.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Library_Management_API.Infrastructure.Repository.Books
{
    public class BookQueryRepository : IBookQueryRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ILogger<BookQueryRepository> _logger;

        public BookQueryRepository(ApplicationDbContext dbContext, ILogger<BookQueryRepository> logger)
        {
            this._dbContext = dbContext;
            this._logger = logger;
        }
        public async Task<IEnumerable<Book>> GetAllAsync()
        {
            return await _dbContext.Books.ToListAsync();
        }

        public async Task<Book?> GetByIdAsync(int id)
        {
            return await _dbContext.Books.FirstOrDefaultAsync(x => x.Id == id);
        }

    }
}
