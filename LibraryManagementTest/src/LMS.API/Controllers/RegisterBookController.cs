using LMS.API.DTOs;
using LMS.Domain.Entities;
using LMS.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace LMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterBookController : ControllerBase
    {
        private readonly IBookRepository _bookRepository ;

        public RegisterBookController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        [HttpPost("register")]
        public async Task<ActionResult> AddBook([FromBody] CreateBookDto createBookDto)
        {
            
                if(createBookDto == null)
                {
                    return BadRequest("Request body is null");
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
