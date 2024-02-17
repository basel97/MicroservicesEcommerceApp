using AutoMapper;
using CartAPI.DTOS.Requests;
using CartAPI.DTOS.Responses;
using CartAPI.Helpers;
using CartAPI.Models.Product;
using CartAPI.Services.Interfaces;

namespace CartAPI.Services.Classes
{
    public class CartWork : ICartWork
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IResponseHandler _response;
        private readonly IProductService _productService;

        public CartWork(IUnitOfWork unitOfWork, IMapper mapper, IResponseHandler response, IProductService productService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _response = response;
            _productService = productService;
        }
        public async Task<APIResponse<Paginator<UserCartRespone>>> OnGetALLProductsInCartForUserAsync(PageParams pageParams, Guid userId)
        {
            var data = await _unitOfWork.Cart.OnGetAllAsync(c => c.UserId == userId && c.IsActive == true);
            if (data == null)
                return _response.NotFound<Paginator<UserCartRespone>>();
            //GetProduct 

            var mappedData = _mapper.Map<IEnumerable<UserCartRespone>>(data);
            var paginatedData = Paginator<UserCartRespone>.CreatePagination(mappedData!, pageParams.PageNumber, pageParams.PageSize);
            foreach (var product in paginatedData)
            {
                product.Product = await _productService.GetProductAsync(product.ProductId);
            }
            var meta = new PaginationInfoResponse(paginatedData.PageNumber, paginatedData.PageSize, paginatedData.TotalCount, paginatedData.TotalPages);
            return _response.Success(paginatedData, meta);
        }
        public async Task<APIResponse<UserCartRespone>> OnGetProductAsync(Guid productId)
        {
            var data = await _unitOfWork.Cart.GetAsync(c => c.Id == productId && c.IsActive == true);
            if (data is null)
                return _response.NotFound<UserCartRespone>();
            var mappedData = _mapper.Map<UserCartRespone>(data);
            return _response.Success(mappedData!);
        }
        public async Task<APIResponse<Cart>> OnAddProductAsync(AddProductInCartRequest addProductRequest)
        {

            var mappedData = _mapper.Map<Cart>(addProductRequest);
            var data = await _unitOfWork.Cart.AddAsync(mappedData!);
            var added = await _unitOfWork.OnSaveChangesAsync();
            return added > 0 ? _response.Success(data) : _response.BadRequest<Cart>();


        }
        public async Task<APIResponse<Cart>> OnUpdateProductAsync(UpdateProductRequest ProductRequest)
        {

            var existProduct = await _unitOfWork.Cart.GetByIdAsync(c => c.Id == ProductRequest.Id);
            if (existProduct == null)
                return _response.NotFound<Cart>();
            Cart mappedData = _mapper.Map(ProductRequest, existProduct)!;
            //var data = _unitOfWork.Product.Update(mappedData!);
            var updated = await _unitOfWork.OnSaveChangesAsync();
            return updated > 0 ? _response.Success(existProduct) : _response.BadRequest<Cart>();



        }
        public async Task<APIResponse<Cart>> OnDeleteProductAsync(Guid ProductId)
        {

            var existProduct = await _unitOfWork.Cart.GetByIdAsync(c => c.Id == ProductId);
            if (existProduct == null)
                return _response.NotFound<Cart>();
            existProduct.IsActive = false;
            var updated = await _unitOfWork.OnSaveChangesAsync();
            return updated > 0 ? _response.Success(existProduct) : _response.BadRequest<Cart>();



        }
    }
}
