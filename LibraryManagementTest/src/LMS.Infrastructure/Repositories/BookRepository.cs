
using LMS.Domain.Entities;
using LMS.Domain.Repositories;
using LMS.Infrastructure.Persistence;

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
    }
}
