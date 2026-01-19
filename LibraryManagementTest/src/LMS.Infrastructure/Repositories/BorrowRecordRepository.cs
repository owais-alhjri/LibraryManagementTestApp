using LMS.Domain.Entities;
using LMS.Domain.Repositories;
using LMS.Infrastructure.Persistence;

namespace LMS.Infrastructure.Repositories
{
    public class BorrowRecordRepository : IBorrowRecordRepository
    {
        private readonly LmsDbContext _dbContext;
        public BorrowRecordRepository(LmsDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
        public async Task BorrowBookAsync(BorrowRecord borrowRecord)
        {

            await _dbContext.BorrowRecords.AddAsync(borrowRecord);
            
        }
    }
}
