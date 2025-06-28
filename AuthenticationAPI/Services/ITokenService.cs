using Microsoft.AspNetCore.Identity;

namespace AuthenticationAPI.Services
{
    public interface ITokenService
    {
        string CreateToken(IdentityUser user, List<string> roles);
    }
}