using demo.api.Setup;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;

namespace demo.api
{
    public class Startup
    {
   

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
           ;
  
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            Log.Logger.Information("Started Startup ConfigureServices");
            services.AddControllers();
            services.AddHealthChecks();
           
            //services.AddSingleton<IApplicationSettings, ApplicationSettings>();
            //services.AddOData();
            //services.AddStackExchangeRedisCache(options =>
            //{
            //    options.Configuration = Configuration.GetValue<string>("CacheConnection");
            //});
            services.SetupApiVersion();
            services.SetupSwaggerDocumentation();
            Log.Logger.Information("Completed Startup ConfigureServices");
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IApiVersionDescriptionProvider provider)
        {
            Log.Logger.Information("Started Startup Configure");
            Log.Logger.Information(Configuration["apiConfig:basePath"]);
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
       
            app.UseSerilogRequestLogging();
            //app.UseHttpsRedirection();
            app.UsePathBase(Configuration["apiConfig:basePath"]);

            app.UseRouting();

            app.UseAuthorization();

            app.UseSwaggerDocument(provider, true);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHealthChecks(string.Empty);
            });
            Log.Logger.Information("Completed Startup Configure");
        }
    }
}
