using LMS.Application.DTOs.User;
using LMS.Application.Interfaces;
using LMS.Domain.Auth;
using LMS.Domain.Enums;

namespace LMS.Application.Services
{
    public class AuthService
    {
        private readonly ITokenService _tokenService;

        public AuthService(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        public string GenerateAccessToken(AuthenticatedUserDto user)
        {
            var jwtClaims = new JwtUserClaims
            {
                UserId = user.Id,
                Email = user.Email,
                Role = Roles.MEMBER
            };
            return _tokenService.GenerateToken(jwtClaims);
        }

    }
}
