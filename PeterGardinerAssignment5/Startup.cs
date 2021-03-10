using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PeterGardinerAssignment5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeterGardinerAssignment5
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddDbContext<ProductDbContext>(options =>
            {
                options.UseSqlite(Configuration["ConnectionStrings:ProductConnection"]);
            });

            services.AddScoped<IProductRepository, EFProductRepository>();

            services.AddRazorPages();

            services.AddDistributedMemoryCache();
            services.AddSession();
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

            app.UseSession();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("page","{category}/{pageNum:int}", new {Controller = "Home", action = "Index"});

                endpoints.MapControllerRoute("page2", "{pageNum:int}", new { Controller = "Home", action = "Index" });

                endpoints.MapControllerRoute("category", "{category}", new { Controller = "Home", action = "Index", pageNum = 1 });
                //edited urls
                endpoints.MapControllerRoute(
                    "pagination",
                    "P{pageNum}",
                    new { controller = "Home", action = "Index" } );

                endpoints.MapDefaultControllerRoute();

                endpoints.MapRazorPages();
            });

            SeedData.EnsurePopulated(app);
        }
    }
}
