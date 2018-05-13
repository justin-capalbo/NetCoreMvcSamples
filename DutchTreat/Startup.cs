using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DutchTreat.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace DutchTreat
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //Dependency injection for services!
            //Transient - No data, just methods that do things
            //Scoped    - Services that are more expensive to create, kept around for the length of the connection
            //Singleton - Services that are kept for the lifetime of the server being up 
            services.AddTransient<IMailService, NullMailService>();

            //TODO - Support for real mail service

            //Needed for dependency injection of MVC when we added UseMvc below.
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //Show developer page when exception is thrown for dev use only
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/error");
            }

            // Add the service of static files as something that the server can do.  By default this looks for files in wwwroot.
            // wwwroot is the "safe place" for files to host.  Treated as the root of the web server for static/flat files.
            app.UseStaticFiles();

            //Listen to requests, and see if we can map them to a Controller, which will map them to a View for us.
            app.UseMvc(cfg =>
            {
                //Routes
                cfg.MapRoute("Default", 
                    "{controller}/{action}/{id?}", 
                    new {controller = "App", Action = "Index"});
            });
        }
    }
}
