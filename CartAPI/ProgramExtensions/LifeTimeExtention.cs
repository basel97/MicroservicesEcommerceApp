using CartAPI.Services.Classes;
using CartAPI.Services.Interfaces;

namespace CartAPI.ProgramExtensions
{
    public static class lifeTimeExtention
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services, IConfiguration config)
        {

            services.AddAutoMapper(typeof(Program));
            //services.AddScoped(typeof(IReposatory<>), typeof(Reposatory<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IResponseHandler, ResponseHandler>();
            services.AddScoped<ICartWork, CartWork>();
            services.AddScoped<IProductService, ProductService>();
            return services;
        }
    }
}
