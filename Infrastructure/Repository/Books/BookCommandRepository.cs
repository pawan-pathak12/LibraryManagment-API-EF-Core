using Library_Management_API.Domain.Models;
using Library_Management_API.Infrastructure.Data;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;

namespace Library_Management_API.Infrastructure.Repository.Books
{
    public class BookCommandRepository : IBookCommandRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ILogger<BookCommandRepository> _logger;

        public BookCommandRepository(ApplicationDbContext dbContext, ILogger<BookCommandRepository> logger)
        {
            this._dbContext = dbContext;
            this._logger = logger;
        }

        public async Task<int> AddAsync(Book book)
        {
            _dbContext.Books.Add(book);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Book book)
        {
            _dbContext.Entry(book).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdatePatchAsync(int bookId, JsonPatchDocument bookModel)
        {
            var book = await _dbContext.Books.FirstOrDefaultAsync(x => x.Id == bookId);
            if (book != null)
            {
                bookModel.ApplyTo(book);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            var book = await _dbContext.Books.FirstOrDefaultAsync(x => x.Id == id);
            if (book == null) _logger.LogWarning($"Failed to delete : Book with Id {id} not found.");

            _dbContext.Books.Remove(book);
            await _dbContext.SaveChangesAsync();
        }
    }
}
