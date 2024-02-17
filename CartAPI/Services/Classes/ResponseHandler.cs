using CartAPI.DTOS.Responses;
using CartAPI.Helpers;
using CartAPI.Services.Interfaces;

namespace CartAPI.Services.Classes
{
    public class ResponseHandler : IResponseHandler
    {


        public APIResponse<T> Deleted<T>()
        {
            return new APIResponse<T>()
            {
                StatusCode = System.Net.HttpStatusCode.OK,
                Succeeded = true,
                Message = MessageHelper.Deleted,
            };
        }

        public APIResponse<T> Success<T>(T entity, object? Meta = null)
        {
            return new APIResponse<T>()
            {
                Data = entity,
                StatusCode = System.Net.HttpStatusCode.OK,
                Succeeded = true,
                Message = MessageHelper.Success,
                Meta = Meta
            };
        }
        public APIResponse<T> Unauthorized<T>()
        {
            return new APIResponse<T>()
            {
                StatusCode = System.Net.HttpStatusCode.Unauthorized,
                Succeeded = true,
                Message = MessageHelper.UnAuthorized
            };
        }
        public APIResponse<T> BadRequest<T>(string? Message = null, string? errors = null)
        {
            return new APIResponse<T>()
            {
                StatusCode = System.Net.HttpStatusCode.BadRequest,
                Succeeded = false,
                Message = Message == null ? MessageHelper.BadRequest : Message,
                Errors = errors
            };
        }

        public APIResponse<T> NotFound<T>(string? message = null)
        {
            return new APIResponse<T>()
            {
                StatusCode = System.Net.HttpStatusCode.NotFound,
                Succeeded = false,
                Message = message == null ? MessageHelper.NotFound : message
            };
        }
        public APIResponse<T> Created<T>(T entity, object? Meta = null)
        {
            return new APIResponse<T>()
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
