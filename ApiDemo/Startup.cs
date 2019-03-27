using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ApiDemo.Interface;
using ApiDemo.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.PlatformAbstractions;
using Newtonsoft.Json.Serialization;
using Swashbuckle.AspNetCore.Swagger;

namespace ApiDemo
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

        }

        public IConfiguration Configuration
        {
            get;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddMvc().AddJsonOptions(option => option.SerializerSettings.ContractResolver = new DefaultContractResolver());

            services.AddMemoryCache();
            //Use MemoryCache
            services.AddSingleton<IMemoryCache>(factory =>
            {
                var cache = new MemoryCache(new MemoryCacheOptions());
                return cache;
            });
            services.AddSingleton<ICacheService, MemoryCacheService>();
            services.AddSingleton<IFiftyOneDegrees, FiftyOneDegreesService>();

            services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc("v1",
                    new Info
                    {
                        Version = "v1", //版本号
                        Title = "ApiDemo接口文档", //标题
                        Description = "RESTful API ",
                        TermsOfService = "None", //服务的条件
                        Contact = new Contact
                        {
                            Name = "李大同",
                            Email = "lidatong@163.com",
                            Url = "http://www.lidatong.com/yilezhu/"
                        },
                        License = new License
                        {
                            Name = "许可证名字",
                            Url = "http://www.cnblogs.com/yilezhu/"
                        }
                    });

                //获取设置配置信息的 的路径对象   swagger界面配置
                var basePath = PlatformServices.Default.Application.ApplicationBasePath;
                var xmlPath = Path.Combine(basePath, "ApiDemo.xml");
                x.IncludeXmlComments(xmlPath);
                x.OperationFilter<HttpHeaderOperation>(); // 添加httpHeader参数
                x.DescribeStringEnumsInCamelCase();
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            app.UseSwagger();
            // 指定站点
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                c.RoutePrefix = string.Empty;
            });

            app.UseCors(builder => builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials());

            app.UseMvc();
            //app.Run(async  (context) => { await context.Response.WriteAsync("Hello World!"); });

        }
    }
}
