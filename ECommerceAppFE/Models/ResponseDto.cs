using System.Net;

namespace ECommerceAppFE.Models
{
    public class ResponseDto
    {
        public HttpStatusCode StatusCode { get; set; }
        public bool Succeeded { get; set; } = true;
        public string? Message { get; set; }
        public object? Meta { get; set; }
        public string? Errors { get; set; }
        public object? Data { get; set; }
    }
}
