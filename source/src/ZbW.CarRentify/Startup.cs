using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NLog.Extensions.Logging;
using ZbW.CarRentify.CarManagement.Domain;
using ZbW.CarRentify.CarManagement.Infrastructure;
using ZbW.CarRentify.CarManagement.Services;
using ZbW.CarRentify.ContractManagment.Domain;
using ZbW.CarRentify.ContractManagment.Infastructure;
using ZbW.CarRentify.ContractManagment.Services;

[assembly: InternalsVisibleTo("ZbW.CarRentify.Tests")]

namespace ZbW.CarRentify
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddScoped<ICarService, CarService>();
            services.AddScoped<ICarRepository, CarRepository>();

            services.AddScoped<ICarClassService, CarClassService>();
            services.AddScoped<ICarClassRepository, CarClassRepository>();

            services.AddScoped<IBrandService, BrandService>();
            services.AddScoped<IBrandRepository, BrandRepository>();

            services.AddScoped<IModelService, ModelService>();
            services.AddScoped<IModelRepository, ModelRepository>();


            services.AddScoped<IContractService, ContractService>();
            services.AddScoped<IContractReposetory, ContractReposetory>();
            services.AddLogging(x => x.AddConsole());

            //var serviceProvider = services.BuildServiceProvider();
            //serviceProvider.GetService<ICarRepository>();
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
