using CouponAPI.DTOS.Requests;
using CouponAPI.DTOS.Responses;
using CouponAPI.Helpers;
using CouponAPI.Models.Coupon;

namespace CouponAPI.Services.Interfaces
{
    public interface ICouponWork
    {
        Task<APIResponse<Paginator<CouponsRespone>>> OnGetALLCouponsAsync(PageParams pageParams);
        Task<APIResponse<Coupon>> OnAddCouponAsync(AddCouponRequest addCouponRequest);
        Task<APIResponse<Coupon>> OnDeleteCouponAsync(Guid CouponId);
        Task<APIResponse<Coupon>> OnUpdateCouponAsync(UpdateCouponRequest CouponRequest);
    }
}
