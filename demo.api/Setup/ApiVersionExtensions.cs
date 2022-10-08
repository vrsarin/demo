using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;

namespace Microsoft.Extensions.DependencyInjection
{
    internal static class ApiVersionExtensions
    {
        private const string API_VERSION_READER = "x-api-version";
        private const string API_VERSION_GROUP_FORMAT = "'v'VVV";

        public static IServiceCollection SetupApiVersion(this IServiceCollection services)
        {
            services.AddApiVersioning(config =>
            {
                config.DefaultApiVersion = new ApiVersion(1,0);
                config.AssumeDefaultVersionWhenUnspecified = true;
                config.ReportApiVersions = true;
                config.ApiVersionReader = ApiVersionReader.Combine(new UrlSegmentApiVersionReader(),
                    new HeaderApiVersionReader(ApiVersionExtensions.API_VERSION_READER),
                    new QueryStringApiVersionReader(ApiVersionExtensions.API_VERSION_READER),
                    new MediaTypeApiVersionReader());
            });
            services.AddVersionedApiExplorer(
                options =>
                {
                    options.GroupNameFormat = ApiVersionExtensions.API_VERSION_GROUP_FORMAT;
                    options.SubstituteApiVersionInUrl = true;
                });

            return services;

        }


    }
}
