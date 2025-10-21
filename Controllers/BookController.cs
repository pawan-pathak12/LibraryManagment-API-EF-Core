using AutoMapper;
using Library_Management_API.Data;
using Library_Management_API.DTOs.Book;
using Library_Management_API.Interface;
using Library_Management_API.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Library_Management_API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BookController : ControllerBase
{
    private readonly IBookRepository _bookRepository;
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;

    public BookController(IBookRepository bookRepository, IMapper mapper, ApplicationDbContext context)
    {
        _bookRepository = bookRepository;
        _mapper = mapper;
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateBookDto createBook)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var book = _mapper.Map<Book>(createBook);
        var result = await _bookRepository.AddAsync(book);

        return Ok("Book data created Successfully");
    }

    #region httpPut

    [HttpPut("{id}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateBookDto updateBook)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        if (id != updateBook.Id) return BadRequest("Id MisMatched");
        var book = _mapper.Map<Book>(updateBook);
        await _bookRepository.UpdateAsync(book);
        return Ok("Update is successful");
    }

    #endregion

    #region httpDelete

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var book = await _bookRepository.GetByIdAsync(id);
        if (book == null) return NotFound("Book not found");

        await _bookRepository.DeleteAsync(id);
        return Ok($"Book with id {id} is deleted successfully");
    }

    #endregion

    #region httpPatch

    //wdm

    [HttpPatch("{id}")]
    public async Task<IActionResult> UpdatePatchBook([FromRoute] int id, [FromBody] JsonPatchDocument bookModel)
    {
        await _bookRepository.UpdatePatchAsync(id, bookModel);
        return Ok("Updated is successfully");
    }

    #endregion

    #region HttpGet

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var books = await _bookRepository.GetAllAsync();
        return Ok(books);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var book = await _bookRepository.GetByIdAsync(id);
        return Ok(book);
    }

    #endregion
}