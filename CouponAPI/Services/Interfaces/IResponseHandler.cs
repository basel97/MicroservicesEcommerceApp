using CouponAPI.DTOS.Responses;

namespace CouponAPI.Services.Interfaces
{
    public interface IResponseHandler
    {
        APIResponse<T> Deleted<T>();
        APIResponse<T> Success<T>(T entity, object Meta = null);
        APIResponse<T> Unauthorized<T>();
        APIResponse<T> BadRequest<T>(string Message = null, string errors = null);
        APIResponse<T> NotFound<T>(string message = null);
        APIResponse<T> Created<T>(T entity, object Meta = null);
    }
}
