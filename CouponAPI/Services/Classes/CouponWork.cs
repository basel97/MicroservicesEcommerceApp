using AutoMapper;
using CouponAPI.DTOS.Requests;
using CouponAPI.DTOS.Responses;
using CouponAPI.Helpers;
using CouponAPI.Models.Coupon;
using CouponAPI.Services.Interfaces;

namespace CouponAPI.Services.Classes
{
    public class CouponWork : ICouponWork
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IResponseHandler _response;

        public CouponWork(IUnitOfWork unitOfWork, IMapper mapper, IResponseHandler response)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _response = response;
        }
        public async Task<APIResponse<Paginator<CouponsRespone>>> OnGetALLCouponsAsync(PageParams pageParams)
        {
            var data = await _unitOfWork.Coupon.OnGetAllAsync(c => c.IsActive == true);
            var mappedData = _mapper.Map<IEnumerable<CouponsRespone>>(data);
            var paginatedData = Paginator<CouponsRespone>.CreatePagination(mappedData!, pageParams.PageNumber, pageParams.PageSize);
            var meta = new PaginationInfoResponse(paginatedData.PageNumber, paginatedData.PageSize, paginatedData.TotalCount, paginatedData.TotalPages);
            return _response.Success(paginatedData, meta);
        }
        public async Task<APIResponse<Coupon>> OnAddCouponAsync(AddCouponRequest addCouponRequest)
        {

            var mappedData = _mapper.Map<Coupon>(addCouponRequest);
            var data = await _unitOfWork.Coupon.AddAsync(mappedData!);
            var added = await _unitOfWork.OnSaveChangesAsync();
            return added > 0 ? _response.Success(data) : _response.BadRequest<Coupon>();


        }
        public async Task<APIResponse<Coupon>> OnUpdateCouponAsync(UpdateCouponRequest CouponRequest)
        {

            var existCoupon = await _unitOfWork.Coupon.GetByIdAsync(c => c.Id == CouponRequest.Id);
            if (existCoupon == null)
                return _response.NotFound<Coupon>();
            Coupon mappedData = _mapper.Map(CouponRequest, existCoupon)!;
            //var data = _unitOfWork.Coupon.Update(mappedData!);
            var updated = await _unitOfWork.OnSaveChangesAsync();
            return updated > 0 ? _response.Success(existCoupon) : _response.BadRequest<Coupon>();



        }
        public async Task<APIResponse<Coupon>> OnDeleteCouponAsync(Guid CouponId)
        {

            var existCoupon = await _unitOfWork.Coupon.GetByIdAsync(c => c.Id == CouponId);
            if (existCoupon == null)
                return _response.NotFound<Coupon>();
            existCoupon.IsActive = false;
            var updated = await _unitOfWork.OnSaveChangesAsync();
            return updated > 0 ? _response.Success(existCoupon) : _response.BadRequest<Coupon>();



        }
    }
}
