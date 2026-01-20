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

        [HttpPost]
        public async Task<ActionResult<Guid>> BorrowBook([FromBody] BorrowRecordCreateDto dto)
        {
            var borrowId = await _borrowRecordService.BorrowBook(dto);
            return Ok(borrowId);
        }

        [HttpPost("return")]
        public async Task<ActionResult<Guid>> ReturnBook([FromBody] ReturnBookDto dto)
        {
            var id = await _borrowRecordService.ReturnBook(dto);
            return Ok(id);
        }
    }
}
