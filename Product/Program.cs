using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using ProductAPI.Data;
using ProductAPI.DTOS.Responses;
using ProductAPI.ProgramExtensions;
using System.Net;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddApplicationService(builder.Configuration);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//handle modelState Error Response to custom Response
builder.Services.AppApiBehavior(builder.Configuration);
builder.Services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("Default")));
//authorization JWT
builder.Services.AddAppAuthorization(builder.Configuration);
var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.UseAuthorization();
app.UseExceptionHandler(error =>
{
    error.Run(async context =>
    {
        context.Response.StatusCode = StatusCodes.Status500InternalServerError;
        context.Response.ContentType = "application/json";
        var exception = context.Features.Get<IExceptionHandlerFeature>();
        if (exception != null)
        {
            //Log.Error($"Something went Wrong in the {exception.Error}");
            await context.Response.WriteAsync(new APIResponse<string>
            {
                StatusCode = (HttpStatusCode)context.Response.StatusCode,
                Message = exception.Error.Message,
                Errors = exception.Error.ToString(),
                Succeeded = false,
            }.ToString()!);
        }
    });
});
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