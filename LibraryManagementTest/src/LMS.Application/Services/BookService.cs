using System.ComponentModel.DataAnnotations;
using LMS.API.DTOs;
using LMS.Application.DTOs;
using LMS.Application.Interfaces;
using LMS.Domain.Entities;
using LMS.Domain.Enums;
using LMS.Domain.Repositories;

namespace LMS.Application.Services
{
    public class BookService :IBookService
    {
        private readonly IBookRepository _bookRepository;
        
        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<List<ResponseBookDto>> GetAllBooksAsync()
        {
            var books = await _bookRepository.GetAllAsync();

            return books.Select(b => new ResponseBookDto
            {
                Id = b.Id,
                Title = b.Title,
                Author = b.Author,
                BookState = b.State.ToString()
            }).ToList();
        }

        public async Task<Guid> AddBookAsync(CreateBookDto createBookDto)
        {
            var book = new Book(createBookDto.Title, createBookDto.Author);

            await _bookRepository.AddAsync(book);
            await _bookRepository.SaveChangesAsync();

            return  book.Id;
        }
        
        public async Task<bool> UpdateBookAsync(UpdateBook updateBook,Guid id)
        {
            var book = await _bookRepository.GetByIdAsync(id);
            if(book is null)
            {
                throw new KeyNotFoundException("Book not dound");
            }
            BookState? parsedState = null;

            if (updateBook.BookState != null)
            {
                if (!Enum.TryParse<BookState>(updateBook.BookState, true, out var state))
                {

                    throw new ValidationException("Invalid BookState");

                }

                parsedState = state;
            }
            book.UpdateBook(updateBook.Title, updateBook.Author, parsedState);
            await _bookRepository.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteBook(Guid id)
        {
            var book = await _bookRepository.GetByIdAsync(id);
            if(book == null)
            {
                return false;
            }

            await _bookRepository.DeleteByIdAsync(id);
            await _bookRepository.SaveChangesAsync();
            return true;

        }
        public async Task<ResponseBookDto?> GetBookByIdAsync(Guid id)
        {
            var book = await _bookRepository.GetByIdAsync(id);
            if (book is null) return null;

            return new ResponseBookDto
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author,
                BookState = book.State.ToString()
            };
        }

    }
}
