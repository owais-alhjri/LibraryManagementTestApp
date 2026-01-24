using LMS.Domain.Enums;

namespace LMS.Domain.Auth
{
    public class JwtUserClaims
    {
        public string UserId { get; set; } = null!;
        public string Email { get; set; } = null!;
        public Roles Role { get; set; }
    }
}
