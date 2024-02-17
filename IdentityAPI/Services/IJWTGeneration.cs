using IdentityAPI.Models;

namespace IdentityAPI.Services
{
    public interface IJWTGeneration
    {
        string GenerateToken(CustomIdentityUser user);
    }
}
