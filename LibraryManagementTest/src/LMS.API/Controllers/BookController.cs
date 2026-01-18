using LMS.API.DTOs;
using LMS.Application.DTOs;
using LMS.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllBooks()
        {
            var books = await _bookService.GetAllBooksAsync();

            return Ok(books);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult> GetBookById([FromRoute] Guid id)
        {
            var book = await _bookService.GetBookByIdAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        [HttpPost]
        public async Task<ActionResult> AddBook([FromBody] CreateBookDto createBookDto)
        {

            var bookId = await _bookService.AddBookAsync(createBookDto);

            return CreatedAtAction(nameof(GetBookById), new { id = bookId }, null);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult> UpdateBook([FromBody] UpdateBook updateBookDto, [FromRoute] Guid id)
        {

            var updated = await _bookService.UpdateBookAsync(updateBookDto, id);

            if (updated == false)
            {
                return NotFound($"Book not found with this Id: {id}");
            }


            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> DeleteBook([FromRoute] Guid id)
        {
            var deleted = await _bookService.DeleteBook(id);
            if (deleted == false)
            {
                return NotFound($"Book not found with this Id: {id}");
            }

            return NoContent();
        }

    }
}
