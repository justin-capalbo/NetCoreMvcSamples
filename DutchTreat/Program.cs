using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace DutchTreat
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration(SetupConfiguration) //Get our hands on configuration setup and don't take the default
                .UseStartup<Startup>()
                .Build();

        private static void SetupConfiguration(WebHostBuilderContext ctx, IConfigurationBuilder builder)
        {
            //Clear default config sources in preparation for adding our own
            builder.Sources.Clear();

            builder.AddJsonFile("config.json", false, true) //Optional, reload on change
                   .AddEnvironmentVariables(); 

            //Could chain many additional different types of config sources together here.
            //Conflicts are handled by the order of how we chain the calls.  Later calls are more trustworthy.
        }
    }
}
