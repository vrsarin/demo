using demo.api.Data;
using demo.api.Utils;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using System.Linq;

namespace demo.api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        private readonly IAPIConfigurationManager configurationManager;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            this.configurationManager = new APIConfigurationManager(configuration);

        }

        public void ConfigureServices(IServiceCollection services)
        {
            Log.Logger.Information("Started Startup ConfigureServices");
            services.AddControllers();
            services.AddSingleton<IAPIConfigurationManager>(this.configurationManager);
            services.SetupApiVersion();
            services.SetupSwaggerDocumentation();
            services.AddHealthChecks();
            switch (this.configurationManager.DbType)
            {
                case DbTypeEnum.InMemory:
                    services.AddDbContext<DemoApiDbContext>(opts => opts.UseInMemoryDatabase("LOCAL_DB"));
                    break;
                case DbTypeEnum.Postgres:
                    services.AddDbContext<DemoApiDbContext>(opts => opts.UseNpgsql(this.configurationManager.PgsqlConnectionString));
                    break;
                default:
                    Log.Logger.Error("Couldnot interpret which DBTTYPE is used");
                    break;
            }



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

            app.UsePathBase(this.configurationManager.ApiBasePath);

            app.UseRouting();

            app.UseAuthorization();

            app.UseSwaggerDocument(provider, true);

            using (var scope = app.ApplicationServices.CreateScope())
            {
                var dataContext = scope.ServiceProvider.GetRequiredService<DemoApiDbContext>();

                dataContext.Database.Migrate();
            }
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHealthChecks(string.Empty);

            });
            Log.Logger.Information("Completed Startup Configure");
        }
    }
}
