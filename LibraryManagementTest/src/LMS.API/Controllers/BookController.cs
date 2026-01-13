using LMS.API.DTOs;
using LMS.Domain.Entities;
using LMS.Domain.Repositories;
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
    }
}
