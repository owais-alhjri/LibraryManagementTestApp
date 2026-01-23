using LMS.Application.DTOs.BorrowRecords;
using LMS.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LMS.API.Controllers
{
    [Route("api/borrow-records")]
    [ApiController]
    public class BorrowRecordController(IBorrowRecordService borrowRecordService) : ControllerBase
    {
        private readonly IBorrowRecordService _borrowRecordService = borrowRecordService;

        [HttpGet("{id:guid}")]
        public async Task<ActionResult> FetchBorrowedBook([FromRoute] Guid id)
        {
            var borooed = await _borrowRecordService.GetBorrowedaRecordById(id);

            return Ok(new BorrowRecordResponseDto
            {
                Message = "Borrowed Info",
                Id = id,
                UserId = borooed.UserId,
                BookId = borooed.BookId,
                BorrowedDate = borooed.BorrowedDate

            });
        }


        [HttpPost]
        public async Task<ActionResult<Guid>> BorrowBook([FromBody] BorrowRecordCreateDto dto)
        {
            var borrowId = await _borrowRecordService.BorrowBook(dto);
            var borrowedInfo = new BorrowRecordResponseDto
            {
                Id = borrowId,
                UserId = dto.UserId,
                BookId = dto.BookId,
                Message = "You have borrowed successfully",
                BorrowedDate = DateTime.UtcNow

            };
            return CreatedAtAction(nameof(FetchBorrowedBook), new { id = borrowId }, borrowedInfo);
        }

        [HttpPost("return")]
        public async Task<ActionResult<ReturnBookResponseDto>> ReturnBook([FromBody] ReturnBookDto dto)
        {
            var result = await _borrowRecordService.ReturnBook(dto);
            return Ok(new ReturnBookResponseDto
            {
                Id = result.Id,
                ReturnedDate = result.ReturnedDate,
                Message = "Book returned successfully",
            });
        }
    }
}
