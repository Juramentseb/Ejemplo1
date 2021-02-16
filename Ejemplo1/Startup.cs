using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ejemplo1.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Ejemplo1
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(option => option.EnableEndpointRouting = false);
            //services.AddMvcCore();
            services.AddSingleton<IAmigoAlmacen, MockAmigoRepositorio>();
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {

                DeveloperExceptionPageOptions d = new DeveloperExceptionPageOptions
                {
                    SourceCodeLineCount = 2
                };
                app.UseDeveloperExceptionPage(d);

            }
            else if( env.IsProduction() || env.IsStaging())
            {
                app.UseExceptionHandler("/Error");

            }


            app.UseStaticFiles();
            //app.UseMvcWithDefaultRoute();
            app.UseMvc();
            
            
            
            //app.UseMvc(routes =>
            //{ Rutas personalizadas
            //    routes.MapRoute("default", "{controller=Home}/{action=Index}/{id?}");
            //});

            //app.Run( async (context) =>
            //{
            //       await context.Response.WriteAsync("Hola");
            //});


        }
    }
}
