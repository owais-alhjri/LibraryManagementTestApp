using LMS.Application.DTOs.BorrowRecords;

namespace LMS.Application.Interfaces
{
    public interface IBorrowRecordService
    {
        public Task<Guid> BorrowBook(BorrowRecordCreateDto borrowRecordCreateDto);
        public Task<Guid> ReturnBook(ReturnBookDto returnBookDto);
    }
}
