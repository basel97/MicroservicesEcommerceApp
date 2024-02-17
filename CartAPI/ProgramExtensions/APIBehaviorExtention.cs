using Microsoft.AspNetCore.Mvc;
using CartAPI.DTOS.Responses;
using System.Net;
using System.Text;

namespace CartAPI.ProgramExtensions
{
    public static class APIBehaviorExtention
    {
        public static IServiceCollection AppApiBehavior(this IServiceCollection services, IConfiguration config)
        {
            services.Configure<ApiBehaviorOptions>(o =>
            {
                o.InvalidModelStateResponseFactory = actionContext =>
                {
                    var modelState = actionContext.ModelState.Values;
                    var errorList = modelState.SelectMany(m => m.Errors.Select(e => e.ErrorMessage)).ToList();
                    var errorBuilder = new StringBuilder();
                    foreach (var error in errorList)
                        errorBuilder.Append(error);
                    return new BadRequestObjectResult(new APIResponse<List<string>> { StatusCode = HttpStatusCode.BadRequest, Errors = errorBuilder.ToString(), Succeeded = false });
                };
            });
            return services;
        }
    }
}
