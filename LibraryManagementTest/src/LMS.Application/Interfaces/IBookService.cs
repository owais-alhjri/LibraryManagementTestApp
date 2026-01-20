using LMS.Application.DTOs.Book;

namespace LMS.Application.Interfaces
{
    public interface IBookService
    {
        Task<List<ResponseBookDto>> GetAllBooksAsync();

        Task<Guid> AddBookAsync(CreateBookDto createBookDto);
        Task UpdateBookAsync(UpdateBook updateBook, Guid id);
        Task DeleteBook(Guid id);
        Task<ResponseBookDto?> GetBookByIdAsync(Guid id);
    }
}
