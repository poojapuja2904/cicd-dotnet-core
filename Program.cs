//using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using techwork_after_america_return.Data;
using Microsoft.AspNetCore.Hosting;

namespace techwork_after_america_return
{
    public class Program
    {
        public static void Main(string[] args)
        {
             var host = CreateHostBuilder(args).Build();
             if (args.Length == 1 && args[0].ToLower() == "/seed")
             {
                 RunSeeding(host);
                return;
            }
             else
             {
                 host.Run();
              //  CreateHostBuilder(args).Build().Run();

            }
           // CreateHostBuilder(args).Build().Run(); //system
            //dotnet run /seed
        }
        
        private static void RunSeeding(IHost host)
        {
           var scopefactory = host.Services.GetService<IServiceScopeFactory>();

            using var scope = scopefactory.CreateScope();
            {
                var seeder = scope.ServiceProvider.GetService<TechworkSeeder>();
               seeder.Seed();
           }
            //throw new notimplementedexception();
        }

      

     

        public static IHostBuilder CreateHostBuilder(string[] args) =>
             Host.CreateDefaultBuilder(args)
             .ConfigureAppConfiguration(SetupConfiguration)
                 .ConfigureWebHostDefaults(webBuilder =>
                 {
                     webBuilder.UseStartup<Startup>();
                 });

      

        private static void SetupConfiguration( HostBuilderContext ctx, IConfigurationBuilder builder)
        {
            builder.Sources.Clear();
               builder.AddJsonFile("config.json")
                .AddEnvironmentVariables();//root directory
        }
    }//to have changing method configuration 
}

/* public static IWebHost BuildWebHost(string[] args) =>
          WebHost.CreateDefaultBuilder(args).
          ConfigureAppConfiguration(AddConfiguration).
          UseStartup<Startup>().Build(); written on 22-9

starting written code for configuration

 private static void AddConfiguration( HostBuilderContext ctx, IConfigurationBuilder builder)
        {
            builder.Sources.Clear();
            builder.SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("config.json")
                .AddEnvironmentVariables();//root directory

        }

 ----webhost seeding..since ihost is their i removed this
   /*private static void RunSeeding(IWebHost host)
        {//it creates scope to entire
            var scopeFactory = host.Services.GetService<IServiceScopeFactory>();

            using (var scope = scopeFactory.CreateScope())
            {
                var seeder = scope.ServiceProvider.GetService<TechworkSeeder>();
                seeder.Seed();
            }
          
           // throw new NotImplementedException();
        }


*/

