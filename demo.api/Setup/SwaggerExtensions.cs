using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.OpenApi.Models;

namespace Microsoft.Extensions.DependencyInjection
{
    internal static class SwaggerExtensions
    {
        
        public static IServiceCollection SetupSwaggerDocumentation(this IServiceCollection services)
        {
            var provider = services.BuildServiceProvider().GetRequiredService<IApiVersionDescriptionProvider>();
            services.AddSwaggerGen(options =>
            {
                foreach (var description in provider.ApiVersionDescriptions)
                {
                    options.SwaggerDoc(
                        description.GroupName,
                        new OpenApiInfo
                        {
                            Title = "Demo API",
                            Version = description.ApiVersion.ToString()
                        });
                }
                options.EnableAnnotations();
            });
            return services;
        }


        public static IApplicationBuilder UseSwaggerDocument(this IApplicationBuilder app,IApiVersionDescriptionProvider provider, bool showSwagerUI = true)
        {

            app.UseSwagger();
            if (showSwagerUI)
            {
                app.UseSwaggerUI(options =>
                {
                    foreach (var description in provider.ApiVersionDescriptions)
                    {
                        options.SwaggerEndpoint($"../swagger/{description.GroupName}/swagger.json",
                            description.GroupName.ToUpperInvariant());
                    }
                });
            }

            return app;
        }
    }
}
