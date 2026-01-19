using LMS.Application.DTOs.User;

namespace LMS.Application.Interfaces
{
    public interface IUserService
    {
        public Task<Guid> AddUserAsync(RegisterUserDto registerUserDto);
    }
}
