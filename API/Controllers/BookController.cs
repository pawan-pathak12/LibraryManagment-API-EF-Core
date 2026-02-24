using AutoMapper;
using Library_Management_API.Domain.Models;
using Library_Management_API.Infrastructure.Data;
using Library_Management_API.Infrastructure.Repository.Books;
using Library_Management_API.Shared.DTOs.Books;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Library_Management_API.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BookController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    private readonly IBookCommandRepository _bookCommandRepository;
    private readonly IBookQueryRepository _bookQueryRepository;
    private readonly IMapper _mapper;

    public BookController(IBookCommandRepository bookCommandRepository, IBookQueryRepository bookQueryRepository, IMapper mapper, ApplicationDbContext context)
    {
        this._bookCommandRepository = bookCommandRepository;
        this._bookQueryRepository = bookQueryRepository;
        _mapper = mapper;
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateBookDto createBook)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var book = _mapper.Map<Book>(createBook);
        var result = await _bookCommandRepository.AddAsync(book);

        return Ok("Book data created Successfully");
    }

    #region httpPut

    [HttpPut("{id}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateBookDto updateBook)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        if (id != updateBook.Id) return BadRequest("Id MisMatched");
        var book = _mapper.Map<Book>(updateBook);
        await _bookCommandRepository.UpdateAsync(book);
        return Ok("Update is successful");
    }

    #endregion

    #region httpDelete

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var book = await _bookQueryRepository.GetByIdAsync(id);
        if (book == null) return NotFound("Book not found");

        await _bookCommandRepository.DeleteAsync(id);
        return Ok($"Book with id {id} is deleted successfully");
    }

    #endregion

    #region httpPatch
    [HttpPatch("{id}")]
    public async Task<IActionResult> UpdatePatchBook([FromRoute] int id, [FromBody] JsonPatchDocument bookModel)
    {
        await _bookCommandRepository.UpdatePatchAsync(id, bookModel);
        return Ok("Updated is successfully");
    }

    #endregion

    #region HttpGet

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var books = await _bookQueryRepository.GetAllAsync();
        return Ok(books);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var book = await _bookQueryRepository.GetByIdAsync(id);
        return Ok(book);
    }

    #endregion
}