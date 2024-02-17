using IdentityAPI.DTO.Response;

namespace IdentityAuth.Services
{
    public interface IResponseHandler
    {
        AuthResponse<T> Deleted<T>();
        AuthResponse<T> Success<T>(T entity, object Meta = null);
        AuthResponse<T> Unauthorized<T>();
        AuthResponse<T> BadRequest<T>(string Message = null, string errors = null);
        AuthResponse<T> NotFound<T>(string message = null);
        AuthResponse<T> Created<T>(T entity, object Meta = null);
    }
}
