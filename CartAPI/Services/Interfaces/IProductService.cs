using CartAPI.DTOS.Responses;

namespace CartAPI.Services.Interfaces
{
    public interface IProductService
    {
        Task<ProductRespone> GetProductAsync(Guid id);
    }
}
