using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace ProjectX.Middlewares
{
    public class CustomMiddleware1 : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            Console.WriteLine("Middleware 1/1");
            await next(context);
            Console.WriteLine("Middleware 1/2");

        }
    }
}
