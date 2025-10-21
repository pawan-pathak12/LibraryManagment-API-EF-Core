using AutoMapper;
using Library_Management_API.DTOs.Category;
using Library_Management_API.Interface;
using Library_Management_API.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Library_Management_API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoryController : ControllerBase
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;

    public CategoryController(ICategoryRepository categoryRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<IActionResult> AddAsync([FromBody] CreateCategoryDto createCategory)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var category = _mapper.Map<Category>(createCategory);
        var created = await _categoryRepository.AddAsync(category);
        return Ok(category);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var category = await _categoryRepository.GetAllAsync();
        return Ok(category);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var category = await _categoryRepository.GetByIdAsync(id);
        return Ok(category);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateCategoryDTO updateCategory)
    {
        if (id != updateCategory.Id)
            return BadRequest("ID mismatch");

        var category = _mapper.Map<Category>(updateCategory);
        await _categoryRepository.UpdateAsync(category);
        return Ok($"Category with Id {category.Id} Updated Successfully");
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> UpdatePatch([FromRoute] int id, [FromBody] JsonPatchDocument categoryModel)
    {
        await _categoryRepository.UpdatePatchAsync(id, categoryModel);
        return Ok("Updated Successfully");
    }

    [HttpDelete("id")]
    public async Task<IActionResult> Delete(int id)
    {
        await _categoryRepository.DeleteAsync(id);
        return Ok($"Deleted category with Id {id}");
    }
}