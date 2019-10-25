using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Blog.MVC.CORE
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            //asp.net core automatically injects its internal configuration to this interface.
            //Configuration can be from Environment variables in project properties or from appsettings.json or env specific appsettings json file.
            Configuration = configuration;
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
             
            if (Configuration.GetValue<bool>("Custom_ExceptionPage"))
            {
                app.UseExceptionHandler("/Error.html");
            }

            //Shows custom dev diagonostics page only in dev env
            //if (env.IsDevelopment())
            //Reads config values from appsettings.Development.json
            if(Configuration.GetValue<bool>("ToggleValues:ShowErrorDashboard"))
            {
                app.UseDeveloperExceptionPage();
            }

            app.Use(async (context,next) =>
            {
                if (context.Request.Path.Value.Contains("invalid"))
                {
                    throw new Exception("Error");
                }
                //await context.Response.WriteAsync("Hello jjjjj!");
                await next();
            });

            app.UseMvc((routes) => {
                routes.MapRoute("Blog", "{year:int}/{month:range(1,12)}/{title}", new { controller = "blog", action = "Post" });
                routes.MapRoute("Default", "{controller=Home}/{action=Index}/{id?}");
            });

          //  app.UseMvcWithDefaultRoute();

            app.UseFileServer();
            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("hello shot!");
            //});
        }
    }
}
