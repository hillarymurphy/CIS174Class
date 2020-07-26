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
using Microsoft.AspNetCore.Identity;
using MovieList.Areas.Agile.Models;

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
            // adding functionality to add session state - must be before controlerswithviews
            services.AddMemoryCache();
            services.AddSession();
            services.AddControllersWithViews().AddNewtonsoftJson();
            //enabling dependency injection by using "MovieContext" instead of hard coding string here
            services.AddDbContext<MovieContext>(options => options.UseSqlServer(Configuration.GetConnectionString("MovieContext")));
            services.AddDbContext<MovieList.Areas.ContactList.Models.ContactContext>(options => options.UseSqlServer(Configuration.GetConnectionString("ContactContext")));
            services.AddDbContext<StudentContext>(options => options.UseSqlServer(Configuration.GetConnectionString("StudentContext")));
            services.AddDbContext <MovieList.Areas.OlympicGames.Models.CountryContext>(options => options.UseSqlServer(Configuration.GetConnectionString("CountryContext")));
            services.AddDbContext<MovieList.Areas.Agile.Models.TicketContext>(options => options.UseSqlServer(Configuration.GetConnectionString("TicketContext")));
            // make urls lowercase and end with a trailing slash
            services.AddRouting(options => { options.LowercaseUrls = true; options.AppendTrailingSlash = true; });
            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<TicketContext>()
                .AddDefaultTokenProviders();
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

            app.UseAuthentication();
            app.UseAuthorization();

            // adding set up for using session state - must be before UseEndpoints
            app.UseSession();

            // Updated to have optional section option (slug)
            app.UseEndpoints(endpoints =>
            {
                // Admin Area Routing
                endpoints.MapAreaControllerRoute(
                    name: "admin",
                    areaName: "Admin",
                    pattern: "Admin/{controller=Home}/{action=Index}/{id?}");

                // Agile Area Routing
                endpoints.MapAreaControllerRoute(
                    name: "agile",
                    areaName: "Agile",
                    pattern: "Agile/{controller=Home}/{action=Index}/{id?}/{slug?}");

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

                // Olympic Games Area Routing
                endpoints.MapAreaControllerRoute(
                    name: "olymicgames",
                    areaName: "OlympicGames",
                    pattern: "OlympicGames/{controller=Home}/{action=Index}/sporttype/{activeSportType}/cat/{activeCat}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}/{slug?}");
            });
        }
    }
}
