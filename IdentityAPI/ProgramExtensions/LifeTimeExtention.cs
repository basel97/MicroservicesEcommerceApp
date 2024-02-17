using CouponAuth.Services.Classes;
using IdentityAPI.Data;
using IdentityAPI.DTO.Request;
using IdentityAPI.Models;
using IdentityAPI.Services;
using IdentityAuth.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace IdentityAPI.ProgramExtensions
{
    public static class lifeTimeExtention
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services, IConfiguration config)
        {

            services.AddAutoMapper(typeof(Program));
            services.AddDbContext<AppDbContext>(opts => opts.UseSqlServer(config.GetConnectionString("Default")));
            services.AddIdentity<CustomIdentityUser, IdentityRole>().AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();
            services.Configure<Jwt>(config.GetSection("Jwt"));
            services.AddScoped<IResponseHandler, ResponseHandler>();
            services.AddScoped<IAuth, Auth>();
            services.AddScoped<IJWTGeneration, JWTGeneration>();
            return services;
        }
    }
}
