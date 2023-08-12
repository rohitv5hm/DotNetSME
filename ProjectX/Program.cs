using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProjectX.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.\


builder.Services.AddControllers();

builder.Services.AddTransient<CustomMiddleware1>();
builder.Services.AddTransient<CustomMiddleware2>();
builder.Services.AddTransient<MultitenancyMiddleware>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<CustomMiddleware1>();
app.UseMiddleware<CustomMiddleware2>();
app.UseMiddleware<MultitenancyMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
