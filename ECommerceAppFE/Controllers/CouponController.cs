using ECommerceAppFE.Models.Coupon;
using ECommerceAppFE.Service;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ECommerceAppFE.Controllers
{
    public class CouponController : Controller
    {
        private readonly ICouponService _couponService;

        public CouponController(ICouponService couponService)
        {
            _couponService = couponService;
        }
        public async Task<IActionResult> Index()
        {
            List<CouponsRespone>? coupons = new();
            var result = await _couponService.GetAllCouponsAsync();
            if (result is not null && result.Succeeded)
                coupons = JsonConvert.DeserializeObject<List<CouponsRespone>>(Convert.ToString(result.Data)!);
            return View(coupons);
        }
    }
}
