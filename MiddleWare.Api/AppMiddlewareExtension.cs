using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiddleWare.Api
{
    public static class AppMiddlewareExtension
    {
        public static void UseExtension(this IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                await context.Response.WriteAsync("Final Response");
            });
        }

        
    }
}
