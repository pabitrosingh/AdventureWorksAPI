using System;
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
using AdventureWorksAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Serilog.Extensions.Logging;
using Newtonsoft.Json.Serialization;
using AdventureWorksAPI.Helpers;
using AdventureWorksAPI.DB;
using Microsoft.OpenApi.Models;

namespace AdventureWorksAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }


        public void ConfigureServices(IServiceCollection services)
        {

            string SQLServerConnection = Configuration.GetConnectionString("AdventureWorksDatabase").ToString();

            services.Configure<CookiePolicyOptions>(options=> 
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.Strict;
            });
            
            services.AddDbContext<AdventureWorksContext>(options => options.UseSqlServer(SQLServerConnection));

            //custom validation service
            services.AddSingleton<IValidation, Validation>();
            services.AddSingleton<IDBRepository, DBRepository>();
            services.AddSingleton<IDashboardDBRepository, DashboardDBRepository>();
            services.AddSingleton<IProductionDBRepository, ProductionDBRepository>();
            services.AddSingleton<ISalesDBrepository, SalesDBRepository>();
            services.AddSingleton<IPurchasingDBrepository, PurchasingDBrepository>();

            services.AddElm();
            services.AddCors();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                             .AddJsonOptions(opt=>opt.SerializerSettings.ContractResolver =new DefaultContractResolver());

            services.AddSwaggerGen(c=>
            {
                    c.SwaggerDoc("v1", new OpenApiInfo { 
                                                            Title = "ADWorks API", 
                                                            Version = "v1", 
                                                            Description ="Adevnture Works API" });
            });
        }

        
        public void Configure(IApplicationBuilder app, IHostingEnvironment env ,ILoggerFactory loggerFactory)
        {
            app.UseSwagger();
            
            if (env.IsDevelopment())
            {
                app.UseSwaggerUI(c=>
                {
                    c.SwaggerEndpoint("../swagger/v1/swagger.json", "ADWorks API V1");
                });
                app.UseDeveloperExceptionPage();
                app.UseElmPage();
                app.UseElmCapture();
                loggerFactory.AddFile("Logs/Dev-Debug-{Date}.txt", LogLevel.Debug);
                loggerFactory.AddFile("Logs/Dev-Error-{Date}.txt", LogLevel.Error);
                loggerFactory.AddFile("Logs/Dev-Trace-{Date}.txt", LogLevel.Trace);
                loggerFactory.AddFile("Logs/Dev-Warning-{Date}.txt", LogLevel.Warning);
                loggerFactory.AddFile("Logs/Dev-Information-{Date}.txt", LogLevel.Information);
            }
            else
            {
                app.UseSwaggerUI(c=>
                {
                    c.SwaggerEndpoint("../swagger/v1/swagger.json", "ADWorks API V1");
                });
                //app.UseHsts();
                loggerFactory.AddFile("Logs/Prod-Critical-{Date}.txt", LogLevel.Critical);
                loggerFactory.AddFile("Logs/Prod-Error-{Date}.txt", LogLevel.Error);
                loggerFactory.AddFile("Logs/Prod-Warning-{Date}.txt", LogLevel.Warning);
                loggerFactory.AddFile("Logs/Prod-Information-{Date}.txt", LogLevel.Information);
            }
            
            app.UseElmPage();
            app.UseElmCapture();
            app.UseHttpsRedirection();
            app.UseCors(opt =>opt.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            app.UseCors(opt => opt.AllowAnyOrigin().WithMethods("GET","POST").AllowAnyHeader());
            app.UseMvc(routing=>routing.MapRoute("default", "{controller=Home}/{action=Index}"));
        }
    }
}
