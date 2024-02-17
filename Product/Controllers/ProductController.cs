using Microsoft.AspNetCore.Mvc;
using ProductAPI.DTOS.Requests;
using ProductAPI.DTOS.Responses;
using ProductAPI.Helpers;
using ProductAPI.Services.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace ProductAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductWork _productWork;
        private readonly IResponseHandler _response;

        public ProductController(IProductWork productWork, IResponseHandler response)
        {
            _productWork = productWork;
            _response = response;
        }
        //[Authorize]
        [HttpGet]
        public async Task<APIResponse<Paginator<ProductRespone>>> GetProducts([FromQuery] PageParams pageParams)
        {
            //throw new Exception();
            var user = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var result = await _productWork.OnGetALLProductsAsync(pageParams);
            return result.Succeeded ? result : result;
        }
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<APIResponse<ProductRespone>> GetProduct(Guid id)
        {

            var result = await _productWork.OnGetProductAsync(id);
            return result.Succeeded ? result : result;
        }
        [HttpPost]
        public async Task<IActionResult> AddProduct([FromForm] AddProductRequest addProductRequest)
        {
            var result = await _productWork.OnAddProductAsync(addProductRequest);
            return result.Succeeded ? Ok(result) : BadRequest(result);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateProduct([FromForm] UpdateProductRequest ProductRequest)
        {
            try
            {
                var result = await _productWork.OnUpdateProductAsync(ProductRequest);
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
            var result = await _productWork.OnDeleteProductAsync(Id);
            return result.Succeeded ? Ok(result) : BadRequest(result);
        }
    }
}
