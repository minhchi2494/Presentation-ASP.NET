using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PracticeMVC.ConnectDB;
using PracticeMVC.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracticeMVC
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

            String url = "server=HAN\\SQLEXPRESS;database=Digitech;uid=sa; pwd=123";
            services.AddScoped<ICustomer_Setting, Customer_Setting_Service>();
            services.AddScoped<ICustomer_Attribute, Customer_Attribute_Service>();
            services.AddDbContext<CustomerContext>(options => options.UseSqlServer(url));
            services.AddControllersWithViews();

            //services.AddControllersWithViews();
            //services.AddDbContext<CustomerContext>(options =>
            //    options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"))
            //);
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
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=CustomerSetting}/{action=Index}/{id?}");
            });
        }
    }
}
