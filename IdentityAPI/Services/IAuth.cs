using IdentityAPI.DTO.Request;
using IdentityAPI.DTO.Response;

namespace IdentityAPI.Services
{
    public interface IAuth
    {
        Task<AuthResponse<string>> OnRegisterAsync(RegisterRequest request);

        Task<AuthResponse<string>> OnLoginAsync(LoginRequest request);

    }
}
