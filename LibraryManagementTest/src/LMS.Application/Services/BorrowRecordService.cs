using LMS.Application.Common.Exceptions;
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
            if (book is null)
            {
                throw new NotFoundException("Book", borrowRecordCreateDto.BookId);
            }
            var user = await _userRepository.GetByIdAsync(borrowRecordCreateDto.UserId);
            if (user is null)
            {
                throw new NotFoundException("User", borrowRecordCreateDto.UserId);
            }

            var borrow = new BorrowRecord(user, book);
            book.Borrow();
            await _recordRepository.BorrowBookAsync(borrow);
            await _recordRepository.SaveChangesAsync();

            return borrow.Id;
        }

        public async Task<Guid> ReturnBook(ReturnBookDto dto)
        {
            var book = await _bookRepository.GetByIdAsync(dto.BookId) ?? throw new NotFoundException("Book", dto.BookId);

            var user = await _userRepository.GetByIdAsync(dto.UserId) ?? throw new NotFoundException("User", dto.UserId);

            var borrowRecord = await _recordRepository.GetActiveBorrowAsync(dto.UserId, dto.BookId);
            if (borrowRecord is null)
            {
                throw new NotFoundException("BorrowRecord", $"UserId={dto.UserId} ,BookId={dto.BookId}");
            }

            borrowRecord.Return(book);
            await _recordRepository.SaveChangesAsync();

            return borrowRecord.Id;
        }
    }
}
