using LMS.Application.DTOs.Book;
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
        public async Task<ActionResult> GetAllBooks() => Ok(await _bookService.GetAllBooksAsync());


        [HttpGet("{id:guid}")]
        public async Task<ActionResult> GetBookById([FromRoute] Guid id) => Ok(await _bookService.GetBookByIdAsync(id));


        [HttpPost]
        public async Task<ActionResult> AddBook([FromBody] CreateBookDto createBookDto)
        {

            var bookId = await _bookService.AddBookAsync(createBookDto);

            return CreatedAtAction(nameof(GetBookById), new { id = bookId });
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult> UpdateBook([FromBody] UpdateBook updateBookDto, [FromRoute] Guid id)
        {
            await _bookService.UpdateBookAsync(updateBookDto, id);
            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> DeleteBook([FromRoute] Guid id)
        {
            await _bookService.DeleteBook(id);

            return NoContent();
        }

    }
}
