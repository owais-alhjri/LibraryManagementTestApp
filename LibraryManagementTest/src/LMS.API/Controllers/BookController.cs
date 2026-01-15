using LMS.API.DTOs;
using LMS.Application.DTOs;
using LMS.Application.Interfaces;
using LMS.Domain.Entities;
using LMS.Domain.Enums;
using LMS.Domain.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace LMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;
        private readonly IBookService _bookService;

        public BookController(IBookRepository bookRepository,IBookService bookService)
        {
            _bookRepository = bookRepository;
            _bookService = bookService;
        }

        [HttpGet("allBooks")]
        public async Task<ActionResult> GetAllBooks()
        {
            var books = await _bookService.GetAllBooksAsync();

            return Ok(books);
        }

        [HttpPost("register")]
        public async Task<ActionResult> AddBook([FromBody]CreateBookDto createBookDto)
        {
            if(createBookDto == null)
            {
                return BadRequest("Requsted body is null");
            }

            var bookId = await _bookService.AddBookAsync(createBookDto);

            return CreatedAtAction(
                nameof(AddBook),
                new { id = bookId },
                null);  
        }

        [HttpPut("updateBook/{id:guid}")]
        public async Task<ActionResult> UpdateBook([FromBody] UpdateBook updateBookDto, [FromRoute] Guid id)
        {
            if(updateBookDto == null)
            {
                return BadRequest("Requsted body is null");
            }

            var updated = await _bookService.UpdateBookAsync(updateBookDto,id);

            if (updated == false)
            {
                 return NotFound($"Book not found with this Id: {id}");
            }

            
            return NoContent();
        }

    }
}
