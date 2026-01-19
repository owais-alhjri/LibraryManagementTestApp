using LMS.Domain.Entities;

namespace LMS.Domain.Repositories
{
    public interface IUserRepository
    {
        Task AddUserAsync(User user);

        Task SaveChangesAsync();
        Task<User?> GetByIdAsync(Guid id);
    }
}
