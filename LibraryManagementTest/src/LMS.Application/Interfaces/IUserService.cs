using LMS.Application.DTOs.User;
using LMS.Domain.Entities;

namespace LMS.Application.Interfaces
{
    public interface IUserService
    {
        public Task<User> AddUserAsync(RegisterUserDto registerUserDto);
    }
}
