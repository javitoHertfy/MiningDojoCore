using JavitoHertfy.MiningCodingDojo.WebApi.Application.Services.Contracts;
using JavitoHertfy.MiningCodingDojo.WebApi.Application.Services.Implementation;
using Microsoft.Extensions.DependencyInjection;

namespace JavitoHertfy.MiningCodingDojo.WebApi.Application.Extensions
{
    public static class ApplicationServiceCollectionExtensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddSingleton<IMinerAppService, MinerAppService>();
            services.AddSingleton<IGoldMineAppService, GoldMineAppService>();
            return services;
        }
    }
}
