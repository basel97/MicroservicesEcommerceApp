using CartAPI.DTOS.Requests;
using CartAPI.DTOS.Responses;
using CartAPI.Helpers;
using CartAPI.Models.Product;

namespace CartAPI.Services.Interfaces
{
    public interface ICartWork
    {
        Task<APIResponse<Paginator<UserCartRespone>>> OnGetALLProductsInCartForUserAsync(PageParams pageParams, Guid userId);
        Task<APIResponse<UserCartRespone>> OnGetProductAsync(Guid productId);
        Task<APIResponse<Cart>> OnAddProductAsync(AddProductInCartRequest addProductRequest);
        Task<APIResponse<Cart>> OnDeleteProductAsync(Guid ProductId);
        Task<APIResponse<Cart>> OnUpdateProductAsync(UpdateProductRequest ProductRequest);
    }
}
