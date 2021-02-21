using JavitoHertfy.MiningCodingDojo.WebApi.Api.Swagger;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ApiServiceCollectionExtensions
    {
        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
            services.AddSwaggerGen(options =>
            {
                options.OperationFilter<SwaggerDefaultValues>();
            });

            return services;
        }
        public static IServiceCollection AddVersioning(this IServiceCollection services)
        {
            services
                  .AddApiVersioning(options =>
                  {
                      options.ReportApiVersions = true;
                      options.AssumeDefaultVersionWhenUnspecified = true;
                  })
                  .AddVersionedApiExplorer(options =>
                  {
                      options.GroupNameFormat = "'v'VVV";
                      options.SubstituteApiVersionInUrl = true;
                  });

            return services;
        }
    }
}
