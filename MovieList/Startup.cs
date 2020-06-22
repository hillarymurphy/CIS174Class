using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using MovieList.Models;

namespace MovieList
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            //enabling dependency injection by using "MovieContext" instead of hard coding string here
            services.AddDbContext<MovieContext>(options => options.UseSqlServer(Configuration.GetConnectionString("MovieContext")));
            services.AddDbContext<MovieList.Areas.ContactList.Models.ContactContext>(options => options.UseSqlServer(Configuration.GetConnectionString("ContactContext")));
            services.AddDbContext<StudentContext>(options => options.UseSqlServer(Configuration.GetConnectionString("StudentContext")));
            // make urls lowercase and end with a trailing slash
            services.AddRouting(options => { options.LowercaseUrls = true; options.AppendTrailingSlash = true; });
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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();

            app.UseAuthorization();

            // Updated to have optional section option (slug)
            app.UseEndpoints(endpoints =>
            {
                // Admin Area Routing
                endpoints.MapAreaControllerRoute(
                    name: "admin",
                    areaName: "Admin",
                    pattern: "Admin/{controller=Home}/{action=Index}/{id?}");

                // Contact List Area Routing
                endpoints.MapAreaControllerRoute(
                    name: "contactlist",
                    areaName: "ContactList",
                    pattern: "ContactList/{controller=Home}/{action=Index}/{id?}/{slug?}");
                
                // Future Value Area Routing
                endpoints.MapAreaControllerRoute(
                    name: "futurevalue",
                    areaName: "FutureValue",
                    pattern: "FutureValue/{controller=Home}/{action=Index}/{id?}/{slug?}");

                //endpoints.MapControllerRoute(
                //    name: "custom",
                //    pattern: "[controller]/[action]/{cat}/{page}");
                
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}/{slug?}");
            });
        }
    }
}
