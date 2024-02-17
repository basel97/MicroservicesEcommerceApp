using IdentityAPI.Data;
using IdentityAPI.DTO.Response;
using IdentityAPI.ProgramExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddApplicationService(builder.Configuration);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//global model state error handle
builder.Services.Configure<ApiBehaviorOptions>(o =>
{
    o.InvalidModelStateResponseFactory = actionContext =>
    {
        var modelState = actionContext.ModelState.Values;
        var errorList = modelState.SelectMany(m => m.Errors.Select(e => e.ErrorMessage)).ToList();
        var errorBuilder = new StringBuilder();
        foreach (var error in errorList)
            errorBuilder.Append(error);
        return new BadRequestObjectResult(new AuthResponse<List<string>> { StatusCode = HttpStatusCode.BadRequest, Errors = errorBuilder.ToString(), Succeeded = false });
    };
});
//jwt
builder.Services.AddApplicationAuthenticationService(builder.Configuration);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
ApplyPendingMigrations();
app.Run();
void ApplyPendingMigrations()
{
    using (var scope = app.Services.CreateScope())
    {
        var _db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        if (_db.Database.GetPendingMigrations().Count() > 0)
        {
            _db.Database.Migrate();
        }
    }
}
