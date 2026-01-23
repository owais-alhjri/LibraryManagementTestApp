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

            var book = await _bookService.AddBookAsync(createBookDto);

            return Ok(new ResponseBookDto
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author,
                BookState = book.State.ToString(),
                Message = "Book is registered successfully"
            });
        }

        [HttpPatch("{id:guid}")]
        public async Task<ActionResult> UpdateBook([FromBody] UpdateBookPatchDto updateBookDto, [FromRoute] Guid id)
        {
            var book = await _bookService.UpdateBookAsync(updateBookDto, id);
            return Ok(new ResponseBookDto
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author,
                BookState = book.State.ToString(),
                Message = "Book updated successfully"
            });
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> DeleteBook([FromRoute] Guid id)
        {
            var book = await _bookService.DeleteBook(id);

            return Ok(new DeleteBookResponseDto
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author,
                Message = "Book is deleted successfully"
            });
        }

    }
}
