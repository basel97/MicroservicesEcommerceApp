using CouponAPI.Services.Classes;
using CouponAPI.Services.Interfaces;

namespace CouponAPI.ProgramExtensions
{
    public static class lifeTimeExtention
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services, IConfiguration config)
        {

            services.AddAutoMapper(typeof(Program));
            //services.AddScoped(typeof(IReposatory<>), typeof(Reposatory<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IResponseHandler, ResponseHandler>();
            services.AddScoped<ICouponWork, CouponWork>();
            return services;
        }
    }
}
