using LMS.Models.Auth;

namespace LMS.Services.Interfaces
{
    public interface IJwtService
    {
        string GenerateJwtToken(AppUser user);
    }
}
