using Library_Management_API.Data;
using Library_Management_API.Interface;
using Library_Management_API.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;

namespace Library_Management_API.Repository;

public class BookRepository : IBookRepository
{
    private readonly ApplicationDbContext _dbContext;
    private readonly ILogger<BookRepository> _logger;

    public BookRepository(ApplicationDbContext dbContext, ILogger<BookRepository> logger)
    {
        _dbContext = dbContext;
        _logger = logger;
    }

    public async Task<IEnumerable<Book>> GetAllAsync()
    {
        return await _dbContext.Books.ToListAsync();
    }

    public async Task<Book?> GetByIdAsync(int id)
    {
        return await _dbContext.Books.FirstOrDefaultAsync(x => x.Id == id);
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