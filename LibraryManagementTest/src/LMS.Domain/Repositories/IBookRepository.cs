
using LMS.Domain.Entities;

namespace LMS.Domain.Repositories
{
    public interface IBookRepository
    {
        Task AddAsync(Book book);

        Task SaveChangesAsync();
    }
}
