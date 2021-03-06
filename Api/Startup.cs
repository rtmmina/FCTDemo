﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Service.Contract;
using Service.Implementation;
using DataAccess.Contract;
using DataAccess.Implementation;
using DataAccess.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Api
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
            //services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddControllers();

            //DI
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<ICustomerDAL, CustomerDAL>();

            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProductDAL, ProductDAL>();

            services.AddScoped<IPurchaseService, PurchaseService>();
            services.AddScoped<IPurchaseDAL, PurchaseDAL>();
            //EF core
            services.AddDbContext<FCTContext>(options =>
        options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            //net core 2.1 configuration
            //app.UseMvc();

            //net core 3.1 configuration, following this article
            //https://devblogs.microsoft.com/aspnet/asp-net-core-updates-in-net-core-3-0-preview-4/
            //Update: this article did not work, so adding a new api project with core 3.1.x, 
            //and follow their module solved the problem. I left the commented code to show my trials.
            app.UseRouting();
            //app.UseCookiePolicy();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            //Probably we don need this configuration
            //app.UseEndpoints(routes =>
            //{
            //    routes.MapRazorPages();
            //    routes.MapFallbackToPage("_Host");
            //});
        }
    }
}
