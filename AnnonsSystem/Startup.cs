using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnnonsSystem.Entities;
using AnnonsSystem.Models;
using AnnonsSystem.Services;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PrenumerantSystem.Models;

namespace AnnonsSystem
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddMemoryCache(); /* TempData works between actions */
            services.AddSession();
            services.AddAutoMapper();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            //add the database
            var connectionString = @"Server=(localdb)\mssqllocaldb;Database=AnnonsDB;Trusted_Connection=True;";
            services.AddDbContext<AnnonsContext>(o => o.UseSqlServer(connectionString));
            services.AddScoped<IAnnonsRepository, AnnonsRepository>(); /* Add the prenumerant repository service */

            /* Add the CRUD service so it can be used by controllers */
            services.AddSingleton<IPrenumerantsCRUDService, PrenumerantsCRUDService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, AnnonsContext annonsContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseSession(); /* Tempdata works between actions */
            app.UseStaticFiles();
            
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Ads}/{action=Index}/{id?}");
            });
            app.UseCookiePolicy();

            app.UseDefaultFiles(new DefaultFilesOptions{
                DefaultFileNames = new List<string> { "index.html" }
            });

            annonsContext.EnsureSeedDataForContext(); /* Fill database with dummy stuff if empty */


            AutoMapper.Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Entities.Ad, Models.AdDto>();
                cfg.CreateMap<PrenumerantDto, Entities.PrenumerantAnnonsor>();
                cfg.CreateMap<Models.AdDto, Entities.Ad>();
                cfg.CreateMap<ForetagDto, ForetagAnnonsor>();
            });
        }
    }
}
