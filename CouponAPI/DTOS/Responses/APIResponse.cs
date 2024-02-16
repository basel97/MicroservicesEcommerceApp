using System.Net;

namespace CouponAPI.DTOS.Responses
{
    public class APIResponse<T>
    {
        public HttpStatusCode StatusCode { get; set; }
        public object? Meta { get; set; }
        public bool Succeeded { get; set; }
        public string? Message { get; set; }
        public string? Errors { get; set; }
        public T? Data { get; set; }
    }
}
