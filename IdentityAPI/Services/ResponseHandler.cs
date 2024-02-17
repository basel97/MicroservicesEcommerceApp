using IdentityAPI.DTO.Response;
using IdentityAPI.Helpers;
using IdentityAuth.Services;

namespace CouponAuth.Services.Classes
{
    public class ResponseHandler : IResponseHandler
    {
        public AuthResponse<T> Deleted<T>()
        {
            return new AuthResponse<T>()
            {
                StatusCode = System.Net.HttpStatusCode.OK,
                Succeeded = true,
                Message = MessageHelper.Deleted,
            };
        }
        public AuthResponse<T> Success<T>(T entity, object? Meta = null)
        {
            return new AuthResponse<T>()
            {
                Data = entity,
                StatusCode = System.Net.HttpStatusCode.OK,
                Succeeded = true,
                Message = MessageHelper.Success,
                Meta = Meta
            };
        }
        public AuthResponse<T> Unauthorized<T>()
        {
            return new AuthResponse<T>()
            {
                StatusCode = System.Net.HttpStatusCode.Unauthorized,
                Succeeded = true,
                Message = MessageHelper.UnAuthorized
            };
        }
        public AuthResponse<T> BadRequest<T>(string? Message = null, string? errors = null)
        {
            return new AuthResponse<T>()
            {
                StatusCode = System.Net.HttpStatusCode.BadRequest,
                Succeeded = false,
                Message = Message == null ? MessageHelper.BadRequest : Message,
                Errors = errors
            };
        }
        public AuthResponse<T> NotFound<T>(string? message = null)
        {
            return new AuthResponse<T>()
            {
                StatusCode = System.Net.HttpStatusCode.NotFound,
                Succeeded = false,
                Message = message == null ? MessageHelper.NotFound : message
            };
        }
        public AuthResponse<T> Created<T>(T entity, object? Meta = null)
        {
            return new AuthResponse<T>()
            {
                Data = entity,
                StatusCode = System.Net.HttpStatusCode.Created,
                Succeeded = true,
                Message = MessageHelper.Created,
                Meta = Meta
            };
        }
    }
}
