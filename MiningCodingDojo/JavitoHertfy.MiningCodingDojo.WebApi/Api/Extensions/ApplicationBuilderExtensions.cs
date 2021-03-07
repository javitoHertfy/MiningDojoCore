using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace JavitoHertfy.MiningCodingDojo.WebApi.Api.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseSwagger(this IApplicationBuilder app, IApiVersionDescriptionProvider provider)
        {
            app.UseSwagger();

            app.UseSwaggerUI(
                options =>
                {
                   
                    options.SupportedSubmitMethods(new SubmitMethod[] { SubmitMethod.Get});
                    for (int i = provider.ApiVersionDescriptions.Count - 1; i >= 0; i--)
                    {
                        var description = provider.ApiVersionDescriptions[i];
                        options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
                    }
                });

            return app;
        }
    }
}
