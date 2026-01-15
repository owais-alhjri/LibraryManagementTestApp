using LMS.API.DTOs;
using LMS.Application.DTOs;

namespace LMS.Application.Interfaces
{
    public interface IBookService
    {
        Task<List<ResponseBookDto>> GetAllBooksAsync();

        Task<Guid> AddBookAsync(CreateBookDto createBookDto);
        Task<bool> UpdateBookAsync(UpdateBook updateBook,Guid id);
        Task<bool> DeleteBook(Guid id);
    }
}
