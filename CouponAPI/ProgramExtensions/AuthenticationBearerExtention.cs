using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace CouponAPI.ProgramExtensions
{
    public static class AuthenticationBearerExtention
    {
        public static IServiceCollection AddAppAuthorization(this IServiceCollection services, IConfiguration config)
        {
            services.AddAuthentication(auth =>
            {
                auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(b =>
            {
                b.RequireHttpsMetadata = false;
                b.SaveToken = true;
                b.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey
                    (Encoding.ASCII.GetBytes(config.GetSection("Jwt:JwtKey").Value!)),
                    ValidateAudience = true,
                    ValidateIssuer = true,
                    ValidIssuer = config.GetSection("Jwt:Issuer").Value!,
                    ValidAudience = config.GetSection("Jwt:Audience").Value!,
                    //ClockSkew=TimeSpan.Zero (refresh token replacement)
                };
            });
            services.AddAuthorization();
            return services;
        }
    }
}
