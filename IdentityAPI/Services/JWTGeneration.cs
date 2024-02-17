using IdentityAPI.DTO.Request;
using IdentityAPI.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace IdentityAPI.Services
{
    public class JWTGeneration : IJWTGeneration
    {
        private readonly Jwt _jwt;

        public JWTGeneration(IOptions<Jwt> jwt)
        {
            _jwt = jwt.Value;
        }
        public string GenerateToken(CustomIdentityUser user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwt.JwtKey);
            var userClaims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name,user.UserName!),
                 new Claim(ClaimTypes.Email,user.Email!),
                new Claim(ClaimTypes.NameIdentifier,user.Id!),
            };
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(userClaims),
                Expires = DateTime.Now.AddDays(10),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256),
                Issuer = _jwt.Issuer,
                Audience = _jwt.Audience
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
