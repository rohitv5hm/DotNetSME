using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace ProjectX.Middlewares
{
    public class MultitenancyMiddleware:IMiddleware
    {



        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            /*
                1. Extract customer Id from the request/JWT token claim.

                2. Resolve the database name based on the customer info.

                3. Build the connection string to the specific database.

                4. Save the connection string to a scoped object to be used
                   by the data access layer later.
            */

            await next(context);
        }

 
    }
}
