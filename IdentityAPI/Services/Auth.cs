using AutoMapper;
using IdentityAPI.DTO.Request;
using IdentityAPI.DTO.Response;
using IdentityAPI.Helpers;
using IdentityAPI.Models;
using IdentityAuth.Services;
using Microsoft.AspNetCore.Identity;
using System.Text;

namespace IdentityAPI.Services
{
    public class Auth : IAuth
    {
        private readonly UserManager<CustomIdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IMapper _mapper;
        private readonly IResponseHandler _response;
        private readonly IJWTGeneration _jwt;

        public Auth(UserManager<CustomIdentityUser> userManager, RoleManager<IdentityRole> roleManager, IMapper mapper, IResponseHandler response, IJWTGeneration jwt)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _mapper = mapper;
            _response = response;
            _jwt = jwt;
        }
        public async Task<AuthResponse<string>> OnRegisterAsync(RegisterRequest request)
        {
            if (request is null)
                return _response.BadRequest<string>();
            CustomIdentityUser newUser = _mapper.Map<CustomIdentityUser>(request)!;
            var result = await _userManager.CreateAsync(newUser, request.Password);
            if (!result.Succeeded)
            {
                StringBuilder errors = new StringBuilder();
                foreach (var error in result.Errors)
                    errors.Append(error.Description);

                return _response.BadRequest<string>(errors.ToString());
            }

            //createJwt
            var savedUser = await _userManager.FindByNameAsync(newUser.UserName!);
            var jwtToken = _jwt.GenerateToken(savedUser!);
            return _response.Success<string>(jwtToken);

        }
        public async Task<AuthResponse<string>> OnLoginAsync(LoginRequest request)
        {
            var existUser = await _userManager.FindByNameAsync(request.UserName);
            if (existUser == null)
                return _response.NotFound<string>();
            var check = await _userManager.CheckPasswordAsync(existUser, request.Password);
            if (!check)
                return _response.BadRequest<string>(MessageHelper.InvalidPassword);
            //create jwt
            var jwtToken = _jwt.GenerateToken(existUser);
            return _response.Success<string>(jwtToken);
        }

    }
}
