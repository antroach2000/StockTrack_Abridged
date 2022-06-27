using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Http;
using StockTrade.API.Services.Interfaces;
using StockTrade.API.Services;
using System;
using StockTrade.API.API.Interfaces;
using StockTrade.API.API;
using StockTrade.API.Repositories;
using StockTrade.API.Repositories.Interfaces;
using StockTrade.API.Models;
using StockTrade.API.Automapper.ASX_Api;
using System.Reflection;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using StockTrade.API.Filters;

namespace StockTrade.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IHostEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                 .SetBasePath(env.ContentRootPath)
                 .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                 .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                 .AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApiVersioning(o =>
            {
                o.AssumeDefaultVersionWhenUnspecified = true;
                o.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1,0);
                o.ReportApiVersions = true;
            });

            services.AddVersionedApiExplorer(
                options =>
                    {
                        options.GroupNameFormat = "'v'VVV";
                        options.SubstituteApiVersionInUrl = true;
                    });

            services.AddControllers();

            // Add our Config object so it can be injected
            services.Configure<AppOptions>(Configuration.GetSection("ApplicationConfiguration"));

            services.AddSingleton<IConfiguration>(Configuration);
            services.AddScoped<ValidationFilterAttribute>();
            services.Configure<ApiBehaviorOptions>(options => options.SuppressModelStateInvalidFilter = true);

            services.AddCors();

            // register an IHttpContextAccessor so we can access the current HttpContext in services by injecting it
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddTransient<ICompanyService, CompanyService>();
            services.AddTransient<IAsxComAPI, AsxComAPI>();
            services.AddTransient<IIndustryGroupService, IndustryGroupService>();
            services.AddTransient<IIndustryGroupRepository, IndustryGroupRepository>();
            services.AddTransient<IPortfolioService, PortfolioService>();
            services.AddTransient<IPortfolioRepository, PortfolioRepository>();

            // Auto Mapper Configurations
            services.AddAutoMapper(typeof(ASXProfile));

            // Add functionality to inject IOptions<T>
            services.AddOptions();

            services.AddHttpClient(GlobalConstants.ASX_API, c =>
            {
                c.BaseAddress = new Uri("https://www.asx.com.au/asx/1/");
            });

            services.AddHttpClient(GlobalConstants.GOOGLEMAPS_API, c =>
            {
                c.BaseAddress = new Uri("https://maps.googleapis.com/maps/api/");
            });

            services.AddHttpClient(GlobalConstants.IDENTITY_TOOLKIT, c =>
            {
                c.BaseAddress = new Uri("https://identitytoolkit.googleapis.com/");
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Stock Tracker.Api",
                    Version = "v1",
                    Description = "An API to retrieve stock market data from various apis",
                    //TermsOfService = new Uri("https://example.com/terms"),
                    Contact = new OpenApiContact
                    {
                        Name = "Ant Roach",
                        Email = "antroach2000@gmail.com",
                    },
                });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Stock Tracker Api"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}