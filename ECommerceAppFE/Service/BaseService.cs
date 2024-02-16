using ECommerceAppFE.Models;
using Newtonsoft.Json;
using System.Net;
using System.Text;
using static ECommerceAppFE.Helper.SD;

namespace ECommerceAppFE.Service
{
    public class BaseService : IService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BaseService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<ResponseDto> SendAsync(RequestDto requestDto)
        {
            try
            {
                HttpClient client = _httpClientFactory.CreateClient("MicroApp");
                HttpRequestMessage request = new();
                request.Headers.Add("accept", "application/json");

                //bearer

                request.RequestUri = new Uri(requestDto.Url);
                if (requestDto.Data != null)
                {
                    request.Content = new StringContent(JsonConvert.SerializeObject(requestDto.Data), Encoding.UTF8, "application/json");
                }
                HttpResponseMessage apiResponse;
                switch (requestDto.APIMethod)
                {
                    case ApiMethod.POST:
                        request.Method = HttpMethod.Post;
                        break;
                    case ApiMethod.PUT:
                        request.Method = HttpMethod.Put;
                        break;
                    case ApiMethod.DELETE:
                        request.Method = HttpMethod.Delete;
                        break;
                    default:
                        request.Method = HttpMethod.Get;
                        break;
                }
                apiResponse = await client.SendAsync(request);
                switch (apiResponse.StatusCode)
                {
                    case System.Net.HttpStatusCode.BadRequest:
                        return new ResponseDto { StatusCode = System.Net.HttpStatusCode.BadRequest, Succeeded = false, Message = "Bad Request" };

                    case System.Net.HttpStatusCode.NotFound:
                        return new ResponseDto { StatusCode = System.Net.HttpStatusCode.NotFound, Succeeded = false, Message = "Not Found" };

                    case System.Net.HttpStatusCode.Unauthorized:
                        return new ResponseDto { StatusCode = System.Net.HttpStatusCode.Unauthorized, Succeeded = false, Message = "Unauthorized" };

                    case System.Net.HttpStatusCode.InternalServerError:
                        return new ResponseDto { StatusCode = System.Net.HttpStatusCode.InternalServerError, Succeeded = false, Message = "Internal Server Error" };

                    default:
                        var apiContent = await apiResponse.Content.ReadAsStringAsync();
                        ResponseDto apiResponseDto = JsonConvert.DeserializeObject<ResponseDto>(apiContent)!;
                        return apiResponseDto;

                }
            }
            catch (Exception ex)
            {
                return new ResponseDto { StatusCode = HttpStatusCode.InternalServerError, Succeeded = false, Message = ex.Message };
            }
            //return new ResponseDto();
        }
    }
}
