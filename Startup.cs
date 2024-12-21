using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using techwork_after_america_return.Services;
using techwork_after_america_return.Data;
using System.Net.Http;
using System.Reflection;

namespace techwork_after_america_return
{
    public class Startup
    {
        private readonly IConfiguration _config;
        public Startup(IConfiguration config)
        {
            _config = config;
        }

        // public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddDbContext<TechworkContext>(cfg =>
            {
                cfg.UseSqlServer(_config.GetConnectionString("TechworkConnectionString"));
            });

            services.AddTransient<IMailService, NullMailService> ();
            services.AddTransient<TechworkSeeder>();
            services.AddScoped<ITechworkRepository, TechworkRepository>();

            //services.AddControllersWithViews();
             services.AddControllersWithViews()
                .AddRazorRuntimeCompilation()
                .AddNewtonsoftJson(cfg => 
                cfg.SerializerSettings
                .ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                );
            services.AddRazorPages();
           
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();
         //   app.UseDefaultFiles();no longer needed

            app.UseRouting();//for individual calls
              
            app.UseAuthorization();
            //for end points
            app.UseEndpoints(cfg =>
            {

            cfg.MapControllerRoute("Default", "{controller}/{Action}/{id?}",
                new { controller = "App", action = "Index" });
                // endpoints.MapRazorPages();
                cfg.MapRazorPages();


            });
        }
    }
}

//tell which database we are using (cfg =>
/*  services.AddDbContext<TechworkContext> (cfg=>
      {
          cfg.UseSqlServer();
  });//this wont work coz we need a constructor so in techwork we need to build override config builder

 later
/*  services.AddDbContext<TechworkContext>(cfg =>
            {
                cfg.UseSqlServer(_config.GetConnectionString("TechworkConnectionString"));
            });

services.AddDbContext<TechworkContext>(cfg =>
            {
                cfg.UseSqlServer(_config.GetConnectionString("TechworkConnectionString"));
            });
            services.AddAutoMapper();

 
 
 */

