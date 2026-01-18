
using LMS.Application.DTOs;

namespace LMS.Application.Interfaces
{
    public interface IUserService
    {
        public Task<Guid> AddUserAsync(RegisterUserDto registerUserDto);
    }
}
