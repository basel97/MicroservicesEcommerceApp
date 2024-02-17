using IdentityAPI.DTO.Request;
using IdentityAPI.DTO.Response;
using IdentityAPI.Services;
using IdentityAuth.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace IdentityAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAuth _auth;
        private readonly IResponseHandler _response;

        public AccountController(IAuth auth, IResponseHandler response)
        {
            _auth = auth;
            _response = response;
        }
        [HttpPost]
        [Route("Login")]
        public async Task<AuthResponse<string>> Login([FromForm] LoginRequest request)
        {
            return await _auth.OnLoginAsync(request);
        }
        [HttpPost]
        [Route("Register")]
        public async Task<AuthResponse<string>> Register(RegisterRequest request)
        {
            return await _auth.OnRegisterAsync(request);
        }
        [Authorize]
        [HttpGet]
        public IActionResult test()
        {

            var userId = User.Identity.Name;
            var x = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
            var t = User.FindFirstValue(ClaimTypes.Email);
            return Ok(new { message = "ok" });
        }
    }
}
