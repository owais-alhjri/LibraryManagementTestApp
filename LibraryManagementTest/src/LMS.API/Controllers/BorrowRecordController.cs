using LMS.Application.DTOs.BorrowRecords;
using LMS.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LMS.API.Controllers
{
    [Route("api/borrow-records")]
    [ApiController]
    public class BorrowRecordController : ControllerBase
    {
        private readonly IBorrowRecordService _borrowRecordService;
        public BorrowRecordController(IBorrowRecordService borrowRecordService)
        {
            _borrowRecordService = borrowRecordService;
        }
        [HttpPost]
        public async Task<ActionResult<Guid>> BorrowBook([FromBody] BorrowRecordCreateDto dto)
        {
            var borrowId = await _borrowRecordService.BorrowBook(dto);
            return CreatedAtAction(nameof(BorrowBook),new { id = borrowId },borrowId);
        }

        [HttpPost("return")]
        public async Task<ActionResult<Guid>> ReturnBook([FromBody] ReturnBookDto dto)
        {
            var returnedId = await _borrowRecordService.ReturnBook(dto);


            return CreatedAtAction(nameof(ReturnBook),new { id = returnedId},returnedId);
        }
    }
}
