using ProductAPI.DTOS.Requests;
using ProductAPI.DTOS.Responses;
using ProductAPI.Helpers;
using ProductAPI.Models.Product;

namespace ProductAPI.Services.Interfaces
{
    public interface IProductWork
    {
        Task<APIResponse<Paginator<ProductRespone>>> OnGetALLProductsAsync(PageParams pageParams);
        Task<APIResponse<ProductRespone>> OnGetProductAsync(Guid productId);
        Task<APIResponse<Product>> OnAddProductAsync(AddProductRequest addProductRequest);
        Task<APIResponse<Product>> OnDeleteProductAsync(Guid ProductId);
        Task<APIResponse<Product>> OnUpdateProductAsync(UpdateProductRequest ProductRequest);
    }
}
