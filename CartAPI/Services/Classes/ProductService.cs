using CartAPI.DTOS.Responses;
using CartAPI.Services.Interfaces;
using Newtonsoft.Json;

namespace CartAPI.Services.Classes
{
    public class ProductService : IProductService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ProductService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<ProductRespone> GetProductAsync(Guid id)
        {
            var client = _httpClientFactory.CreateClient("Product");
            var request = await client.GetAsync($"{id}");
            var apiContent = await request.Content.ReadAsStringAsync();
            var response = JsonConvert.DeserializeObject<APIResponse<ProductRespone>>(apiContent);
            if (response!.Succeeded)
                return response.Data!;
            return new ProductRespone();

        }
    }
}
