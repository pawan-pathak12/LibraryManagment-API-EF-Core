using Library_Management_API.Application.Interface;
using Library_Management_API.Domain.Models;
using Library_Management_API.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Library_Management_API.Infrastructure.Repository
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly ApplicationDbContext _context;

        public AuthorRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // CREATE
        public async Task<Author> AddAuthorAsync(Author author)
        {
            _context.Authors.Add(author);
            await _context.SaveChangesAsync();
            return author;
        }

        // READ (Get All)
        public async Task<IEnumerable<Author>> GetAllAuthorsAsync()
        {
            return await _context.Authors.Include(a => a.Books).ToListAsync();
        }

        // READ (Get by Id)
        public async Task<Author> GetAuthorByIdAsync(int id)
        {
            return await _context.Authors
                                 .Include(a => a.Books)
                                 .FirstOrDefaultAsync(a => a.AuthorId == id);
        }

        // UPDATE
        public async Task<Author> UpdateAuthorAsync(Author author)
        {
            _context.Authors.Update(author);
            await _context.SaveChangesAsync();
            return author;
        }

        // DELETE
        public async Task<bool> DeleteAuthorAsync(int id)
        {
            var author = await _context.Authors.FindAsync(id);
            if (author == null)
                return false;

            _context.Authors.Remove(author);
            await _context.SaveChangesAsync();
            return true;
        }
    }


}
