using LMS.API.DTOs;
using LMS.Application.DTOs;
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

        public BookController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        [HttpGet("allBooks")]
        public async Task<ActionResult<List<ResponseBookDto>>> GetAllBooks()
        {
            var books = await _bookRepository.ListOfBooksAsync();

            var bookDtos = books.Select(b => new ResponseBookDto
            {
                Id = b.Id,
                Title = b.Title,
                Author = b.Author,
                BookState = b.BookState.ToString()
            }).ToList();

            return Ok(bookDtos);
        }



        [HttpPost("register")]
        public async Task<ActionResult> AddBook([FromBody]CreateBookDto createBookDto)
        {
            if(createBookDto == null)
            {
                return BadRequest("Requsted body is null");
            }

            var book = new Book(createBookDto.Title, createBookDto.Author);

            await _bookRepository.AddAsync(book);
            await _bookRepository.SaveChangesAsync();

            return CreatedAtAction(
                nameof(AddBook),
                new { id = book.Id },
                "Book registerd successfully");  
        }

        [HttpPut("updateBook/{id:guid}")]
        public async Task<ActionResult> UpdateBook([FromBody] UpdateBook updateBookDto, [FromRoute] Guid id)
        {
            if(updateBookDto == null)
            {
                return BadRequest("Requsted body is null");
            }

            var book = await _bookRepository.GetByIdAsync(id);

            if (book == null)
            {
                return NotFound($"Book not found with this Id: {id}");
            }

            BookState? parsedState = null;

            if(updateBookDto.BookState != null)
            {
                if (!Enum.TryParse<BookState>(updateBookDto.BookState,true,out var state))
                {
                    return BadRequest("Invalid BookState value");
                }

                parsedState = state;
            }
            

            book.UpdateBook(updateBookDto.Title, updateBookDto.Author, parsedState);

            
            
             await _bookRepository.SaveChangesAsync();

            return NoContent();
        }

    }
}
