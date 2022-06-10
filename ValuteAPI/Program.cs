using ValuteAPI.BLL.Middleware;
using ValuteAPI.BLL.ValuteProfile;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddAutoMapper(m => m.AddProfile(new ValuteProfile()));



var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseCustomExeptionMiddleware();


app.MapControllers();

app.Run();
