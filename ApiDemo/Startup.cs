using System;
using System.IO;
using System.Linq;
using System.Net.Http.Formatting;
using System.Reflection;
using System.Xml;
using ApiDemo.Controllers;
using ApiDemo.Filter;
using ApiDemo.Services.Interface;
using ApiDemo.Library;
using ApiDemo.Library.Contracts;
using ApiDemo.Map;
using ApiDemo.Services;
using ApiDemo.Services.Interface;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using Taylor.Apl.Dapper.Sql;
using Formatting = Newtonsoft.Json.Formatting;
using AutoMapper;

namespace ApiDemo
{
    public class Startup
    {
        #region constructors

        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                          .SetBasePath(env.ContentRootPath)
                          .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                          .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)//增加环境配置文件，新建项目默认有
                          .AddEnvironmentVariables();
            Configuration = builder.Build();

            Configuration = configuration;
        }

        #endregion

        #region properties

        public IConfiguration Configuration
        {
            get;
        }

        #endregion

        #region methods

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
                                 c.SwaggerEndpoint("/swagger/v2/swagger.json", "My API V2");
                                 c.RoutePrefix = string.Empty;
                             });

            //ASP.NET Core CORS WebAPI: no Access-Control-Allow-Origin header
            app.UseCors(builder => builder.AllowAnyOrigin().
                                           AllowAnyMethod().
                                           AllowAnyHeader().
                                           AllowCredentials());

            app.UseMvc();

            //app.UseMvc(routes =>
            //           {
            //               routes.MapRoute(name: "default", template: "{controller=Home}/{action=Index}/{id?}");

            //               //app.Run(async  (context) => { await context.Response.WriteAsync("Hello World!"); });
            //           });
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //ASP.NET Core CORS WebAPI: no Access-Control-Allow-Origin header
            services.AddCors();

            services.AddMvc().
                     AddJsonOptions(option =>
                                    {
                                        option.SerializerSettings.ContractResolver = new LowercaseContractResolver();
                                    });
            // set auto mapper
            services.AddAutoMapper(typeof(MappingProfile).GetTypeInfo().Assembly);

            //Use MemoryCache
            services.AddSingleton<IMemoryCache>(factory =>
                                                {
                                                    var cache = new MemoryCache(new MemoryCacheOptions());

                                                    return cache;
                                                });
            services.AddSingleton<ICacheService, MemoryCacheService>();
            services.AddSingleton<IFiftyOneDegrees, FiftyOneDegreesService>();
            //services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            //services.AddScoped<ISqlHelper, SqlHelper>();
            //services.AddScoped<IDamConnectorLogic, DamConnectorLogic>();
            //services.AddScoped<IDamConnectorDataAccess, DamConnectorDataAccess>();
            //services.AddScoped<IRenditionProxy, RenditionProxy>();
            //services.AddScoped<IAes, Aes>();
            //services.AddScoped<IDamLogger, DamLogger>();
            services.AddScoped<ISqlHelper, SqlHelper>();
            services.AddScoped<ILocationsService, LocationsService>();
            services.AddScoped<ILocation, ApiDemo.Library.Location>();
            services.AddScoped<IConfigIdService, ConfigIdService>();
            services.AddScoped<IConfigId, ConfigId>();
            services.AddScoped<ITestProductLib, TestProductLib>();
            services.AddScoped<ITestProductService, TestProductService>();
            services.AddScoped<IAes, Aes>();
            services.AddScoped<IQrCodeLibrary, QrCodeLibrary>();

            services.AddSwaggerGen(x =>
            {
                //forbid actions require unique method/path combination 
                x.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());

                //根据全名来生成
                x.CustomSchemaIds((type) => type.FullName);

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
                                                            Url = "http://www.baidu.com/"
                                                        },
                                                        License = new License
                                                        {
                                                            Name = "许可证名字",
                                                            Url = "http://www.baidu.com/"
                                                        },


                                                    });
                                       x.SwaggerDoc("v2",
                                                    new Info
                                                    {
                                                        Version = "v2", //版本号
                                                        Title = "ApiDemo接口文档v2", //标题
                                                        Description = "RESTful API v2",
                                                        TermsOfService = "None", //服务的条件
                                                        Contact = new Contact
                                                        {
                                                            Name = "李大同v2",
                                                            Email = "lidatong@163.com",
                                                            Url = "http://www.baidu.com/"
                                                        },
                                                        License = new License
                                                        {
                                                            Name = "许可证名字",
                                                            Url = "http://www.baidu.com/"
                                                        },


                                                    });

                                       // 设置Swagger JSON和UI的注释路径
                                       var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                                       var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                                       x.IncludeXmlComments(xmlPath);
                                      
                                       //反射注入全部程序集说明

                                       //GetAllAssemblies().Where(t => t.CodeBase.EndsWith("Controller.dll")).ToList().ForEach(assembly =>
                                       //                                                                                      {
                                       //                                                                                          c.IncludeXmlComments(assembly.CodeBase.Replace(".dll", ".xml"));
                                       //                                                                                      });

                                       //请输入Token，格式为bearer XXX
                                       //x.OperationFilter<HttpHeaderOperationFilter>();
                                       x.DocumentFilter<HiddenApiFilter>();
                                      
                                   });

            //api 版本控制
            services.AddApiVersioning(x =>
                                      {
                                          x.ReportApiVersions = true;
                                          x.AssumeDefaultVersionWhenUnspecified = true;
                                          x.DefaultApiVersion = new ApiVersion(1, 0);
                                      });
        }

        #endregion
    }
}
