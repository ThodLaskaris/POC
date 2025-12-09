using Application02.Application;
using Application02.Domain;
using Application02.Infrastructure;
using Application02.Infrastructure.EFCore;
using Microsoft.EntityFrameworkCore;
using Application02.Application.Query;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApi();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowVite",
        policy =>
        {
            policy.WithOrigins("http://localhost:5173")
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<ISensorDataRepository, SensorResourceRepository>();
builder.Services.AddScoped<PostSensorHandler>();
builder.Services.AddScoped<GetSensorHandler>();

var cs = builder.Configuration.GetConnectionString("DefaultConnection");

var app = builder.Build();

app.MapOpenApi();

app.UseCors("AllowVite");
app.UseAuthorization();
app.MapControllers();
app.Run();