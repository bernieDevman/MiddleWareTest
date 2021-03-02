using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiddleWare.Api
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            
            // this aqui no pasa nada 
            app.Use(async (context,next) =>
            {
                await context.Response.WriteAsync("Response from First middleWare");
                await context.Response.WriteAsync("<br>");

                await context.Response.WriteAsync("Response from second middleWare");
                await next();
            });


            app.UseWhen(context => context.Request.Query.ContainsKey("roler"), a => {
            a.Run(async context => {
                await context.Response.WriteAsync($"<br><H1>Role is {context.Request.Query["role"]} </H1>");
                });
            });


            app.Map("/Telepatia", a => {
                a.Run(async context => { await context.Response.WriteAsync("New Branch Map"); });
            });


            app.UseMiddleware<CustomMiddleware>();

            app.UseExtension();

           




        }
    }

}
