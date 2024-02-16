using ECommerceAppFE.Models;
using ECommerceAppFE.Models.Coupon;

namespace ECommerceAppFE.Service
{
    public interface ICouponService
    {
        Task<ResponseDto> GetAllCouponsAsync(PageParams? pageParams = null);
        Task<ResponseDto> AddCoupon(AddCouponRequest request);
        Task<ResponseDto> UpdateCoupon(UpdateCouponRequest request);
        Task<ResponseDto> DeleteCoupon(Guid Id);


    }
}
