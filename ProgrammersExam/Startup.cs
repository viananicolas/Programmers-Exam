using System;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProgrammersExam.Data.AutoMapper.Profiles;
using ProgrammersExam.Data.Context;
using ProgrammersExam.Data.DependencyInjection;
using ProgrammersExam.Data.Service;
using ProgrammersExam.Data.Service.Base;
using ProgrammersExam.Data.Service.Base.Interface;
using ProgrammersExam.Entities.Entity;

namespace ProgrammersExam
{
    public class Startup
    {
        private IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new ViewModelToDomainProfile());
                mc.AddProfile(new DomainToViewModelProfile());
            });

            var mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
            services.AddAutoMapper();
            //services.AddScoped<IBaseService<PerformanceOrder>, PerformanceOrderService>();
            services.AddDbContext<ProgrammersContext>(config =>
            {
                var connection = Configuration.GetConnectionString("DefaultConnection");
                config.UseSqlServer(connection ?? throw new InvalidOperationException(nameof(connection)));
            }).AddUnitOfWork<ProgrammersContext>();
            services.AddScoped<IBaseService<PerformanceOrder>, Service<PerformanceOrder>>();
            services.AddScoped<IPerformanceOrderService, PerformanceOrderService>();

            // In production, the React files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/build";
            });
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
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseReactDevelopmentServer(npmScript: "start");
                }
            });
        }
    }
}
