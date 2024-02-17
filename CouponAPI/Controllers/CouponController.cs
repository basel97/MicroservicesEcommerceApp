using CouponAPI.DTOS.Requests;
using CouponAPI.DTOS.Responses;
using CouponAPI.Helpers;
using CouponAPI.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace CouponAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CouponController : ControllerBase
    {
        private readonly ICouponWork _couponWork;
        private readonly IResponseHandler _response;

        public CouponController(ICouponWork couponWork, IResponseHandler response)
        {
            _couponWork = couponWork;
            _response = response;
        }
        [Authorize]
        [HttpGet]
        public async Task<APIResponse<Paginator<CouponsRespone>>> GetCoupons([FromQuery] PageParams pageParams)
        {
            var user = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var result = await _couponWork.OnGetALLCouponsAsync(pageParams);
            return result.Succeeded ? result : result;
        }
        [HttpPost]
        public async Task<IActionResult> AddCoupon([FromForm] AddCouponRequest addCouponRequest)
        {
            var result = await _couponWork.OnAddCouponAsync(addCouponRequest);
            return result.Succeeded ? Ok(result) : BadRequest(result);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCoupon([FromForm] UpdateCouponRequest CouponRequest)
        {
            try
            {
                var result = await _couponWork.OnUpdateCouponAsync(CouponRequest);
                return result.Succeeded ? Ok(result) : BadRequest(result);
            }
            catch (Exception ex)
            {
                return BadRequest(_response.BadRequest<Exception>(ex.Message));
            }

        }
        [HttpDelete]
        public async Task<IActionResult> DeleteCoupon([FromForm][Required] Guid Id)
        {
            var result = await _couponWork.OnDeleteCouponAsync(Id);
            return result.Succeeded ? Ok(result) : BadRequest(result);
        }
    }
}
