using LMS.Domain.Entities;
using LMS.Domain.Repositories;
using LMS.Infrastructure.Persistence;

namespace LMS.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly LmsDbContext _dbContext;

        public UserRepository(LmsDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task AddUserAsync(User user)
        {
            await _dbContext.Users.AddAsync(user);
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
        public async Task<User?> GetByIdAsync(Guid id)
        {
            var userId = await _dbContext.Users.FindAsync(id);

            return userId;
        }

    }
}
