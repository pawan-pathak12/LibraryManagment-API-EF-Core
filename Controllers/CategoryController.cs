using AutoMapper;
using Library_Management_API.Data;
using Library_Management_API.DTOs;
using Library_Management_API.DTOs.Update;
using Library_Management_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Library_Management_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly IMapper _mapper;

        public CategoryController(ApplicationDbContext applicationDbContext, IMapper mapper)
        {
            this._applicationDbContext = applicationDbContext;
            this._mapper = mapper;
        }

        [HttpPost("Add Category")]
        public async Task<IActionResult> AddCategoryAsync([FromBody] CreateCategoryDto Data)

        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var categoryDto = _mapper.Map<Category>(Data);
            var input = await _applicationDbContext.Categories.AddAsync(categoryDto);
            await _applicationDbContext.SaveChangesAsync();
            return Ok("Category added successfully!");

        }

        [HttpGet("Get All Category")]
        public async Task<IActionResult> ShowAllCategoryAsync()
        {
            var data = await _applicationDbContext.Categories.ToListAsync();

          var categoryDtos = _mapper.Map<List<CategoryDto>>(data);
            return Ok(categoryDtos);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> FindCategoryByIdAsync(int id)
        {
            var data = await _applicationDbContext.Categories.FirstOrDefaultAsync(x=>x.Id==id);
            var categoryDto = _mapper.Map<CategoryDto>(data);
            return Ok(categoryDto);
        }
        [HttpPut("{id:int}")]
        public async Task<IActionResult> ShowAllCategoryAsync(int id ,[FromBody] UpdateCategoryDTO updateCategoryDTO)
        {
            var categoryData = await _applicationDbContext.Categories.FindAsync(id);
            if(categoryData == null)
            {
                return NotFound("Category not found");
            }
            _mapper.Map(updateCategoryDTO, categoryData);
            _applicationDbContext.Entry(categoryData).State = EntityState.Modified;
            await _applicationDbContext.SaveChangesAsync();
            return Ok("Category updated successfully!");

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategoryAsync(int id)
        {
            var categoryData = await _applicationDbContext.Categories.FindAsync(id);
            if (categoryData == null)
            {
                return NotFound("Category not found");
            }
            
            _applicationDbContext.Categories.Remove(categoryData);
            await _applicationDbContext.SaveChangesAsync();
            return Ok("Category deleted successfully!");

        }
       

    }
}
