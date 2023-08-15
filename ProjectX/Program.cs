using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ProjectX.Data;
using ProjectX.Extensions;
using ProjectX.Middlewares;
using Serilog;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.\


builder.Services.AddControllers();

builder.Services.AddTransient<CustomMiddleware1>();
builder.Services.AddTransient<CustomMiddleware2>();
builder.Services.AddTransient<MultitenancyMiddleware>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApplicationServices(builder.Configuration);


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

using var scope = app.Services.CreateAsyncScope();
var services = scope.ServiceProvider;
try
{
    var context = services.GetRequiredService<DataContext>();
    await context.Database.MigrateAsync();
    // Previously seeded with data context now with user manager
}
catch (Exception e)
{
    var logger = services.GetService<ILogger<Program>>();
    logger.LogError(e, "An error occurred during migration");
}

app.Run();
