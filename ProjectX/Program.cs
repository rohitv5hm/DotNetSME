using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ProjectX.Middlewares;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.\


builder.Services.AddControllers();

builder.Services.AddTransient<CustomMiddleware1>();
builder.Services.AddTransient<CustomMiddleware2>();
builder.Services.AddTransient<MultitenancyMiddleware>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Serilog logger
builder.Host.UseSerilog((context, configuration) => { 
    configuration.ReadFrom.Configuration(context.Configuration);
});



builder.Services.AddLogging(builder =>
{
    builder.AddConsole();  // Add console logger provider
    builder.AddDebug();    // Add debug logger provider
});

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

app.UseSerilogRequestLogging();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
