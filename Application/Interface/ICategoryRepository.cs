using Library_Management_API.Domain.Models;
using Microsoft.AspNetCore.JsonPatch;

namespace Library_Management_API.Application.Interface;

public interface ICategoryRepository
{
    Task<IEnumerable<Category>> GetAllAsync();
    Task<Category?> GetByIdAsync(int id);
    Task<int> AddAsync(Category category);
    Task UpdateAsync(Category category);
    Task UpdatePatchAsync(int id, JsonPatchDocument category);
    Task DeleteAsync(int id);
}