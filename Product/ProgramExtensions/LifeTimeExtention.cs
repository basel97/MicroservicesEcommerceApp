using ProductAPI.Services.Classes;
using ProductAPI.Services.Interfaces;

namespace ProductAPI.ProgramExtensions
{
    public static class lifeTimeExtention
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services, IConfiguration config)
        {

            services.AddAutoMapper(typeof(Program));
            //services.AddScoped(typeof(IReposatory<>), typeof(Reposatory<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IResponseHandler, ResponseHandler>();
            services.AddScoped<IProductWork, ProductWork>();
            return services;
        }
    }
}
