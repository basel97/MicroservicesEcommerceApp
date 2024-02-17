using CartAPI.DTOS.Requests;
using CartAPI.DTOS.Responses;
using CartAPI.Helpers;
using CartAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace CartAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartWork _couponWork;
        private readonly IResponseHandler _response;

        public CartController(ICartWork couponWork, IResponseHandler response)
        {
            _couponWork = couponWork;
            _response = response;
        }
        //[Authorize]
        [HttpGet]
        public async Task<APIResponse<Paginator<UserCartRespone>>> GetProducts([FromQuery] PageParams pageParam, Guid userId)
        {
            //throw new Exception();
            var user = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var result = await _couponWork.OnGetALLProductsInCartForUserAsync(pageParam, userId);
            return result.Succeeded ? result : result;
        }
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<APIResponse<UserCartRespone>> GetProduct(Guid id)
        {

            var result = await _couponWork.OnGetProductAsync(id);
            return result.Succeeded ? result : result;
        }
        [HttpPost]
        public async Task<IActionResult> AddProduct([FromForm] AddProductInCartRequest addProductRequest)
        {
            var result = await _couponWork.OnAddProductAsync(addProductRequest);
            return result.Succeeded ? Ok(result) : BadRequest(result);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateProduct([FromForm] UpdateProductRequest ProductRequest)
        {
            try
            {
                var result = await _couponWork.OnUpdateProductAsync(ProductRequest);
                return result.Succeeded ? Ok(result) : BadRequest(result);
            }
            catch (Exception ex)
            {
                return BadRequest(_response.BadRequest<Exception>(ex.Message));
            }

        }
        [HttpDelete]
        public async Task<IActionResult> DeleteProduct([FromForm][Required] Guid Id)
        {
            var result = await _couponWork.OnDeleteProductAsync(Id);
            return result.Succeeded ? Ok(result) : BadRequest(result);
        }
    }
}
