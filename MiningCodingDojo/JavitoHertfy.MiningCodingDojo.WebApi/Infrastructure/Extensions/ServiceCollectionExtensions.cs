using JavitoHertfy.MiningCodingDojo.WebApi.Domain.Repository.Contracts;
using JavitoHertfy.MiningCodingDojo.WebApi.Infrastructure.Database.Contracts;
using JavitoHertfy.MiningCodingDojo.WebApi.Infrastructure.Database.Implementations;
using JavitoHertfy.MiningCodingDojo.WebApi.Infrastructure.Mappers.Contracts;
using JavitoHertfy.MiningCodingDojo.WebApi.Infrastructure.Mappers.Implementation;
using JavitoHertfy.MiningCodingDojo.WebApi.Infrastructure.Options;
using JavitoHertfy.MiningCodingDojo.WebApi.Infrastructure.Repository.Implementations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace JavitoHertfy.MiningCodingDojo.WebApi.Infrastructure.Extensions
{
    public static class InfrastrutureServiceCollectionExtensions
    {
        public static IServiceCollection AddRepository(this IServiceCollection services, IConfiguration iConfiguration)
        {
            services.AddSingleton<IDatabaseFactory, DatabaseFactory>();
            services.AddSingleton<IMinerDbContext, MinerDbContext>();
            services.AddSingleton<IMinerRepository, MinerRepository>();
            services.AddSingleton<IGoldMineRepository, GoldMineRepository>();
            services.AddSingleton<IMinerEntityMapper, MinerEntityMapper>();
            services.AddSingleton<IGoldMineEntityMapper, GoldMineEntityMapper>();

            services.AddOptions<MinerDbOptions>();

            return services;
        }
    }
}
