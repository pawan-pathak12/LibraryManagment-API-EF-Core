using Library_Management_API.Data;
using Library_Management_API.Interface;
using Library_Management_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Library_Management_API.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly Logger<CategoryRepository> _logger;

        public CategoryRepository(ApplicationDbContext dbContext, Logger<CategoryRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await _dbContext.Categories.ToListAsync();
        }

        public async Task<Category?> GetByIdAsync(int id)
        {
            return await _dbContext.Categories.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<int> AddAsync(Category category)
        {
            _dbContext.Categories.Add(category);
            await _dbContext.SaveChangesAsync();
            return category.Id;

        }

        public async Task UpdateAsync(Category category)
        {
            _dbContext.Entry(category).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var category = await _dbContext.Categories.FirstOrDefaultAsync(x => x.Id == id);
            if (category == null)
            {
                _logger.LogWarning($"Their is no category with Id {id}");
            }
            _dbContext.Categories.Remove(category);
            await _dbContext.SaveChangesAsync();
        }
    }
}
