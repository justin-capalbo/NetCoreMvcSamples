﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DutchTreat.Data;
using DutchTreat.Services;
using DutchTreat.Views.Shared;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace DutchTreat
{
    public class Startup
    {
        private readonly IConfiguration _config;
        private readonly IHostingEnvironment _env;

        public Startup(IConfiguration config, IHostingEnvironment env)
        {
            _config = config;
            _env = env;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //Configure identity
            services.AddIdentity<StoreUser, IdentityRole>(cfg =>
                {
                    cfg.User.RequireUniqueEmail = true;
                    cfg.Password.RequireUppercase = false;
                })
                .AddEntityFrameworkStores<DutchContext>();

            //Add what types of authentication we support.
            services.AddAuthentication()
                .AddCookie()
                .AddJwtBearer(cfg =>
                {
                    //Set up token validation parameters
                    cfg.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidIssuer = _config["Tokens:Issuer"],
                        ValidAudience = _config["Tokens:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Tokens:Key"]))
                    };
                });

            //Tell services that we'd like it to use our context.
            services.AddDbContext<DutchContext>(cfg =>
            {
                if (_env.IsDevelopment())
                {
                    cfg.UseSqlite("Data Source=DutchDb");
                }

                if (_env.IsProduction())
                {
                    //Get the connection string from configuration.
                    cfg.UseSqlServer(_config.GetConnectionString("DutchConnectionString"));
                }
            });

            //Provide a workaround for dotnet CLI to handle automapper when doing CLI ops to prevent duplicate initialization of Mapper.
            if (_env.IsDevelopment())
            {
                Mapper.Reset();
            }
            services.AddAutoMapper();

            //Dependency injection for services!
            //  TODO - Support for real mail service
            //Transient - No data, just methods that do things
            //Scoped    - Services that are more expensive to create, kept around for the length of the connection
            //Singleton - Services that are kept for the lifetime of the server being up 
            services.AddTransient<IMailService, NullMailService>()
                    .AddTransient<DutchSeeder>()
                    .AddScoped<IDutchRepository, DutchRepository>();


            //Needed for dependency injection of MVC when we added UseMvc below.
            //Here we set the option for how to handle self referencing entity relationships when serializing json for a response
            services.AddMvc(opt =>
                {
                    if (_env.IsProduction() && _config["DisableSSL"] != "true")
                    {
                        opt.Filters.Add(new RequireHttpsAttribute());
                    }
                })
                .AddJsonOptions(opt => opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
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

            //Turn ON authentication.
            app.UseAuthentication();

            //Listen to requests, and see if we can map them to a Controller, which will map them to a View for us.
            app.UseMvc(cfg =>
            {
                //Routes
                cfg.MapRoute("Default",
                    "{controller}/{action}/{id?}",
                    new { controller = "App", Action = "Index" });
            });

            //Don't seed the DB in production.
            if (env.IsDevelopment())
            {
                //Seed the database
                using (var scope = app.ApplicationServices.CreateScope())
                {
                    var seeder = scope.ServiceProvider.GetService<DutchSeeder>();
                    seeder.Seed().Wait();
                }
            }
        }
    }
}
