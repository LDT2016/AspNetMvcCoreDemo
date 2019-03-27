#region using

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;
using ShowInfos.Core.Interfaces;
using ShowInfos.Core.Models;
using ShowInfos.Infrastructure.Data;

#endregion

namespace ShowInfos
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
                //options.CheckConsentNeeded = context => true;//把隐私要求和https要求先屏蔽。
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddMvc().AddJsonOptions(option => option.SerializerSettings.ContractResolver = new DefaultContractResolver());
            //.SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddDbContext<ApplicationDbContext>(optionsBuilder => optionsBuilder.UseSqlServer(AppConfig.MySqlConnection));

            //services.AddScoped<IRepository<Ninja>, EfRepository<Ninja>>();
            services.AddScoped<IRepository<Doctors>, EfRepository<Doctors>>();
            services.AddTransient<IRepository<Doctors>, EfRepository<Doctors>>();
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
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            //app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    "default",
                    "{controller=Pdf}/{action=Index}/{id?}");

                //routes.MapRoute(
                //    name: "default",
                //    template: "{controller=Doctors}/{action=Index}/{id?}");

                //// Areas support
                //routes.MapRoute(
                //    name: "areaRoute",
                //    template: "{area:exists}/{controller=Doctors}/{action=Index}/{id?}");
            });
        }
    }
}