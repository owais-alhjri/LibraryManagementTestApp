using LMS.Domain.Entities;
using LMS.Domain.Repositories;
using LMS.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace LMS.Infrastructure.Repositories
{
    public class BookRepository :IBookRepository
    {
        private readonly LmsDbContext _dbContext;

        public BookRepository(LmsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Book book)
        {
            await _dbContext.Books.AddAsync(book);
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Book>> ListOfBooksAsync()
        {
            return await _dbContext.Books.ToListAsync();
        }

        
        public Task UpdateBook(Book book)
        {
             _dbContext.Books.Update(book);
            return Task.CompletedTask;
        }
        

        public async Task<Book> GetByIdAsync(Guid id )
        {
             var book = await _dbContext.Books.FindAsync(id);
            return book;
        }

        public async Task DeleteByIdAsync(Guid id)
        {
            var book = await _dbContext.Books.FindAsync(id);
            if (book == null)
            {
                return;
            }
            _dbContext.Remove(book);
            await _dbContext.SaveChangesAsync();
        }

    }
}
