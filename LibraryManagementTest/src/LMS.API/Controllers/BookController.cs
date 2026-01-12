using LMS.API.DTOs;
using LMS.Domain.Entities;
using LMS.Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly LmsDbContext _dbContext;

        public BookController(LmsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("allBooks")]
        public async Task<ActionResult<List<BookDto>>> GetAllBooks()
        {
            var books = await _dbContext.Books.ToListAsync();

            var bookDtos = books.Select(b => new BookDto
            {
                Id = b.Id,
                Title = b.Title,
                Author = b.Author,
                BookState = b.BookState.ToString()
            }).ToList();

            return Ok(bookDtos);
        }
    }
}
