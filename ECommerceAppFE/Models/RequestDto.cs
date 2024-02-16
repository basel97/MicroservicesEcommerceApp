using static ECommerceAppFE.Helper.SD;

namespace ECommerceAppFE.Models
{
    public class RequestDto
    {
        public ApiMethod APIMethod { get; set; } = ApiMethod.GET;
        public string Url { get; set; }
        public object? Data { get; set; }
        //public object? Params { get; set; }
        public string? AccessToken { get; set; }
    }
}
