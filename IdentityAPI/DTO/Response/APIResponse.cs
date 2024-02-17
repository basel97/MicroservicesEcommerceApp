using System.Net;

namespace IdentityAPI.DTO.Response
{
    public class AuthResponse<T>
    {
        public HttpStatusCode StatusCode { get; set; }
        public object? Meta { get; set; }
        public bool Succeeded { get; set; }
        public string? Message { get; set; }
        public string? Errors { get; set; }
        public T? Data { get; set; }
    }
}
