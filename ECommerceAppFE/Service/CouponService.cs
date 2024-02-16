using ECommerceAppFE.Helper;
using ECommerceAppFE.Models;
using ECommerceAppFE.Models.Coupon;
using static ECommerceAppFE.Helper.SD;

namespace ECommerceAppFE.Service
{
    public class CouponService : ICouponService
    {
        private readonly IService _baseService;

        public CouponService(IService baseService)
        {
            _baseService = baseService;
        }

        public async Task<ResponseDto> AddCoupon(AddCouponRequest request)
        {
            return await _baseService.SendAsync(new RequestDto { APIMethod = ApiMethod.POST, Data = request, Url = SD.CouponApiUrl + "api/v1/Coupon" });
        }

        public async Task<ResponseDto> DeleteCoupon(Guid Id)
        {
            return await _baseService.SendAsync(new RequestDto { APIMethod = ApiMethod.DELETE, Data = Id, Url = SD.CouponApiUrl + "api/v1/Coupon" });
        }

        public async Task<ResponseDto> GetAllCouponsAsync(PageParams? pageParams = null)
        {
            return await _baseService.SendAsync(new RequestDto { APIMethod = ApiMethod.GET, Url = SD.CouponApiUrl + "api/v1/Coupon" });
        }

        public async Task<ResponseDto> UpdateCoupon(UpdateCouponRequest request)
        {
            return await _baseService.SendAsync(new RequestDto { APIMethod = ApiMethod.PUT, Data = request, Url = SD.CouponApiUrl + "api/v1/Coupon" });
        }
    }
}
