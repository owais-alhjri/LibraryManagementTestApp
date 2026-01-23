using LMS.Application.DTOs.User;
using LMS.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<ActionResult> RegisterUser([FromBody] RegisterUserDto registerUserDto)
        {
            var user = await _userService.AddUserAsync(registerUserDto);

            return Ok(new ResponseUserDto
            {
                Id =user.Id,
                Name = user.Name,
                Email = user.Email,
                Message = "User is registered successfully"
            });
        }


    }
}
