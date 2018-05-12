using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //Run this first.  Looks for a blank directory URL (at the root of the web server or folder).  Looks for things like default.html, index.html, index.htm.
            //Changes the internal path to that file.  Then the StaticFiles takes that path and knows what to do with it.
            //If we used static files first, it would look at the URL and not find anything to serve, and THEN change the setting for default files, but not do anything with it.
            app.UseDefaultFiles();

            // Add the service of static files as something that the server can do.  By default this looks for files in wwwroot.
            // wwwroot is the "safe place" for files to host.  Treated as the root of the web server for static/flat files.
            app.UseStaticFiles();
        }
    }
}
