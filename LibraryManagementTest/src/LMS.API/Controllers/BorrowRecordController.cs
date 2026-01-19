using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LMS.API.Controllers
{
    [Route("api/borrow-records")]
    [ApiController]
    public class BorrowRecordController : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult> BorrowBook()
        {

            return Ok();
        }
    }
}
