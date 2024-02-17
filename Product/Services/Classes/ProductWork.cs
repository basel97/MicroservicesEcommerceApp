using AutoMapper;
using ProductAPI.DTOS.Requests;
using ProductAPI.DTOS.Responses;
using ProductAPI.Helpers;
using ProductAPI.Models.Product;
using ProductAPI.Services.Interfaces;

namespace ProductAPI.Services.Classes
{
    public class ProductWork : IProductWork
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IResponseHandler _response;

        public ProductWork(IUnitOfWork unitOfWork, IMapper mapper, IResponseHandler response)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _response = response;
        }
        public async Task<APIResponse<Paginator<ProductRespone>>> OnGetALLProductsAsync(PageParams pageParams)
        {
            var data = await _unitOfWork.Product.OnGetAllAsync(c => c.IsActive == true);
            var mappedData = _mapper.Map<IEnumerable<ProductRespone>>(data);
            var paginatedData = Paginator<ProductRespone>.CreatePagination(mappedData!, pageParams.PageNumber, pageParams.PageSize);
            var meta = new PaginationInfoResponse(paginatedData.PageNumber, paginatedData.PageSize, paginatedData.TotalCount, paginatedData.TotalPages);
            return _response.Success(paginatedData, meta);
        }
        public async Task<APIResponse<ProductRespone>> OnGetProductAsync(Guid productId)
        {
            var data = await _unitOfWork.Product.GetAsync(c => c.Id == productId && c.IsActive == true);
            if (data is null)
                return _response.NotFound<ProductRespone>();
            var mappedData = _mapper.Map<ProductRespone>(data);
            return _response.Success(mappedData!);
        }
        public async Task<APIResponse<Product>> OnAddProductAsync(AddProductRequest addProductRequest)
        {

            var mappedData = _mapper.Map<Product>(addProductRequest);
            var data = await _unitOfWork.Product.AddAsync(mappedData!);
            var added = await _unitOfWork.OnSaveChangesAsync();
            return added > 0 ? _response.Success(data) : _response.BadRequest<Product>();


        }
        public async Task<APIResponse<Product>> OnUpdateProductAsync(UpdateProductRequest ProductRequest)
        {

            var existProduct = await _unitOfWork.Product.GetByIdAsync(c => c.Id == ProductRequest.Id);
            if (existProduct == null)
                return _response.NotFound<Product>();
            Product mappedData = _mapper.Map(ProductRequest, existProduct)!;
            //var data = _unitOfWork.Product.Update(mappedData!);
            var updated = await _unitOfWork.OnSaveChangesAsync();
            return updated > 0 ? _response.Success(existProduct) : _response.BadRequest<Product>();



        }
        public async Task<APIResponse<Product>> OnDeleteProductAsync(Guid ProductId)
        {

            var existProduct = await _unitOfWork.Product.GetByIdAsync(c => c.Id == ProductId);
            if (existProduct == null)
                return _response.NotFound<Product>();
            existProduct.IsActive = false;
            var updated = await _unitOfWork.OnSaveChangesAsync();
            return updated > 0 ? _response.Success(existProduct) : _response.BadRequest<Product>();



        }
    }
}
