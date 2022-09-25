using demo.api.Utils;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace demo.api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        private readonly IConfigurationManager configurationManager;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            this.configurationManager = new ConfigurationManager(configuration);

        }
        
        public void ConfigureServices(IServiceCollection services)
        {
            Log.Logger.Information("Started Startup ConfigureServices");
            services.AddControllers();            
            services.AddSingleton<IConfigurationManager>(this.configurationManager);            
            services.SetupApiVersion();
            services.SetupSwaggerDocumentation();
            //services.AddHealthChecksUI();
            services.AddHealthChecks();
            Log.Logger.Information("Completed Startup ConfigureServices");
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IApiVersionDescriptionProvider provider)
        {
            Log.Logger.Information("Started Startup Configure");
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSerilogRequestLogging();
            //app.UseHttpsRedirection();
            app.UsePathBase(this.configurationManager.ApiBasePath);

            app.UseRouting();

            app.UseAuthorization();

            app.UseSwaggerDocument(provider, true);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHealthChecks(string.Empty);
                //endpoints.MapHealthChecksUI(options =>
                //{
                //    options.UIPath = "/healthui";
                //});

            });
            Log.Logger.Information("Completed Startup Configure");
        }
    }
}
