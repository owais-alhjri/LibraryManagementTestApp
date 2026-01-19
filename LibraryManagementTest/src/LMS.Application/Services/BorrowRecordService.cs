using LMS.Application.DTOs.BorrowRecords;
using LMS.Application.Interfaces;
using LMS.Domain.Entities;
using LMS.Domain.Repositories;

namespace LMS.Application.Services
{
    public class BorrowRecordService : IBorrowRecordService
    {
        private readonly IBorrowRecordRepository _recordRepository;
        private readonly IBookRepository _bookRepository;
        private readonly IUserRepository _userRepository;
        public BorrowRecordService(IBorrowRecordRepository recordRepository, IBookRepository bookRepository, IUserRepository userRepository)
        {
            _recordRepository = recordRepository;
            _bookRepository = bookRepository;
            _userRepository = userRepository;
        }
        public async Task<Guid> BorrowBook(BorrowRecordCreateDto borrowRecordCreateDto)
        {
            var book = await _bookRepository.GetByIdAsync(borrowRecordCreateDto.BookId);
            if(book is null)
            {
                throw new KeyNotFoundException("Book not found");
            }
            var user = await _userRepository.GetByIdAsync(borrowRecordCreateDto.UserId);
            if(user is null)
            {
                throw new KeyNotFoundException("User Not found");
            }
            

            var borrow = new BorrowRecord(user, book);
            await _recordRepository.BorrowBookAsync(borrow);
            await _recordRepository.SaveChangesAsync();

            return borrow.Id;

        }
    }
}
