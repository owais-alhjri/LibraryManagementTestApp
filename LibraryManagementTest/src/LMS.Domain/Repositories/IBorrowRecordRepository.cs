using LMS.Domain.Entities;

namespace LMS.Domain.Repositories
{
    public interface IBorrowRecordRepository
    {
        Task BorrowBookAsync(BorrowRecord borrowRecord);
        Task SaveChangesAsync();
    }
}
